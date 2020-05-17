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
    
    public partial class kitapDuzenle : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\denemeDb.accdb");

        public kitapDuzenle()
        {
            InitializeComponent();
        }
        public void companentemizle()
        {
            txtBarkodNo.Clear();
            txtKitapAdi.Clear();
            txtYazar.Clear();
            txtSayfaSayisi.Clear();
            comboBox1.Text = "";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string barkodNo = txtBarkodNo.Text.Trim();
            string kitapAdi = txtKitapAdi.Text.Trim();
            string kitapYazari = txtYazar.Text.Trim();
            string sayfaSayisi = txtSayfaSayisi.Text.Trim();
            int secilentur = comboBox1.SelectedIndex + 1;
            if (barkodNo == "" || kitapAdi == "" || kitapYazari == "" || sayfaSayisi == "")
            {
                MessageBox.Show("Alanlar boş geçilemez", "Uyarı");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("UPDATE kitaplar SET barkodno='" + barkodNo + "', adi='" + kitapAdi + "', yazar='" + kitapYazari + "', sayfaSayisi='" + sayfaSayisi + "', rafNo='" + secilentur.ToString() + "' where barkodNo='" + barkodNo + "'", baglanti);
                komut.ExecuteNonQuery();
                companentemizle();
                MessageBox.Show("Kitap başarıyla güncellendi.");
                baglanti.Close();
            }
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM kitaplar INNER JOIN raflar ON kitaplar.rafNo=raflar.rafNo WHERE barkodNo LIKE '" + txtBarkodNo.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                txtKitapAdi.Text = okuyucu["kitapAdi"].ToString();
                txtSayfaSayisi.Text = okuyucu["yazar"].ToString();
                txtYazar.Text = okuyucu["sayfaSayisi"].ToString();
                comboBox1.Text = okuyucu["rafIsmi"].ToString();
                
            }
            baglanti.Close();
        }

        private void kitapDuzenle_Load(object sender, EventArgs e)
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
    }
}
