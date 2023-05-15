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
            this.addButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.loadButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.searchTabPage.SuspendLayout();
            this.addTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(445, 210);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(96, 37);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // dataGridView1
            // 
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
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(280, 210);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(160, 37);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Załaduj do poglądu";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Klienci",
            "Produkty",
            "Paragony",
            "Zakupy"});
            this.comboBox1.Location = new System.Drawing.Point(100, 14);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextUpdate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(11, 356);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1173, 175);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wyświetlanie danych";
            // 
            // groupBox2
            // 
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
            this.tabControl1.Controls.Add(this.searchTabPage);
            this.tabControl1.Controls.Add(this.addTabPage);
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
            this.addTabPage.Controls.Add(this.comboBox1);
            this.addTabPage.Controls.Add(this.label6);
            this.addTabPage.Controls.Add(this.label7);
            this.addTabPage.Controls.Add(this.label5);
            this.addTabPage.Controls.Add(this.label1);
            this.addTabPage.Controls.Add(this.label4);
            this.addTabPage.Controls.Add(this.textBox3);
            this.addTabPage.Controls.Add(this.label3);
            this.addTabPage.Controls.Add(this.loadButton);
            this.addTabPage.Controls.Add(this.textBox5);
            this.addTabPage.Controls.Add(this.addButton);
            this.addTabPage.Controls.Add(this.textBox4);
            this.addTabPage.Controls.Add(this.label2);
            this.addTabPage.Controls.Add(this.textBox1);
            this.addTabPage.Controls.Add(this.textBox2);
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(108, 154);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 6;
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
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(108, 218);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(132, 22);
            this.textBox5.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(108, 186);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(132, 22);
            this.textBox4.TabIndex = 7;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 90);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 122);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 5;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
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
    }
}