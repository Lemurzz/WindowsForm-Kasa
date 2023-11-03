using ProjekatPMK_MarkoMileski.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatPMK_MarkoMileski
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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

            foreach (Kategorija category in categories)
            {
                Button button = new Button();
                button.Text = category.Name;
                button.Tag = category.Id;
                //button.Padding = new Padding(20);
                button.AutoSize = true;
                button.MaximumSize = new Size(150, button.Height);
                button.Click += CategoryButtonClick;
                flowLayoutPanel1.Controls.Add(button);
            }

            void CategoryButtonClick(object sender, EventArgs e)
            {
                Button clickedButton = (Button)sender;
                int selectedCategory = (int)clickedButton.Tag;
                flowLayoutPanel2.Controls.Clear();

                // Step 7: Retrieve products for the selected category from the database
                List<Artikal> artikli = new List<Artikal>();
                using (SqlConnection connection = new SqlConnection(konekcija))
                {
                    connection.Open();

                    string sqlQuery = "SELECT * FROM Artikal WHERE Kategorija_Id = @kategorija_id";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@kategorija_id", (int)clickedButton.Tag);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Artikal artikal = new Artikal();
                                artikal.Id = reader.GetInt32(0);
                                artikal.Name = reader.GetString(1);

                                artikli.Add(artikal);
                                //Console.WriteLine(kategorija.Name);
                            }
                        }

                    }
                }
                //List<string> products = GetProductsByCategory(selectedCategory);

                foreach (Artikal artikal in artikli)
                {
                    Button button = new Button();
                    button.Text = artikal.Name;
                    button.Tag = artikal.Id;

                    button.Click += ArticalButtonClick;
                    //button.Click += CategoryButtonClick;
                    flowLayoutPanel2.Controls.Add(button);
                }

                void ArticalButtonClick(object sender, EventArgs e)
                {
                    Button clickedButton = (Button)sender;
                    string selectedArticalName = (string)clickedButton.Text;
                    int selectedArticalId = (int)clickedButton.Tag;
                    textBox1.Text = selectedArticalName;
                }
            }

            listBox1.Items.Add(".................");
            listBox1.Items.Add("Ukupno");
            listBox1.Items.Add("000");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += " 4";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += " x ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string konekcija = "Data Source=MILOS-PC\\SQLEXPRESS;Initial Catalog=ProjekatPMK;Integrated Security=True";

            //string nazivArtikla = "Banane X 2";
            string nazivArtikla = textBox1.Text;
            string[] parts = nazivArtikla.Split(new string[] { " x " }, StringSplitOptions.RemoveEmptyEntries);
            string naziv = parts[0].Trim();
            int kolicina = Convert.ToInt32(parts.Length > 1 ? parts[1].Trim() : "");
            
            Artikal artikal = new Artikal();

            using (SqlConnection connection = new SqlConnection(konekcija))
            {
                connection.Open();

                string sqlQuery = "SELECT a.*, j.Name AS JedinicaMereName " +
                 "FROM Artikal a " +
                 "JOIN Jedinica_Mere j ON a.Jedinica_Mere_Id = j.Id " +
                 "WHERE a.Name = @Naziv";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Naziv", naziv);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            
                            artikal.Id = reader.GetInt32(0);
                            artikal.Name = reader.GetString(1);
                            artikal.Price = reader.GetInt32(2);
                            artikal.Kategorija_Id = reader.GetInt32(3);
                            artikal.Jedinica_Mere_Id = reader.GetInt32(4);
                            artikal.NazivJediniceMere = reader.GetString(5);
                        }
                    }

                }
            }

            listBox2.Items.Add(artikal.Name + '(' + kolicina.ToString() + ' ' + artikal.NazivJediniceMere + ')');
            listBox1.Items.Insert(listBox1.Items.Count - 3, artikal.Name + "     " + (artikal.Price * kolicina).ToString());
            var cena = Convert.ToDecimal(listBox1.Items[listBox1.Items.Count-1]);
            //var cena = listBox1.Items[listBox1.Items.Count -1];
            cena += artikal.Price * kolicina;
            listBox1.Items[listBox1.Items.Count-1] = cena.ToString();

            decimal totalPrice = Convert.ToDecimal(label1.Text);
            totalPrice += artikal.Price * kolicina;
            label1.Text = totalPrice.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
}
