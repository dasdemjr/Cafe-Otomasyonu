using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.Migrations;
using CafeOtomasyonu.Entities.Models;
using Menu = CafeOtomasyonu.Entities.Models.Menu;

namespace CafeOtomasyonu.Entities.Tools
{
    public class ConnectionTools
    {
        public static string baglan()
        {
            string readStr;
            string path = @"ConnectionStr\baglanti.txt";
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            using (var reader=new StreamReader(fileStream))
            {
                string row = reader.ReadLine();
                readStr = row;
                reader.Close();
            }
            fileStream.Close();
            return readStr;
        }
        public static void BaglantiKontrol()
        {
            using (var context = new CafeContext())
            {
                if (!context.Database.Exists())
                {
                    MessageBox.Show("Veritabanı oluşturulacak. Daha sonra ayrı bir forma yönlendirileceksiniz");
                    context.Database.CreateIfNotExists();
                }
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<CafeContext, Entities.Migrations.Configuration>());
            }
        }

        public static void VerileriDoldur(CafeContext context)
        {
            if (!context.Masalar.Any())
            {
                List<Masalar> list = new List<Masalar>()
                {
                    new Masalar
                    {
                        MasaAdi = "Masa-1",
                        Aciklama = "A Grubu 1. Sıra",
                        Islem = "Masa-1 Oluşturuldu"
                    },
                    new Masalar
                    {
                        MasaAdi = "Masa-2",
                        Aciklama = "A Grubu 2. Sıra",
                        Islem = "Masa-2 Oluşturuldu"
                    },
                    new Masalar
                    {
                        MasaAdi = "Masa-3",
                        Aciklama = "A Grubu 3. Sıra",
                        Islem = "Masa-3 Oluşturuldu"
                    }

                };
                context.Masalar.AddRange(list);
            }
            if (!context.Menu.Any())
            {
                List<Menu> menuList = new List<Menu>()
                {
                    new Menu
                    {
                        MenuAdi = "Soğuk İçecekler",
                        Aciklama = "Soğuk İçecekler Grubu"
                    },
                    new Menu
                    {
                        MenuAdi = "Sıcak İçecekler",
                        Aciklama = "Sıcak İçecekler Grubu"
                    },
                    new Menu
                    {
                        MenuAdi = "Tatlılar",
                        Aciklama = "Tatlılar Grubu"
                    }
                };
                context.Menu.AddRange(menuList);
            }

            if (!context.SatisKodu.Any())
            {
                List<SatisKodu> satisKoduList = new List<SatisKodu>
                {
                    new SatisKodu
                    {
                        SatisTanimi = "Satis",
                        Sayi = 1
                    }
                };
                context.SatisKodu.AddRange(satisKoduList);
            }

            context.SaveChanges();
        }
    }
}
