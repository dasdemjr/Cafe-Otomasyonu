using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.Odemeler;
using CafeOtomasyonu.WinForms.RaporDosyalari;
using CafeOtomasyonu.WinForms.RaporFormlari;
using CafeOtomasyonu.WinForms.Urunler;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class frmMasaSiparisleri : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        private MusterilerDal musterilerDal = new MusterilerDal();
        private MasaHareketleriDal masaHareketleriDal = new MasaHareketleriDal();
        int? _masaId = null;
        private string _satisKodu = null;
        private OdemeHareketleriDal odemeHareketleriDal = new OdemeHareketleriDal();
        private Entities.Models.Satislar satislar;
        private SatislarDal satislarDal = new SatislarDal();
        private Entities.Models.Masalar masalar;
        private MasalarDal masalarDal = new MasalarDal();
        UrunDal urunDal = new UrunDal();
        private bool _paketSiparis = false;
        private bool yazdir;
        frmUrunSec frm = new frmUrunSec();
        private MenuDal menuDal = new MenuDal();

        public frmMasaSiparisleri(int? masaId = null, string masaAdi = null, string satiskodu = null, bool paketSiparis = false)
        {
            InitializeComponent();
            _satisKodu = satiskodu;
            _paketSiparis = paketSiparis;
            _masaId = masaId;
            context.MasaHareketleri.Where(m => m.SatisKodu == _satisKodu).Load();
            context.OdemeHareketleri.Where(o => o.SatisKodu == _satisKodu).Load();
            gridControlSiparisler.DataSource = context.MasaHareketleri.Local.ToBindingList();
            gridControlOdemeler.DataSource = context.OdemeHareketleri.Local.ToBindingList();
            context.Urun.Load();
            lookUpMusteri.Properties.DataSource = musterilerDal.GetAll(context);
            if (_masaId != null)
            {
                lblBaslik.Text = masaAdi + " Siparişleri";
                masalar = masalarDal.GetByFilter(context, m => m.Id == _masaId);
            }
            else if (_masaId == null)
            {
                lblBaslik.Text = "Paket Siparişi veya Versiye İşlmeleri";
            }

            satislar = satislarDal.GetByFilter(context, s => s.SatisKodu == _satisKodu);
            if (satislar != null)
            {
                lookUpMusteri.EditValue = satislar.MusteriId;
                txtAciklama.Text = satislar.Aciklama;
                dateEditTarih.Text = satislar.SonIslemTarihi.ToString("dd.MM.yyyy");
            }
            HizliSatis();

        }

        public void HizliSatis()
        {
            var model = menuDal.GetAll(context);
            foreach (var item in model)
            {
                var page = new XtraTabPage();
                page.Text = item.MenuAdi;
                page.Name = item.Id.ToString();
                xtraTabControl1.TabPages.Add(page);
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Dock = DockStyle.Fill;
                page.Controls.Add(panel);

                var modelHizliSatis = urunDal.GetAll(context, u => u.HizliSatis && u.MenuId == item.Id);
                foreach (var urun in modelHizliSatis)
                {
                    SimpleButton btn = new SimpleButton();
                    btn.Text = urun.UrunAdi;
                    btn.Name = urun.Id.ToString();
                    btn.Appearance.TextOptions.VAlignment = VertAlignment.Bottom;
                    btn.Appearance.BackColor = Control.DefaultBackColor;
                    btn.BorderStyle = BorderStyles.NoBorder;
                    var image = Image.FromFile(urun.Resim);
                    ımageList1.Images.Add(image);
                    btn.ImageToTextAlignment = ImageAlignToText.TopCenter;
                    btn.ImageList = ımageList1;
                    btn.Image = ımageList1.Images[0];
                    btn.Size = new Size(150, 150);
                    panel.Controls.Add(btn);
                    ımageList1.Images.RemoveAt(0);

                    btn.Click += Btn_Click;
                }

            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var senderbtn = sender as SimpleButton;

            int urunId = Convert.ToInt32(senderbtn.Name);

            var model = urunDal.GetByFilter(context, u => u.Id == urunId);

            MasaHareketleri entity = new MasaHareketleri
            {
                SatisKodu = _satisKodu,
                UrunId = urunId,
                MasaId = _masaId,
                Miktari = 1,
                indirimOrani = 0,
                BirimFiyati = Fiyat(model),
                Aciklama = " ",
                Tarih = DateTime.Now
            };
            masaHareketleriDal.AddOrUpdate(context, entity);
        }

        void Hesapla()
        {
            calcIndirimToplami.Value = Convert.ToDecimal(colindirimTutari2.SummaryItem.SummaryValue);
            calcIndirimliToplam.Value = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue);
            calcOdenen.Value = Convert.ToDecimal(colOdenen.SummaryItem.SummaryValue);
            //calcToplam.Value = calcIndirimToplami.Value + calcIndirimliToplam.Value;
            calcToplam.Value = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue) +
                               Convert.ToDecimal(colindirimTutari2.SummaryItem.SummaryValue);
            calcKalan.Value = calcIndirimliToplam.Value - calcOdenen.Value;

            if (calcToplam.Value != 0)
            {
                calcIndirimOran.Value = 100 * Convert.ToDecimal(colindirimTutari2.SummaryItem.SummaryValue) /
                                        (Convert.ToDecimal(colTutar.SummaryItem.SummaryValue) +
                                         Convert.ToDecimal(colindirimTutari2.SummaryItem.SummaryValue));
            }
            else if (calcToplam.Value == 0)
            {
                calcIndirimOran.Value = 0;
            }

        }

        private void btnMusteriTemizle_Click(object sender, EventArgs e)
        {
            lookUpMusteri.EditValue = null;
        }

        private void repositorySiparisSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili siparişin silinmesini onaylıyor musunuz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gridViewSiparisler.DeleteSelectedRows();
                Hesapla();
            }
        }

        private void repositoryOdemeSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili ödemenin silinmesini onaylıyor musunuz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gridViewOdemeler.DeleteSelectedRows();
                Hesapla();
            }
        }

        decimal Fiyat(Urun model)
        {
            decimal birimfiyat = model.BirimFiyati1;
            var modelprogram = context.ProgramAyarlari.FirstOrDefault(p => p.AyarTanimi == "Birim Fiyatı");
            if (modelprogram != null)
            {
                switch (modelprogram.AyarAdi)
                {
                    case "BirimFiyati1":
                        birimfiyat = model.BirimFiyati1;
                        break;
                    case "BirimFiyati2":
                        birimfiyat = model.BirimFiyati2;
                        break;
                    case "BirimFiyati3":
                        birimfiyat = model.BirimFiyati3;
                        break;
                }
            }
            return birimfiyat;
        }
        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            frm.ShowDialog();
            if (frm.secildi)
            {
                MasaHareketleri entity = new MasaHareketleri
                {
                    SatisKodu = _satisKodu,
                    MasaId = _masaId,
                    UrunId = frm.urunModel.Id,
                    Miktari = 1,
                    BirimFiyati = Fiyat(frm.urunModel),
                    indirimOrani = 0,
                    Aciklama = "",
                    Tarih = DateTime.Now
                };
                masaHareketleriDal.AddOrUpdate(context, entity);
            }
        }



        private void gridViewSiparisler_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            Hesapla();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (gridViewSiparisler.RowCount > 0)
            {
                if (dateEditTarih.EditValue != null)
                {
                    if (satislar == null)
                    {
                        satislar = new Entities.Models.Satislar();
                        satislar.SatisKodu = _satisKodu;
                    }

                    satislar.MusteriId = (int?)lookUpMusteri.EditValue;
                    satislar.Aciklama = txtAciklama.Text;
                    satislar.SonIslemTarihi = Convert.ToDateTime(dateEditTarih.EditValue);
                    satislar.Kalan = calcKalan.Value;
                    satislar.Odenen = calcOdenen.Value;
                    satislar.Tutar = calcToplam.Value;
                    satislar.indirimToplami = calcIndirimToplami.Value;
                    satislar.PaketSiparisMi = _paketSiparis;
                    satislarDal.AddOrUpdate(context, satislar);
                    context.SaveChanges();
                    yazdir = true;
                }
                else
                {
                    MessageBox.Show("Lütfen bir tarih seçiniz", "Uyarı!", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Herhangi bir sipariş bulunamadı", "Uyarı!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void Odemeler_Click(object sender, EventArgs e)
        {
            if (gridViewSiparisler.RowCount > 0)
            {
                var btn = sender as SimpleButton;
                frmOdeme frm = new frmOdeme(btn.Text, _satisKodu, calcKalan.Value);
                frm.ShowDialog();
                if (frm.kaydedildi)
                {
                    if (odemeHareketleriDal.AddOrUpdate(context, frm.odemeHareketleri))
                    {
                        gridViewOdemeler.RefreshData();
                        Hesapla();
                    }
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewOdemeler_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            Hesapla();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void btnSonuclandir_Click(object sender, EventArgs e)
        {
            if (gridViewSiparisler.RowCount > 0)
            {
                if (_masaId != null)
                {
                    if (calcKalan.Value > 0)
                    {
                        if (MessageBox.Show("Bu işlemi onaylarsanız müşteriye borç işlemi kaydedilecektir.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (satislar != null)
                            {
                                if (satislar.MusteriId == null)
                                {
                                    MessageBox.Show("Önce müşteri seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    Sonuclandir();
                                    this.Close();
                                }
                            }

                        }
                    }
                    else if (calcKalan.Value == 0)
                    {
                        Sonuclandir();
                        this.Close();
                    }
                }
            }
        }

        private void Sonuclandir()
        {
            masalar.SatisKodu = null;
            masalar.Durumu = false;
            masalar.Islem = null;
            masalar.RezerveMi = false;
            masalar.KullaniciId = null;
            masalarDal.AddOrUpdate(context, masalar);
            masalarDal.Save(context);
        }

        private void repositoryFiyat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int urunId = Convert.ToInt32(gridViewSiparisler.GetFocusedRowCellValue(colUrunId));
            var model = urunDal.GetByFilter(context, u => u.Id == urunId);
            barFiyat1.Caption = model.BirimFiyati1.ToString();
            barFiyat2.Caption = model.BirimFiyati2.ToString();
            barFiyat3.Caption = model.BirimFiyati3.ToString();


            radialMenu1.ShowPopup(MousePosition);
        }

        private void Fiyatlar(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewSiparisler.SetFocusedRowCellValue(colBirimFiyati, e.Item.Caption);
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            btnKaydet.PerformClick();

            if (yazdir)
            {
                if (_masaId != null)
                {
                    rptSiparisFisi rpt = new rptSiparisFisi(_satisKodu, masalar.MasaAdi, satislar);
                    frmRaporGoruntule frm = new frmRaporGoruntule(rpt);
                    frm.ShowDialog();
                }
                else if (_masaId == null)
                {
                    if (satislar.MusteriId == null)
                    {
                        rptSiparisFisi rpt = new rptSiparisFisi(_satisKodu, _satisKodu, satislar);
                        frmRaporGoruntule frm = new frmRaporGoruntule(rpt);
                        frm.ShowDialog();
                    }
                    else if (satislar.MusteriId != null)
                    {
                        rptSiparisFisi rpt = new rptSiparisFisi(_satisKodu, satislar.Musteriler.AdiSoyadi, satislar);
                        frmRaporGoruntule frm = new frmRaporGoruntule(rpt);
                        frm.ShowDialog();
                    }

                }
            }
            else
            {
                MessageBox.Show("Lütfen kaydetme işlemini tamamlayın", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        
    }
}