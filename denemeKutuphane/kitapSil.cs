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
    public partial class kitapSil : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\denemeDb.accdb");

        public kitapSil()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("DELETE FROM kitaplar WHERE barkodNo='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kitap başarıyla silindi..");
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM kitaplar INNER JOIN raflar ON kitaplar.rafNo=raflar.rafNo WHERE barkodNo LIKE '" + textBox1.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                txtKitapAdi.Text = okuyucu["kitapAdi"].ToString();
                txtYazar.Text = okuyucu["yazar"].ToString();
                comboBox1.Text = okuyucu["rafIsmi"].ToString() ;
            }
            baglanti.Close();
        }
    }
}
