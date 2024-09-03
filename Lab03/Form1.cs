using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Lab03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = "Server=DESKTOP-OT3T8Q7; Database=Tecsup2023DB; Integrated Security=True";
                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                MessageBox.Show("Conexion Exitosa");
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Conexion");
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cadena = "Server=DESKTOP-OT3T8Q7; Database=Tecsup2023DB; Integrated Security=True";
            SqlConnection connection = new SqlConnection(cadena);

            connection.Open();
            SqlCommand listar = new SqlCommand("select * from Students", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(listar);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            connection.Close();

            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cadena = "Server=DESKTOP-OT3T8Q7; Database=Tecsup2023DB; Integrated Security=True";
            SqlConnection connection = new SqlConnection(cadena);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from Students", connection);

                List<Student> listaEstudiantes = new List<Student>();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student estudiante = new Student();
                    estudiante.StudentId = reader["StudentId"].ToString();
                    estudiante.FirstName = reader["FirstName"].ToString();
                    estudiante.LastName = reader["LastName"].ToString();
                    listaEstudiantes.Add(estudiante);
                }

                reader.Close();
                dataGridView2.DataSource = listaEstudiantes; 
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Conexion");
            }

        }
    }

    internal class Student
    {
        public string? StudentId { get; internal set; }
        public string? FirstName { get; internal set; }
        public string? LastName { get; internal set; }
    }
}