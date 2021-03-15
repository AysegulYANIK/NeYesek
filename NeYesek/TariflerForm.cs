using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeYesek
{
    public partial class TariflerForm : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView mealsDataGridView = new DataGridView();
        //private DataGridView ingredientsDataGridView = new DataGridView();
        private Button addNewRowButton = new Button();
        private Button getIngredientsButton = new Button();
        private Button recipeListButton = new Button();

        public TariflerForm()
        {

        InitializeComponent();
        this.Load += new EventHandler(Form_Load);
       
        }
        
        private void Form_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void mealsDataGridView_CellFormatting(object sender,
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {/*
            if (e != null)
            {
                if (this.mealsDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString()).ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }*/
        }
        private void addNewRowButton_Click(object sender, EventArgs e)
        {
            this.mealsDataGridView.Rows.Add();
        }

        static void RestartApp(int pid, string applicationName)
        {
            // Wait for the process to terminate
            Process process = null;
            try
            {
                process = Process.GetProcessById(pid);
                process.WaitForExit(1000);
            }
            catch (ArgumentException ex)
            {
                // ArgumentException to indicate that the 
                // process doesn't exist?   LAME!!
            }
            Process.Start(applicationName, "NeYesek");
        }

        private void recipeListButton_Click(object sender, EventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            
            RestartApp( currentProcess.Id, "NeYesek");
        }

            private void getIngredientsButton_Click(object sender, EventArgs e)
        {
                //this.mealsDataGridView.SelectedRows[0].Cells.Count;
                //string tarifAdı = this.mealsDataGridView.SelectedRows[0].Cells[0].Value.ToString;
                
                //int index = this.mealsDataGridView.SelectedRows.Count;
                //this.Controls.Add(ingredientsDataGridView);
                mealsDataGridView.ColumnCount = 1;

                mealsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                mealsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                mealsDataGridView.ColumnHeadersDefaultCellStyle.Font =
                    new Font(mealsDataGridView.Font, FontStyle.Bold);

                mealsDataGridView.Name = "mealsDataGridView";
                mealsDataGridView.Location = new Point(8, 8);
                mealsDataGridView.Size = new Size(500, 250);
                mealsDataGridView.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                mealsDataGridView.ColumnHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;
                mealsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                mealsDataGridView.GridColor = Color.Black;
                mealsDataGridView.RowHeadersVisible = false;

                mealsDataGridView.Columns[0].Name = "Malzemeler";
                mealsDataGridView.Columns[0].DefaultCellStyle.Font =
                    new Font(mealsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

                //mealsDataGridView.Rows.Add(index);

                mealsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                mealsDataGridView.MultiSelect = false;
                mealsDataGridView.Dock = DockStyle.Fill;

        }

        private void SetupLayout()
        {
            this.Size = new Size(600, 500);
            /*
            addNewRowButton.Text = "Satır Ekle";
            addNewRowButton.Location = new Point(10, 10);
            addNewRowButton.Click += new EventHandler(addNewRowButton_Click);
            */

            getIngredientsButton.Text = "Malzemeleri Getir";
            getIngredientsButton.Width = 200;
            getIngredientsButton.Location = new Point(100, 10);
            getIngredientsButton.Click += new EventHandler( getIngredientsButton_Click );

            recipeListButton.Text = "Tarifler Listesi";
            recipeListButton.Width = 200;
            recipeListButton.Location = new Point(300, 10);
            recipeListButton.Click += new EventHandler(recipeListButton_Click);

            //buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add( getIngredientsButton);
            buttonPanel.Controls.Add(recipeListButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(mealsDataGridView);

            mealsDataGridView.ColumnCount = 4;

            mealsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            mealsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            mealsDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(mealsDataGridView.Font, FontStyle.Bold);

            mealsDataGridView.Name = "mealsDataGridView";
            mealsDataGridView.Location = new Point(8, 8);
            mealsDataGridView.Size = new Size(500, 250);
            mealsDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            mealsDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            mealsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            mealsDataGridView.GridColor = Color.Black;
            mealsDataGridView.RowHeadersVisible = false;

            mealsDataGridView.Columns[0].Name = "Tarifin Türü";
            mealsDataGridView.Columns[1].Name = "Tarifin Adı";
            mealsDataGridView.Columns[2].Name = "Yapılışı";
            mealsDataGridView.Columns[3].Name = "Malzemeler";
            mealsDataGridView.Columns[3].DefaultCellStyle.Font =
                new Font(mealsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            mealsDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            mealsDataGridView.MultiSelect = false;
            mealsDataGridView.Dock = DockStyle.Fill;

            mealsDataGridView.CellFormatting += new
                DataGridViewCellFormattingEventHandler(mealsDataGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {

            Tarif tarif = new Tarif();

            tarif.tarifAdı = "Tarif 1";
            tarif.tarifTürü = "Tarif Türü 1";
            tarif.tarifYapılışı = "Tarif Yapılışı 1";
            tarif.Malzemeler = new List<string>()
            {
                "carrot",
                "fox",
                "explorer"
            };

            mealsDataGridView.Rows.Add(tarif.tarifAdı, tarif.tarifTürü, tarif.tarifYapılışı, "malzemeler");
            //tarif1 >> { "Ana Yemek", "Biber Dolması", "Dolma nasıl Yapılır?", "Buraya liste gelecek." }
            //tarif2 >> { "Tatlı", "Sütlaç", "Sütlaç nasıl Yapılır?", "Buraya liste gelecek." }
            //tarif3 >>{ "Salata", "Çoban Salata", "Çoban Salata  nasıl Yapılır?", "Buraya liste gelecek." }
            
        }

        public void malzemeleriGetir(Tarif tarif)
        {

            DataTable malzemeTablosu = new DataTable();
            malzemeTablosu.Columns.Add("Malzemeler", typeof(string));

            if (tarif.Malzemeler != null)
            {
                foreach (string malzeme in tarif.Malzemeler)
                {
                    malzemeTablosu.Rows.Add(malzeme);
                }
            }
            DataGridView ingredientsDataGridView = new DataGridView();
            ingredientsDataGridView.DataSource = malzemeTablosu;

        }

    }
}
