using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    public class MasaHareketleriValidator : AbstractValidator<MasaHareketleri>
    {
        public MasaHareketleriValidator()
        {
            RuleFor(p => p.SatisKodu).NotEmpty().WithMessage("Satış kodu alanı boş geçilemez");
           // RuleFor(p => p.SatisKodu).Length(12).WithMessage("Satış kodu alanı 12 karakterden oluşmalıdır");
            RuleFor(p => p.Miktari).NotEmpty().WithMessage("Miktar adı alanı boş geçilemez");
            RuleFor(p => p.Miktari).GreaterThan(0).WithMessage("Miktar alanı 0'dan büyük olmalıdır");


            RuleFor(p => p.BirimFiyati).NotEmpty().WithMessage("Birim Fiyatı alanı boş geçilemez");
            RuleFor(p => p.BirimFiyati).LessThanOrEqualTo(150).WithMessage("Birim Fiyatı 150 den küçük olmalıdır");
        }
    }
}
