using ProjekatPMK_MarkoMileski.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatPMK_MarkoMileski
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string konekcija = "Data Source=MILOS-PC\\SQLEXPRESS;Initial Catalog=ProjekatPMK;Integrated Security=True";
            List<Kategorija> categories = new List<Kategorija>();

            using (SqlConnection connection = new SqlConnection(konekcija))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Kategorija";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kategorija kategorija = new Kategorija();
                            kategorija.Id = reader.GetInt32(0);
                            kategorija.Name = reader.GetString(1);

                            categories.Add(kategorija);
                            Console.WriteLine(kategorija.Name);
                        }
                    }

                }
            }
            comboBox1.DataSource = categories;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            foreach (Kategorija kategorija in categories)
            {
               
                
                listBox1.Items.Add(kategorija.Id + " | " + kategorija.Name);
            }





        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            string kategorijaNaziv = textBox1.Text;
            string konekcija = "Data Source=MILOS-PC\\SQLEXPRESS;Initial Catalog=ProjekatPMK;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(konekcija))
                {
                    string query = "INSERT INTO Kategorija (Name) VALUES (@Name)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", kategorijaNaziv);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            MessageBox.Show("Kategorija uspešno dodata.");

                            LoadKategorija();
                        }
                        else
                        {
                            MessageBox.Show("Dodavanje kategorije nije uspelo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dodavanju kategorije: " + ex.Message);
            }
        }
        private void LoadKategorija()
        {
            string konekcija = "Data Source=MILOS-PC\\SQLEXPRESS;Initial Catalog=ProjekatPMK;Integrated Security=True";
            List<Kategorija> categories = new List<Kategorija>();

            using (SqlConnection connection = new SqlConnection(konekcija))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Kategorija";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kategorija kategorija = new Kategorija();
                            kategorija.Id = reader.GetInt32(0);
                            kategorija.Name = reader.GetString(1);

                            categories.Add(kategorija);
                            Console.WriteLine(kategorija.Name);
                        }
                    }

                }
            }
            listBox1.Items.Clear();
            comboBox1.Items.Clear();

            foreach (Kategorija kategorija in categories)
            {
                comboBox1.Items.Add(kategorija.Name);
                listBox1.Items.Add(kategorija.Id + " | " + kategorija.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string konekcija = "Data Source=MILOS-PC\\SQLEXPRESS;Initial Catalog=ProjekatPMK;Integrated Security=True";
            List<Kategorija> categories = new List<Kategorija>();

            using (SqlConnection connection = new SqlConnection(konekcija))
            {
                connection.Open();

                string sqlQuery = "DELETE FROM Kategorija WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", this.selectedId);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Uspjeli smo lol");
                    LoadKategorija();

                }
            }

        }

        private int selectedId;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selektovana_kategorija = listBox1.SelectedItem.ToString();

            int indeks = selektovana_kategorija.IndexOf("|") - 1;
            textBox1.Text = selektovana_kategorija.Substring(indeks + 3);

            int id = Convert.ToInt32(selektovana_kategorija.Substring(0, indeks));
            //textBox1.Text = id.ToString();
            this.selectedId = id;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string konekcija = "Data Source=MILOS-PC\\SQLEXPRESS;Initial Catalog=ProjekatPMK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(konekcija))
            {
                connection.Open();

                string sqlQuery = "UPDATE Kategorija SET Name = @NewName WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@NewName", textBox1.Text);
                    command.Parameters.AddWithValue("@Id", this.selectedId);

                    // Execute the SQL command
                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("Rows affected: " + rowsAffected);
                    LoadKategorija();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            // Get the selected category from the ComboBox
            Kategorija selectedCategory = comboBox1.SelectedItem as Kategorija;

            if (selectedCategory != null)
            {
                // Retrieve the selected category's ID
                int selectedCategoryId = selectedCategory.Id;
                 

                // Retrieve the items from the "Artikal" table based on the selected category
                string konekcija = "Data Source=MILOS-PC\\SQLEXPRESS;Initial Catalog=ProjekatPMK;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(konekcija))
                {
                    connection.Open();

                    //string sqlQuery = "SELECT * FROM Artikal WHERE Kategorija_Id = @CategoryId";
                    string sqlQuery = "SELECT a.*, j.Name AS JedinicaMereName " +
                 "FROM Artikal a " +
                 "JOIN Jedinica_Mere j ON a.Jedinica_Mere_Id = j.Id " +
                 "WHERE a.Kategorija_Id = @CategoryId";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryId", selectedCategoryId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create an instance of the Artikal class and populate its properties
                                Artikal item = new Artikal();
                                item.Id = reader.GetInt32(0); // Assuming ID is in the first column (index 0)
                                item.Name = reader.GetString(1); // Assuming Name is in the second column (index 1)
                                item.Price = reader.GetInt32(2); // Assuming Price is in the third column (index 2)
                                item.Kategorija_Id = reader.GetInt32(3); // Assuming KategorijaId is in the fourth column (index 3)
                                item.Jedinica_Mere_Id = reader.GetInt32(4); // Assuming Jedinica_Mere_Id is in the fifth column (index 4)
                                item.NazivJediniceMere = reader.GetString(5);

                                // Add the item to the ListBox
                               listBox2.Items.Add( item.Name+" "+item.Price+"/"+item.NazivJediniceMere );
                                
                            }
                        }
                    }
                }
            }
          
        }

        private void listBox2_selectedIndexChanged(object sender, EventArgs e)
        {
            string inputString = listBox2.SelectedItem.ToString();

            int firstSlashIndex = inputString.IndexOf('/');
           
            string measureUnit = inputString.Substring(firstSlashIndex + 1).Trim();

            int lastSpaceIndex = inputString.LastIndexOf(' ', firstSlashIndex);

            string price = inputString.Substring(lastSpaceIndex + 1, firstSlashIndex - lastSpaceIndex - 1).Trim();

            string name = inputString.Substring(0, lastSpaceIndex).Trim();

            textBox5.Text = name;
            textBox4.Text = price;
            textBox3.Text = measureUnit;
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
    }
}

