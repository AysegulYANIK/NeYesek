using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private Button addNewRowButton = new Button();
        //private Button deleteRowButton = new Button();

        public TariflerForm()
        {

        InitializeComponent();
        this.Load += new EventHandler(Form_Load);
        /*
            Tarif tarif = new Tarif();

            //tarif.Malzemeler.Add("Malzeme 2");
            //EXCEPTION >> System.NullReferenceException: 'Object reference not set to an instance of an object.'

            tarif.tarifAdı = "Tarif 1";
            tarif.tarifTürü = "Tarif Türü 1";
            tarif.tarifYapılışı = "Tarif Yapılışı 1";
            tarif.Malzemeler = new List<string>()
            {
                "carrot",
                "fox",
                "explorer"
            };

            //Tarifler tarifler = null;
            //tarifler.TariflerListesi.Add(tarif);

            DataTable tarifTablosu = new DataTable();

            tarifTablosu.Columns.Add("Tarif Adı", typeof(string));
            tarifTablosu.Columns.Add("Tarif Türü", typeof(string));
            tarifTablosu.Columns.Add("Tarif Yapılışı", typeof(string));

            tarifTablosu.Rows.Add(tarif.tarifAdı , tarif.tarifTürü , tarif.tarifYapılışı );
            tariflerTablosu.DataSource = tarifTablosu;

            //List<int> ListOfInt = new List<int>();
            //DataTable ListAsDataTable = BuildDataTable<int>(ListOfInt);
            //DataTable ListAsDataTable = BuildDataTable<string>(tarif.Malzemeler);
            //DataView ListAsDataView = ListAsDataTable.DefaultView;

            malzemeleriGetir(tarif);
        */
        }
        /*
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

            DataView.DataSource = malzemeTablosu;
        }
        */
        private void Form_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void mealsDataGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.mealsDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }
        private void addNewRowButton_Click(object sender, EventArgs e)
        {
            this.mealsDataGridView.Rows.Add();
        }

        private void SetupLayout()
        {
            this.Size = new Size(600, 500);


            addNewRowButton.Text = "Add Row";
            addNewRowButton.Location = new Point(10, 10);
            addNewRowButton.Click += new EventHandler(addNewRowButton_Click);
            /*
            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Location = new Point(100, 10);
            deleteRowButton.Click += new EventHandler(deleteRowButton_Click);
            */

            buttonPanel.Controls.Add(addNewRowButton);
            //buttonPanel.Controls.Add(deleteRowButton);
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
                DataGridViewCellFormattingEventHandler(
                mealsDataGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {

            Tarif tarif = new Tarif();

            //tarif.Malzemeler.Add("Malzeme 2");
            //EXCEPTION >> System.NullReferenceException: 'Object reference not set to an instance of an object.'

            tarif.tarifAdı = "Tarif 1";
            tarif.tarifTürü = "Tarif Türü 1";
            tarif.tarifYapılışı = "Tarif Yapılışı 1";
            tarif.Malzemeler = new List<string>()
            {
                "carrot",
                "fox",
                "explorer"
            };

            //Tarifler tarifler = null;
            //tarifler.TariflerListesi.Add(tarif);

            //DataTable tarifTablosu = new DataTable();

            //tarifTablosu.Columns.Add("Tarif Adı", typeof(string));
            //tarifTablosu.Columns.Add("Tarif Türü", typeof(string));
            //tarifTablosu.Columns.Add("Tarif Yapılışı", typeof(string));

            //tarifTablosu.Rows.Add(tarif.tarifAdı, tarif.tarifTürü, tarif.tarifYapılışı, "malzemeler");
            //mealsDataGridView.DataSource = tarifTablosu;

            /*
            string[] row0 = { "Ana Yemek", "Biber Dolması", "Dolma nasıl Yapılır?",
            "Buraya liste gelecek." };
            string[] row1 = { "Tatlı", "Sütlaç", "Sütlaç nasıl Yapılır?",
            "Buraya liste gelecek."};
            string[] row2 = { "Salata", "Çoban Salata", "Çoban Salata  nasıl Yapılır?",
            "Buraya liste gelecek."};

            mealsDataGridView.Rows.Add(row0);
            mealsDataGridView.Rows.Add(row1);
            mealsDataGridView.Rows.Add(row2);

           
            mealsDataGridView.Columns[0].DisplayIndex = 3;
            mealsDataGridView.Columns[1].DisplayIndex = 4;
            mealsDataGridView.Columns[2].DisplayIndex = 0;
            mealsDataGridView.Columns[3].DisplayIndex = 1;
            mealsDataGridView.Columns[4].DisplayIndex = 2;
            */
            mealsDataGridView.Rows.Add(tarif.tarifAdı, tarif.tarifTürü, tarif.tarifYapılışı, "malzemeler");


        }



    }
}
