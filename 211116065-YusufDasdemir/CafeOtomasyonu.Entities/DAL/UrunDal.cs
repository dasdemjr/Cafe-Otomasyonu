using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeOtomasyonu.Entities.Validations;

namespace CafeOtomasyonu.Entities.DAL
{
    public class UrunDal : EntityRepositoryBase<CafeContext, Urun,UrunValidator>
    {
        public object UrunListele(CafeContext context)
        {
            var liste = (from u in context.Urun
                select new
                {
                    u.Id,
                    u.MenuId,
                    Menu = u.Menu.MenuAdi,
                    u.UrunKodu,
                    u.UrunAdi,
                    u.BirimFiyati1,
                    u.BirimFiyati2,
                    u.BirimFiyati3,
                    u.Aciklama,
                    u.Resim,
                    u.Tarih,
                    u.HizliSatis
                }).ToList();
            return liste;
        }
    }
}
