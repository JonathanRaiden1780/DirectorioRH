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

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        private MySqlConnection _Conn;

        MySqlDataReader reader;
        MySqlDataAdapter _DataAdapterTitles;
        DataSet _DataSet;

        public Form4()
        {
            InitializeComponent();

            Listviewiniarea();
            GetDataarea();
            ID();
            Loadlistarea();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ID()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // string connectionString = "datasource=sql209.byetcluster.com;port=3306;username=n260m_22236702@192.168.0.6;password=ADMIN735;database=n260m_22236702_directoriocR;SslMode = none;"; // Nube


            // Tu consulta en SQL
            string query = "SELECT `ID_SUCURSAL` FROM `sucursal` ORDER by `ID_SUCURSAL` DESC LIMIT 1 ";
            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            int id;
            reader = commandDatabase.ExecuteReader();
            using (reader)
                while (reader.Read())
                {

                    // Define the list items

                    textBox1.Text = reader["ID_SUCURSAL"].ToString();
                    // Add the list items to the ListView
                    id = Convert.ToInt32(textBox1.Text) + 1;
                    textBox1.Text = Convert.ToString(id);
                }
            databaseConnection.Close();

        }
        private void Loadlistarea()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL
            string query = "SELECT * FROM sucursal";

            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            MySqlDataAdapter _DataAdapterTitles;

            // Get the table from the data set
            DataTable dtable = _DataSet.Tables["sucursal"];

            // Clear the ListView control
            listView1.Items.Clear();

            reader = commandDatabase.ExecuteReader();
            using (reader)
                while (reader.Read())
                {

                    // Define the list items
                    ListViewItem lvi = new ListViewItem(reader["ID_SUCURSAL"].ToString());
                    lvi.SubItems.Add(reader["sucursales"].ToString());
                    // Add the list items to the ListView
                    listView1.Items.Add(lvi);

                }
            databaseConnection.Close();
        }
        private void GetDataarea()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL

            try
            {
                _Conn = new MySqlConnection(connectionString);

                // Fill DataSet

                string query = "SELECT * FROM sucursal";


                _DataSet = new DataSet();
                _DataAdapterTitles = new MySqlDataAdapter(query, _Conn);
                _DataAdapterTitles.Fill(_DataSet, "sucursal");

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


        private void Listviewiniarea()
        {
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            // listView1.Sorting = SortOrder.Ascending;
            listView1.Columns.Add("#Sucursal", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("Sucursales", 220, HorizontalAlignment.Left);
        }

        private void SaveUserarea()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "INSERT INTO sucursal(`ID_SUCURSAL`, `sucursales`) VALUES ('" + textBox1.Text + "', '" + textBox5.Text + "')";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Sucursal creada correctamente");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                MessageBox.Show("Ya existe el número de sucursal, validar datos ingresados");
            }
        }
        private void deleteUserarea()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "DELETE FROM `sucursal` WHERE ID_SUCURSAL=" + textBox1.Text.Trim();

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
            if (MessageBox.Show("¿Desea Cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();

            }
        }
        private void Guardar_Click(object sender, EventArgs e)
        {

            bool ban = false;
            if (textBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Ingrese Datos Corrrectamente");
                ban = true;
            }

            else if (ban == false)
            {
                string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
                string querya = "SELECT sucursales FROM `sucursal` WHERE sucursales LIKE '" + '%' + textBox5.Text + '%' + "' ";

                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(querya, databaseConnection2);
                MySqlDataReader reader2;
                databaseConnection2.Open();
                string guarda;
                reader2 = commandDatabase2.ExecuteReader();
                using (reader2)
                    while (reader2.Read())
                    {

                        textBox2.Text = reader2["sucursales"].ToString();

                    }
                guarda = textBox5.Text;

                if (MessageBox.Show("¿Desea guardar la sucursal  " + guarda + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (guarda == textBox2.Text)
                    {
                        MessageBox.Show("Esta sucursal ya existe, verificar los datos ingresados");
                        textBox1.Clear();
                        textBox5.Clear();
                    }
                    else if (guarda != textBox2.Text)
                    {
                        SaveUserarea();
                        GetDataarea();
                        Loadlistarea();
                        textBox1.Clear();
                        textBox5.Clear();
                        Form1 frm1 = new Form1();
                        Form2 frm2 = new Form2();
                        frm1.Actualizar();
                        frm2.Actualizar();
                        ID();
                    }
                }
                else
                {
                    textBox1.Clear();
                    textBox5.Clear();
                    ID();
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool ban = true;

            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                MessageBox.Show("Ingrese número de sucursal corrrectamente");
                ban = false;
            }


            else if (ban == true)
            {

                //condicionar el area y sucursal para el cambio
                string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";

                string querya = "SELECT sucursales FROM `sucursal` WHERE ID_SUCURSAL=" + textBox1.Text.Trim();

                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(querya, databaseConnection2);


                MySqlDataReader reader2;

                databaseConnection2.Open();
                string elim;

                reader2 = commandDatabase2.ExecuteReader();
                using (reader2)
                    while (reader2.Read())
                    {


                        textBox5.Text = reader2["sucursales"].ToString();

                    }
                elim = textBox5.Text;



                if (MessageBox.Show("¿Desea eliminar la sucursal " + elim + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    deleteUserarea();
                    deleteUserareas2();
                    GetDataarea();
                    Loadlistarea();
                    textBox1.Clear();
                    textBox5.Clear();
                    Form1 frm1 = new Form1();
                    Form2 frm2 = new Form2();
                    frm1.Actualizar();
                    frm2.Actualizar();
                    ID();
                }
                else
                {
                    textBox1.Clear();
                    textBox5.Clear();
                    ID();
                }

            }

        }
        private void deleteUserareas2()
        {




            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "DELETE FROM `areasysucursales` WHERE sucursal LIKE '" + '%' + textBox5.Text + '%' + "' ";


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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                //  filtrotxt1 = 1; // para ext
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


    }
}
