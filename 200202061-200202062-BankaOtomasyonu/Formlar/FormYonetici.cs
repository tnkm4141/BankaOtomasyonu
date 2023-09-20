
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
    public partial class FormYonetici : Form
    {
        public FormYonetici()
        {
            InitializeComponent();
        }
        static String constring = ("Data Source=LAPTOP-GML3BQ0N\\SQLEXPRESS2;Initial Catalog=DbBanka;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        private void btnPersonelCikar_Click(object sender, EventArgs e)
        {
            baglan.Open();
            String sil = "Delete From Personel Where PersonelID=@id";
            SqlCommand komut = new SqlCommand(sil, baglan);
            komut.Parameters.AddWithValue("@id", txtPersonelSil.Text);
            komut.ExecuteNonQuery();
            XtraMessageBox.Show("Kayıt Silme işlemi Başarılı.");
            baglan.Close();
            txtPersonelSil.Clear();
            txtPersonelSil.Focus();


        }

        private void simpleButton2_Click(object sender, EventArgs e)//Müşteri Ekle
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
                    komut.Parameters.AddWithValue("@Personel", txtMusPersonel.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kayıt Ekleme işlemi Başarılı.");
                    txtMusAd.Clear();
                    txtMusTel.Clear();
                    txtMusTC.Clear();
                    txtMusMail.Clear();
                    txtMusSifre.Clear();
                    txtMusAdres.Clear();
                    txtMusPersonel.Clear();
                    txtMusAd.Focus();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }
        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String kayit = "INSERT INTO Personel(AdSoyad,Telefon,TC,Adres,Mail,Sifre,Maas)values(@AdSoyad," +
                        "@Telefon,@TC,@Adres,@Mail,@Sifre,@Maas)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@AdSoyad", txtPersonelAd.Text);
                    komut.Parameters.AddWithValue("@Telefon", txtPersonelTel.Text);
                    komut.Parameters.AddWithValue("@TC", txtPersonelTC.Text);
                    komut.Parameters.AddWithValue("@Mail", txtPersonelMail.Text);
                    komut.Parameters.AddWithValue("@Sifre", txtPersonelSifre.Text);
                    komut.Parameters.AddWithValue("@Adres", txtPersonelAdres.Text);
                    komut.Parameters.AddWithValue("@Maas", txtPersonelMaas.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kayıt Ekleme işlemi Başarılı.");
                    txtPersonelAd.Clear();
                    txtPersonelTel.Clear();
                    txtPersonelTC.Clear();
                    txtPersonelMail.Clear();
                    txtPersonelSifre.Clear();
                    txtPersonelAdres.Clear();
                    txtPersonelMaas.Clear();
                   


                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)//Personel Listele
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String getir = "Select * From Personel ";
                    SqlCommand komut = new SqlCommand(getir, baglan);
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

        private void btnKurKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String kayit = "INSERT INTO Kur(KurAd,Sembol,Deger,Tarih)values(@KurAd," +
                        "@Sembol,@Deger,@Tarih)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@KurAd", txtKurAd.Text);
                    komut.Parameters.AddWithValue("@Sembol", txtKurSembol.Text);
                    komut.Parameters.AddWithValue("@Deger", txtKurDeger.Text);
                    komut.Parameters.AddWithValue("@Tarih",dateTimePickerKurTarih.Value);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kur Ekleme işlemi Başarılı.");
                    baglan.Close();
                    txtKurAd.Clear();
                    txtKurSembol.Clear();
                    txtKurDeger.Clear();
                    txtKurAd.Focus();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnKurGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String KayitGuncelle = ("Update  Kur Set KurAd=@KurAd,Sembol=@Sembol," +
                        "Deger=@Deger,Tarih=@Tarih Where KurID=@id");
                    SqlCommand komut = new SqlCommand(KayitGuncelle, baglan);
                    komut.Parameters.AddWithValue("@KurAd", txtKurAd.Text);
                    komut.Parameters.AddWithValue("@Sembol", txtKurSembol.Text);
                    komut.Parameters.AddWithValue("@Deger", txtKurDeger.Text);
                    komut.Parameters.AddWithValue("@Tarih", dateTimePickerKurTarih.Value);
                    komut.Parameters.AddWithValue("@id", txtKurID.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kur Güncelleme işlemi Başarılı.");
                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnKurSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String sil = "Delete From Kur Where KurID=@id";
                    SqlCommand komut = new SqlCommand(sil, baglan);
                    komut.Parameters.AddWithValue("@id", txtKurID.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kur Silme işlemi Başarılı.");
                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnKurListele_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String getir = "Select * From Kur ";
                    SqlCommand komut = new SqlCommand(getir, baglan);
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

        private void btnBankaIslemList_Click(object sender, EventArgs e)
        {
            baglan.Close();
            if (baglan.State == ConnectionState.Closed)
                baglan.Open();
            String getir = "Select * From Hesaplar ";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                int HesapID = 3;
                dr.Close();
                getir = @"select h.Tarih,isnull(kh.HesapAd,m.AdSoyad)Aciklama,h.Tutar,h.HedefBakiye
from HesapHareketler h
inner join Hesaplar kh on h.KaynakHesap=kh.HesapID
left join Musteri m on kh.Musteri=m.MusteriID
inner join Hesaplar hh on h.HedefeHesap=hh.HesapID
where h.HedefeHesap=@HesapID and h.Tarih>=@BasTarih and h.Tarih<=@SonTarih
union all
select h.Tarih,isnull(hh.HesapAd,m.AdSoyad)Aciklama,h.Tutar*-1,h.KaynakBakiye
from HesapHareketler h
inner join Hesaplar kh on h.KaynakHesap=kh.HesapID
inner join Hesaplar hh on h.HedefeHesap=hh.HesapID
left join Musteri m on hh.Musteri=m.MusteriID
where h.KaynakHesap=@HesapID  and h.Tarih>=@BasTarih and h.Tarih<=@SonTarih
order by h.Tarih ";
                komut = new SqlCommand(getir, baglan);
                komut.Parameters.AddWithValue("@HesapID", HesapID);
                komut.Parameters.AddWithValue("@BasTarih", dateTimeBaslangic.Value);
                komut.Parameters.AddWithValue("@sonTarih", dateTimeBitis.Value);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                baglan.Close();
                decimal topGelen = 0;
                decimal topGiden = 0;
                decimal topKAR = 0;
                foreach (DataRow row in dt.Rows)
                {
                    decimal tutar = row.Field<decimal>("Tutar");
                    if (tutar > 0)
                    {
                        topGelen += tutar;
                    }
                    else
                    {
                        topGiden += (tutar * -1);
                    }
                    if (topGelen > topGiden)
                    {
                        topKAR = topGelen - topGiden;
                    }
                }
                txtTopGelen.Text = topGelen.ToString();
                txtTopGiden.Text = topGiden.ToString();
                txtKar.Text = topKAR.ToString();
            }


        }

        private void btnKrediFaizBelirle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String kayit = "Update Parametre set KrediFaizi=@KrediFaizi,GecikmeFaizi=@GecikmeFaizi";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@KrediFaizi", txtKrediFaizOrani.Text);
                    komut.Parameters.AddWithValue("@GecikmeFaizi", txtGecikmeFaizOran.Text);
                   
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kredi Faiz Oranı Eklendi.");
                    baglan.Close();
                    txtKrediFaizOrani.Clear();
                    txtGecikmeFaizOran.Clear();

                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();

                String KayitGuncelle = ("Update  Kredi Set Onaylandi=@Onay where KrediID=@KrediID");
                SqlCommand komut = new SqlCommand(KayitGuncelle, baglan);
                komut.Parameters.AddWithValue("@KrediID", txtKrediIDOnay.Text);
                komut.Parameters.AddWithValue("@Onay", 1);
                komut.ExecuteNonQuery();
                XtraMessageBox.Show("Onaylama işlemi Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //String getir="Select * from Hesaplar where "
                //int HesapID = (int)dr["HesapID"];
               // KayitGuncelle = ("update Hesaplar set Bakiye=@Bakiye where HesapID=@HesapID");

                baglan.Close();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnOnayListele_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();

                    String getir = "Select * From Kredi ";
                    SqlCommand komut = new SqlCommand(getir, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView4.DataSource = dt;
                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }
    }
    }

