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

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class frmMasaDurumlari : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        private CheckButton btnsender;
        private SatisKodu modelSatisKodu;
        private string _satisKodu;
        private int _masaId;
        private Entities.Models.Masalar masalar;
        private MasalarDal masalarDal = new MasalarDal();

        public frmMasaDurumlari()
        {
            InitializeComponent();
            modelSatisKodu = context.SatisKodu.First();
            MasalariGetir();
        }

        public void MasalariGetir()
        {
            flowLayoutPanel1.Controls.Clear();
            context = new CafeContext();
            var model = context.Masalar.ToList();
            for (int i = 0; i < model.Count; i++)
            {
                var btn = new CheckButton();
                btn.Text = model[i].MasaAdi;
                btn.Name = model[i].Id.ToString();
                btn.Tag = model[i].SatisKodu;
                btn.Height = 100;
                btn.Width = 80;
                flowLayoutPanel1.Controls.Add(btn);

                if (model[i].RezerveMi && !model[i].Durumu)
                {
                    btn.Appearance.BackColor = Color.Yellow;
                }
                else if (model[i].Durumu)
                {
                    btn.Appearance.BackColor = Color.Red;
                }
                else if (!model[i].Durumu)
                {
                    btn.Appearance.BackColor = Color.Green;
                }

                btn.Click += Btn_Click;
            }
        }

        public void DurumlariYenile()
        {
            btnSiparisler.Enabled = false;
            btnMasaAc.Enabled = false;
            btnRezervEt.Enabled = false;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            btnsender = sender as CheckButton;
            _masaId = Convert.ToInt32(btnsender.Name);
            DurumlariYenile();
            if (btnsender.Appearance.BackColor == Color.Yellow)
            {
                btnMasaAc.Enabled = true;
            }
            else if (btnsender.Appearance.BackColor == Color.Green)
            {
                btnMasaAc.Enabled = true;
                btnRezervEt.Enabled = true;
            }
            else if (btnsender.Appearance.BackColor == Color.Red)
            {
                btnSiparisler.Enabled = true;
            }
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            _satisKodu = btnsender.Tag.ToString();
            frmMasaSiparisleri frm = new frmMasaSiparisleri(masaId: _masaId, masaAdi: btnsender.Text, satiskodu: _satisKodu);
            frm.ShowDialog();
            btnsender = null;
            DurumlariYenile();
            MasalariGetir();
        }

        private void btnMasaAc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(btnsender.Text + " Açılsın mı?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                masalar = masalarDal.GetByFilter(context, m => m.Id == _masaId);
                masalar.SatisKodu = modelSatisKodu.SatisTanimi + modelSatisKodu.Sayi;
                masalar.Durumu = true;
                masalar.RezerveMi = false;
                var sayiarttir = context.SatisKodu.First();
                sayiarttir.Sayi++;
                masalarDal.Save(context);
                btnsender = null;
                DurumlariYenile();
                MasalariGetir();
                modelSatisKodu = context.SatisKodu.First();
            }
        }

        private void btnRezervEt_Click(object sender, EventArgs e)
        {
            frmMasaRezerv frm = new frmMasaRezerv(_masaId);
            frm.ShowDialog();
            if (frm.islemYapildi)
            {
                MasalariGetir();
            }
            DurumlariYenile();
            btnsender = null;
        }
    }
}