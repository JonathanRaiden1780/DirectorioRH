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
    public partial class Form2 : Form
    {
        private string valorEnForm2;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        private MySqlConnection _Conn;

        MySqlDataReader reader;
        MySqlDataAdapter _DataAdapterTitles;
        DataSet _DataSet;
        int oparea = 9;
        public Form2(  )
        {
            InitializeComponent();
            Listviewini();

            combosucu();
            comboarea();
            textBox5.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox2.Enabled = false;
            comboBox1.Enabled = false;
            Guardar.Enabled = false;
            Cancelar.Enabled = false;
            comboBox1.Text = " ";
            comboBox2.Text = " ";



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Text = " ";
            comboBox2.Text = " ";
        }
        private void Loadlist()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL
            string query = "SELECT * FROM directoriocr WHERE ID_Datos= " + textBox1.Text.Trim();

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
                    ListViewItem lvi = new ListViewItem(reader["ID_Datos"].ToString());
                    lvi.SubItems.Add(reader["Nombre"].ToString());
                    lvi.SubItems.Add(reader["Correo"].ToString());
                    lvi.SubItems.Add(reader["Extension"].ToString());
                    lvi.SubItems.Add(reader["Sucursal"].ToString());
                    lvi.SubItems.Add(reader["Area"].ToString());
                    lvi.SubItems.Add(reader["fecha"].ToString());
                    textBox5.Text = reader["Nombre"].ToString();
                    textBox2.Text = reader["Correo"].ToString();
                    textBox3.Text = reader["Extension"].ToString();
                    comboBox1.Text = reader["Sucursal"].ToString();
                    comboBox2.Text = reader["Area"].ToString();
                    lvi.SubItems.Add(reader["fecha"].ToString());

                    // Add the list items to the ListView
                    listView1.Items.Add(lvi);

                }





            databaseConnection.Close();





        }
        private void GetData()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL

            try
            {
                _Conn = new MySqlConnection(connectionString);

                // Fill DataSet

                string query = "SELECT * FROM directoriocr WHERE ID_Datos= " + textBox1.Text.Trim() ;


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
                    listView1.Columns.Add("ID_Datos", 70, HorizontalAlignment.Left);
                    listView1.Columns.Add("Nombre", 150, HorizontalAlignment.Left);
                    listView1.Columns.Add("Correo", 150, HorizontalAlignment.Left);
                    listView1.Columns.Add("Extension", 70, HorizontalAlignment.Left);
                    listView1.Columns.Add("Sucursal", 150, HorizontalAlignment.Left);
                    listView1.Columns.Add("Area", 150, HorizontalAlignment.Left);
                    listView1.Columns.Add("Fecha de nacimiento", 110, HorizontalAlignment.Left);
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            String id = textBox1.Text.Trim();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese número de empleado");
            }
            else
            {
                GetData();
                Loadlist();

                textBox5.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox2.Enabled = true;
                comboBox1.Enabled = true;
                Guardar.Enabled = true;
                Cancelar.Enabled = true;
                // Llenacombobox();
                //Llenannombre();
            }
        }
        public void Actualizar()
        {
            
            comboarea();
            combosucu();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea modificar los datos?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                if (comboBox1.SelectedIndex.Equals(-1))

                {
                    MessageBox.Show("Seleccione la sucursal");
                }
               else if ( comboBox2.SelectedIndex.Equals(-1))

                {
                    MessageBox.Show("Seleccione el área");
                }
                else if (textBox5.Text == "" )
                {
                    MessageBox.Show("Ingrese datos corrrectamente");
                }
                else
                {
                    deleteUser();
                    SaveUser();
                    GetData();
                    Loadlist();
                    Actualizar();

                }

            }

                
        }


        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SaveUser()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "INSERT INTO directoriocr(`ID_Datos`, `Nombre`, `Correo`, `Extension`, `Sucursal`, `Area`, `fecha`) VALUES ('" + textBox1.Text + "', '" + textBox5.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + dateTimePicker1.Text + "')";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Usuario modificado satisfactoriamente");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteUser()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "DELETE FROM `directoriocr` WHERE ID_Datos=" + textBox1.Text.Trim();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboarea();

        }

        public void combosucu()
        {
      
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // string connectionString = "datasource=sql209.byetcluster.com;port=3306;username=n260m_22236702@192.168.0.6;password=ADMIN735;database=n260m_22236702_directoriocR;SslMode = none;"; // Nube


            // Tu consulta en SQL
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);


            string querycsu = "SELECT sucursales FROM sucursal WHERE sucursales=0  ORDER BY sucursales ASC";
            MySqlCommand commandDatabasene = new MySqlCommand(querycsu, databaseConnection);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commandDatabasene);
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.ValueMember = "sucursales";

            

        }
        public void comboarea()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // string connectionString = "datasource=sql209.byetcluster.com;port=3306;username=n260m_22236702@192.168.0.6;password=ADMIN735;database=n260m_22236702_directoriocR;SslMode = none;"; // Nube
            string sucursal;
            sucursal = comboBox1.Text.Trim();

            // Tu consulta en SQL
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            if (sucursal == "" || sucursal == " ")
            {
                string querya = "SELECT areas FROM area WHERE areas =0  ORDER BY areas ASC"; //todas

                MySqlCommand commandDatabasepc = new MySqlCommand(querya, databaseConnection);
                MySqlDataAdapter adaptadorpc = new MySqlDataAdapter(commandDatabasepc);
                DataSet dspc = new DataSet();
                adaptadorpc.Fill(dspc);
                comboBox2.DataSource = dspc.Tables[0].DefaultView;
                comboBox2.ValueMember = "areas";
            }
            else
            {
                string querypc = "SELECT area FROM areasysucursales WHERE sucursal LIKE '" + '%' + sucursal + '%' + "' " + "  ORDER BY area ASC"; //seleccionadas

                MySqlCommand commandDatabasepc = new MySqlCommand(querypc, databaseConnection);
                MySqlDataAdapter adaptadorpc = new MySqlDataAdapter(commandDatabasepc);
                DataSet dspc = new DataSet();
                adaptadorpc.Fill(dspc);
                comboBox2.DataSource = dspc.Tables[0].DefaultView;
                comboBox2.ValueMember = "area";
            }
        }


        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '/' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-' && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
