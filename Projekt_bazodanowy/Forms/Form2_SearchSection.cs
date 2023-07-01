using NHibernate;
using Projekt_bazodanowy.DataRepository;
using Projekt_bazodanowy.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Projekt_bazodanowy
{
    public partial class Form2 : Form
    {
        // Reset all search text boxes and disable the,
        private void resetSearchTextBoxes()
        {
            // Clear the text in all search text boxes
            idKlienta_textBox.Clear();
            imieNazwisko_textBox.Clear();
            nazwaFirmy_textBox.Clear();
            email_textBox.Clear();
            idKlienta_textBox.Clear();
            idDokumentu_textBox.Clear();
            dataZakupu_textBox.Clear();
            kwotaCalkowita_textBox.Clear();
            idProduktu_textBox.Clear();
            nazwaProduktu_textBox.Clear();
            aktualnaCena_textBox.Clear();
            dostepnosc_textBox.Clear();
            idDokumentu_textBox.Clear();
            idProduktu_textBox.Clear();
            idZakupu_textBox.Clear();
            ilosc_textBox.Clear();
            cenaZakupu_textBox.Clear();

            // Disable all search text boxes
            idKlienta_textBox.Enabled = false;
            imieNazwisko_textBox.Enabled = false;
            nazwaFirmy_textBox.Enabled = false;
            email_textBox.Enabled = false;
            idDokumentu_textBox.Enabled = false;
            dataZakupu_textBox.Enabled = false;
            kwotaCalkowita_textBox.Enabled = false;
            idProduktu_textBox.Enabled = false;
            nazwaProduktu_textBox.Enabled = false;
            aktualnaCena_textBox.Enabled = false;
            dostepnosc_textBox.Enabled = false;
            idDokumentu_textBox.Enabled = false;
            idProduktu_textBox.Enabled = false;
            idZakupu_textBox.Enabled = false;
            ilosc_textBox.Enabled = false;
            cenaZakupu_textBox.Enabled = false;
        }
        // Handle the event when the search combo boc text changes
        private void search_comboBox_TextChanged(object sender, EventArgs e)
        {
            // Reset all search text boxes and enable the relevant ones based od the selected search option
            switch (search_comboBox.Text.ToString())
            {
                case "Klienci":
                    resetSearchTextBoxes();
                    idKlienta_textBox.Enabled = true;
                    imieNazwisko_textBox.Enabled = true;
                    nazwaFirmy_textBox.Enabled = true;
                    email_textBox.Enabled = true;
                    break;
                case "Paragony":
                    resetSearchTextBoxes();
                    idKlienta_textBox.Enabled = true;
                    idDokumentu_textBox.Enabled = true;
                    dataZakupu_textBox.Enabled = true;
                    kwotaCalkowita_textBox.Enabled = true;
                    break;
                case "Produkty":
                    resetSearchTextBoxes();
                    idProduktu_textBox.Enabled = true;
                    nazwaProduktu_textBox.Enabled = true;
                    aktualnaCena_textBox.Enabled = true;
                    dostepnosc_textBox.Enabled = true;
                    break;
                case "Zakupy":
                    resetSearchTextBoxes();
                    idDokumentu_textBox.Enabled = true;
                    idProduktu_textBox.Enabled = true;
                    idZakupu_textBox.Enabled = true;
                    ilosc_textBox.Enabled = true;
                    cenaZakupu_textBox.Enabled = true;
                    break;
            }
        }

        // Handle the event when a cell is clicked in the data grid view, used to handle deleting a row funtionality
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open a session for database operations
            ISession session = sessionFactor.OpenSession();
            try
            {
                switch (search_comboBox.Text.ToString())
                {
                    case "Klienci":
                        // Check if the delete button column is clicked
                        if (e.ColumnIndex == 5)
                        {
                            using (session)
                            {
                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                                string rowIdentifier = row.Cells["IDKlienta"].Value.ToString();

                                Klienci rowToDelete = session.Get<Klienci>(rowIdentifier);

                                // Check if the primary key is referenced in another table
                                bool isReferenced = session.QueryOver<Paragony>()
                                    .Where(re => re.IDKlienta == rowIdentifier)
                                    .RowCount() > 0;

                                if (isReferenced)
                                {
                                    throw new Exception("Nie można usunąć wiersza używanego przez inne tabele.");
                                }

                                if (rowToDelete != null)
                                {
                                    using (var transaction = session.BeginTransaction())
                                    {
                                        session.Delete(rowToDelete);
                                        transaction.Commit();
                                    }
                                }

                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                            }
                            // Check if the details button column is clicked
                        }
                        else if (e.ColumnIndex == 4)
                        {
                            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                            string rowIdentifier = row.Cells["IDKlienta"].Value.ToString();

                            // Create an instance of Form3 and show it
                            Form3 form3 = new Form3(sessionFactor, rowIdentifier);
                            form3.Show();
                            form3.BringToFront();
                        }
                        break;
                    case "Paragony":
                        // Check if the delete button column is clicked
                        if (e.ColumnIndex == 5)
                        {
                            using (session)
                            {
                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                                string rowIdentifier = row.Cells["IDDokumentu"].Value.ToString();

                                Paragony rowToDelete = session.Get<Paragony>(rowIdentifier);

                                // Check if the primary key is referenced in another table
                                bool isReferenced = session.QueryOver<Zakupy>()
                                    .Where(re => re.IDDokumentu == rowIdentifier)
                                    .RowCount() > 0;

                                if (isReferenced)
                                {
                                    throw new Exception("Nie można usunąć wiersza używanego przez inne tabele.");
                                }

                                if (rowToDelete != null)
                                {
                                    using (var transaction = session.BeginTransaction())
                                    {
                                        session.Delete(rowToDelete);
                                        transaction.Commit();
                                    }
                                }

                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                            }
                            // Check if the details button column is clicked
                        }
                        else if (e.ColumnIndex == 4)
                        {
                            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                            string rowIdentifier = row.Cells["IDDokumentu"].Value.ToString();

                            // Create an instance of Form4 and show it
                            Form4 form4 = new Form4(sessionFactor, rowIdentifier);
                            form4.Show();
                            form4.BringToFront();
                        }
                        break;
                    case "Produkty":
                        // Check if the delete button column is clicked
                        if (e.ColumnIndex == 4)
                        {
                            using (session)
                            {
                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                                string rowIdentifier = row.Cells["IDProduktu"].Value.ToString();

                                Produkty rowToDelete = session.Get<Produkty>(rowIdentifier);

                                // Check if the primary key is referenced in another table
                                bool isReferenced = session.QueryOver<Zakupy>()
                                    .Where(re => re.IDProduktu == rowIdentifier)
                                    .RowCount() > 0;

                                if (isReferenced)
                                {
                                    throw new Exception("Nie można usunąć wiersza używanego przez inne tabele.");
                                }

                                if (rowToDelete != null)
                                {
                                    using (var transaction = session.BeginTransaction())
                                    {
                                        session.Delete(rowToDelete);
                                        transaction.Commit();
                                    }
                                }

                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                        break;
                    case "Zakupy":
                        // Check if the delete button column is clicked
                        if (e.ColumnIndex == 5)
                        {
                            using (session)
                            {
                                session.BeginTransaction();

                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                                string rowIdentifier = row.Cells["IDZakupu"].Value.ToString();

                                // Create a delete query using HQL or SQL
                                string deleteQuery = "DELETE FROM Zakupy WHERE IDZakupu = :id";
                                var query = session.CreateQuery(deleteQuery);
                                query.SetParameter("id", rowIdentifier);

                                // Execute the delete query
                                int deletedCount = query.ExecuteUpdate();

                                if (deletedCount > 0)
                                {
                                    // Commit the transaction
                                    session.Transaction.Commit();
                                }
                                else
                                {
                                    // Rollback the transaction
                                    session.Transaction.Rollback();

                                    throw new Exception("Wystapil problem podczas usuwania pozycji");
                                }

                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Adds a delete button column to the DataGridView
        private void deleteRowButtonAdd()
        {
            DataGridViewButtonColumn delButton = new DataGridViewButtonColumn();
            delButton.HeaderText = "Usuń";
            delButton.Text = "-";
            delButton.Name = "delButton";
            delButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delButton);
        }

        // Adds a details button column to the DataGridView
        private void detailsRowButtonAdd()
        {
            DataGridViewButtonColumn detailsButton = new DataGridViewButtonColumn();
            detailsButton.HeaderText = "Szczegóły";
            detailsButton.Name = "detailsButton";
            detailsButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(detailsButton);
        }
        private void search_button_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear(); // Clears existing columns in the DataGridView
            dataGridView1.DataSource = null; // Clears the data source of the DataGridView
            try
            {
                switch (search_comboBox.Text.ToString())
                {
                    case "Klienci":

                        string clientsToSearch = "SEARCH;Clients;";
                        if (!string.IsNullOrEmpty(idKlienta_textBox.Text))
                        {
                            clientsToSearch += idKlienta_textBox.Text + ";";
                        }
                        else
                        {
                            clientsToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                        {
                            if (!string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                            {
                                throw new Exception("Wpisano za dużo parametrów! (Imie Nazwisko oraz Nazwa Firmy)");
                            }
                        }

                        if (!string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                        {
                            if (string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                            {
                                clientsToSearch += nazwaFirmy_textBox.Text + ";";
                            }
                        }
                        else
                        {
                            clientsToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                        {
                            if (string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                            {
                                clientsToSearch += imieNazwisko_textBox.Text + ";";
                            }
                        }
                        else
                        {
                            clientsToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(email_textBox.Text))
                        {
                            clientsToSearch += email_textBox.Text + ";";
                        }
                        else
                        {
                            clientsToSearch += "-" + ";";
                        }
                        connection.WriteLineAndGetReply(clientsToSearch, TimeSpan.FromSeconds(2));
                        IList<Klienci> clientsInfo = ClientsJsonDataRepository.DataList;
                        dataGridView1.DataSource = clientsInfo;
                        dataGridView1.AllowUserToAddRows = false;
                        detailsRowButtonAdd();
                        break;

                    case "Paragony":
                        string receiptToSearch = "SEARCH;Receipts;";
                        if (!string.IsNullOrEmpty(idDokumentu_textBox.Text))
                        {
                            receiptToSearch += idDokumentu_textBox.Text + ";";
                        }
                        else
                        {
                            receiptToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(dataZakupu_textBox.Text))
                        {
                            receiptToSearch += dataZakupu_textBox.Text + ";";
                        }
                        else
                        {
                            receiptToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(idKlienta_textBox.Text))
                        {
                            receiptToSearch += idKlienta_textBox.Text + ";";
                        }
                        else
                        {
                            receiptToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(kwotaCalkowita_textBox.Text))
                        {
                            receiptToSearch += kwotaCalkowita_textBox.Text + ";";
                        }
                        else
                        {
                            receiptToSearch += "-" + ";";
                        }

                        connection.WriteLineAndGetReply(receiptToSearch, TimeSpan.FromSeconds(2));
                        IList<Paragony> receiptInfo = ReceiptsJsonDataRepository.DataList;
                        dataGridView1.DataSource = receiptInfo;
                        dataGridView1.AllowUserToAddRows = false;
                        detailsRowButtonAdd();
                        break;

                    case "Produkty":
                        string productsToSearch = "SEARCH;Products;";
                        if (!string.IsNullOrEmpty(idProduktu_textBox.Text))
                        {
                            productsToSearch += idProduktu_textBox.Text + ";";
                        }
                        else
                        {
                            productsToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(nazwaProduktu_textBox.Text))
                        {
                            productsToSearch += nazwaProduktu_textBox.Text + ";";
                        }
                        else
                        {
                            productsToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(aktualnaCena_textBox.Text))
                        {
                            productsToSearch += aktualnaCena_textBox.Text + ";";
                        }
                        else
                        {
                            productsToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(dostepnosc_textBox.Text))
                        {
                            productsToSearch += dostepnosc_textBox.Text + ";";
                        }
                        else
                        {
                            productsToSearch += "-" + ";";
                        }

                        connection.WriteLineAndGetReply(productsToSearch, TimeSpan.FromSeconds(2));
                        IList<Produkty> productsInfo = ProductsJsonDataRepository.DataList;
                        dataGridView1.DataSource = productsInfo;
                        dataGridView1.AllowUserToAddRows = false;
                        break;

                    case "Zakupy":
                        string purchasesToSearch = "SEARCH;Purchase;";
                        if (!string.IsNullOrEmpty(idZakupu_textBox.Text))
                        {
                            purchasesToSearch += idZakupu_textBox.Text + ";";
                        }
                        else
                        {
                            purchasesToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(idDokumentu_textBox.Text))
                        {
                            purchasesToSearch += idDokumentu_textBox.Text + ";";
                        }
                        else
                        {
                            purchasesToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(idProduktu_textBox.Text))
                        {
                            purchasesToSearch += idProduktu_textBox.Text + ";";
                        }
                        else
                        {
                            purchasesToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(ilosc_textBox.Text))
                        {
                            purchasesToSearch += ilosc_textBox.Text + ";";
                        }
                        else
                        {
                            purchasesToSearch += "-" + ";";
                        }

                        if (!string.IsNullOrEmpty(cenaZakupu_textBox.Text))
                        {
                            purchasesToSearch += cenaZakupu_textBox.Text + ";";
                        }
                        else
                        {
                            purchasesToSearch += "-" + ";";
                        }

                        connection.WriteLineAndGetReply(purchasesToSearch, TimeSpan.FromSeconds(2));
                        IList<Zakupy> purchaseInfo = PurchaseJsonDataRepository.DataList;
                        dataGridView1.DataSource = purchaseInfo;
                        dataGridView1.AllowUserToAddRows = false;
                        break;
                        /*
                        using (session)
                        {
                            var query = session.QueryOver<Klienci>();
                            // Perform search based on provided criteria
                            if (!string.IsNullOrEmpty(idKlienta_textBox.Text))
                            {
                                query = query.Where(c => c.IDKlienta == idKlienta_textBox.Text);
                            }

                            if (!string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                            {
                                if (string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                                {
                                    query = query.WhereRestrictionOn(c => c.NazwaFirmy).IsInsensitiveLike("%" + nazwaFirmy_textBox.Text + "%");
                                }
                            }

                            if (!string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                            {
                                if (string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                                {
                                    query = query.WhereRestrictionOn(c => c.ImieNazwisko).IsInsensitiveLike("%" + imieNazwisko_textBox.Text + "%");
                                }
                            }

                            if (!string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                            {
                                if (!string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                                {
                                    throw new Exception("Wpisano za dużo parametrów! (Imie Nazwisko oraz Nazwa Firmy)");
                                }
                            }

                            if (!string.IsNullOrEmpty(email_textBox.Text))
                            {
                                query = query.WhereRestrictionOn(c => c.Email).IsInsensitiveLike("%" + email_textBox.Text + "%");
                            }
                            var result = query.List();
                            var bindingList = new BindingList<Klienci>(result);
                            dataGridView1.DataSource = bindingList;
                            dataGridView1.AllowUserToAddRows = false;
                        }
                        detailsRowButtonAdd();
                        break;
                        */
                        /*
                        case "Paragony":
                            using (session)
                            {
                                var query = session.QueryOver<Paragony>();
                                // Perform search based on provided criteria
                                if (!(string.IsNullOrEmpty(idDokumentu_textBox.Text)) ||
                                    !(string.IsNullOrEmpty(dataZakupu_textBox.Text)) ||
                                    !(string.IsNullOrEmpty(idKlienta_textBox.Text)) ||
                                    !(string.IsNullOrEmpty(kwotaCalkowita_textBox.Text)))
                                {
                                    if (!string.IsNullOrEmpty(idDokumentu_textBox.Text))
                                    {
                                        query = query.Where(c => c.IDDokumentu == idDokumentu_textBox.Text);
                                    }
                                    if (!string.IsNullOrEmpty(dataZakupu_textBox.Text))
                                    {
                                        DateTime dataZakupu;
                                        if (DateTime.TryParse(dataZakupu_textBox.Text, out dataZakupu))
                                        {
                                            query = query.Where(c => c.DataZakupu == dataZakupu);
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(idKlienta_textBox.Text))
                                    {
                                        query = query.Where(c => c.IDKlienta == idKlienta_textBox.Text);
                                    }
                                    if (!string.IsNullOrEmpty(kwotaCalkowita_textBox.Text))
                                    {
                                        query = query.Where(c => c.KwotaCalkowita == kwotaCalkowita_textBox.Text);
                                    }
                                }
                                var result = query.List();
                                var bindingList = new BindingList<Paragony>(result);
                                dataGridView1.DataSource = bindingList;
                                dataGridView1.AllowUserToAddRows = false;
                                detailsRowButtonAdd();
                            }
                            break;
                        case "Produkty":
                            using (session)
                            {
                                var query = session.QueryOver<Produkty>();
                                // Perform search based on provided criteria
                                if (!string.IsNullOrEmpty(idProduktu_textBox.Text))
                                {
                                    query = query.Where(c => c.IDProduktu == idProduktu_textBox.Text);
                                }
                                if (!string.IsNullOrEmpty(nazwaProduktu_textBox.Text))
                                {
                                    query = query.WhereRestrictionOn(c => c.Nazwa).IsInsensitiveLike("%" + nazwaProduktu_textBox.Text + "%");
                                }
                                if (!string.IsNullOrEmpty(aktualnaCena_textBox.Text))
                                {
                                    query = query.Where(c => c.CenaAktualna == aktualnaCena_textBox.Text);
                                }
                                if (!string.IsNullOrEmpty(dostepnosc_textBox.Text))
                                {
                                    query = query.WhereRestrictionOn(c => c.Dostepnosc).IsInsensitiveLike("%" + dostepnosc_textBox.Text + "%");
                                }
                                var result = query.List();
                                var bindingList = new BindingList<Produkty>(result);
                                dataGridView1.DataSource = bindingList;
                                dataGridView1.AllowUserToAddRows = false;
                            }
                            break;
                        case "Zakupy":
                            using (session)
                            {
                                var query = session.QueryOver<Zakupy>();
                                // Perform search based on provided criteria

                                if (!string.IsNullOrEmpty(idZakupu_textBox.Text))
                                {
                                    query = query.Where(c => c.IDZakupu == idZakupu_textBox.Text);
                                }

                                if (!string.IsNullOrEmpty(idDokumentu_textBox.Text))
                                {
                                    query = query.Where(c => c.IDDokumentu == idDokumentu_textBox.Text);
                                }

                                if (!string.IsNullOrEmpty(idProduktu_textBox.Text))
                                {
                                    query = query.Where(c => c.IDProduktu == idProduktu_textBox.Text);
                                }

                                if (!string.IsNullOrEmpty(ilosc_textBox.Text))
                                {
                                    query = query.Where(c => c.Ilosc == ilosc_textBox.Text);
                                }

                                if (!string.IsNullOrEmpty(cenaZakupu_textBox.Text))
                                {
                                    query = query.Where(c => c.CenaZakupu == cenaZakupu_textBox.Text);
                                }
                                var result = query.List();
                                var bindingList = new BindingList<Zakupy>(result);
                                dataGridView1.DataSource = bindingList;
                                dataGridView1.AllowUserToAddRows = false;
                            }
                            break;
                        */
                }
                deleteRowButtonAdd();  // Adds the delete button column to the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
