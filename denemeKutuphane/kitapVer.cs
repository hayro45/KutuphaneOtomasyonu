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
using System.Security.Cryptography.X509Certificates;

namespace denemeKutuphane
{
    public partial class kitapVer : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\denemeDb.accdb");
      
        DataTable tablo = new DataTable();
        public kitapVer()
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

        public void componentSifirla()
        {
            txtTC.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtTel.Clear();
            txtEposta.Clear();
            rchAdres.Clear();
            txtBarkod.Clear();
            txtKitapAdi.Clear();
            txtYazar.Clear();
            comboBox1.Text = "";
            txtSayfa.Clear();

        }

        private void KitapVer_Load(object sender, EventArgs e)
        {
            baglantiKontrolu();
            tablo.Clear();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("select * from kitapVer", baglanti);
            adaptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
        private void txtTCTextChanged(object sender, EventArgs e)
        {
            baglantiKontrolu();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM ogrenciler WHERE tcno LIKE '" + txtTC.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                txtAd.Text = okuyucu["adi"].ToString();
                txtSoyad.Text = okuyucu["soyadi"].ToString();
                txtTel.Text = okuyucu["telefon"].ToString();
                txtEposta.Text = okuyucu["eposta"].ToString();
                rchAdres.Text = okuyucu["adres"].ToString();
            }
            baglanti.Close();
        }

        private void txtBarkodTextChanged(object sender, EventArgs e)
        {

            baglantiKontrolu();

            OleDbCommand komut = new OleDbCommand("SELECT * FROM kitaplar INNER JOIN raflar ON kitaplar.rafNo=raflar.rafNo WHERE barkodNo LIKE '" + txtBarkod.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
           
            OleDbCommand komut2 = new OleDbCommand("SELECT * FROM kitaplar WHERE barkodNo LIKE '" + txtBarkod.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu2 = komut2.ExecuteReader();
            while (okuyucu.Read())
            {
                txtKitapAdi.Text = okuyucu["kitapAdi"].ToString();
                txtYazar.Text = okuyucu["yazar"].ToString();
                txtSayfa.Text = okuyucu["sayfaSayisi"].ToString();
                comboBox1.Text= okuyucu["rafIsmi"].ToString();
                while (okuyucu2.Read()) { lblTur.Text = okuyucu2["rafNo"].ToString(); }
                //dateTimePicker1.Value = Convert.ToDateTime(okuyucu["verilisTarihi"]);
                //dateTimePicker2.Value = Convert.ToDateTime(okuyucu["teslimTarihi"]);
            }
            baglanti.Close();
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            baglantiKontrolu();
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtTC.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBarkod.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            lblTur.Text = Convert.ToString(dataGridView1.Rows[secilen].Cells[9].Value);
            dateTimePicker1.Text = Convert.ToString(dataGridView1.Rows[secilen].Cells[10].Value);
            dateTimePicker2.Text = Convert.ToString(dataGridView1.Rows[secilen].Cells[11].Value);
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtAd.Text != "" && txtKitapAdi.Text != "")
            {
                baglantiKontrolu();
                OleDbCommand komut = new OleDbCommand("DELETE FROM kitapver WHERE barkodNo='" + txtBarkod.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                tablo.Clear();
                OleDbDataAdapter adaptr = new OleDbDataAdapter("select * from kitapVer", baglanti);
                adaptr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                componentSifirla();
                MessageBox.Show("Kitap başarıyla teslim edildi","Onay");
                baglanti.Close();
                
            }
            else
            {
                MessageBox.Show("Teslim edilecek kitap seçiniz!");
            }
        }
        
        private void btnKitapVerClick(object sender, EventArgs e)
        {
            string tc = txtTC.Text.Trim();
            string barkodNo = txtBarkod.Text.Trim();
            if (tc == "")
            {
                MessageBox.Show("Lütfen tc giriniz","Uyarı");
            }
            else if (barkodNo == "") 
            {
                MessageBox.Show("Lütfen barkod giriniz","Uyarı");
            }
            else
            {
                baglantiKontrolu();
                OleDbCommand komut = new OleDbCommand("insert into kitapVer (tcno, adi, soyadi, telefon, adres, barkodNo, kitapAdi, yazar, sayfaSayisi, rafNo, verilisTarihi, teslimTarihi) values ('" + txtTC.Text + "', '" + txtAd.Text + "', '" + txtSoyad.Text + "', '" + txtTel.Text + "', '" + rchAdres.Text + "', '" + txtBarkod.Text + "', '" + txtKitapAdi.Text + "', '" + txtYazar.Text + "', '" + txtSayfa.Text + "', '" + lblTur.Text.ToString() + "', '" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "')", baglanti);
                komut.ExecuteNonQuery();

                tablo.Clear();
                OleDbDataAdapter adaptr = new OleDbDataAdapter("select * from kitapVer", baglanti);
                adaptr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                componentSifirla();
                MessageBox.Show("Başarıyla kaydedildi!");
                baglanti.Close();
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            componentSifirla();
        }
    }
}
