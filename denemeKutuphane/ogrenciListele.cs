using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace denemeKutuphane
{
    public partial class ogrenciListele : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source="+Application.StartupPath+"\\denemeDb.accdb");
        DataTable tablo = new DataTable();
        public ogrenciListele()
        {
            InitializeComponent();
        }

        private void OgrenciListele_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("TC NO", 150);
            listView1.Columns.Add("AD", 150);
            listView1.Columns.Add("SOYAD", 100);
            listView1.Columns.Add("TELEFON", 150);
            listView1.Columns.Add("ADRES", 200);
            listView1.Columns.Add("EPOSTA", 150);
            listView1.Columns.Add("CİNSİYET", 100);

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM ogrenciler ", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read()) 
            {
                bool _cinsiyet = Convert.ToBoolean(okuyucu["cinsiyet"]);
                string cinsiyet = "";
                if (_cinsiyet == true) 
                {
                    cinsiyet = "Kadın";
                }
                else
                {
                    cinsiyet = "Erkek";
                }
                ListViewItem item = new ListViewItem(okuyucu["tcno"].ToString());
                item.SubItems.Add(okuyucu["adi"].ToString());
                item.SubItems.Add(okuyucu["soyadi"].ToString());  
                item.SubItems.Add(okuyucu["telefon"].ToString());
                item.SubItems.Add(okuyucu["adres"].ToString());
                item.SubItems.Add(okuyucu["eposta"].ToString());
                item.SubItems.Add(cinsiyet);

                listView1.Items.Add(item);
            }

            baglanti.Close();
        }
    }
}
