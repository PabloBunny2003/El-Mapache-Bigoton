using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapache_Bigoton
{
    public partial class Consultar_Citas : Form
    {
        public Consultar_Citas()
        {
            InitializeComponent();
        }

        private void Consultar_Citas_Load(object sender, EventArgs e)
        {
            //Agregamos un método donde hace toda la operación de cargar los datos
            //desde la base de datos al dataGridView
            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia para pasar al formulario Principal (Redirigirnos)
            Principal formularioPrincipal = new Principal();
            // Aquí mostramos el formulario
            formularioPrincipal.Show();
            this.Close();
        }

        private void CargarDatos()
        {
            // Hacemos nuestra cadena de conexión a la base de datos
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BarberiaBD"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Nombre, Apellido, Telefono, Servicio, Fecha, Hora FROM Citas";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agregamos una nueva fila al DataGridView con los datos leídos
                                // a la hora de agregar una cita
                                dataGrid.Rows.Add(
                                    reader["Nombre"].ToString(),
                                    reader["Apellido"].ToString(),
                                    reader["Telefono"].ToString(),
                                    reader["Servicio"].ToString(),
                                    Convert.ToDateTime(reader["FechaHora"]),
                                    reader["Hora"]

                                );
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + error.Message);
            }
        }
    }
}
