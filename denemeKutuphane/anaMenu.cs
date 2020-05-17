using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Data.OleDb;

namespace denemeKutuphane
{
    public partial class anaMenu : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\denemeDb.accdb");
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,   
            int nTopRect,      
            int nRightRect,    
            int nBottomRect,   
            int nWidthEllipse, 
            int nHeightEllipse 
        );
        public anaMenu()
        {
            InitializeComponent();
        }
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ogrenciekle = new ogrenciEkle();
            ogrenciekle.Show();
        }

        private void SilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ogrencisil = new ogrenciSil();
            ogrencisil.Show();
        }

        private void DüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ogrenciduzenle = new ogrenciDuzenle();
            ogrenciduzenle.Show();
        }

        private void ListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ogrencilistele = new ogrenciListele();
            ogrencilistele.Show();
        }

        private void EkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kitapekle = new kitapEkle();
            kitapekle.Show();
        }

        private void SilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kitapesil = new kitapSil();
            kitapesil.Show();
        }

        private void DüzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kitapduzenle = new kitapDuzenle();
            kitapduzenle.Show();
        }

        private void ListeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kitaplistele = new kitapListele();
            kitaplistele.Show();
        }

        private void KitapVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kitapver = new kitapVer();
            kitapver.Show();

        }

        private void GeçKalanKitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form geckalankitaplar = new gecKalanKitaplar();
            geckalankitaplar.Show();
        }

        
        private void anaMenu_Load(object sender, EventArgs e)
        {
            toplamKitap();
            toplamOgrenci();
            toplamOkunanKitap();
            kitapturleri();
            OkunanKitapturleri();
        }
        public void toplamKitap()
        {
            baglanti.Open();
            DataSet ds2 = new DataSet();
            OleDbDataAdapter da2 = new OleDbDataAdapter("SELECT * FROM kitaplar", baglanti);
            ds2.Clear();
            da2.Fill(ds2, "kitaplar");
            lblToplamKitap.Text = ds2.Tables["kitaplar"].Rows.Count.ToString();
            baglanti.Close();
        }
        public void toplamOgrenci()
        {
            //öğrenci sayısı
            baglanti.Open();
            DataSet ds1 = new DataSet();
            OleDbDataAdapter da1 = new OleDbDataAdapter("SELECT * FROM ogrenciler", baglanti);
            ds1.Clear();
            da1.Fill(ds1, "ogrenciler");
            lblToplamOgrenci.Text = ds1.Tables["ogrenciler"].Rows.Count.ToString();

            //Kadın Sayısı
            DataSet ds2 = new DataSet();
            OleDbDataAdapter da2 = new OleDbDataAdapter("SELECT * FROM ogrenciler WHERE cinsiyet=@evet", baglanti);
            da2.SelectCommand.Parameters.Add("@evet",OleDbType.Boolean,15).Value=true;
            ds2.Clear();
            da2.Fill(ds2, "ogrenciler");
            lblKadınSayisi.Text = ds2.Tables["ogrenciler"].Rows.Count.ToString();

            //Erkek Sayısı
            DataSet ds3 = new DataSet();
            OleDbDataAdapter da3 = new OleDbDataAdapter("SELECT * FROM ogrenciler WHERE cinsiyet=@hayir", baglanti);
            da3.SelectCommand.Parameters.Add("@hayir", OleDbType.Boolean, 15).Value = false;
            ds3.Clear();
            da3.Fill(ds3, "ogrenciler");
            lblErkekSayisi.Text = ds3.Tables["ogrenciler"].Rows.Count.ToString();
            baglanti.Close();
        }
         
        public void toplamOkunanKitap()
        {
            baglanti.Open();
            DataSet ds2 = new DataSet();
            OleDbDataAdapter da2 = new OleDbDataAdapter("SELECT * FROM kitapver", baglanti);
            ds2.Clear();
            da2.Fill(ds2, "kitapver");
            lblOkunanKitap.Text = ds2.Tables["kitapver"].Rows.Count.ToString();
            baglanti.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            toplamKitap();
            toplamOgrenci();
            toplamOkunanKitap();
            kitapturleri();
            OkunanKitapturleri();
        }

        private void veriGoster(object sender, EventArgs e)
        {
            pnlCinsiyet.Visible = true;
        }

        private void veriKaybet(object sender, EventArgs e)
        {
            pnlCinsiyet.Visible = false;
        }

        private void listeGoster(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }

        private void listeKapat(object sender, EventArgs e)
        {
            listBox1.Visible = false;
        }
        public void kitapturleri()
        {
            baglanti.Open();
            string myRafSelectCommand = "SELECT * FROM raflar ";
            OleDbCommand komut = new OleDbCommand(myRafSelectCommand, baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();

            listBox1.Items.Clear();
                while (okuyucu.Read())
                {
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM kitaplar WHERE rafNo='" + okuyucu["rafNo"].ToString() + "'", baglanti);
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "kitaplar");
                    string turSayisi = dataSet.Tables["kitaplar"].Rows.Count.ToString();
                if (Convert.ToInt32(turSayisi) > 0)
                {
                    listBox1.Items.Add(okuyucu["rafIsmi"].ToString() + ": " + turSayisi);

                }

            }
            

            baglanti.Close();
        }
        public void OkunanKitapturleri()
        {
            baglanti.Open();
            string myRafSelectCommand = "SELECT * FROM raflar ";
            OleDbCommand komut = new OleDbCommand(myRafSelectCommand, baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();

            listBox2.Items.Clear();
            while (okuyucu.Read())
            {
                DataSet dataSet = new DataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM kitapVer WHERE rafNo='" + okuyucu["rafNo"].ToString() + "'", baglanti);
                dataSet.Clear();
                dataAdapter.Fill(dataSet, "kitapVer");
                string turSayisi = dataSet.Tables["kitapVer"].Rows.Count.ToString();

                if (Convert.ToInt32(turSayisi) > 0) 
                { 
                    listBox2.Items.Add(okuyucu["rafIsmi"].ToString() + ": " + turSayisi ); 
                }

            }
            
            baglanti.Close();
        }
        private void liste2Goster(object sender, EventArgs e)
        {
            listBox2.Visible = true;
        }

        private void liste2Kapap(object sender, EventArgs e)
        {
            listBox2.Visible = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.DarkGray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(244, 67, 54);
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.DarkGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
