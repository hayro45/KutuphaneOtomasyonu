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
    public partial class kitapEkle : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\denemeDb.accdb");
        public kitapEkle()
        {
            InitializeComponent();
        }

        private void KitapEkle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM raflar", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["rafIsmi"]);
            }
            baglanti.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string barkodNo = txtBarkodNo.Text.Trim();
            string kitapAdi = txtKitapAdi.Text.Trim();
            string kitapYazari = txtYazar.Text.Trim();
            string sayfaSayisi = txtSayfaSayisi.Text.Trim();
            int secilentur = comboBox1.SelectedIndex + 1;
            
            if(barkodNo=="" || kitapAdi=="" || kitapYazari=="" || sayfaSayisi=="")
            {
                MessageBox.Show("Alanlar boş geçilemez","Uyarı");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into kitaplar (barkodNo, kitapAdi, yazar, sayfaSayisi, rafNo) values ('" + barkodNo + "', '" + kitapAdi + "', '" + kitapYazari + "', '" + sayfaSayisi + "', '" + secilentur.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                companentemizle();
                MessageBox.Show("Kitap Başarıyla Eklendi");
                baglanti.Close();
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            companentemizle();
        }
        public void companentemizle()
        {
            txtBarkodNo.Clear();
            txtKitapAdi.Clear();
            txtYazar.Clear();
            txtSayfaSayisi.Clear();
            comboBox1.Text = "";
        }
    }
}
