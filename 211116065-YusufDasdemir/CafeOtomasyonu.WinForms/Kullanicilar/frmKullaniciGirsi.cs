using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.WinTools;

namespace CafeOtomasyonu.WinForms.Kullanicilar
{
    public partial class frmKullaniciGirsi : DevExpress.XtraEditors.XtraForm
    {
        private bool giris;
        CafeContext context = new CafeContext();
        private KullaniciHareketleriDal kullaniciHareketleriDal = new KullaniciHareketleriDal();
        private KullaniciHareketleri entity = new KullaniciHareketleri();

        void BilgileriGetir()
        {
            if (Properties.Settings.Default.BeniHatirla == true)
            {
                txtKullaniciAdi.Text = Properties.Settings.Default.KullaniciAdi;
                txtSifre.Text = Properties.Settings.Default.Sifre;
                checkEdit1.Checked = true;
            }
            else
            {
                txtKullaniciAdi.Text = null;
                txtSifre.Text = null;
                checkEdit1.Checked = false;
            }
        }

        void BilgileriKaydet()
        {
            if (checkEdit1.Checked)
            {
                Properties.Settings.Default.KullaniciAdi = txtKullaniciAdi.Text;
                Properties.Settings.Default.Sifre = txtSifre.Text;
                Properties.Settings.Default.BeniHatirla = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.KullaniciAdi = null;
                Properties.Settings.Default.Sifre = null;
                Properties.Settings.Default.BeniHatirla = false;
                Properties.Settings.Default.Save();
            }
        }

        public frmKullaniciGirsi()
        {
            InitializeComponent();
            BilgileriGetir();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var model = context.Kullanicilar.FirstOrDefault(k =>
                k.KullaniciAdi == txtKullaniciAdi.Text && k.Sifre == txtSifre.Text);
            if (model != null)
            {
                giris = true;
                BilgileriKaydet();
                KullaniciAyarlari.kullaniciId = model.Id;
                entity.KullaniciId = model.Id;
                string aciklama = model.KullaniciAdi+" adlı kullanıcı sisteme giriş yaptı";
                kullaniciHareketleriDal.KullaniciHareketleriEkle(context,entity,aciklama);

                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            frmSifremiUnuttum frm = new frmSifremiUnuttum();
            frm.ShowDialog();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (!giris)
            {
                Application.Exit();
            }

        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            frmKaydol frm = new frmKaydol(new Entities.Models.Kullanicilar());
            frm.ShowDialog();
        }
    }
}