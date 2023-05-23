namespace Projekt_bazodanowy
{
    partial class Form2
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
            this.add_Button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.load_Button = new System.Windows.Forms.Button();
            this.add_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.searchTabPage = new System.Windows.Forms.TabPage();
            this.search_button = new System.Windows.Forms.Button();
            this.idZakupu_textBox = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cenaZakupu_textBox = new System.Windows.Forms.TextBox();
            this.ilosc_textBox = new System.Windows.Forms.TextBox();
            this.dostepnosc_textBox = new System.Windows.Forms.TextBox();
            this.aktualnaCena_textBox = new System.Windows.Forms.TextBox();
            this.nazwaProduktu_textBox = new System.Windows.Forms.TextBox();
            this.idProduktu_textBox = new System.Windows.Forms.TextBox();
            this.kwotaCalkowita_textBox = new System.Windows.Forms.TextBox();
            this.dataZakupu_textBox = new System.Windows.Forms.TextBox();
            this.idDokumentu_textBox = new System.Windows.Forms.TextBox();
            this.email_textBox = new System.Windows.Forms.TextBox();
            this.nazwaFirmy_textBox = new System.Windows.Forms.TextBox();
            this.imieNazwisko_textBox = new System.Windows.Forms.TextBox();
            this.idKlienta_textBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.search_comboBox = new System.Windows.Forms.ComboBox();
            this.addTabPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.field3_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.field5_textBox = new System.Windows.Forms.TextBox();
            this.field4_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.field1_textBox = new System.Windows.Forms.TextBox();
            this.field2_textBox = new System.Windows.Forms.TextBox();
            this.reportPage = new System.Windows.Forms.TabPage();
            this.yearReport_checkBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.report_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.weekReport_checkBox = new System.Windows.Forms.CheckBox();
            this.monthReport_checkBox = new System.Windows.Forms.CheckBox();
            this.dayReport_checkBox = new System.Windows.Forms.CheckBox();
            this.report_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.searchTabPage.SuspendLayout();
            this.addTabPage.SuspendLayout();
            this.reportPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // add_Button
            // 
            this.add_Button.Location = new System.Drawing.Point(445, 210);
            this.add_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(96, 37);
            this.add_Button.TabIndex = 0;
            this.add_Button.Text = "Dodaj";
            this.add_Button.UseVisualStyleBackColor = true;
            this.add_Button.Click += new System.EventHandler(this.addButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 20);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1111, 151);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // load_Button
            // 
            this.load_Button.Location = new System.Drawing.Point(280, 210);
            this.load_Button.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.load_Button.Name = "load_Button";
            this.load_Button.Size = new System.Drawing.Size(160, 37);
            this.load_Button.TabIndex = 2;
            this.load_Button.Text = "Załaduj do poglądu";
            this.load_Button.UseVisualStyleBackColor = true;
            this.load_Button.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // add_comboBox
            // 
            this.add_comboBox.FormattingEnabled = true;
            this.add_comboBox.Items.AddRange(new object[] {
            "Klienci",
            "Produkty",
            "Paragony",
            "Zakupy"});
            this.add_comboBox.Location = new System.Drawing.Point(100, 14);
            this.add_comboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.add_comboBox.Name = "add_comboBox";
            this.add_comboBox.Size = new System.Drawing.Size(140, 24);
            this.add_comboBox.TabIndex = 3;
            this.add_comboBox.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            this.add_comboBox.TextChanged += new System.EventHandler(this.comboBox1_TextUpdate);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(11, 356);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1120, 175);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wyświetlanie danych";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(16, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1111, 343);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operacje";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.searchTabPage);
            this.tabControl1.Controls.Add(this.addTabPage);
            this.tabControl1.Controls.Add(this.reportPage);
            this.tabControl1.Location = new System.Drawing.Point(7, 22);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1097, 315);
            this.tabControl1.TabIndex = 14;
            // 
            // searchTabPage
            // 
            this.searchTabPage.Controls.Add(this.search_button);
            this.searchTabPage.Controls.Add(this.idZakupu_textBox);
            this.searchTabPage.Controls.Add(this.label32);
            this.searchTabPage.Controls.Add(this.label31);
            this.searchTabPage.Controls.Add(this.label30);
            this.searchTabPage.Controls.Add(this.label29);
            this.searchTabPage.Controls.Add(this.label28);
            this.searchTabPage.Controls.Add(this.label27);
            this.searchTabPage.Controls.Add(this.label26);
            this.searchTabPage.Controls.Add(this.label25);
            this.searchTabPage.Controls.Add(this.label24);
            this.searchTabPage.Controls.Add(this.label23);
            this.searchTabPage.Controls.Add(this.label22);
            this.searchTabPage.Controls.Add(this.label21);
            this.searchTabPage.Controls.Add(this.label20);
            this.searchTabPage.Controls.Add(this.label19);
            this.searchTabPage.Controls.Add(this.cenaZakupu_textBox);
            this.searchTabPage.Controls.Add(this.ilosc_textBox);
            this.searchTabPage.Controls.Add(this.dostepnosc_textBox);
            this.searchTabPage.Controls.Add(this.aktualnaCena_textBox);
            this.searchTabPage.Controls.Add(this.nazwaProduktu_textBox);
            this.searchTabPage.Controls.Add(this.idProduktu_textBox);
            this.searchTabPage.Controls.Add(this.kwotaCalkowita_textBox);
            this.searchTabPage.Controls.Add(this.dataZakupu_textBox);
            this.searchTabPage.Controls.Add(this.idDokumentu_textBox);
            this.searchTabPage.Controls.Add(this.email_textBox);
            this.searchTabPage.Controls.Add(this.nazwaFirmy_textBox);
            this.searchTabPage.Controls.Add(this.imieNazwisko_textBox);
            this.searchTabPage.Controls.Add(this.idKlienta_textBox);
            this.searchTabPage.Controls.Add(this.label18);
            this.searchTabPage.Controls.Add(this.search_comboBox);
            this.searchTabPage.Location = new System.Drawing.Point(4, 25);
            this.searchTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchTabPage.Name = "searchTabPage";
            this.searchTabPage.Size = new System.Drawing.Size(1089, 286);
            this.searchTabPage.TabIndex = 2;
            this.searchTabPage.Text = "Wyszukiwanie i usuwanie";
            this.searchTabPage.UseVisualStyleBackColor = true;
            // 
            // search_button
            // 
            this.search_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_button.Location = new System.Drawing.Point(377, 241);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(294, 32);
            this.search_button.TabIndex = 34;
            this.search_button.Text = "Szukaj";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // idZakupu_textBox
            // 
            this.idZakupu_textBox.Location = new System.Drawing.Point(133, 186);
            this.idZakupu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idZakupu_textBox.Name = "idZakupu_textBox";
            this.idZakupu_textBox.Size = new System.Drawing.Size(89, 22);
            this.idZakupu_textBox.TabIndex = 33;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(12, 188);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(68, 16);
            this.label32.TabIndex = 32;
            this.label32.Text = "ID Zakupu";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(810, 188);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(88, 16);
            this.label31.TabIndex = 31;
            this.label31.Text = "Cena zakupu:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(810, 147);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(138, 16);
            this.label30.TabIndex = 30;
            this.label30.Text = "Dostępność produktu:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(810, 111);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(108, 16);
            this.label29.TabIndex = 29;
            this.label29.Text = "Kwota całkowita:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(810, 71);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(44, 16);
            this.label28.TabIndex = 28;
            this.label28.Text = "Email:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(521, 191);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(129, 16);
            this.label27.TabIndex = 27;
            this.label27.Text = "Ilość pozycji zakupu:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(521, 148);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(150, 16);
            this.label26.TabIndex = 26;
            this.label26.Text = "Aktualna cena produktu:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(521, 72);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 16);
            this.label25.TabIndex = 25;
            this.label25.Text = "Nazwa firmy:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(265, 150);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(106, 16);
            this.label24.TabIndex = 24;
            this.label24.Text = "Nazwa produktu:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(265, 111);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(85, 16);
            this.label23.TabIndex = 23;
            this.label23.Text = "Data zakupu:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(265, 74);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 16);
            this.label22.TabIndex = 22;
            this.label22.Text = "Imie i nazwisko:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 147);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 16);
            this.label21.TabIndex = 21;
            this.label21.Text = "ID Produktu:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 111);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 16);
            this.label20.TabIndex = 20;
            this.label20.Text = "ID Dokumentu:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 16);
            this.label19.TabIndex = 19;
            this.label19.Text = "ID Klienta:";
            // 
            // cenaZakupu_textBox
            // 
            this.cenaZakupu_textBox.Location = new System.Drawing.Point(978, 186);
            this.cenaZakupu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cenaZakupu_textBox.Name = "cenaZakupu_textBox";
            this.cenaZakupu_textBox.Size = new System.Drawing.Size(89, 22);
            this.cenaZakupu_textBox.TabIndex = 18;
            // 
            // ilosc_textBox
            // 
            this.ilosc_textBox.Location = new System.Drawing.Point(693, 186);
            this.ilosc_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ilosc_textBox.Name = "ilosc_textBox";
            this.ilosc_textBox.Size = new System.Drawing.Size(89, 22);
            this.ilosc_textBox.TabIndex = 17;
            // 
            // dostepnosc_textBox
            // 
            this.dostepnosc_textBox.Location = new System.Drawing.Point(978, 145);
            this.dostepnosc_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dostepnosc_textBox.Name = "dostepnosc_textBox";
            this.dostepnosc_textBox.Size = new System.Drawing.Size(89, 22);
            this.dostepnosc_textBox.TabIndex = 13;
            // 
            // aktualnaCena_textBox
            // 
            this.aktualnaCena_textBox.Location = new System.Drawing.Point(693, 146);
            this.aktualnaCena_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aktualnaCena_textBox.Name = "aktualnaCena_textBox";
            this.aktualnaCena_textBox.Size = new System.Drawing.Size(89, 22);
            this.aktualnaCena_textBox.TabIndex = 12;
            // 
            // nazwaProduktu_textBox
            // 
            this.nazwaProduktu_textBox.Location = new System.Drawing.Point(396, 147);
            this.nazwaProduktu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nazwaProduktu_textBox.Name = "nazwaProduktu_textBox";
            this.nazwaProduktu_textBox.Size = new System.Drawing.Size(89, 22);
            this.nazwaProduktu_textBox.TabIndex = 11;
            // 
            // idProduktu_textBox
            // 
            this.idProduktu_textBox.Location = new System.Drawing.Point(133, 147);
            this.idProduktu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idProduktu_textBox.Name = "idProduktu_textBox";
            this.idProduktu_textBox.Size = new System.Drawing.Size(89, 22);
            this.idProduktu_textBox.TabIndex = 10;
            // 
            // kwotaCalkowita_textBox
            // 
            this.kwotaCalkowita_textBox.Location = new System.Drawing.Point(978, 106);
            this.kwotaCalkowita_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kwotaCalkowita_textBox.Name = "kwotaCalkowita_textBox";
            this.kwotaCalkowita_textBox.Size = new System.Drawing.Size(89, 22);
            this.kwotaCalkowita_textBox.TabIndex = 9;
            // 
            // dataZakupu_textBox
            // 
            this.dataZakupu_textBox.Location = new System.Drawing.Point(396, 109);
            this.dataZakupu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataZakupu_textBox.Name = "dataZakupu_textBox";
            this.dataZakupu_textBox.Size = new System.Drawing.Size(89, 22);
            this.dataZakupu_textBox.TabIndex = 7;
            // 
            // idDokumentu_textBox
            // 
            this.idDokumentu_textBox.Location = new System.Drawing.Point(133, 109);
            this.idDokumentu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idDokumentu_textBox.Name = "idDokumentu_textBox";
            this.idDokumentu_textBox.Size = new System.Drawing.Size(89, 22);
            this.idDokumentu_textBox.TabIndex = 6;
            // 
            // email_textBox
            // 
            this.email_textBox.Location = new System.Drawing.Point(978, 69);
            this.email_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.email_textBox.Name = "email_textBox";
            this.email_textBox.Size = new System.Drawing.Size(89, 22);
            this.email_textBox.TabIndex = 5;
            // 
            // nazwaFirmy_textBox
            // 
            this.nazwaFirmy_textBox.Location = new System.Drawing.Point(693, 70);
            this.nazwaFirmy_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nazwaFirmy_textBox.Name = "nazwaFirmy_textBox";
            this.nazwaFirmy_textBox.Size = new System.Drawing.Size(89, 22);
            this.nazwaFirmy_textBox.TabIndex = 4;
            // 
            // imieNazwisko_textBox
            // 
            this.imieNazwisko_textBox.Location = new System.Drawing.Point(396, 71);
            this.imieNazwisko_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imieNazwisko_textBox.Name = "imieNazwisko_textBox";
            this.imieNazwisko_textBox.Size = new System.Drawing.Size(89, 22);
            this.imieNazwisko_textBox.TabIndex = 3;
            // 
            // idKlienta_textBox
            // 
            this.idKlienta_textBox.Location = new System.Drawing.Point(133, 71);
            this.idKlienta_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idKlienta_textBox.Name = "idKlienta_textBox";
            this.idKlienta_textBox.Size = new System.Drawing.Size(89, 22);
            this.idKlienta_textBox.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(11, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 20);
            this.label18.TabIndex = 1;
            this.label18.Text = "Szukaj w:";
            // 
            // search_comboBox
            // 
            this.search_comboBox.FormattingEnabled = true;
            this.search_comboBox.Items.AddRange(new object[] {
            "Klienci",
            "Paragony",
            "Produkty",
            "Zakupy"});
            this.search_comboBox.Location = new System.Drawing.Point(102, 22);
            this.search_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search_comboBox.Name = "search_comboBox";
            this.search_comboBox.Size = new System.Drawing.Size(134, 24);
            this.search_comboBox.TabIndex = 0;
            this.search_comboBox.TextChanged += new System.EventHandler(this.search_comboBox_TextChanged);
            // 
            // addTabPage
            // 
            this.addTabPage.Controls.Add(this.add_comboBox);
            this.addTabPage.Controls.Add(this.label6);
            this.addTabPage.Controls.Add(this.label7);
            this.addTabPage.Controls.Add(this.label5);
            this.addTabPage.Controls.Add(this.label1);
            this.addTabPage.Controls.Add(this.label4);
            this.addTabPage.Controls.Add(this.field3_textBox);
            this.addTabPage.Controls.Add(this.label3);
            this.addTabPage.Controls.Add(this.load_Button);
            this.addTabPage.Controls.Add(this.field5_textBox);
            this.addTabPage.Controls.Add(this.add_Button);
            this.addTabPage.Controls.Add(this.field4_textBox);
            this.addTabPage.Controls.Add(this.label2);
            this.addTabPage.Controls.Add(this.field1_textBox);
            this.addTabPage.Controls.Add(this.field2_textBox);
            this.addTabPage.Location = new System.Drawing.Point(4, 25);
            this.addTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.addTabPage.Name = "addTabPage";
            this.addTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.addTabPage.Size = new System.Drawing.Size(1089, 286);
            this.addTabPage.TabIndex = 0;
            this.addTabPage.Text = "Dodawanie";
            this.addTabPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 222);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Pole 5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Pola w tabeli";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 190);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Pole 4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybór tabeli";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Pole 3";
            // 
            // field3_textBox
            // 
            this.field3_textBox.Location = new System.Drawing.Point(108, 154);
            this.field3_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.field3_textBox.Name = "field3_textBox";
            this.field3_textBox.Size = new System.Drawing.Size(132, 22);
            this.field3_textBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pole 2";
            // 
            // field5_textBox
            // 
            this.field5_textBox.Location = new System.Drawing.Point(108, 218);
            this.field5_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.field5_textBox.Name = "field5_textBox";
            this.field5_textBox.Size = new System.Drawing.Size(132, 22);
            this.field5_textBox.TabIndex = 8;
            // 
            // field4_textBox
            // 
            this.field4_textBox.Location = new System.Drawing.Point(108, 186);
            this.field4_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.field4_textBox.Name = "field4_textBox";
            this.field4_textBox.Size = new System.Drawing.Size(132, 22);
            this.field4_textBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pole 1";
            // 
            // field1_textBox
            // 
            this.field1_textBox.Location = new System.Drawing.Point(108, 90);
            this.field1_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.field1_textBox.Name = "field1_textBox";
            this.field1_textBox.Size = new System.Drawing.Size(132, 22);
            this.field1_textBox.TabIndex = 4;
            // 
            // field2_textBox
            // 
            this.field2_textBox.Location = new System.Drawing.Point(108, 122);
            this.field2_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.field2_textBox.Name = "field2_textBox";
            this.field2_textBox.Size = new System.Drawing.Size(132, 22);
            this.field2_textBox.TabIndex = 5;
            // 
            // reportPage
            // 
            this.reportPage.Controls.Add(this.yearReport_checkBox);
            this.reportPage.Controls.Add(this.label9);
            this.reportPage.Controls.Add(this.report_button);
            this.reportPage.Controls.Add(this.label8);
            this.reportPage.Controls.Add(this.weekReport_checkBox);
            this.reportPage.Controls.Add(this.monthReport_checkBox);
            this.reportPage.Controls.Add(this.dayReport_checkBox);
            this.reportPage.Controls.Add(this.report_dateTimePicker);
            this.reportPage.Location = new System.Drawing.Point(4, 25);
            this.reportPage.Name = "reportPage";
            this.reportPage.Size = new System.Drawing.Size(1089, 286);
            this.reportPage.TabIndex = 3;
            this.reportPage.Text = "Raporty";
            this.reportPage.UseVisualStyleBackColor = true;
            // 
            // yearReport_checkBox
            // 
            this.yearReport_checkBox.AutoSize = true;
            this.yearReport_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.yearReport_checkBox.Location = new System.Drawing.Point(438, 76);
            this.yearReport_checkBox.Name = "yearReport_checkBox";
            this.yearReport_checkBox.Size = new System.Drawing.Size(87, 24);
            this.yearReport_checkBox.TabIndex = 7;
            this.yearReport_checkBox.Text = "Roczny";
            this.yearReport_checkBox.UseVisualStyleBackColor = true;
            this.yearReport_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxesChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(14, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(291, 29);
            this.label9.TabIndex = 6;
            this.label9.Text = "Wybierz początkową date:";
            // 
            // report_button
            // 
            this.report_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.report_button.Location = new System.Drawing.Point(3, 244);
            this.report_button.Name = "report_button";
            this.report_button.Size = new System.Drawing.Size(1083, 39);
            this.report_button.TabIndex = 5;
            this.report_button.Text = "Generuj raport";
            this.report_button.UseVisualStyleBackColor = true;
            this.report_button.Click += new System.EventHandler(this.report_button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(14, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 29);
            this.label8.TabIndex = 4;
            this.label8.Text = "Wybierz typ raportu:";
            // 
            // weekReport_checkBox
            // 
            this.weekReport_checkBox.AutoSize = true;
            this.weekReport_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.weekReport_checkBox.Location = new System.Drawing.Point(144, 76);
            this.weekReport_checkBox.Name = "weekReport_checkBox";
            this.weekReport_checkBox.Size = new System.Drawing.Size(118, 24);
            this.weekReport_checkBox.TabIndex = 3;
            this.weekReport_checkBox.Text = "Tygodniowy";
            this.weekReport_checkBox.UseVisualStyleBackColor = true;
            this.weekReport_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxesChanged);
            // 
            // monthReport_checkBox
            // 
            this.monthReport_checkBox.AutoSize = true;
            this.monthReport_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monthReport_checkBox.Location = new System.Drawing.Point(298, 76);
            this.monthReport_checkBox.Name = "monthReport_checkBox";
            this.monthReport_checkBox.Size = new System.Drawing.Size(115, 24);
            this.monthReport_checkBox.TabIndex = 2;
            this.monthReport_checkBox.Text = "Miesięczny";
            this.monthReport_checkBox.UseVisualStyleBackColor = true;
            this.monthReport_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxesChanged);
            // 
            // dayReport_checkBox
            // 
            this.dayReport_checkBox.AutoSize = true;
            this.dayReport_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dayReport_checkBox.Location = new System.Drawing.Point(15, 76);
            this.dayReport_checkBox.Name = "dayReport_checkBox";
            this.dayReport_checkBox.Size = new System.Drawing.Size(86, 24);
            this.dayReport_checkBox.TabIndex = 1;
            this.dayReport_checkBox.Text = "Dniowy";
            this.dayReport_checkBox.UseVisualStyleBackColor = true;
            this.dayReport_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxesChanged);
            // 
            // report_dateTimePicker
            // 
            this.report_dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.report_dateTimePicker.Location = new System.Drawing.Point(19, 189);
            this.report_dateTimePicker.Name = "report_dateTimePicker";
            this.report_dateTimePicker.Size = new System.Drawing.Size(321, 28);
            this.report_dateTimePicker.TabIndex = 0;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.searchTabPage.ResumeLayout(false);
            this.searchTabPage.PerformLayout();
            this.addTabPage.ResumeLayout(false);
            this.addTabPage.PerformLayout();
            this.reportPage.ResumeLayout(false);
            this.reportPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button load_Button;
        private System.Windows.Forms.ComboBox add_comboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox field5_textBox;
        private System.Windows.Forms.TextBox field4_textBox;
        private System.Windows.Forms.TextBox field3_textBox;
        private System.Windows.Forms.TextBox field2_textBox;
        private System.Windows.Forms.TextBox field1_textBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage addTabPage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage searchTabPage;
        private System.Windows.Forms.TextBox idDokumentu_textBox;
        private System.Windows.Forms.TextBox email_textBox;
        private System.Windows.Forms.TextBox nazwaFirmy_textBox;
        private System.Windows.Forms.TextBox imieNazwisko_textBox;
        private System.Windows.Forms.TextBox idKlienta_textBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox search_comboBox;
        private System.Windows.Forms.TextBox dostepnosc_textBox;
        private System.Windows.Forms.TextBox aktualnaCena_textBox;
        private System.Windows.Forms.TextBox nazwaProduktu_textBox;
        private System.Windows.Forms.TextBox idProduktu_textBox;
        private System.Windows.Forms.TextBox kwotaCalkowita_textBox;
        private System.Windows.Forms.TextBox dataZakupu_textBox;
        private System.Windows.Forms.TextBox cenaZakupu_textBox;
        private System.Windows.Forms.TextBox ilosc_textBox;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox idZakupu_textBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TabPage reportPage;
        private System.Windows.Forms.DateTimePicker report_dateTimePicker;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button report_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox weekReport_checkBox;
        private System.Windows.Forms.CheckBox monthReport_checkBox;
        private System.Windows.Forms.CheckBox dayReport_checkBox;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.CheckBox yearReport_checkBox;
    }
}