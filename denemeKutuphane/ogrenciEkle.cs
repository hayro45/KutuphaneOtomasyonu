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
    public partial class ogrenciEkle : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\denemeDb.accdb");
        public ogrenciEkle()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string tcNo = txtTc.Text.Trim();
            string Ad = txtAd.Text.Trim();
            string Soyad = txtSoyad.Text.Trim();
            string telefon = txtTel.Text.Trim();
            string eposta = txtEposta.Text.Trim();
            string adres = richAdres.Text.Trim();

            if(tcNo=="" || Ad=="" || Soyad=="" || telefon=="" || eposta=="" || adres == "")
            {
                MessageBox.Show("Alanlar boş geçilemez", "Uyarı");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into ogrenciler (tcno, adi, soyadi, telefon, eposta, adres) values ('" + tcNo + "', '" + Ad + "', '" + Soyad + "', '" + telefon + "', '" + eposta + "', '" + adres + "')", baglanti);
                komut.ExecuteNonQuery();
                companentemizle();
                MessageBox.Show("Öğrenci başarıyla kaydedildi");
                baglanti.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            companentemizle();
        }
        public void companentemizle()
        {
            txtTc.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtTel.Clear();
            txtEposta.Clear();
            richAdres.Clear();
        }
    }
}
