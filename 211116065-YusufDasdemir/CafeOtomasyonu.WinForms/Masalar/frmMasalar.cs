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

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class frmMasalar : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        private MasalarDal masalarDal = new MasalarDal();
        public frmMasalar()
        {
            InitializeComponent();
            Listele();
        }

        private void Listele()
        {
            gridControl1.DataSource = masalarDal.MasalariListele(context);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            frmMasaKaydet frm = new frmMasaKaydet(new Entities.Models.Masalar());
            frm.ShowDialog();
            if (frm.kaydet)
            {
                Listele();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            int seciliid = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colId));
            var masalar = masalarDal.GetByFilter(context, m => m.Id == seciliid);
            frmMasaKaydet frm = new frmMasaKaydet(masalar);
            frm.ShowDialog();
            if (frm.kaydet)
            {
                Listele();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int seciliId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colId));
            if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                masalarDal.Delete(context, m => m.Id == seciliId);
                masalarDal.Save(context);
                Listele();
            }
        }

        private void btnRezerveDegis_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int seciliid = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colId));
                var masalar = masalarDal.GetByFilter(context, m => m.Id == seciliid);
                if (masalar.RezerveMi)
                {
                    masalar.RezerveMi = false;
                }
                else if (masalar.RezerveMi == false)
                {
                    masalar.RezerveMi = true;
                }
                masalarDal.Save(context);
                Listele();
            }
        }

        private void btnDurumDegis_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount>0)
            {
                int seciliid = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colId));
                var masalar = masalarDal.GetByFilter(context, m => m.Id == seciliid);
                if (masalar.Durumu)
                {
                    masalar.Durumu = false;
                }
                else if (masalar.Durumu == false)
                {
                    masalar.Durumu = true;
                } 
                masalarDal.Save(context);
                Listele();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMasaHareketleri_Click(object sender, EventArgs e)
        {
            int masaId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colId));
            frmMasaHareketleri frm = new frmMasaHareketleri(masaId:masaId);
            frm.ShowDialog();
        }
    }
}