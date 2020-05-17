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
    public partial class ogrenciDuzenle : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\denemeDb.accdb");

        public ogrenciDuzenle()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTel.Clear();
            txtEposta.Clear();
            richAdres.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string tcNo = txtTc.Text.Trim();
            string Ad = txtAd.Text.Trim();
            string Soyad = txtSoyad.Text.Trim();
            string telefon = txtTel.Text.Trim();
            string eposta = txtEposta.Text.Trim();
            string adres = richAdres.Text.Trim();
            
            if (tcNo == "" || Ad == "" || Soyad == "" || telefon == "" || eposta == "" || adres == "")
            {
                MessageBox.Show("Alanlar boş geçilemez", "Uyarı");
            }
            else
            {
                bool cinsiyet = true;
                if (radioButton1.Checked)
                {
                    cinsiyet = true;
                }
                else if (radioButton2.Checked)
                {
                    cinsiyet = false;
                }
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("UPDATE ogrenciler SET tcno='" + tcNo + "', adi='" + Ad + "', soyadi='" + Soyad + "', telefon='" + telefon + "', eposta='" + eposta + "', adres='" + adres + "', cinsiyet=@cinsiyet WHERE tcno='" + txtTc.Text + "'", baglanti);
                komut.Parameters.Add("cinsiyet", OleDbType.Boolean, 1).Value = cinsiyet;
                komut.ExecuteNonQuery();
                MessageBox.Show("öğrenci bilgileri başarıyla düzenlendi");
                baglanti.Close();
            }

            
        }

        private void txtTc_Text_Changed(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM ogrenciler WHERE tcno LIKE '" + txtTc.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                txtAd.Text = okuyucu["adi"].ToString() ;
                txtSoyad.Text = okuyucu["soyadi"].ToString();
                txtTel.Text = okuyucu["telefon"].ToString();
                txtEposta.Text = okuyucu["eposta"].ToString();
                richAdres.Text = okuyucu["adres"].ToString();
                string cinsiyet =okuyucu["cinsiyet"].ToString();
                if (cinsiyet=="True")
                {
                    radioButton2.Checked = false;
                    radioButton1.Checked = true;
                }
                else if (cinsiyet == "False")
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
            }
            baglanti.Close();
        }

        private void OgrenciDuzenle_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
