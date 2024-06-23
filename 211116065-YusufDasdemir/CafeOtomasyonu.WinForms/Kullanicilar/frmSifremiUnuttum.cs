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
using CafeOtomasyonu.Entities.Mapping;

namespace CafeOtomasyonu.WinForms.Kullanicilar
{
    public partial class frmSifremiUnuttum : DevExpress.XtraEditors.XtraForm
    {
        CafeContext context = new CafeContext();
        KullanicilarDal kullanicilarDal = new KullanicilarDal();
        private KullaniciHareketleri kullaniciHareketleri = new KullaniciHareketleri();
        private KullaniciHareketleriDal kullaniciHareketleriDal = new KullaniciHareketleriDal();
        public frmSifremiUnuttum()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var entity = kullanicilarDal.GetByFilter(context,k=>k.KullaniciAdi==txtKAdi.Text || k.Email == txtKAdi.Text);
            if (entity != null)
            {
                if (entity.HatirlatmaSorusu == txtHatSorusu.Text && entity.Cevap == txtCevap.Text)
                {
                    if (txtSifre.Text == txtSifreTekrar.Text)
                    {
                        entity.Sifre = txtSifre.Text;
                        if (kullanicilarDal.AddOrUpdate(context,entity))
                        {
                            kullanicilarDal.Save(context);
                            kullaniciHareketleri.KullaniciId = entity.Id;
                            string aciklama = entity.KullaniciAdi + " adlı kullanıcının şifresi yenilendi";
                            kullaniciHareketleriDal.KullaniciHareketleriEkle(context, kullaniciHareketleri, aciklama);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Hatırlata Sorusu veya Cevanı hatalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}