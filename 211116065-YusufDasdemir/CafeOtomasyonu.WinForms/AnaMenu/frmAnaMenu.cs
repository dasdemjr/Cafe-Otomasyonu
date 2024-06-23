using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.Kullanicilar;
using CafeOtomasyonu.WinForms.Masalar;
using CafeOtomasyonu.WinForms.Menuler;
using CafeOtomasyonu.WinForms.Musteriler;
using CafeOtomasyonu.WinForms.Odemeler;
using CafeOtomasyonu.WinForms.RaporDosyalari;
using CafeOtomasyonu.WinForms.RaporFormlari;
using CafeOtomasyonu.WinForms.Roles;
using CafeOtomasyonu.WinForms.Satislar;
using CafeOtomasyonu.WinForms.Urunler;
using DevExpress.XtraEditors;
using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Tools;
using CafeOtomasyonu.WinForms.Ayarlar;
using CafeOtomasyonu.WinForms.WinTools;

namespace CafeOtomasyonu.WinForms.AnaMenu
{
    public partial class frmAnaMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private CafeContext context = new CafeContext();
        private KullanicilarDal kullanicilarDal = new KullanicilarDal();
        void FormGetir(XtraForm frm)
        {
            frm.MdiParent = this;
            frm.Show();
        }
        public frmAnaMenu()
        {
            InitializeComponent();

            ConnectionTools.VerileriDoldur(context);

            if (!context.Kullanicilar.Any(k => k.KullaniciAdi == "Admin"))
            {
                Entities.Models.Kullanicilar model = new Entities.Models.Kullanicilar
                {
                    AdSoyad = "Admin Deneme",
                    Telefon = "5315649789",
                    Adres = "Admin Adres Deneme",
                    Email = "adminmail@gmail.com",
                    Gorevi = "Deneme Görev",
                    KullaniciAdi = "Admin",
                    Sifre = "Admin123",
                    HatirlatmaSorusu = "1",
                    Cevap = "1",
                    KayitTarihi = DateTime.Now,
                    IsAdmin = true
                };
                context.Kullanicilar.Add(model);
                context.SaveChanges();

                foreach (var item in ribbon.Items)
                {
                    if (item is BarButtonItem)
                    {
                        var btn = item as BarButtonItem;
                        if (btn.Caption != "")
                        {
                            Roller rol = new Roller
                            {
                                KullaniciId = 1,
                                FormName = "frmAnaMenu",
                                ControlCaption = btn.Caption,
                                ControlName = btn.Name,
                                Visible = true
                            };
                            context.Roller.Add(rol);
                            context.SaveChanges();
                        }
                    }
                }

            }
        }

        private frmUrunler frm1;
        private frmMasalar frm2;
        private frmMasaDurumlari frm3;
        private frmMusteriler frm4;
        private frmSatislar frm5;
        private frmOdemeHareketleri frm6;
        private frmMasaHareketleri frm7;
        private frmDashboard frm8;
        private frmKullanicilar frm9;
        private frmGrafik frm10;
        private void btnUrunler_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm1 == null || frm1.IsDisposed)
            {
                frm1 = new frmUrunler();
                frm1.MdiParent = this;
                frm1.Show();
            }
            // frmUrunler frm = new frmUrunler();
            // FormGetir(frm);
        }

        private void btnMenuler_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMenuler frm = new frmMenuler();
            frm.ShowDialog();
        }

        private void btnMasalar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new frmMasalar();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void btnMasaSiparisleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new frmMasaDurumlari();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        private void btnMusteriler_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new frmMusteriler();
                frm4.MdiParent = this;
                frm4.Show();
            }

        }

        private void btnSatislar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new frmSatislar();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }

        private void btnOdemeHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed)
            {
                frm6 = new frmOdemeHareketleri();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }

        private void btnPaketSiparis_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Paket sipariş işlemini onaylıyor musunuz ? ", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var model = context.SatisKodu.First();
                string satisKodu = model.SatisTanimi + model.Sayi;
                model.Sayi++;
                context.SaveChanges();
                frmMasaSiparisleri frm = new frmMasaSiparisleri(satiskodu: satisKodu, paketSiparis: true);
                frm.ShowDialog();
            }
        }

        private void btnMasaHareketleriRapor_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptMasaHareketleri report = new rptMasaHareketleri();
            frmRaporGoruntule2 frm = new frmRaporGoruntule2(report);
            frm.ShowDialog();
        }

        private void btnOzelRapor_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmOzelRaporOlustur frm = new frmOzelRaporOlustur();
            frm.ShowDialog();
        }

        private void btnMenuHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnMasaHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm7 == null || frm7.IsDisposed)
            {
                frm7 = new frmMasaHareketleri();
                frm7.MdiParent = this;
                frm7.Show();
            }
        }

        private void btnDashBoard_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm8 == null || frm8.IsDisposed)
            {
                frm8 = new frmDashboard();
                frm8.MdiParent = this;
                frm8.Show();
            }
        }

        private void frmAnaMenu_Load(object sender, EventArgs e)
        {
            frmKullaniciGirsi frm = new frmKullaniciGirsi();
            frm.ShowDialog();
            KullaniciYetki.YetkileriGetir(context, ribbon);
        }

        private void btnKullanicilar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm9 == null || frm9.IsDisposed)
            {
                frm9 = new frmKullanicilar();
                frm9.MdiParent = this;
                frm9.Show();
            }
        }

        private void btnBilgilerim_ItemClick(object sender, ItemClickEventArgs e)
        {
            var model = kullanicilarDal.GetByFilter(context, k => k.Id == KullaniciAyarlari.kullaniciId);

            frmKullaniciKaydet frm = new frmKullaniciKaydet(model,"dfd");
            frm.ShowDialog();
        }

        private void btnAyarlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAyarlar frm = new frmAyarlar();
            frm.ShowDialog();
        }

        private void btnYedekle_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBackup frm = new frmBackup();
            frm.ShowDialog();
        }

        private void btnGrafik_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm10 == null || frm10.IsDisposed)
            {
                frm10 = new frmGrafik();
                frm10.MdiParent = this;
                frm10.Show();
            }
        }
    }
}