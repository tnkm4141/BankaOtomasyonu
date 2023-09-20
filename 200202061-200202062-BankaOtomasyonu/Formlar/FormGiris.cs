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
    public partial class FormGiris : Form
    {
        SqlConnection con;
        SqlCommand com;
        //SqlDataAdapter da;
        SqlDataReader dr;
       
        public FormGiris()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormGiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnYoneticiGiris_Click(object sender, EventArgs e)
        {
            String AdSoyad = "Admin";
            String Sifre = "2022";
            String AdSoyad1 = txtNameSurname.Text;
            String Sifre1 = txtPassword.Text;

            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            Panel Panel1 = form1.Controls["Panel1"] as Panel;
            Panel1.Controls.Clear();
            if (AdSoyad==AdSoyad1 && Sifre==Sifre1) {
                XtraMessageBox.Show("Yonetici" + AdSoyad + "Olarak Giriş yapıldı");
                Formlar.FormYonetici fr = new Formlar.FormYonetici();
                fr.TopLevel = false;
                Panel1.Controls.Add(fr);
                fr.Show();
                fr.Dock = DockStyle.Fill; 
            }
            else
            {
                XtraMessageBox.Show("Hata Oluştu Tekrar Deneyiniz!!");
                Formlar.FormGiris fr = new Formlar.FormGiris();
                fr.TopLevel = false;
                Panel1.Controls.Add(fr);
                fr.Show();
                fr.Dock = DockStyle.Fill;
                txtNameSurname.Clear();
                txtPassword.Clear();
                txtNameSurname.Focus();
            }
        }

        private void BtnPersonelGiris_Click(object sender, EventArgs e)
        {
            String AdSoyad = txtNameSurname.Text;
            String Sifre = txtPassword.Text;

            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            Panel Panel1 = form1.Controls["Panel1"] as Panel;
            Panel1.Controls.Clear();

            con = new SqlConnection("Data Source=LAPTOP-GML3BQ0N\\SQLEXPRESS2;Initial Catalog=DbBanka;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*From Personel where AdSoyad= '" + AdSoyad+"' And Sifre='"+ Sifre +"'";
            dr = com.ExecuteReader();
            if (dr.Read()) {
                XtraMessageBox.Show("Personel "+AdSoyad+"Olarak Giriş yapıldı");
                Formlar.FormPersonel fr = new Formlar.FormPersonel();
                fr.PersonelID = (int)dr["PersonelID"];
                fr.TopLevel = false;
                Panel1.Controls.Add(fr);
                fr.Show();
                fr.Dock = DockStyle.Fill;
            }
            else
            {
                XtraMessageBox.Show("Hata Oluştu Tekrar Deneyiniz!!");
                Formlar.FormGiris fr = new Formlar.FormGiris();
                fr.TopLevel = false;
                Panel1.Controls.Add(fr);
                fr.Show();
                fr.Dock = DockStyle.Fill;
                txtNameSurname.Clear();
                txtPassword.Clear();
                txtNameSurname.Focus();

            }
            con.Close();
        }

        private void btnMusteriGiris_Click(object sender, EventArgs e)
        {
            String AdSoyad = txtNameSurname.Text;
            String Sifre = txtPassword.Text;

            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            Panel Panel1 = form1.Controls["Panel1"] as Panel;
            Panel1.Controls.Clear();

            con = new SqlConnection("Data Source=LAPTOP-GML3BQ0N\\SQLEXPRESS2;Initial Catalog=DbBanka;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*From Musteri where AdSoyad= '" + AdSoyad + "' And Sifre='" + Sifre + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                XtraMessageBox.Show("Müşteri "+AdSoyad+"Olarak Giriş yapıldı");
                Formlar.FormMusteri fr = new Formlar.FormMusteri();
                fr.MusteriID = (int)dr["MusteriID"];
                fr.TopLevel = false;
                Panel1.Controls.Add(fr);
                fr.Show();
                fr.Dock = DockStyle.Fill;
            }
            else
            {
                XtraMessageBox.Show("Hata Oluştu Tekrar Deneyiniz!!");
                Formlar.FormGiris fr = new Formlar.FormGiris();
                fr.TopLevel = false;
                Panel1.Controls.Add(fr);
                fr.Show();
                fr.Dock = DockStyle.Fill;
                txtNameSurname.Clear();
                txtPassword.Clear();
                txtNameSurname.Focus();


            }
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState==CheckState.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
