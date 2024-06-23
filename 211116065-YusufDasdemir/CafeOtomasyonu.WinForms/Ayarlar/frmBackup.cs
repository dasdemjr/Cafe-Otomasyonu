using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.Models;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace CafeOtomasyonu.WinForms.Ayarlar
{
    public partial class frmBackup : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        public frmBackup()
        {
            InitializeComponent();
            Server sunucu = new Server();
            var model = context.Database.SqlQuery<Database>("Select * from sys.databases").ToList();
            foreach (var item in model)
            {
                cmbVT.Properties.Items.Add(item.Name);
            }

            cmbVT.EditValue = "Cafe";
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Backup(Yedekleme) Dosyaları(*.bak)|*.bak";
            xtraSaveFileDialog1.Title = "Yedeklenecek Dosyalar";
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtYol.Text = xtraSaveFileDialog1.FileName;
            }
        }

        private void btnYedekAl_Click(object sender, EventArgs e)
        {
            progressBarControl1.EditValue = 0;
            try
            {
                if (File.Exists(txtYol.Text))
                {
                    File.Delete(txtYol.Text);
                }

                Server dbServer = new Server(new ServerConnection(txtSunucu.Text));
                Backup dBackup = new Backup();
                dBackup.Action = BackupActionType.Database;
                dBackup.Database = cmbVT.Text;
                dBackup.Devices.AddDevice(txtYol.Text,DeviceType.File);
                dBackup.Initialize = false;
                dBackup.PercentComplete += DBackup_PercentComplete;
                dBackup.Complete += DBackup_Complete;
                dBackup.SqlBackup(dbServer);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata\n" + exception.Message);
            }
        }

        private void DBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            MessageBox.Show("Yedekleme işlemi başarıyla tamamlandı");
            lblDurumu.Text = "Tamamlandı";
        }

        private void DBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBarControl1.EditValue = e.Percent;
            progressBarControl1.Update();
            lblYuzde.Text = $"{e.Percent} %";
        }
    }
}