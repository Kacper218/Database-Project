namespace Projekt_bazodanowy
{
    partial class Form3
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
            this.klienci_dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addRecipt_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.idKlienta_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.nazwaKlienta_label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataWyst_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.idDok_textBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.klienci_dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // klienci_dataGridView
            // 
            this.klienci_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klienci_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.klienci_dataGridView.Location = new System.Drawing.Point(7, 26);
            this.klienci_dataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.klienci_dataGridView.Name = "klienci_dataGridView";
            this.klienci_dataGridView.RowHeadersWidth = 51;
            this.klienci_dataGridView.RowTemplate.Height = 24;
            this.klienci_dataGridView.Size = new System.Drawing.Size(860, 305);
            this.klienci_dataGridView.TabIndex = 0;
            this.klienci_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.klienci_dataGridView_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.klienci_dataGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(14, 150);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(873, 344);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paragony klienta";
            // 
            // addRecipt_button
            // 
            this.addRecipt_button.Location = new System.Drawing.Point(702, 21);
            this.addRecipt_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addRecipt_button.Name = "addRecipt_button";
            this.addRecipt_button.Size = new System.Drawing.Size(158, 78);
            this.addRecipt_button.TabIndex = 2;
            this.addRecipt_button.Text = "Dodaj paragon";
            this.addRecipt_button.UseVisualStyleBackColor = true;
            this.addRecipt_button.Click += new System.EventHandler(this.addRecipt_button_Click);
            // 
            // close_button
            // 
            this.close_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_button.Location = new System.Drawing.Point(716, 622);
            this.close_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(158, 46);
            this.close_button.TabIndex = 3;
            this.close_button.Text = "Zamknij";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // idKlienta_label
            // 
            this.idKlienta_label.AutoSize = true;
            this.idKlienta_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.idKlienta_label.Location = new System.Drawing.Point(28, 34);
            this.idKlienta_label.Name = "idKlienta_label";
            this.idKlienta_label.Size = new System.Drawing.Size(119, 26);
            this.idKlienta_label.TabIndex = 4;
            this.idKlienta_label.Text = "ID Klienta: ";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.email_label.Location = new System.Drawing.Point(376, 34);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(80, 26);
            this.email_label.TabIndex = 5;
            this.email_label.Text = "Email: ";
            // 
            // nazwaKlienta_label
            // 
            this.nazwaKlienta_label.AutoSize = true;
            this.nazwaKlienta_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nazwaKlienta_label.Location = new System.Drawing.Point(28, 76);
            this.nazwaKlienta_label.Name = "nazwaKlienta_label";
            this.nazwaKlienta_label.Size = new System.Drawing.Size(164, 26);
            this.nazwaKlienta_label.TabIndex = 6;
            this.nazwaKlienta_label.Text = "Nazwa Klienta: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dataWyst_dateTimePicker);
            this.groupBox2.Controls.Add(this.idDok_textBox);
            this.groupBox2.Controls.Add(this.addRecipt_button);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(14, 501);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(866, 114);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dodaj nowy paragon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(64, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID Dokumentu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(333, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data wystawienia:";
            // 
            // dataWyst_dateTimePicker
            // 
            this.dataWyst_dateTimePicker.Location = new System.Drawing.Point(338, 61);
            this.dataWyst_dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataWyst_dateTimePicker.Name = "dataWyst_dateTimePicker";
            this.dataWyst_dateTimePicker.Size = new System.Drawing.Size(315, 28);
            this.dataWyst_dateTimePicker.TabIndex = 4;
            // 
            // idDok_textBox
            // 
            this.idDok_textBox.Location = new System.Drawing.Point(69, 61);
            this.idDok_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idDok_textBox.Name = "idDok_textBox";
            this.idDok_textBox.Size = new System.Drawing.Size(181, 28);
            this.idDok_textBox.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.email_label);
            this.groupBox3.Controls.Add(this.nazwaKlienta_label);
            this.groupBox3.Controls.Add(this.idKlienta_label);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(20, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(860, 128);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacje o kliencie";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 684);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.Text = "Szczegóły klienta";
            ((System.ComponentModel.ISupportInitialize)(this.klienci_dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView klienci_dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addRecipt_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label idKlienta_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label nazwaKlienta_label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dataWyst_dateTimePicker;
        private System.Windows.Forms.TextBox idDok_textBox;
    }
}