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

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        private MySqlConnection _Conn;

        MySqlDataReader reader;
        MySqlDataAdapter _DataAdapterTitles;
        DataSet _DataSet;
        public Form6()
        {
            InitializeComponent();
            Listviewini();
            label1.Text = DateTime.Now.ToString("dd/MM");
            GetData();
            Loadlist();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void GetData()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL

            try
            {
                _Conn = new MySqlConnection(connectionString);

                // Fill DataSet

                string query = "SELECT * FROM directoriocr WHERE fecha LIKE '" + '%' + label1.Text.Trim() + '%' + "' ";


                _DataSet = new DataSet();
                _DataAdapterTitles = new MySqlDataAdapter(query, _Conn);
                _DataAdapterTitles.Fill(_DataSet, "directoriocr");

            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();

                MessageBox.Show(msg, "Unable to retrieve data.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }
        }
        private void Listviewini()
        {
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            // listView1.Sorting = SortOrder.Ascending;
            
            listView1.Columns.Add("Nombre", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Correo", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Extension", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("Sucursal", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Area", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Fecha de nacimiento", 110, HorizontalAlignment.Left);
        }
        private void Loadlist()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL
            string query = "SELECT * FROM directoriocr WHERE fecha LIKE '" + '%' + label1.Text.Trim() + '%' + "' ";

            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            MySqlDataAdapter _DataAdapterTitles;

            // Get the table from the data set
            DataTable dtable = _DataSet.Tables["directoriocr"];

            // Clear the ListView control
            listView1.Items.Clear();

            reader = commandDatabase.ExecuteReader();
            using (reader)
                while (reader.Read())
                {

                    // Define the list items
                    ListViewItem lvi = new ListViewItem(reader["Nombre"].ToString());
                    lvi.SubItems.Add(reader["Correo"].ToString());
                    lvi.SubItems.Add(reader["Extension"].ToString());
                    lvi.SubItems.Add(reader["Sucursal"].ToString());
                    lvi.SubItems.Add(reader["Area"].ToString());
                    lvi.SubItems.Add(reader["fecha"].ToString());

                    // Add the list items to the ListView
                    listView1.Items.Add(lvi);

                }
            databaseConnection.Close();
        }
        
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = listView1.Items[intselectedindex].Text;
                textBox1.Text = text;
                //do something
                //MessageBox.Show(listView1.Items[intselectedindex].Text); 
            }

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // string connectionString = "datasource=sql209.byetcluster.com;port=3306;username=n260m_22236702@192.168.0.6;password=ADMIN735;database=n260m_22236702_directoriocR;SslMode = none;"; // Nube


            // Tu consulta en SQL
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader;

            string query = "SELECT Correo FROM directoriocr WHERE Nombre LIKE '" + '%' + textBox1.Text + '%' + "' ";

            MySqlCommand commandDatabasenom = new MySqlCommand(query, databaseConnection);
            commandDatabasenom.CommandTimeout = 60;
            databaseConnection.Open();
            reader = commandDatabasenom.ExecuteReader();
            using (reader)
                while (reader.Read())
                {
                    // Define the list items
                    textBox2.Text = reader["Correo"].ToString();
                    
                }
            databaseConnection.Close();
            
            //Clipboard.SetText(textBox2.Text);


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + textBox2.Text);
        }
    }
}
