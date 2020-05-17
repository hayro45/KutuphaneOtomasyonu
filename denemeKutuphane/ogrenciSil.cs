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
    public partial class ogrenciSil : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\denemeDb.accdb");

        public ogrenciSil()
        {
            InitializeComponent();
        }
        public void baglantiKontrolu()
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Close();
                baglanti.Open();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            baglantiKontrolu();
            OleDbCommand komut = new OleDbCommand("DELETE FROM ogrenciler WHERE tcno='" + txtTC.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci başarıyla silindi..");
            txtTC.Clear();
            txtAdi.Clear();
            txtSoyadi.Clear();
            baglanti.Close();
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            baglantiKontrolu();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM ogrenciler WHERE tcNo LIKE '" + txtTC.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                txtAdi.Text = okuyucu["adi"].ToString();
                txtSoyadi.Text = okuyucu["soyadi"].ToString();
            }
            baglanti.Close();
        }
    }
}
