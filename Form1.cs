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

    public partial class Form1 : Form
    {
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        private MySqlConnection _Conn;

        MySqlDataReader reader;
        MySqlDataAdapter _DataAdapterTitles;
        DataSet _DataSet;
        
        
        public Form1()
        {

            
            //cumpleaños();
            InitializeComponent();
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            Listviewini();
            comboarea();
            combosucu();
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            // La siguiente linea es la que provee la conexión entre C# y MySQL.
            // Debes cambiar el nombre de usuario, contrasenia y nombre de base de datos
            // de acuerdo a tus datos
            // Puedes ignorar la opción de base de datos (database) si quieres acceder a todas
            // 127.0.0.1 es de localhost y el puerto predeterminado para conectar
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL
            string query = "SELECT * FROM directoriocr ORDER BY Nombre";

            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            // A consultar !
            try
            {
                // Abre la base de datos
                databaseConnection.Open();

                // Ejecuta la consultas
                reader = commandDatabase.ExecuteReader();

                // Hasta el momento todo bien, es decir datos obtenidos

                // IMPORTANTE :#
                // Si tu consulta retorna un resultado, usa el siguiente proceso para obtener datos

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // En nuestra base de datos, el array contiene:  ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                        // Hacer algo con cada fila obtenida
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron datos.");
                }

                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = " ";
            comboBox2.Text = " ";
        }
        private void SaveUser()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "INSERT INTO directoriocr(`ID_Datos`, `Nombre`, `Correo`, `Extension`, `Sucursal`, `Area`, `fecha`) VALUES ('" + ID.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text+ "', '" + comboBox2.Text + "', '" + dateTimePicker1.Text + "')";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Usuario insertado satisfactoriamente");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                

               
                    MessageBox.Show("Ya existe un registro con ese  empleado, verificar los datos insertados");
               
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        private void deleteUser()
        {

            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            string query = "DELETE FROM `directoriocr` WHERE ID_Datos=" + ID.Text.Trim();

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Eliminado satisfactoriamente");
                // Eliminado satisfactoriamente

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, quizás el id no existe
                MessageBox.Show(ex.Message);
            }
        }


        private void New_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.Equals(-1) || comboBox1.Text == "")

            {
                MessageBox.Show("Seleccione la sucursal");
            }
            else if (comboBox2.SelectedIndex.Equals(-1) || comboBox2.Text == "")

            {
                MessageBox.Show("Seleccione el área");
            }
            else if (ID.Text == "" || textBox1.Text == "")

            {
                MessageBox.Show("Ingrese datos corrrectamente");
                ID.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();


            }
            else
            {
                SaveUser();
                GetData();
                Loadlist();
                limpiar();

            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
           
            if (ID.Text == "")

            {
                MessageBox.Show("Ingrese número de empleado a eliminar");
                ID.Clear();
            }
            else
            {
                string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
                string query = "SELECT Nombre FROM `directoriocr` WHERE ID_Datos=" + ID.Text.Trim();

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                databaseConnection.Open();

                string elim;
                reader = commandDatabase.ExecuteReader();
                using (reader)
                    while (reader.Read())
                    {
                        textBox1.Text = reader["Nombre"].ToString();
                    }
                elim = textBox1.Text;
                if (MessageBox.Show("¿Esta seguro que desea eliminar el usuario " + elim + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    deleteUser();
                    GetData();
                    Loadlist();
                    limpiar();
                }
                else
                    limpiar();
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Actualizar();
            GetData();
            Loadlist();


        }
        public void Actualizar()
        {
            
            comboarea();
            combosucu();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void listView1_load(object sender, EventArgs e)
        {

        }

        private void Listviewini()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
           // listView1.Sorting = SortOrder.Ascending;
            listView1.Columns.Add("# Empleado", 80, HorizontalAlignment.Left);
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
            string query = "SELECT * FROM directoriocr ORDER BY Nombre ASC ";

            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            
            MySqlDataAdapter _DataAdapterTitles;
           
            // Get the table from the data set
            DataTable dtable = _DataSet.Tables["directoriocr"];

            // Clear the ListView control
            listView1.Items.Clear();

            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DataRow drow = dtable.Rows[i];

                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {
                    // Define the list items
                    ListViewItem lvi = new ListViewItem(drow["ID_Datos"].ToString());
                    lvi.SubItems.Add(drow["Nombre"].ToString());
                    lvi.SubItems.Add(drow["Correo"].ToString());
                    lvi.SubItems.Add(drow["Extension"].ToString());
                    lvi.SubItems.Add(drow["Sucursal"].ToString());
                    lvi.SubItems.Add(drow["Area"].ToString());
                    lvi.SubItems.Add(drow["fecha"].ToString());

                    // Add the list items to the ListView
                    listView1.Items.Add(lvi);
                   
                    
                }
                


                    
            }
        }
        private void GetData()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            // Tu consulta en SQL

            try
            {
                _Conn = new MySqlConnection(connectionString);

                // Fill DataSet

                string query = "SELECT * FROM directoriocr ";


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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboarea();
        }
        public void Llenacombobox()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                      
            try
            {
                _Conn = new MySqlConnection(connectionString);

                // Fill DataSet

                string query = "SELECT Sucursal FROM directoriocr WHERE ID_Datos " + ID.Text.Trim(); 

                //codigo para llenar el comboBox

                _DataSet = new DataSet();
                _DataAdapterTitles = new MySqlDataAdapter(query, _Conn);
                _DataAdapterTitles.Fill(_DataSet, "directoriocr");
                //se indica el nombre de la tabla
                comboBox1.DataSource = _DataSet.Tables[0].DefaultView;
                //se especifica el campo de la tabla
                comboBox1.ValueMember = "Sucursal";
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
        public void RellenarTextbox()
        {
            string connectionString = "datasource=10.108.1.93;port=3306;username=rootadmin;password=admin735;database=directorio;SslMode = none;";

            try
            {
                _Conn = new MySqlConnection(connectionString);

                // Fill DataSet

                string queryn = "SELECT * FROM directoriocr WHERE ID_Datos= " ;

                //codigo para llenar el comboBox
                MySqlCommand commandDatabase = new MySqlCommand(queryn, _Conn);
                commandDatabase.CommandTimeout = 60;
                commandDatabase.Parameters.AddWithValue("ID_Datos",Convert.ToInt32(textBox1.Text));
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                string query = "SELECT Sucursal FROM directoriocr WHERE ID_Datos " ;

                //codigo para llenar el comboBox

                _DataSet = new DataSet();
                _DataAdapterTitles = new MySqlDataAdapter(query, _Conn);
                _DataAdapterTitles.Fill(_DataSet, "directoriocr");
                //se indica el nombre de la tabla
                comboBox1.DataSource = _DataSet.Tables[0].DefaultView;
                //se especifica el campo de la tabla
                comboBox1.ValueMember = "Sucursal";
                if (reader.Read())
                {
                    textBox1.Text = Convert.ToString(reader["Nombre"]);
                    textBox2.Text = Convert.ToString(reader["Correo"]);
                    textBox3.Text = Convert.ToString(reader["Extension"]);
                    
                }
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

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 frm = new Form2();
            frm.Show();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void combosucu()
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
        private void comboarea()
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
                string querypc = "SELECT area FROM areasysucursales WHERE sucursal LIKE '" + '%' +  sucursal + '%' + "' " + "  ORDER BY area ASC"; //seleccionadas

                MySqlCommand commandDatabasepc = new MySqlCommand(querypc, databaseConnection);
                MySqlDataAdapter adaptadorpc = new MySqlDataAdapter(commandDatabasepc);
                DataSet dspc = new DataSet();
                adaptadorpc.Fill(dspc);
                comboBox2.DataSource = dspc.Tables[0].DefaultView;
                comboBox2.ValueMember = "area";
            }

        }
        private void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            ID.Text = " ";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

            private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox1.Text = "";
        }
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }

        private void ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                //  filtrotxt1 = 1; // para ext
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '/')
            {
                e.Handled = true;
                //  filtrotxt1 = 1; // para ext
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void nuevaAreasucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void sucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '@' && !char.IsLetter(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-')
            {
                e.Handled = true;
                //  filtrotxt1 = 1; // para ext
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por:\nJonathan Alexis Huerta Vazquez \nRedes y Soporte \nCasanova Rentacar ");
        }

        private void comunicadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void cumpleañosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }
    }



}

