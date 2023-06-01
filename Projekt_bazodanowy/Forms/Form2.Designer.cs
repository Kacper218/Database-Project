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
            this.field5_label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.field4_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.field3_label = new System.Windows.Forms.Label();
            this.field3_textBox = new System.Windows.Forms.TextBox();
            this.field2_label = new System.Windows.Forms.Label();
            this.field5_textBox = new System.Windows.Forms.TextBox();
            this.field4_textBox = new System.Windows.Forms.TextBox();
            this.field1_label = new System.Windows.Forms.Label();
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
            this.add_Button.Location = new System.Drawing.Point(554, 262);
            this.add_Button.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(108, 46);
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
            this.dataGridView1.Location = new System.Drawing.Point(6, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1250, 189);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // load_Button
            // 
            this.load_Button.Location = new System.Drawing.Point(368, 262);
            this.load_Button.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.load_Button.Name = "load_Button";
            this.load_Button.Size = new System.Drawing.Size(180, 46);
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
            this.add_comboBox.Location = new System.Drawing.Point(166, 18);
            this.add_comboBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.add_comboBox.Name = "add_comboBox";
            this.add_comboBox.Size = new System.Drawing.Size(157, 28);
            this.add_comboBox.TabIndex = 3;
            this.add_comboBox.TextChanged += new System.EventHandler(this.add_comboBox_TextUpdate);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 445);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1260, 219);
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
            this.groupBox2.Location = new System.Drawing.Point(18, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1250, 429);
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
            this.tabControl1.Location = new System.Drawing.Point(8, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1234, 394);
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
            this.searchTabPage.Location = new System.Drawing.Point(4, 29);
            this.searchTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchTabPage.Name = "searchTabPage";
            this.searchTabPage.Size = new System.Drawing.Size(1226, 361);
            this.searchTabPage.TabIndex = 2;
            this.searchTabPage.Text = "Wyszukiwanie i usuwanie";
            this.searchTabPage.UseVisualStyleBackColor = true;
            // 
            // search_button
            // 
            this.search_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_button.Location = new System.Drawing.Point(424, 301);
            this.search_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(331, 40);
            this.search_button.TabIndex = 34;
            this.search_button.Text = "Szukaj";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // idZakupu_textBox
            // 
            this.idZakupu_textBox.Location = new System.Drawing.Point(150, 232);
            this.idZakupu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idZakupu_textBox.Name = "idZakupu_textBox";
            this.idZakupu_textBox.Size = new System.Drawing.Size(100, 26);
            this.idZakupu_textBox.TabIndex = 33;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(14, 235);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(84, 20);
            this.label32.TabIndex = 32;
            this.label32.Text = "ID Zakupu";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(911, 235);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(107, 20);
            this.label31.TabIndex = 31;
            this.label31.Text = "Cena zakupu:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(911, 184);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(166, 20);
            this.label30.TabIndex = 30;
            this.label30.Text = "Dostępność produktu:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(911, 139);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(127, 20);
            this.label29.TabIndex = 29;
            this.label29.Text = "Kwota całkowita:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(911, 89);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 20);
            this.label28.TabIndex = 28;
            this.label28.Text = "Email:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(586, 239);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(153, 20);
            this.label27.TabIndex = 27;
            this.label27.Text = "Ilość pozycji zakupu:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(586, 185);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(182, 20);
            this.label26.TabIndex = 26;
            this.label26.Text = "Aktualna cena produktu:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(586, 90);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(98, 20);
            this.label25.TabIndex = 25;
            this.label25.Text = "Nazwa firmy:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(298, 188);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(128, 20);
            this.label24.TabIndex = 24;
            this.label24.Text = "Nazwa produktu:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(298, 139);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 20);
            this.label23.TabIndex = 23;
            this.label23.Text = "Data zakupu:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(298, 92);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(119, 20);
            this.label22.TabIndex = 22;
            this.label22.Text = "Imie i nazwisko:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 184);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 20);
            this.label21.TabIndex = 21;
            this.label21.Text = "ID Produktu:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 139);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 20);
            this.label20.TabIndex = 20;
            this.label20.Text = "ID Dokumentu:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 95);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 20);
            this.label19.TabIndex = 19;
            this.label19.Text = "ID Klienta:";
            // 
            // cenaZakupu_textBox
            // 
            this.cenaZakupu_textBox.Location = new System.Drawing.Point(1100, 232);
            this.cenaZakupu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cenaZakupu_textBox.Name = "cenaZakupu_textBox";
            this.cenaZakupu_textBox.Size = new System.Drawing.Size(100, 26);
            this.cenaZakupu_textBox.TabIndex = 18;
            // 
            // ilosc_textBox
            // 
            this.ilosc_textBox.Location = new System.Drawing.Point(780, 232);
            this.ilosc_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ilosc_textBox.Name = "ilosc_textBox";
            this.ilosc_textBox.Size = new System.Drawing.Size(100, 26);
            this.ilosc_textBox.TabIndex = 17;
            // 
            // dostepnosc_textBox
            // 
            this.dostepnosc_textBox.Location = new System.Drawing.Point(1100, 181);
            this.dostepnosc_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dostepnosc_textBox.Name = "dostepnosc_textBox";
            this.dostepnosc_textBox.Size = new System.Drawing.Size(100, 26);
            this.dostepnosc_textBox.TabIndex = 13;
            // 
            // aktualnaCena_textBox
            // 
            this.aktualnaCena_textBox.Location = new System.Drawing.Point(780, 182);
            this.aktualnaCena_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aktualnaCena_textBox.Name = "aktualnaCena_textBox";
            this.aktualnaCena_textBox.Size = new System.Drawing.Size(100, 26);
            this.aktualnaCena_textBox.TabIndex = 12;
            // 
            // nazwaProduktu_textBox
            // 
            this.nazwaProduktu_textBox.Location = new System.Drawing.Point(446, 184);
            this.nazwaProduktu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nazwaProduktu_textBox.Name = "nazwaProduktu_textBox";
            this.nazwaProduktu_textBox.Size = new System.Drawing.Size(100, 26);
            this.nazwaProduktu_textBox.TabIndex = 11;
            // 
            // idProduktu_textBox
            // 
            this.idProduktu_textBox.Location = new System.Drawing.Point(150, 184);
            this.idProduktu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idProduktu_textBox.Name = "idProduktu_textBox";
            this.idProduktu_textBox.Size = new System.Drawing.Size(100, 26);
            this.idProduktu_textBox.TabIndex = 10;
            // 
            // kwotaCalkowita_textBox
            // 
            this.kwotaCalkowita_textBox.Location = new System.Drawing.Point(1100, 132);
            this.kwotaCalkowita_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kwotaCalkowita_textBox.Name = "kwotaCalkowita_textBox";
            this.kwotaCalkowita_textBox.Size = new System.Drawing.Size(100, 26);
            this.kwotaCalkowita_textBox.TabIndex = 9;
            // 
            // dataZakupu_textBox
            // 
            this.dataZakupu_textBox.Location = new System.Drawing.Point(446, 136);
            this.dataZakupu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataZakupu_textBox.Name = "dataZakupu_textBox";
            this.dataZakupu_textBox.Size = new System.Drawing.Size(100, 26);
            this.dataZakupu_textBox.TabIndex = 7;
            // 
            // idDokumentu_textBox
            // 
            this.idDokumentu_textBox.Location = new System.Drawing.Point(150, 136);
            this.idDokumentu_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idDokumentu_textBox.Name = "idDokumentu_textBox";
            this.idDokumentu_textBox.Size = new System.Drawing.Size(100, 26);
            this.idDokumentu_textBox.TabIndex = 6;
            // 
            // email_textBox
            // 
            this.email_textBox.Location = new System.Drawing.Point(1100, 86);
            this.email_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.email_textBox.Name = "email_textBox";
            this.email_textBox.Size = new System.Drawing.Size(100, 26);
            this.email_textBox.TabIndex = 5;
            // 
            // nazwaFirmy_textBox
            // 
            this.nazwaFirmy_textBox.Location = new System.Drawing.Point(780, 88);
            this.nazwaFirmy_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nazwaFirmy_textBox.Name = "nazwaFirmy_textBox";
            this.nazwaFirmy_textBox.Size = new System.Drawing.Size(100, 26);
            this.nazwaFirmy_textBox.TabIndex = 4;
            // 
            // imieNazwisko_textBox
            // 
            this.imieNazwisko_textBox.Location = new System.Drawing.Point(446, 89);
            this.imieNazwisko_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imieNazwisko_textBox.Name = "imieNazwisko_textBox";
            this.imieNazwisko_textBox.Size = new System.Drawing.Size(100, 26);
            this.imieNazwisko_textBox.TabIndex = 3;
            // 
            // idKlienta_textBox
            // 
            this.idKlienta_textBox.Location = new System.Drawing.Point(150, 89);
            this.idKlienta_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idKlienta_textBox.Name = "idKlienta_textBox";
            this.idKlienta_textBox.Size = new System.Drawing.Size(100, 26);
            this.idKlienta_textBox.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(12, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 25);
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
            this.search_comboBox.Location = new System.Drawing.Point(115, 28);
            this.search_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search_comboBox.Name = "search_comboBox";
            this.search_comboBox.Size = new System.Drawing.Size(150, 28);
            this.search_comboBox.TabIndex = 0;
            this.search_comboBox.TextChanged += new System.EventHandler(this.search_comboBox_TextChanged);
            // 
            // addTabPage
            // 
            this.addTabPage.Controls.Add(this.add_comboBox);
            this.addTabPage.Controls.Add(this.field5_label);
            this.addTabPage.Controls.Add(this.label7);
            this.addTabPage.Controls.Add(this.field4_label);
            this.addTabPage.Controls.Add(this.label1);
            this.addTabPage.Controls.Add(this.field3_label);
            this.addTabPage.Controls.Add(this.field3_textBox);
            this.addTabPage.Controls.Add(this.field2_label);
            this.addTabPage.Controls.Add(this.load_Button);
            this.addTabPage.Controls.Add(this.field5_textBox);
            this.addTabPage.Controls.Add(this.add_Button);
            this.addTabPage.Controls.Add(this.field4_textBox);
            this.addTabPage.Controls.Add(this.field1_label);
            this.addTabPage.Controls.Add(this.field1_textBox);
            this.addTabPage.Controls.Add(this.field2_textBox);
            this.addTabPage.Location = new System.Drawing.Point(4, 29);
            this.addTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addTabPage.Name = "addTabPage";
            this.addTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addTabPage.Size = new System.Drawing.Size(1226, 361);
            this.addTabPage.TabIndex = 0;
            this.addTabPage.Text = "Dodawanie";
            this.addTabPage.UseVisualStyleBackColor = true;
            // 
            // field5_label
            // 
            this.field5_label.AutoSize = true;
            this.field5_label.Location = new System.Drawing.Point(28, 278);
            this.field5_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.field5_label.Name = "field5_label";
            this.field5_label.Size = new System.Drawing.Size(53, 20);
            this.field5_label.TabIndex = 12;
            this.field5_label.Text = "Pole 5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Pola w tabeli";
            // 
            // field4_label
            // 
            this.field4_label.AutoSize = true;
            this.field4_label.Location = new System.Drawing.Point(28, 238);
            this.field4_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.field4_label.Name = "field4_label";
            this.field4_label.Size = new System.Drawing.Size(53, 20);
            this.field4_label.TabIndex = 11;
            this.field4_label.Text = "Pole 4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybór tabeli";
            // 
            // field3_label
            // 
            this.field3_label.AutoSize = true;
            this.field3_label.Location = new System.Drawing.Point(28, 198);
            this.field3_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.field3_label.Name = "field3_label";
            this.field3_label.Size = new System.Drawing.Size(53, 20);
            this.field3_label.TabIndex = 10;
            this.field3_label.Text = "Pole 3";
            // 
            // field3_textBox
            // 
            this.field3_textBox.Location = new System.Drawing.Point(175, 192);
            this.field3_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.field3_textBox.Name = "field3_textBox";
            this.field3_textBox.Size = new System.Drawing.Size(148, 26);
            this.field3_textBox.TabIndex = 6;
            // 
            // field2_label
            // 
            this.field2_label.AutoSize = true;
            this.field2_label.Location = new System.Drawing.Point(28, 158);
            this.field2_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.field2_label.Name = "field2_label";
            this.field2_label.Size = new System.Drawing.Size(53, 20);
            this.field2_label.TabIndex = 9;
            this.field2_label.Text = "Pole 2";
            // 
            // field5_textBox
            // 
            this.field5_textBox.Location = new System.Drawing.Point(175, 272);
            this.field5_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.field5_textBox.Name = "field5_textBox";
            this.field5_textBox.Size = new System.Drawing.Size(148, 26);
            this.field5_textBox.TabIndex = 8;
            // 
            // field4_textBox
            // 
            this.field4_textBox.Location = new System.Drawing.Point(175, 232);
            this.field4_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.field4_textBox.Name = "field4_textBox";
            this.field4_textBox.Size = new System.Drawing.Size(148, 26);
            this.field4_textBox.TabIndex = 7;
            // 
            // field1_label
            // 
            this.field1_label.AutoSize = true;
            this.field1_label.Location = new System.Drawing.Point(28, 118);
            this.field1_label.Name = "field1_label";
            this.field1_label.Size = new System.Drawing.Size(53, 20);
            this.field1_label.TabIndex = 1;
            this.field1_label.Text = "Pole 1";
            // 
            // field1_textBox
            // 
            this.field1_textBox.Location = new System.Drawing.Point(175, 112);
            this.field1_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.field1_textBox.Name = "field1_textBox";
            this.field1_textBox.Size = new System.Drawing.Size(148, 26);
            this.field1_textBox.TabIndex = 4;
            // 
            // field2_textBox
            // 
            this.field2_textBox.Location = new System.Drawing.Point(175, 152);
            this.field2_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.field2_textBox.Name = "field2_textBox";
            this.field2_textBox.Size = new System.Drawing.Size(148, 26);
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
            this.reportPage.Location = new System.Drawing.Point(4, 29);
            this.reportPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportPage.Name = "reportPage";
            this.reportPage.Size = new System.Drawing.Size(1226, 361);
            this.reportPage.TabIndex = 3;
            this.reportPage.Text = "Raporty";
            this.reportPage.UseVisualStyleBackColor = true;
            // 
            // yearReport_checkBox
            // 
            this.yearReport_checkBox.AutoSize = true;
            this.yearReport_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.yearReport_checkBox.Location = new System.Drawing.Point(493, 95);
            this.yearReport_checkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.yearReport_checkBox.Name = "yearReport_checkBox";
            this.yearReport_checkBox.Size = new System.Drawing.Size(110, 29);
            this.yearReport_checkBox.TabIndex = 7;
            this.yearReport_checkBox.Text = "Roczny";
            this.yearReport_checkBox.UseVisualStyleBackColor = true;
            this.yearReport_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxesChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(16, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(344, 32);
            this.label9.TabIndex = 6;
            this.label9.Text = "Wybierz początkową date:";
            // 
            // report_button
            // 
            this.report_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.report_button.Location = new System.Drawing.Point(3, 305);
            this.report_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.report_button.Name = "report_button";
            this.report_button.Size = new System.Drawing.Size(1218, 49);
            this.report_button.TabIndex = 5;
            this.report_button.Text = "Generuj raport";
            this.report_button.UseVisualStyleBackColor = true;
            this.report_button.Click += new System.EventHandler(this.report_button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(16, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(266, 32);
            this.label8.TabIndex = 4;
            this.label8.Text = "Wybierz typ raportu:";
            // 
            // weekReport_checkBox
            // 
            this.weekReport_checkBox.AutoSize = true;
            this.weekReport_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.weekReport_checkBox.Location = new System.Drawing.Point(162, 95);
            this.weekReport_checkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.weekReport_checkBox.Name = "weekReport_checkBox";
            this.weekReport_checkBox.Size = new System.Drawing.Size(153, 29);
            this.weekReport_checkBox.TabIndex = 3;
            this.weekReport_checkBox.Text = "Tygodniowy";
            this.weekReport_checkBox.UseVisualStyleBackColor = true;
            this.weekReport_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxesChanged);
            // 
            // monthReport_checkBox
            // 
            this.monthReport_checkBox.AutoSize = true;
            this.monthReport_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monthReport_checkBox.Location = new System.Drawing.Point(335, 95);
            this.monthReport_checkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.monthReport_checkBox.Name = "monthReport_checkBox";
            this.monthReport_checkBox.Size = new System.Drawing.Size(146, 29);
            this.monthReport_checkBox.TabIndex = 2;
            this.monthReport_checkBox.Text = "Miesięczny";
            this.monthReport_checkBox.UseVisualStyleBackColor = true;
            this.monthReport_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxesChanged);
            // 
            // dayReport_checkBox
            // 
            this.dayReport_checkBox.AutoSize = true;
            this.dayReport_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dayReport_checkBox.Location = new System.Drawing.Point(17, 95);
            this.dayReport_checkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dayReport_checkBox.Name = "dayReport_checkBox";
            this.dayReport_checkBox.Size = new System.Drawing.Size(108, 29);
            this.dayReport_checkBox.TabIndex = 1;
            this.dayReport_checkBox.Text = "Dniowy";
            this.dayReport_checkBox.UseVisualStyleBackColor = true;
            this.dayReport_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxesChanged);
            // 
            // report_dateTimePicker
            // 
            this.report_dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.report_dateTimePicker.Location = new System.Drawing.Point(21, 236);
            this.report_dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.report_dateTimePicker.Name = "report_dateTimePicker";
            this.report_dateTimePicker.Size = new System.Drawing.Size(361, 32);
            this.report_dateTimePicker.TabIndex = 0;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 675);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
        private System.Windows.Forms.Label field1_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label field5_label;
        private System.Windows.Forms.Label field4_label;
        private System.Windows.Forms.Label field3_label;
        private System.Windows.Forms.Label field2_label;
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