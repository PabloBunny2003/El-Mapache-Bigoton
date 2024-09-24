using System.Data.SqlClient;

namespace Mapache_Bigoton
{
    public partial class Agregar_Citas : Form
    {
        public Agregar_Citas()
        {
            InitializeComponent();

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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validamos que todos los campos estén llenos y que la opción seleccionada sea válida
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione un servicio válido.");
                return;
            }

            // Obtenemos los valores de los TextBox, ComboBox y DateTimePicker
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefono = txtTelefono.Text;
            string servicio = comboBox1.SelectedItem.ToString();
            DateTime fecha = dateTime.Value;
            string hora = comboBox2.SelectedItem.ToString();

            // Hacemos nuestra cadena de conexión a la base de datos
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BarberiaBD"].ConnectionString;

            // Guardamos los datos obtenidos del Formulario a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Citas (Nombre, Apellido, Telefono, Servicio, Fecha, Hora) VALUES (@Nombre, @Apellido, @Telefono, @Servicio, @Fecha, @Hora)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Servicio", servicio);
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
    }
}
