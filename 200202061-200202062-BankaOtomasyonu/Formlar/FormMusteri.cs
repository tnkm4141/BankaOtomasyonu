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
    public partial class FormMusteri : Form
    {
        public int MusteriID { get; set; }
        public FormMusteri()
        {
            InitializeComponent();
        }
        static String constring = ("Data Source=LAPTOP-GML3BQ0N\\SQLEXPRESS2;Initial Catalog=DbBanka;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        decimal havaleUcreti = 5;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPane1_Click(object sender, EventArgs e)
        {

        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String getir = "Select * From Hesaplar where Musteri=@MusteriId and HesapNo=@HesapNo";
                    SqlCommand komut = new SqlCommand(getir, baglan);
                    komut.Parameters.AddWithValue("@MusteriId", MusteriID);
                    komut.Parameters.AddWithValue("@HesapNo", txtParaCekHesNo.Text);
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {

                        int HesapID = (int)dr["HesapID"];
                        decimal Bakiye = (decimal)dr["Bakiye"];
                        decimal tutar = decimal.Parse(txtParaCekMik.Text);
                        dr.Close();
                        if (tutar > Bakiye)
                        {
                            XtraMessageBox.Show("Hesabınızda Yeterli Bakiye Bulunmamaktadır\r\nBakiyeniz:" + Bakiye);
                            return;

                        }

                        String kayit = "INSERT INTO HesapHareketler(KaynakHesap,HedefeHesap,KaynakBakiye,HedefBakiye,Tarih,Tutar)" +
                            "values(@KaynakHesap,@HedefHesap,@KaynakBakiye,@HedefBakiye,@Tarih,@Tutar)";

                        komut = new SqlCommand(kayit, baglan);
                        komut.Parameters.AddWithValue("@KaynakHesap", HesapID);
                        komut.Parameters.AddWithValue("@HedefHesap", 2);
                        komut.Parameters.AddWithValue("@KaynakBakiye", (Bakiye - tutar));
                        komut.Parameters.AddWithValue("@HedefBakiye", 0);
                        komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                        komut.Parameters.AddWithValue("@Tutar", tutar);
                        komut.ExecuteNonQuery();
                        XtraMessageBox.Show("Hesap Bulundu");

                        kayit = "Update Hesaplar set Bakiye=@Bakiye where HesapID=@HesapID ";
                        komut = new SqlCommand(kayit, baglan);
                        komut.Parameters.AddWithValue("@Bakiye", (Bakiye - tutar));
                        komut.Parameters.AddWithValue("@HesapID", HesapID);
                        komut.ExecuteNonQuery();
                        XtraMessageBox.Show("Para Çekme İşlemi Başarılı");
                    }
                    else
                    {
                        XtraMessageBox.Show("Hesap Bulunamadı !!");
                    }
                    baglan.Close();
                    txtParaCekHesNo.Clear();
                    txtParaCekMik.Clear();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnHesapEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String kayit = "INSERT INTO Hesaplar(HesapNo,Tarih,KurID)values(@HesapNo," +
                        "@Tarih,@KurID)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@HesapNo", txtYeniHesapNo.Text);
                    komut.Parameters.AddWithValue("@Tarih", txtYeniHesapTarih.Text);
                    komut.Parameters.AddWithValue("@KurID",txtYeniHesKurNo.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Hesap Ekleme işlemi Başarılı.");
                    baglan.Close();
                    txtYeniHesapNo.Clear();
                    txtYeniHesKurNo.Clear();
                }
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
                    String sil = "Delete From Hesaplar Where HesapNo=@HesapNo";
                    SqlCommand komut = new SqlCommand(sil, baglan);
                    komut.Parameters.AddWithValue("@HesapNo", txtHesapSilHesNo.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Hesap Silme işlemi Başarılı.");
                    baglan.Close();
                    txtHesapSilHesNo.Clear();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnHesapListele_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)//baglantı kapalıysa
                {
                    baglan.Open();
                    String getir = "Select * From Hesaplar where Musteri=@MusteriID ";
                    SqlCommand komut = new SqlCommand(getir, baglan);
                    komut.Parameters.AddWithValue("@MusteriID",MusteriID);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridHesaplarim.DataSource = dt;
                    baglan.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void BtnMusGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed) {
                    baglan.Open();
                    String KayitGuncelle = ("Update  Musteri Set AdSoyad=@AdSoyad,Telefon=@Telefon," +
                        "TC=@TC,Mail=@Mail,Sifre=@Sifre,Adres=@Adres Where MusteriID=@id");
                    SqlCommand komut = new SqlCommand(KayitGuncelle, baglan);
                    komut.Parameters.AddWithValue("@AdSoyad", txtMusAdSoyad.Text);
                    komut.Parameters.AddWithValue("@Telefon", txtMusTel.Text);
                    komut.Parameters.AddWithValue("@TC", txtMusTC.Text);
                    komut.Parameters.AddWithValue("@Mail", txtMusMail.Text);
                    komut.Parameters.AddWithValue("@Sifre", txtMusSifre.Text);
                    komut.Parameters.AddWithValue("@Adres", txtMusAdres.Text);
                    komut.Parameters.AddWithValue("@id", txtMusID.Text);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show(" Güncelleme işlemi Başarılı.");
                    baglan.Close();
                    txtMusAdSoyad.Clear();
                    txtMusTel.Clear();
                    txtMusTC.Clear();
                    txtMusAdres.Clear();
                    txtMusMail.Clear();
                    txtMusSifre.Clear();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnParaYat_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    String getir = "Select * From Hesaplar where Musteri=@MusteriId and HesapNo=@HesapNo";
                    SqlCommand komut = new SqlCommand(getir, baglan);
                    komut.Parameters.AddWithValue("@MusteriId", MusteriID);
                    komut.Parameters.AddWithValue("@HesapNo", txtParaYatHesNo.Text);
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {

                        int HesapID = (int)dr["HesapID"];
                        decimal Bakiye = (decimal)dr["Bakiye"];                                              
                         decimal tutar = decimal.Parse(txtParaYatMik.Text);
                            dr.Close();

                            String kayit = "INSERT INTO HesapHareketler(KaynakHesap,HedefeHesap,KaynakBakiye,HedefBakiye,Tarih,Tutar)" +
                                "values(@KaynakHesap,@HedefHesap,@KaynakBakiye,@HedefBakiye,@Tarih,@Tutar)";

                            komut = new SqlCommand(kayit, baglan);
                            komut.Parameters.AddWithValue("@KaynakHesap", 1);
                            komut.Parameters.AddWithValue("@HedefHesap", HesapID);
                            komut.Parameters.AddWithValue("@KaynakBakiye", 0);
                            komut.Parameters.AddWithValue("@HedefBakiye", (Bakiye + tutar));
                            komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                            komut.Parameters.AddWithValue("@Tutar", tutar);
                            komut.ExecuteNonQuery();
                            XtraMessageBox.Show("Hesap Bulundu.");

                            kayit = "Update Hesaplar set Bakiye=@Bakiye where HesapID=@HesapID ";
                            komut = new SqlCommand(kayit, baglan);
                            komut.Parameters.AddWithValue("@Bakiye", (Bakiye + tutar));
                            komut.Parameters.AddWithValue("@HesapID", HesapID);
                            komut.ExecuteNonQuery();
                            XtraMessageBox.Show("Para Yatırma İşlemi Başarılı.");
                            baglan.Close();
                        txtParaYatHesNo.Clear();
                        txtParaYatMik.Clear();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Hesap Bulunamadı !!");


                    }
                
            }
            catch (Exception hata)
           {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }

        }

        private void btnHavaleGönder_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();
                String getir = "Select * From Hesaplar where Musteri=@MusteriId and HesapNo=@HesapNo";
                SqlCommand komut = new SqlCommand(getir, baglan);
                komut.Parameters.AddWithValue("@MusteriId", MusteriID);
                komut.Parameters.AddWithValue("@HesapNo", txtKayHesap.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {

                    int HesapID = (int)dr["HesapID"];
                    decimal Bakiye = (decimal)dr["Bakiye"];
                    decimal tutar = decimal.Parse(txtHavaleMik.Text);
                    dr.Close();
                    if (tutar > Bakiye)
                    {
                        XtraMessageBox.Show("Hesabınızda Yeterli Bakiye Bulunmamaktadır\r\nBakiyeniz:" + Bakiye);
                        return;

                    }

                    getir = "Select * From Hesaplar where  HesapNo=@HesapNo";
                    komut = new SqlCommand(getir, baglan);
                    komut.Parameters.AddWithValue("@HesapNo", txtHedefHesap.Text);
                    dr = komut.ExecuteReader();
                    if (!dr.Read())
                    {
                        XtraMessageBox.Show("Hesap Bulunamadı.");
                        return;
                    }


                    int HedefHesapID = (int)dr["HesapID"];
                    decimal HedefBakiye = (decimal)dr["Bakiye"];
                    dr.Close();

                    String kayit = "INSERT INTO HesapHareketler(KaynakHesap,HedefeHesap,KaynakBakiye,HedefBakiye,Tarih,Tutar)" +
                    "values(@KaynakHesap,@HedefHesap,@KaynakBakiye,@HedefBakiye,@Tarih,@Tutar)";

                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@KaynakHesap", HesapID);
                    komut.Parameters.AddWithValue("@HedefHesap", HedefHesapID);
                    komut.Parameters.AddWithValue("@KaynakBakiye", (Bakiye - tutar));
                    komut.Parameters.AddWithValue("@HedefBakiye", (Bakiye + tutar));
                    komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    komut.Parameters.AddWithValue("@Tutar", tutar);
                    komut.ExecuteNonQuery();
                    
                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@KaynakHesap", HesapID);
                    komut.Parameters.AddWithValue("@HedefHesap", 3);
                    komut.Parameters.AddWithValue("@KaynakBakiye", (Bakiye - tutar-havaleUcreti));
                    komut.Parameters.AddWithValue("@HedefBakiye", (Bakiye + havaleUcreti));
                    komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    komut.Parameters.AddWithValue("@Tutar", havaleUcreti);
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Hesap Bulundu.");

                    kayit = "Update Hesaplar set Bakiye=@Bakiye where HesapID=@HesapID ";
                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@Bakiye", (Bakiye -tutar -havaleUcreti));
                    komut.Parameters.AddWithValue("@HesapID", HesapID);
                    komut.ExecuteNonQuery();                    

                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@Bakiye", (HedefBakiye + tutar));
                    komut.Parameters.AddWithValue("@HesapID", HedefHesapID);
                    komut.ExecuteNonQuery();

                    kayit = "Update Hesaplar set Bakiye=Bakiye+@Bakiye where HesapID=@HesapID ";
                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@Bakiye", (havaleUcreti));
                    komut.Parameters.AddWithValue("@HesapID", 3);
                    komut.ExecuteNonQuery();

                    XtraMessageBox.Show("Havale İşlemi Başarılı.");
                    txtHedefHesap.Clear();
                    txtKayHesap.Clear();
                    txtHavaleMik.Clear();
                }
                else
                {
                    XtraMessageBox.Show("Hesap Bulunamadı !!");

                }
            }
            catch(Exception hata)
            {
                XtraMessageBox.Show("Bir Hata var" + hata.Message);
            }
        }

        private void btnOzetListele_Click(object sender, EventArgs e)
        {
            baglan.Close();
            if (baglan.State == ConnectionState.Closed)
                baglan.Open();
            String getir = "Select * From Hesaplar where Musteri=@MusteriId and HesapNo=@HesapNo";
            SqlCommand komut = new SqlCommand(getir, baglan);
            komut.Parameters.AddWithValue("@MusteriId", MusteriID);
            komut.Parameters.AddWithValue("@HesapNo", txtHesaNoOzet.Text);
            SqlDataReader dr = komut.ExecuteReader();
            
            if (dr.Read())
            {
                int HesapID = (int)dr["HesapID"];
                txtBakiye.Text = dr["Bakiye"].ToString();

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
                dataGridHesapOzeti.DataSource = dt;
                baglan.Close();
                decimal topGelen = 0;
                decimal topGiden = 0;
                foreach(DataRow row in dt.Rows)
                {
                    decimal tutar =row.Field<decimal>("Tutar");
                    if (tutar > 0)
                    {
                        topGelen += tutar;
                    }
                    else
                    {
                        topGiden += (tutar * -1);
                    }
                    
                }
                txtTopGelen.Text = topGelen.ToString();
                txtTopGiden.Text = topGiden.ToString();
            }
     
            
        }

        private void tabNavigationPage4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKrediOde_Click(object sender, EventArgs e)
        {
           /* try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();
                String getir = "Select * From Hesaplar where Musteri=@MusteriId and HesapNo=@HesapNo";
                SqlCommand komut = new SqlCommand(getir, baglan);
                komut.Parameters.AddWithValue("@MusteriId", MusteriID);
                komut.Parameters.AddWithValue("@HesapNo", txtKrediHesNo.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {

                    int HesapID = (int)dr["HesapID"];
                    decimal Bakiye = (decimal)dr["Bakiye"];
                   // decimal tutar = decimal.Parse(txtKrediOdeMik.Text);
                    dr.Close();
                    if (tutar > Bakiye)
                    {
                        MessageBox.Show("Hesabınızda Yeterli Bakiye Bulunmamaktadır\r\nBakiyeniz:" + Bakiye);
                        return;

                    }

                    getir = "Select * From Hesaplar where  HesapNo=@HesapNo";
                    komut = new SqlCommand(getir, baglan);

                    komut.Parameters.AddWithValue("@HesapNo", txtHedefHesap.Text);
                    dr = komut.ExecuteReader();
                    if (!dr.Read())
                    {
                        MessageBox.Show("Hesap Bulunamadı.");
                        return;
                    }


                    int HedefHesapID = (int)dr["HesapID"];
                    decimal HedefBakiye = (decimal)dr["Bakiye"];
                    dr.Close();

                    String kayit = "INSERT INTO HesapHareketler(KaynakHesap,HedefeHesap,KaynakBakiye,HedefBakiye,Tarih,Tutar)" +
                    "values(@KaynakHesap,@HedefHesap,@KaynakBakiye,@HedefBakiye,@Tarih,@Tutar)";

                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@KaynakHesap", HesapID);
                    komut.Parameters.AddWithValue("@HedefHesap", HedefHesapID);
                    komut.Parameters.AddWithValue("@KaynakBakiye", (Bakiye - tutar));
                    komut.Parameters.AddWithValue("@HedefBakiye", (Bakiye + tutar));
                    komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    komut.Parameters.AddWithValue("@Tutar", tutar);

                    komut.ExecuteNonQuery();
                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@KaynakHesap", HesapID);
                    komut.Parameters.AddWithValue("@HedefHesap", 3);
                    komut.Parameters.AddWithValue("@KaynakBakiye", (Bakiye - tutar - havaleUcreti));
                    komut.Parameters.AddWithValue("@HedefBakiye", (Bakiye + havaleUcreti));
                    komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    komut.Parameters.AddWithValue("@Tutar", havaleUcreti);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hesap Bulundu.");



                    kayit = "Update Hesaplar set Bakiye=@Bakiye where HesapID=@HesapID ";


                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@Bakiye", (Bakiye - tutar - havaleUcreti));
                    komut.Parameters.AddWithValue("@HesapID", HesapID);
                    komut.ExecuteNonQuery();



                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@Bakiye", (HedefBakiye + tutar));
                    komut.Parameters.AddWithValue("@HesapID", HedefHesapID);
                    komut.ExecuteNonQuery();

                    kayit = "Update Hesaplar set Bakiye=Bakiye+@Bakiye where HesapID=@HesapID ";
                    komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@Bakiye", (havaleUcreti));
                    komut.Parameters.AddWithValue("@HesapID", 3);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Havale İşlemi Başarılı.");


                }
                else
                {
                    MessageBox.Show("Hesap Bulunamadı !!");


                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir Hata var" + hata.Message);
            }*/
        }

        private void txtMusID_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            String getir = "Select * from Musteri where MusteriID=@MusteriID";
            SqlCommand komut = new SqlCommand(getir, baglan);
            komut.Parameters.AddWithValue("@MusteriID", MusteriID);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtMusAdSoyad.Text = (String)dr["AdSoyad"];
                txtMusTel.Text = (String)dr["Telefon"];
                txtMusTC.Text = (String)dr["TC"];
                txtMusAdres.Text = (String)dr["Adres"];
                txtMusMail.Text = (String)dr["Mail"];
                txtMusSifre.Text = (String)dr["Sifre"];

            }
            baglan.Close();
        }
    }
}
