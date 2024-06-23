using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeOtomasyonu.Entities.Interfaces;

namespace CafeOtomasyonu.Entities.Models
{

    public class Urun:IEntity
    {

        public int Id { get; set; }
        public int MenuId { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public decimal BirimFiyati1 { get; set; }
        public decimal BirimFiyati2 { get; set; }
        public decimal BirimFiyati3 { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public bool HizliSatis { get; set; } = false;
        public string Resim { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ICollection<MasaHareketleri> MasaHareketleri { get; set; }
    }
}
