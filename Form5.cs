using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Storage;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        private MySqlConnection _Conn;

        MySqlDataReader reader;
        MySqlDataAdapter _DataAdapterTitles;
        DataSet _DataSet;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "EbHT0Cj8ZZHnIOYoqu7RAtyu5nxBDz2ClpTRLy4L",
            BasePath= "https://directorio-casanovarentacar.firebaseio.com/",
            
            
        };
        
        IFirebaseClient client;
        
        public Form5()
        {
            InitializeComponent();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            textBox2.Text = "1";

          // comunicado();
        }
        private async void comunicado()
        {
            

            FirebaseResponse response = await client.GetAsync("Comunicados/ID" );


            Data obj = response.ResultAs<Data>();
            
            string ID = obj.ID;
            textBox2.Text = ID;
        }
     
              
        private async void Guardar_Click(object sender, EventArgs e )
        {
            deleteUser();
            SaveUser();
            var data = new Data
            {
                ID=textBox2.Text
            };
            FirebaseResponse response = await client.UpdateAsync("Comunicados/ID" , data);
            
            MessageBox.Show("Comunicado enviado");

        }
        private void SaveUser()
        {
            
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "INSERT INTO comunicados(`ID`, `Encabezado`, `Descripcion`) VALUES ('" + textBox2.Text + "', '" + textBox1.Text + "', '" + textBox3.Text +  "')";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error



                MessageBox.Show("Conexión invalida");

            }
        }
        private void deleteUser()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "DELETE FROM `comunicados` WHERE ID=" + textBox2.Text.Trim();

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                
                // Eliminado satisfactoriamente

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, quizás el id no existe
                MessageBox.Show(ex.Message);
            }
        }


        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
