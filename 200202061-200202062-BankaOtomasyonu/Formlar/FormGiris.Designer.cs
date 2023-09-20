
namespace _200202061_200202062_BankaOtomasyonu.Formlar
{
    partial class FormGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGiris));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtNameSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnYoneticiGiris = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPersonelGiris = new DevExpress.XtraEditors.SimpleButton();
            this.btnMusteriGiris = new DevExpress.XtraEditors.SimpleButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtNameSurname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(345, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 189);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giriş Bilgileri";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(208, 84);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(173, 26);
            this.txtPassword.TabIndex = 7;
            // 
            // txtNameSurname
            // 
            this.txtNameSurname.Location = new System.Drawing.Point(206, 34);
            this.txtNameSurname.Name = "txtNameSurname";
            this.txtNameSurname.Size = new System.Drawing.Size(173, 26);
            this.txtNameSurname.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Şifre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ad Soyad:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnYoneticiGiris);
            this.groupBox2.Controls.Add(this.BtnPersonelGiris);
            this.groupBox2.Controls.Add(this.btnMusteriGiris);
            this.groupBox2.Location = new System.Drawing.Point(158, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(769, 134);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giris";
            // 
            // BtnYoneticiGiris
            // 
            this.BtnYoneticiGiris.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnYoneticiGiris.ImageOptions.Image")));
            this.BtnYoneticiGiris.Location = new System.Drawing.Point(553, 45);
            this.BtnYoneticiGiris.Name = "BtnYoneticiGiris";
            this.BtnYoneticiGiris.Size = new System.Drawing.Size(200, 52);
            this.BtnYoneticiGiris.TabIndex = 2;
            this.BtnYoneticiGiris.Text = "Yönetici Giriş";
            this.BtnYoneticiGiris.Click += new System.EventHandler(this.BtnYoneticiGiris_Click);
            // 
            // BtnPersonelGiris
            // 
            this.BtnPersonelGiris.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnPersonelGiris.ImageOptions.Image")));
            this.BtnPersonelGiris.Location = new System.Drawing.Point(302, 45);
            this.BtnPersonelGiris.Name = "BtnPersonelGiris";
            this.BtnPersonelGiris.Size = new System.Drawing.Size(200, 52);
            this.BtnPersonelGiris.TabIndex = 1;
            this.BtnPersonelGiris.Text = "Personel Giriş";
            this.BtnPersonelGiris.Click += new System.EventHandler(this.BtnPersonelGiris_Click);
            // 
            // btnMusteriGiris
            // 
            this.btnMusteriGiris.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMusteriGiris.ImageOptions.Image")));
            this.btnMusteriGiris.Location = new System.Drawing.Point(41, 45);
            this.btnMusteriGiris.Name = "btnMusteriGiris";
            this.btnMusteriGiris.Size = new System.Drawing.Size(200, 52);
            this.btnMusteriGiris.TabIndex = 0;
            this.btnMusteriGiris.Text = "Müşteri Girişi";
            this.btnMusteriGiris.Click += new System.EventHandler(this.btnMusteriGiris_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(56, 135);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(121, 24);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Şifre Göster";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGiris";
            this.Text = "FormGiris";
            this.Load += new System.EventHandler(this.FormGiris_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNameSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnMusteriGiris;
        private DevExpress.XtraEditors.SimpleButton BtnYoneticiGiris;
        private DevExpress.XtraEditors.SimpleButton BtnPersonelGiris;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}