namespace Projekt_bazodanowy
{
    partial class Form4
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
            this.paragony_dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addPurchase_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.idDokumentu_label = new System.Windows.Forms.Label();
            this.DataWystawienia_label = new System.Windows.Forms.Label();
            this.idKlienta_label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ilosc_textBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.kwotaCalkowita_label = new System.Windows.Forms.Label();
            this.produkty_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.paragony_dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // paragony_dataGridView
            // 
            this.paragony_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paragony_dataGridView.Location = new System.Drawing.Point(6, 21);
            this.paragony_dataGridView.Name = "paragony_dataGridView";
            this.paragony_dataGridView.RowHeadersWidth = 51;
            this.paragony_dataGridView.RowTemplate.Height = 24;
            this.paragony_dataGridView.Size = new System.Drawing.Size(764, 244);
            this.paragony_dataGridView.TabIndex = 0;
            this.paragony_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.paragony_dataGridView_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.paragony_dataGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 275);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zakupy z paragonu";
            // 
            // addPurchase_button
            // 
            this.addPurchase_button.Location = new System.Drawing.Point(624, 17);
            this.addPurchase_button.Name = "addPurchase_button";
            this.addPurchase_button.Size = new System.Drawing.Size(140, 62);
            this.addPurchase_button.TabIndex = 2;
            this.addPurchase_button.Text = "Dodaj zakup";
            this.addPurchase_button.UseVisualStyleBackColor = true;
            this.addPurchase_button.Click += new System.EventHandler(this.addRecipt_button_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(636, 498);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(140, 37);
            this.close_button.TabIndex = 3;
            this.close_button.Text = "Zamknij";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // idDokumentu_label
            // 
            this.idDokumentu_label.AutoSize = true;
            this.idDokumentu_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.idDokumentu_label.Location = new System.Drawing.Point(25, 27);
            this.idDokumentu_label.Name = "idDokumentu_label";
            this.idDokumentu_label.Size = new System.Drawing.Size(133, 22);
            this.idDokumentu_label.TabIndex = 4;
            this.idDokumentu_label.Text = "ID Dokumentu: ";
            // 
            // DataWystawienia_label
            // 
            this.DataWystawienia_label.AutoSize = true;
            this.DataWystawienia_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataWystawienia_label.Location = new System.Drawing.Point(334, 27);
            this.DataWystawienia_label.Name = "DataWystawienia_label";
            this.DataWystawienia_label.Size = new System.Drawing.Size(164, 22);
            this.DataWystawienia_label.TabIndex = 5;
            this.DataWystawienia_label.Text = "Data Wystawienia: ";
            // 
            // idKlienta_label
            // 
            this.idKlienta_label.AutoSize = true;
            this.idKlienta_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.idKlienta_label.Location = new System.Drawing.Point(25, 61);
            this.idKlienta_label.Name = "idKlienta_label";
            this.idKlienta_label.Size = new System.Drawing.Size(97, 22);
            this.idKlienta_label.TabIndex = 6;
            this.idKlienta_label.Text = "ID Klienta: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.produkty_comboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ilosc_textBox);
            this.groupBox2.Controls.Add(this.addPurchase_button);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(12, 401);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 91);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dodaj nowy zakup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(57, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ilość:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(317, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Produkt";
            // 
            // ilosc_textBox
            // 
            this.ilosc_textBox.Location = new System.Drawing.Point(61, 49);
            this.ilosc_textBox.Name = "ilosc_textBox";
            this.ilosc_textBox.Size = new System.Drawing.Size(161, 24);
            this.ilosc_textBox.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.kwotaCalkowita_label);
            this.groupBox3.Controls.Add(this.DataWystawienia_label);
            this.groupBox3.Controls.Add(this.idKlienta_label);
            this.groupBox3.Controls.Add(this.idDokumentu_label);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(18, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 102);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacje o paragonie";
            // 
            // kwotaCalkowita_label
            // 
            this.kwotaCalkowita_label.AutoSize = true;
            this.kwotaCalkowita_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kwotaCalkowita_label.Location = new System.Drawing.Point(334, 61);
            this.kwotaCalkowita_label.Name = "kwotaCalkowita_label";
            this.kwotaCalkowita_label.Size = new System.Drawing.Size(70, 22);
            this.kwotaCalkowita_label.TabIndex = 7;
            this.kwotaCalkowita_label.Text = "Kwota: ";
            // 
            // produkty_comboBox
            // 
            this.produkty_comboBox.FormattingEnabled = true;
            this.produkty_comboBox.Location = new System.Drawing.Point(321, 47);
            this.produkty_comboBox.Name = "produkty_comboBox";
            this.produkty_comboBox.Size = new System.Drawing.Size(163, 26);
            this.produkty_comboBox.TabIndex = 7;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form4";
            this.Text = "Szczegóły paragonu";
            ((System.ComponentModel.ISupportInitialize)(this.paragony_dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView paragony_dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addPurchase_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label idDokumentu_label;
        private System.Windows.Forms.Label DataWystawienia_label;
        private System.Windows.Forms.Label idKlienta_label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ilosc_textBox;
        private System.Windows.Forms.Label kwotaCalkowita_label;
        private System.Windows.Forms.ComboBox produkty_comboBox;
    }
}