using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace _200202061_200202062_BankaOtomasyonu.Formlar
{
    public partial class FormPersonel : Form
    {
        public int PersonelID { get; set; }
        public FormPersonel()
        {
            InitializeComponent();
        }
        static String constring = ("Data Source=LAPTOP-GML3BQ0N\\SQLEXPRESS2;Initial Catalog=DbBanka;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        public void Kayitlari_getir()
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();

                    String getir = "Select * From Musteri where Personel=@id";
                    SqlCommand komut = new SqlCommand(getir, baglan);
                    komut.Parameters.AddWithValue("@id", PersonelID);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnMusEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String kayit = "INSERT INTO Musteri(AdSoyad,Telefon,TC,Adres,Mail,Sifre,Personel)values(@AdSoyad," +
                        "@Telefon,@TC,@Adres,@Mail,@Sifre,@Personel)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@AdSoyad", txtMusAd.Text);
                    komut.Parameters.AddWithValue("@Telefon", txtMusTel.Text);
                    komut.Parameters.AddWithValue("@TC", txtMusTC.Text);
                    komut.Parameters.AddWithValue("@Mail", txtMusMail.Text);
                    komut.Parameters.AddWithValue("@Sifre", txtMusSifre.Text);
                    komut.Parameters.AddWithValue("@Adres", txtMusAdres.Text);
                    komut.Parameters.AddWithValue("@Personel", txtMusEklePersonel.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kayıt Ekleme işlemi Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMusAd.Clear();
                    txtMusTel.Clear();
                    txtMusTC.Clear();
                    txtMusMail.Clear();
                    txtMusSifre.Clear();
                    txtMusAdres.Clear();
                    txtMusEklePersonel.Clear();
                    
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }

        }

        private void btnMusteriList_Click(object sender, EventArgs e)
        {
            Kayitlari_getir();
        }


        private void simpleButton1_Click(object sender, EventArgs e)//AramaYapButonu
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();

                    String getir = "Select * From Musteri where MusteriID=@MusteriID and Personel=@id";
                    SqlCommand komut = new SqlCommand(getir, baglan);
                    komut.Parameters.AddWithValue("@MusteriID", txtMusAra.Text);
                    komut.Parameters.AddWithValue("@id", PersonelID);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnMusteriCikar_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String sil = "Delete From Musteri Where MusteriID=@id";
                    SqlCommand komut = new SqlCommand(sil, baglan);
                    komut.Parameters.AddWithValue("@id", txtMusteriSil.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kayıt Silme işlemi Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnMusGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();

                String KayitGuncelle = ("Update  Musteri Set AdSoyad=@AdSoyad,Telefon=@Telefon," +
                    "TC=@TC,Mail=@Mail,Sifre=@Sifre,Adres=@Adres Where MusteriID=@id");

                SqlCommand komut = new SqlCommand(KayitGuncelle, baglan);
                komut.Parameters.AddWithValue("@AdSoyad", txtMusGunAd.Text);
                komut.Parameters.AddWithValue("@Telefon", txtMusGunTel.Text);
                komut.Parameters.AddWithValue("@TC", txtMusGunTC.Text);
                komut.Parameters.AddWithValue("@Mail", txtMusGunMail.Text);
                komut.Parameters.AddWithValue("@Sifre", txtMusGunSifre.Text);
                komut.Parameters.AddWithValue("@Adres", txtMusGunAdres.Text);
                komut.Parameters.AddWithValue("@id", txtMusGunID.Text);
                komut.ExecuteNonQuery();
                XtraMessageBox.Show("Kayıt Güncelleme işlemi Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglan.Close();
                txtMusGunAd.Clear();
                txtMusGunTel.Clear();
                txtMusGunTC.Clear();
                txtMusGunAdres.Clear();
                txtMusGunPersonel.Clear();
                txtMusGunMail.Clear();
                txtMusGunSifre.Clear();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnMusIslemList_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    
                    baglan.Open();
                    String getir = @"select hh.*,M.MusteriID,M.AdSoyad,M.Personel
                                   from HesapHareketler HH ,Hesaplar H, Musteri M
                                   where M.Personel = @PersonelID and h.Musteri = m.MusteriID and h.HesapID = hh.KaynakHesap";
                    SqlCommand komut = new SqlCommand(getir, baglan);
                    komut.Parameters.AddWithValue("@PersonelID", PersonelID);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglan.Close();

                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnMusIsAra_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String kayit = "Select * From HesapHareketler Where HareketID =@id";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@id", txtMusISAra.Text);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }

        }


        private void btnKrediEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                
                    baglan.Open();
                    String kayit = @"INSERT INTO Kredi(Hesap,KrediMiktari,TaksitSayisi,TaksitMiktari,TaksitAnaPara,TaksitFaiz,Onaylandi,KrediTarihi,TaksitOdemeGunu,KrediOdenenAy)
                                    values(@Hesap,@KrediMiktari,@TaksitSayisi,@TaksitMiktari,@TaksitAnaPara,@TaksitFaiz,@Onaylandi,@KrediTarihi,@TaksitOdemeGunu,@KrediOdenenAy)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@Hesap", txtKrediHesapNo.Text);
                    komut.Parameters.AddWithValue("@KrediMiktari", decimal.Parse(txtKrediMik.Text));
                    komut.Parameters.AddWithValue("@TaksitSayisi", txtTaksitSayisi.Text);
                    komut.Parameters.AddWithValue("@TaksitMiktari", decimal.Parse(txtTaksitMiktari.Text));
                    komut.Parameters.AddWithValue("@TaksitAnaPara", decimal.Parse(txtTaksitAnaPara.Text));
                    komut.Parameters.AddWithValue("@TaksitFaiz", decimal.Parse(txtTaksitFaiz.Text));
                    komut.Parameters.AddWithValue("@Onaylandi", 0);
                    komut.Parameters.AddWithValue("@KrediTarihi", dateTimeKrediTarihi.Value);
                    komut.Parameters.AddWithValue("@TaksitOdemeGunu", txtTaksitOdemeGun.Text);
                    komut.Parameters.AddWithValue("@KrediOdenenAy", 0);
                    komut.ExecuteNonQuery();
                XtraMessageBox.Show("Kredi Hesabı Oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnHesapSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String sil = "Delete From Hesaplar Where HesapID=@HesapID";
                    SqlCommand komut = new SqlCommand(sil, baglan);
                    komut.Parameters.AddWithValue("@HesapID", txtHesapSilHesNo.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Hesap Silme İşlemi Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglan.Close();

                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnMusteriAra_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String kayit = "Select * From Hesaplar Where Musteri =@MusteriID";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@MusteriID", txtMusteriAra.Text);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView3.DataSource = dt;
                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }
        decimal krediFaizi = 0;
        private void btnHesapEkle_Click(object sender, EventArgs e)
        {

            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String kayit = "INSERT INTO Hesaplar(HesapNo,Tarih,KurID,Musteri,Bakiye,HesapAd)values(@HesapNo," +
                        "@Tarih,@KurID,@Musteri,@Bakiye,@HesapAd)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@HesapNo", txtYeniHesapNo.Text);
                    komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("@KurID", txtYeniHesKurNo.Text);
                    komut.Parameters.AddWithValue("@Musteri", txtMusteriID.Text);
                    komut.Parameters.AddWithValue("@HesapAd", txtYeniHesapAd.Text);
                    komut.Parameters.AddWithValue("@Bakiye", 0);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Hesap Ekleme işlemi Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtYeniHesapNo.Clear();
                    txtYeniHesKurNo.Clear();
                    txtMusteriID.Clear();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void tabNavigationPage6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormPersonel_Load(object sender, EventArgs e)
        {

            baglan.Close();
            if (baglan.State == ConnectionState.Closed)
                baglan.Open();
            String getir = "Select * From Parametre ";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                krediFaizi = (decimal)dr["KrediFaizi"];
                txtFaizOrani.Text = krediFaizi.ToString();
                
            }
            dr.Close();
            baglan.Close();
        }

        private void txtKrediMik_TextChanged(object sender, EventArgs e)
        {
            int taksitSayisi = 0;
            decimal tutar = 0;
            if (decimal.TryParse(txtKrediMik.Text,out tutar)&& int.TryParse(txtTaksitSayisi.Text,out taksitSayisi))
            {
                decimal taksitTutar = tutar / taksitSayisi;
                decimal taksitFaiz = tutar *(krediFaizi / 100);
                txtTaksitMiktari.Text = (taksitTutar + taksitFaiz).ToString();
                txtTaksitAnaPara.Text = (taksitTutar).ToString();
                txtTaksitFaiz.Text = (taksitFaiz).ToString();
            }
        }

        private void txtTaksitSayisi_TextChanged(object sender, EventArgs e)
        {
            int taksitSayisi = 0;
            decimal tutar = 0;
            if (decimal.TryParse(txtKrediMik.Text, out tutar) && int.TryParse(txtTaksitSayisi.Text, out taksitSayisi))
            {
                decimal taksitTutar = tutar / taksitSayisi;
                decimal taksitFaiz = tutar * (krediFaizi / 100);
                txtTaksitMiktari.Text = (taksitTutar + taksitFaiz).ToString();
                txtTaksitAnaPara.Text = (taksitTutar).ToString();
                txtTaksitFaiz.Text = (taksitFaiz).ToString();
            }
        }

        private void txtKrediHesapNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMusGunID_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            String getir = "Select * from Musteri where MusteriID=@MusteriID";
            SqlCommand komut = new SqlCommand(getir, baglan);
            komut.Parameters.AddWithValue("@MusteriID", txtMusGunID.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtMusGunAd.Text = (String)dr["AdSoyad"];
                txtMusGunTel.Text = (String)dr["Telefon"];
                txtMusGunTC.Text = (String)dr["TC"];
                txtMusGunAdres.Text = (String)dr["Adres"];
                txtMusGunPersonel.Text = dr["Personel"].ToString();
                txtMusGunMail.Text = (String)dr["Mail"];
                txtMusGunSifre.Text = (String)dr["Sifre"];

            }
            baglan.Close();
        }
    }
}
