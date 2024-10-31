namespace TrabalhoPOOwinforms
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            textDescription = new TextBox();
            textGuarantee = new TextBox();
            textBrand = new TextBox();
            textStock = new TextBox();
            textPrice = new TextBox();
            textName = new TextBox();
            comboBox1 = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label8 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            textId = new TextBox();
            label9 = new Label();
            textVRAM = new TextBox();
            textBaseClock = new TextBox();
            textBoostClock = new TextBox();
            VRAMlabel = new Label();
            Baselabel = new Label();
            Boostlabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button4);
            panel1.Location = new Point(-5, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(226, 655);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LavenderBlush;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(49, 52);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(123, 22);
            textBox1.TabIndex = 2;
            textBox1.Text = "Admin's Page";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Desenho_PC_PNG;
            pictureBox1.Location = new Point(34, 109);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(170, 163);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Cyan;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(49, 580);
            button4.Name = "button4";
            button4.Size = new Size(118, 54);
            button4.TabIndex = 0;
            button4.Text = "Logout";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textDescription
            // 
            textDescription.Location = new Point(227, 224);
            textDescription.Name = "textDescription";
            textDescription.Size = new Size(141, 23);
            textDescription.TabIndex = 15;
            // 
            // textGuarantee
            // 
            textGuarantee.Location = new Point(227, 496);
            textGuarantee.Name = "textGuarantee";
            textGuarantee.Size = new Size(141, 23);
            textGuarantee.TabIndex = 13;
            // 
            // textBrand
            // 
            textBrand.Location = new Point(227, 428);
            textBrand.Name = "textBrand";
            textBrand.Size = new Size(141, 23);
            textBrand.TabIndex = 12;
            // 
            // textStock
            // 
            textStock.Location = new Point(227, 356);
            textStock.Name = "textStock";
            textStock.Size = new Size(141, 23);
            textStock.TabIndex = 11;
            // 
            // textPrice
            // 
            textPrice.Location = new Point(227, 288);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(141, 23);
            textPrice.TabIndex = 10;
            // 
            // textName
            // 
            textName.Location = new Point(227, 154);
            textName.Name = "textName";
            textName.Size = new Size(141, 23);
            textName.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(227, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 23);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(227, 472);
            label7.Name = "label7";
            label7.Size = new Size(127, 21);
            label7.TabIndex = 6;
            label7.Text = "Garantia (Meses)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(227, 404);
            label6.Name = "label6";
            label6.Size = new Size(53, 21);
            label6.TabIndex = 5;
            label6.Text = "Marca";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(227, 332);
            label5.Name = "label5";
            label5.Size = new Size(47, 21);
            label5.TabIndex = 4;
            label5.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(227, 264);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 3;
            label4.Text = "Preço";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(227, 200);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 2;
            label3.Text = "Descrição";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(227, 130);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 1;
            label2.Text = "Nome";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(227, 58);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 0;
            label1.Text = "Tipo";
            label1.Click += label1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(839, 82);
            label8.Name = "label8";
            label8.Size = new Size(130, 25);
            label8.TabIndex = 16;
            label8.Text = "Manage Stock";
            label8.Click += label8_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.Gold;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(227, 578);
            button1.Name = "button1";
            button1.Size = new Size(90, 40);
            button1.TabIndex = 17;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.YellowGreen;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(323, 578);
            button2.Name = "button2";
            button2.Size = new Size(80, 40);
            button2.TabIndex = 18;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightCoral;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(409, 578);
            button3.Name = "button3";
            button3.Size = new Size(80, 40);
            button3.TabIndex = 19;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(458, 130);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(850, 321);
            dataGridView1.TabIndex = 20;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textId
            // 
            textId.Location = new Point(227, 549);
            textId.Name = "textId";
            textId.ReadOnly = true;
            textId.Size = new Size(141, 23);
            textId.TabIndex = 21;
            textId.TextChanged += textBox6_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(227, 525);
            label9.Name = "label9";
            label9.Size = new Size(23, 21);
            label9.TabIndex = 22;
            label9.Text = "Id";
            label9.Click += label9_Click;
            // 
            // textVRAM
            // 
            textVRAM.Location = new Point(572, 549);
            textVRAM.Name = "textVRAM";
            textVRAM.Size = new Size(100, 23);
            textVRAM.TabIndex = 23;
            // 
            // textBaseClock
            // 
            textBaseClock.Location = new Point(734, 549);
            textBaseClock.Name = "textBaseClock";
            textBaseClock.Size = new Size(100, 23);
            textBaseClock.TabIndex = 24;
            // 
            // textBoostClock
            // 
            textBoostClock.Location = new Point(869, 549);
            textBoostClock.Name = "textBoostClock";
            textBoostClock.Size = new Size(100, 23);
            textBoostClock.TabIndex = 25;
            // 
            // VRAMlabel
            // 
            VRAMlabel.AutoSize = true;
            VRAMlabel.Location = new Point(572, 525);
            VRAMlabel.Name = "VRAMlabel";
            VRAMlabel.Size = new Size(43, 15);
            VRAMlabel.TabIndex = 26;
            VRAMlabel.Text = "VRAM:";
            // 
            // Baselabel
            // 
            Baselabel.AutoSize = true;
            Baselabel.Location = new Point(734, 525);
            Baselabel.Name = "Baselabel";
            Baselabel.Size = new Size(64, 15);
            Baselabel.TabIndex = 27;
            Baselabel.Text = "BaseClock:";
            // 
            // Boostlabel
            // 
            Boostlabel.AutoSize = true;
            Boostlabel.Location = new Point(869, 525);
            Boostlabel.Name = "Boostlabel";
            Boostlabel.Size = new Size(70, 15);
            Boostlabel.TabIndex = 28;
            Boostlabel.Text = "BoostClock:";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(1412, 644);
            Controls.Add(Boostlabel);
            Controls.Add(Baselabel);
            Controls.Add(VRAMlabel);
            Controls.Add(textBoostClock);
            Controls.Add(textBaseClock);
            Controls.Add(textVRAM);
            Controls.Add(label9);
            Controls.Add(textId);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(textDescription);
            Controls.Add(panel1);
            Controls.Add(textGuarantee);
            Controls.Add(label1);
            Controls.Add(textBrand);
            Controls.Add(label2);
            Controls.Add(textStock);
            Controls.Add(label3);
            Controls.Add(textPrice);
            Controls.Add(label4);
            Controls.Add(textName);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(label7);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textDescription;
        private TextBox textGuarantee;
        private TextBox textBrand;
        private TextBox textStock;
        private TextBox textPrice;
        private TextBox textName;
        private Label label8;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private TextBox textId;
        private Label label9;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Button button4;
        private TextBox textVRAM;
        private TextBox textBaseClock;
        private TextBox textBoostClock;
        private Label VRAMlabel;
        private Label Baselabel;
        private Label Boostlabel;
    }
}