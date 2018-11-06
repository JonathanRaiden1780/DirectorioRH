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
    public partial class Form3 : Form
    {
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        private MySqlConnection _Conn;

        MySqlDataReader reader;
        MySqlDataAdapter _DataAdapterTitles;
        DataSet _DataSet;

        public Form3()
        {
            InitializeComponent();
            listView1.Clear();
            ID();
            combosucu();
            comboarea();
            radioButton1.Checked = true;
            button2.Visible = false;



        }

        private void ID()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // string connectionString = "datasource=sql209.byetcluster.com;port=3306;username=n260m_22236702@192.168.0.6;password=ADMIN735;database=n260m_22236702_directoriocR;SslMode = none;"; // Nube


            // Tu consulta en SQL
            string query = "SELECT `ID_AREA` FROM `area` ORDER by `ID_AREA` DESC LIMIT 1 ";
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

                    textBox1.Text = reader["ID_AREA"].ToString();
                    // Add the list items to the ListView
                   id =  Convert.ToInt32(textBox1.Text) + 1 ;
                   textBox1.Text = Convert.ToString(id);
                }
            databaseConnection.Close();
            
        }
        private void Loadlistarea()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL
            string query = "SELECT * FROM area";

            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            MySqlDataAdapter _DataAdapterTitles;

            // Get the table from the data set
            DataTable dtable = _DataSet.Tables["area"];

            // Clear the ListView control
            listView1.Items.Clear();

            reader = commandDatabase.ExecuteReader();
            using (reader)
                while (reader.Read())
                {

                    // Define the list items
                    ListViewItem lvi = new ListViewItem(reader["ID_AREA"].ToString());
                    lvi.SubItems.Add(reader["areas"].ToString());
                    
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

                string query = "SELECT * FROM area";


                _DataSet = new DataSet();
                _DataAdapterTitles = new MySqlDataAdapter(query, _Conn);
                _DataAdapterTitles.Fill(_DataSet, "area");

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
            listView1.Columns.Add("#Area", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("Areas", 220, HorizontalAlignment.Left);
        }
        private void Loadlistareas()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL
            string query = "SELECT * FROM areasysucursales ORDER BY sucursal ASC";

            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            databaseConnection.Open();
            MySqlDataAdapter _DataAdapterTitles;

            // Get the table from the data set
            DataTable dtable = _DataSet.Tables["areasysucursales"];

            // Clear the ListView control
            listView1.Items.Clear();

            reader = commandDatabase.ExecuteReader();
            using (reader)
                while (reader.Read())
                {

                    // Define the list items
                    ListViewItem lvi = new ListViewItem(reader["sucursal"].ToString());
                    lvi.SubItems.Add(reader["area"].ToString());
                    
                    // Add the list items to the ListView
                    listView1.Items.Add(lvi);

                }
            databaseConnection.Close();
        }
        private void GetDataareas()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL

            try
            {
                _Conn = new MySqlConnection(connectionString);

                // Fill DataSet

                string query = "SELECT * FROM areasysucursales ORDER BY sucursal ASC";


                _DataSet = new DataSet();
                _DataAdapterTitles = new MySqlDataAdapter(query, _Conn);
                _DataAdapterTitles.Fill(_DataSet, "areasysucursales");

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


        private void Listviewiniareas()
        {
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            // listView1.Sorting = SortOrder.Ascending;
            listView1.Columns.Add("Sucursal", 220, HorizontalAlignment.Left);
            listView1.Columns.Add("Area", 220, HorizontalAlignment.Left);
        }

        private void SaveUserarea()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "INSERT INTO area(`ID_AREA`, `areas`) VALUES ('" + textBox1.Text + "', '" + textBox5.Text + "')";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Area creada correctamente");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                MessageBox.Show("Ya existe el número de área, validar datos ingresados");
            }
        }
        private void SaveUserareas()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "INSERT INTO areasysucursales(`sucursal`, `area`) VALUES ('" + comboBox1.Text + "', '" + comboBox2.Text + "')";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Area agregada correctamente");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteUserarea()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "DELETE FROM `area` WHERE ID_AREA=" + textBox1.Text.Trim();

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
        private void deleteUserareas()
        {
             
            
           

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "DELETE FROM `areasysucursales` WHERE ID_TOT=" + textBox1.Text.Trim(); 

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
        private void deleteUserareas2()
        {




            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "DELETE FROM `areasysucursales` WHERE area LIKE '" + '%' + textBox5.Text + '%' + "' ";
            

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

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            
            bool ban=false;
            if (textBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Ingrese Datos Corrrectamente");
                ban = true;
            }
            
            else if (ban == false)
            {
                string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
                string querya = "SELECT areas FROM `area` WHERE areas LIKE '" + '%' + textBox5.Text + '%' + "' ";

                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(querya, databaseConnection2);
                MySqlDataReader reader2;
                databaseConnection2.Open();
                string guarda;
                reader2 = commandDatabase2.ExecuteReader();
                using (reader2)
                    while (reader2.Read())
                    {

                        textBox3.Text = reader2["areas"].ToString();

                    }
                guarda = textBox5.Text;
                
                if (MessageBox.Show("¿Desea guardar el área  " + guarda + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (guarda == textBox3.Text)
                    {
                        MessageBox.Show("Esta área ya existe, verificar los datos ingresados");
                        textBox1.Clear();
                        textBox5.Clear();
                    }
                    else if (guarda != textBox3.Text) {
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool ban = true;

            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                MessageBox.Show("Ingrese número de área que desee eliminar");
                ban = false;
            }
            

            else if (ban == true)
            {

                //condicionar el area y sucursal para el cambio
                string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";

                string querya = "SELECT areas FROM `area` WHERE ID_AREA=" + textBox1.Text.Trim();

                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(querya, databaseConnection2);


                MySqlDataReader reader2;

                databaseConnection2.Open();
                string elim;

                reader2 = commandDatabase2.ExecuteReader();
                using (reader2)
                    while (reader2.Read())
                    {


                        textBox5.Text = reader2["areas"].ToString();

                    }
                elim = textBox5.Text;



                if (MessageBox.Show("¿Desea eliminar el área " + elim + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    
                        deleteUserarea();

                    deleteUserareas2();
                        GetDataarea();
                        Loadlistarea();
                        textBox1.Clear();
                        textBox5.Clear();
                        comboBox1.Text = "";
                        comboBox2.Text = "";
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
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    ID();
                }

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public void combosucu()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // string connectionString = "datasource=sql209.byetcluster.com;port=3306;username=n260m_22236702@192.168.0.6;password=ADMIN735;database=n260m_22236702_directoriocR;SslMode = none;"; // Nube


            // Tu consulta en SQL
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);


            string querycsu = "SELECT sucursales FROM sucursal WHERE sucursales=0";
            MySqlCommand commandDatabasene = new MySqlCommand(querycsu, databaseConnection);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commandDatabasene);
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.ValueMember = "sucursales";
        }
        private void comboarea()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // string connectionString = "datasource=sql209.byetcluster.com;port=3306;username=n260m_22236702@192.168.0.6;password=ADMIN735;database=n260m_22236702_directoriocR;SslMode = none;"; // Nube
            string sucursal;
            sucursal = comboBox1.Text.Trim();

            // Tu consulta en SQL
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

           
                string querya = "SELECT areas FROM area WHERE areas =0"; //todas

                MySqlCommand commandDatabasepc = new MySqlCommand(querya, databaseConnection);
                MySqlDataAdapter adaptadorpc = new MySqlDataAdapter(commandDatabasepc);
                DataSet dspc = new DataSet();
                adaptadorpc.Fill(dspc);
                comboBox2.DataSource = dspc.Tables[0].DefaultView;
                comboBox2.ValueMember = "areas";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Clear();

            if (radioButton1.Checked == true)
            {
                Listviewiniarea();
                GetDataarea();
                Loadlistarea();
                label2.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                textBox5.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button1.Visible = true;
                textBox1.Visible = true;
                label1.Visible = true;
                ID();

            }
            else
            {
                Listviewiniareas();
                GetDataareas();
                Loadlistareas();
                label2.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                textBox5.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button1.Visible = false;
                textBox1.Visible = false;
                label1.Visible = false;

            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            listView1.Clear();
            if (radioButton2.Checked == true)
            {
                Listviewiniareas();
                GetDataareas();
                Loadlistareas();
                label2.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                textBox5.Visible = false;
                button2.Visible = true;
                comboarea();
                button3.Visible = true;
                button1.Visible = false;
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            else
            {
                Listviewiniarea();
                GetDataarea();
                Loadlistarea();
                label2.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                textBox5.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button1.Visible = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            bool ban = false;

            if (comboBox1.SelectedIndex.Equals(-1) || comboBox1.Text == "" || comboBox2.SelectedIndex.Equals(-1) || comboBox2.Text == "")

            {
                MessageBox.Show("Seleccione área y sucursal");
                ban = true;
            }
            else if (ban == false)
            {
                
                
                string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";

                string querya = "SELECT * FROM `areasysucursales` WHERE area LIKE '" + '%' + comboBox2.Text + '%' + "' " + "AND sucursal LIKE '" + '%' + comboBox1.Text + '%' + "' ";

                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(querya, databaseConnection2);

                MySqlDataReader reader2;

                databaseConnection2.Open();
                string guarda, guarda2;

                reader2 = commandDatabase2.ExecuteReader();
                using (reader2)
                    while (reader2.Read())
                    {

                        textBox5.Text = reader2["area"].ToString();
                        textBox2.Text = reader2["sucursal"].ToString();

                    }
                guarda = comboBox2.Text;
                guarda2 = comboBox1.Text;
                if (MessageBox.Show("¿Desea agregar el área  " + guarda + " a la sucursal " + guarda2 + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveUserareas();
                    GetDataareas();
                    Loadlistareas();
                    textBox1.Clear();
                    textBox5.Clear();
                    Form1 frm1 = new Form1();
                    Form2 frm2 = new Form2();
                    frm1.Actualizar();
                    frm2.Actualizar();
                }
                else
                {
                    comboBox1.Text="";
                    comboBox2.Text="";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {

                bool ban = true;

                if (comboBox2.Text == "" || comboBox1.Text == "" || comboBox2.SelectedIndex.Equals(-1) || comboBox2.SelectedIndex.Equals(-1) )
                {
                    MessageBox.Show("Seleccione area y sucursal");
                    ban = false;
                }


                else if (ban == true)
                {

                    //condicionar el area y sucursal para el cambio
                    string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";

                    string querya = "SELECT * FROM `areasysucursales` WHERE area LIKE '" + '%' + comboBox2.Text + '%' + "' " + "AND sucursal LIKE '" + '%' + comboBox1.Text + '%' + "' ";
                    
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase2 = new MySqlCommand(querya, databaseConnection2);


                    MySqlDataReader reader2;

                    databaseConnection2.Open();
                    string elim, elim2;

                    reader2 = commandDatabase2.ExecuteReader();
                    using (reader2)
                        while (reader2.Read())
                        {


                            textBox5.Text = reader2["area"].ToString();
                            textBox2.Text = reader2["sucursal"].ToString();

                        }
                    elim = comboBox2.Text;
                    elim2 = comboBox1.Text;



                    if (MessageBox.Show("¿Desea eliminar el área " + elim + " de la sucursal "+ elim2 + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        deleteUserareas();
                        GetDataareas();
                        Loadlistareas();
                        textBox1.Clear();
                        textBox5.Clear();
                        comboBox1.Text = "";
                        comboBox2.Text = "";
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
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        ID();
                    }

                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string queryne = "SELECT ID_TOT FROM areasysucursales WHERE area LIKE '" + '%' + comboBox2.Text + '%' + "' " + "AND sucursal LIKE '" + '%' + comboBox1.Text + '%' + "' ";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(queryne, databaseConnection2);


            MySqlDataReader reader2;

            databaseConnection2.Open();
            

            reader2 = commandDatabase2.ExecuteReader();
            using (reader2)
                while (reader2.Read())
                {


                    textBox1.Text = reader2["ID_TOT"].ToString();

                }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
