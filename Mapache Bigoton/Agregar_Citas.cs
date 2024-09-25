using System.Data.SqlClient;

namespace Mapache_Bigoton
{
    public partial class Agregar_Citas : Form
    {
        public Agregar_Citas()
        {
            InitializeComponent();
            txtTelefono.KeyPress += new KeyPressEventHandler(txtTelefono_KeyPress);
            dateTime.MinDate = DateTime.Now; // Establece la fecha mínima permitida al día actual

            // Agregamos las opciones del ComboBox
            comboBox1.Items.Add("Seleccione un servicio");
            comboBox1.Items.Add("Corte infantil");
            comboBox1.Items.Add("Corte de cabello");
            comboBox1.Items.Add("Afeitado de barba");
            comboBox1.Items.Add("Delineado de barba y bigote, o cejas");
            comboBox1.Items.Add("Tintes para barba y cabello");
            comboBox1.Items.Add("Masajes faciales");
            comboBox1.Items.Add("Peinados especiales");

            // Establecemos el texto predefinido como seleccionado en este caso "Seleccione un servicio"
            comboBox1.SelectedIndex = 0;

            // Deshabilitar la opción de "Seleccione un servicio", como una opción válida
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Agregamos las opciones del ComboBox2
            comboBox2.Items.Add("Seleccione un horario");
            comboBox2.Items.Add("9:00 - 10:00");
            comboBox2.Items.Add("10:00 - 11:00");
            comboBox2.Items.Add("11:00 - 12:00");
            comboBox2.Items.Add("12:00 - 13:00");
            comboBox2.Items.Add("15:00 - 16:00");
            comboBox2.Items.Add("16:00 - 17:00");
            comboBox2.Items.Add("17:00 - 18:00");
            comboBox2.Items.Add("18:00 - 19:00");
            comboBox2.Items.Add("19:00 - 20:00");

            // Establecemos el texto predefinido como seleccionado en este caso "Seleccione un servicio"
            comboBox2.SelectedIndex = 0;

            // Deshabilitar la opción de "Seleccione un servicio", como una opción válida
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            // Agregamos las opciones del ComboBox3
            comboBox3.Items.Add("Seleccione un barbero");
            comboBox3.Items.Add("Pablo Baltazar");
            comboBox3.Items.Add("Carlos Conde");
            comboBox3.Items.Add("Felipe Rafael");
            comboBox3.Items.Add("Bartolo Dolores");

            // Establecemos el texto predefinido como seleccionado en este caso "Seleccione un servicio"
            comboBox3.SelectedIndex = 0;

            // Deshabilitar la opción de "Seleccione un servicio", como una opción válida
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validamos que todos los campos estén llenos y que la opción seleccionada sea válida
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                comboBox1.SelectedIndex == 0 ||
                comboBox2.SelectedIndex == 0 ||
                comboBox3.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione opciones válidas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validamos que el número de teléfono tenga exactamente 10 dígitos
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^\d{10}$"))
            {
                MessageBox.Show("El número de teléfono debe contener exactamente 10 dígitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validamos que la fecha seleccionada no sea anterior a la fecha actual
            if (dateTime.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de la cita no puede ser anterior a la fecha actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos los valores de los TextBox, ComboBox y DateTimePicker
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefono = txtTelefono.Text;
            string servicio = comboBox1.SelectedItem.ToString();
            string barbero = comboBox3.SelectedItem.ToString();
            DateTime fecha = dateTime.Value;
            string hora = comboBox2.SelectedItem.ToString();

            // Hacemos nuestra cadena de conexión a la base de datos
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BarberiaBD"].ConnectionString;

            // Validamos que no haya citas duplicadas
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(*) FROM Citas WHERE Telefono = @Telefono AND Servicio = @Servicio AND Barbero = @Barbero AND Fecha = @Fecha AND Hora = @Hora";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Telefono", telefono);
                    checkCommand.Parameters.AddWithValue("@Servicio", servicio);
                    checkCommand.Parameters.AddWithValue("@Barbero", barbero);
                    checkCommand.Parameters.AddWithValue("@Fecha", fecha);
                    checkCommand.Parameters.AddWithValue("@Hora", hora);

                    connection.Open();
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe una cita para este cliente con los mismos detalles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Guardamos los datos obtenidos del Formulario a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Citas (Nombre, Apellido, Telefono, Servicio, Barbero, Fecha, Hora) VALUES (@Nombre, @Apellido, @Telefono, @Servicio, @Barbero, @Fecha, @Hora)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Servicio", servicio);
                    command.Parameters.AddWithValue("@Barbero", barbero);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    command.Parameters.AddWithValue("@Hora", hora);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Crear una instancia para pasar al formulario de Consulta_Citas
            Consultar_Citas formularioConsultaCitas = new Consultar_Citas();
            // Aquí mostramos el formulario
            formularioConsultaCitas.Show();

            this.Close(); // Oculta el formulario principal en lugar de cerrarlo
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Crear una instancia para pasar al formulario Principal
            Principal formularioPrincipal = new Principal();
            // Aquí mostramos el formulario
            formularioPrincipal.Show();
            this.Close();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtenemos el TextBox que disparó el evento
            TextBox textBox = sender as TextBox;

            // Verificamos si el carácter ingresado es un dígito o una tecla de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelamos el evento si no es un dígito o una tecla de control
            }

            // Verificamos si la longitud del texto es mayor o igual a 10 y la tecla presionada no es de control
            if (textBox.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelamos el evento si ya hay 10 dígitos
            }
        }
    }
}