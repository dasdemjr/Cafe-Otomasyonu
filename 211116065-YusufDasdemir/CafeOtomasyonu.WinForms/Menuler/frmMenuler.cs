﻿using DevExpress.XtraEditors;
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
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.Masalar;
using CafeOtomasyonu.WinForms.Roles;

namespace CafeOtomasyonu.WinForms.Menuler
{
    public partial class frmMenuler : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        public frmMenuler()
        {
            InitializeComponent();
            context.Menu.Load();
            gridControl1.DataSource = context.Menu.Local.ToBindingList();
            KullaniciYetki.AdminMi(context,btnKaydet,btnSil);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            gridView1.RefreshData();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
                context.SaveChanges();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMasaHareketleri_Click(object sender, EventArgs e)
        {
            int menuId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colId));
            frmMasaHareketleri frm = new frmMasaHareketleri(menuId: menuId);
            frm.ShowDialog();
        }
    }
}