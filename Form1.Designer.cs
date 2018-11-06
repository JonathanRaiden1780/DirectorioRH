namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaAreasucursalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucursalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comunicadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cumpleañosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Gropbox = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.New = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip2.SuspendLayout();
            this.Gropbox.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.nuevaAreasucursalToolStripMenuItem,
            this.comunicadoToolStripMenuItem,
            this.cumpleañosToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1155, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(71, 20);
            this.toolStripMenuItem1.Text = "Actualizar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // nuevaAreasucursalToolStripMenuItem
            // 
            this.nuevaAreasucursalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.areaToolStripMenuItem,
            this.sucursalToolStripMenuItem});
            this.nuevaAreasucursalToolStripMenuItem.Name = "nuevaAreasucursalToolStripMenuItem";
            this.nuevaAreasucursalToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.nuevaAreasucursalToolStripMenuItem.Text = "Nueva Area/Sucursal";
            this.nuevaAreasucursalToolStripMenuItem.Click += new System.EventHandler(this.nuevaAreasucursalToolStripMenuItem_Click);
            // 
            // areaToolStripMenuItem
            // 
            this.areaToolStripMenuItem.Name = "areaToolStripMenuItem";
            this.areaToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.areaToolStripMenuItem.Text = "Area";
            this.areaToolStripMenuItem.Click += new System.EventHandler(this.areaToolStripMenuItem_Click);
            // 
            // sucursalToolStripMenuItem
            // 
            this.sucursalToolStripMenuItem.Name = "sucursalToolStripMenuItem";
            this.sucursalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.sucursalToolStripMenuItem.Text = "Sucursal";
            this.sucursalToolStripMenuItem.Click += new System.EventHandler(this.sucursalToolStripMenuItem_Click);
            // 
            // comunicadoToolStripMenuItem
            // 
            this.comunicadoToolStripMenuItem.Name = "comunicadoToolStripMenuItem";
            this.comunicadoToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.comunicadoToolStripMenuItem.Text = "Comunicado";
            this.comunicadoToolStripMenuItem.Click += new System.EventHandler(this.comunicadoToolStripMenuItem_Click);
            // 
            // cumpleañosToolStripMenuItem
            // 
            this.cumpleañosToolStripMenuItem.Name = "cumpleañosToolStripMenuItem";
            this.cumpleañosToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.cumpleañosToolStripMenuItem.Text = "Cumpleaños";
            this.cumpleañosToolStripMenuItem.Click += new System.EventHandler(this.cumpleañosToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(41, 20);
            this.toolStripMenuItem2.Text = "Salir";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Gropbox
            // 
            this.Gropbox.Controls.Add(this.dateTimePicker1);
            this.Gropbox.Controls.Add(this.label13);
            this.Gropbox.Controls.Add(this.comboBox2);
            this.Gropbox.Controls.Add(this.button1);
            this.Gropbox.Controls.Add(this.label12);
            this.Gropbox.Controls.Add(this.ID);
            this.Gropbox.Controls.Add(this.Delete);
            this.Gropbox.Controls.Add(this.New);
            this.Gropbox.Controls.Add(this.label11);
            this.Gropbox.Controls.Add(this.label10);
            this.Gropbox.Controls.Add(this.label9);
            this.Gropbox.Controls.Add(this.label8);
            this.Gropbox.Controls.Add(this.label7);
            this.Gropbox.Controls.Add(this.comboBox1);
            this.Gropbox.Controls.Add(this.textBox3);
            this.Gropbox.Controls.Add(this.textBox2);
            this.Gropbox.Controls.Add(this.textBox1);
            this.Gropbox.Location = new System.Drawing.Point(12, 210);
            this.Gropbox.Name = "Gropbox";
            this.Gropbox.Size = new System.Drawing.Size(276, 339);
            this.Gropbox.TabIndex = 1;
            this.Gropbox.TabStop = false;
            this.Gropbox.Text = "Insertar Datos";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/mm/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(74, 219);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(191, 20);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 26);
            this.label13.TabIndex = 14;
            this.label13.Text = "Fecha de\r\nNacimiento\r\n";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "CENTENARIO",
            "CHAPULTEPEC",
            "COACALCO",
            "CUERNAVACA",
            "LA VIGA",
            "NIÑOS HEROES",
            "PATRIOTISMO CORPORATIVO",
            "PATRIOTISMO SUCURSAL",
            "PATRIOTISMO TALLER",
            "TLALPAN",
            "TLALNEPANTLA",
            "VALLEJO"});
            this.comboBox2.Location = new System.Drawing.Point(74, 183);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox2_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 26);
            this.label12.TabIndex = 13;
            this.label12.Text = "Número de \r\nEmpleado";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(74, 47);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(45, 20);
            this.ID.TabIndex = 0;
            this.ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_KeyPress);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(85, 264);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(72, 24);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "Eliminar";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // New
            // 
            this.New.Location = new System.Drawing.Point(7, 264);
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(72, 24);
            this.New.TabIndex = 6;
            this.New.Text = "Nuevo";
            this.New.UseVisualStyleBackColor = true;
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Area";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 26);
            this.label10.TabIndex = 8;
            this.label10.Text = "Lugar de \r\nTrabajo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Extension";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Correo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Nombre";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CENTENARIO",
            "CHAPULTEPEC",
            "COACALCO",
            "CUERNAVACA",
            "LA VIGA",
            "NIÑOS HEROES",
            "PATRIOTISMO CORPORATIVO",
            "PATRIOTISMO SUCURSAL",
            "PATRIOTISMO TALLER",
            "TLALPAN",
            "TLALNEPANTLA",
            "VALLEJO"});
            this.comboBox1.Location = new System.Drawing.Point(74, 152);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(74, 125);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(57, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox2.Location = new System.Drawing.Point(74, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(74, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel1.BackgroundImage")));
            this.Panel1.Controls.Add(this.pictureBox2);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Location = new System.Drawing.Point(0, 27);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1151, 118);
            this.Panel1.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(266, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.Label2.Location = new System.Drawing.Point(283, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(311, 58);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "DIRECTORIO";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(294, 151);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(861, 425);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1155, 579);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Gropbox);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CasanovaRentacar Directroio RH";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.Gropbox.ResumeLayout(false);
            this.Gropbox.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label Label4;
        
        internal System.Windows.Forms.Label Label3;
        
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.DataGridView DataGridView1;
        
        
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.GroupBox Gropbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button New;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ToolStripMenuItem nuevaAreasucursalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucursalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comunicadoToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem cumpleañosToolStripMenuItem;
    }
}

