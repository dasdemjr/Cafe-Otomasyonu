using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    public class KullanicilarValidator : AbstractValidator<Kullanicilar>
    {
        public KullanicilarValidator()
        {
            RuleFor(p => p.AdSoyad).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez");
            RuleFor(p => p.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(p => p.KullaniciAdi).MinimumLength(5).WithMessage("Kullanıcı adı alanı 5 karakterden az olamaz");
            RuleFor(p => p.KullaniciAdi).MaximumLength(20).WithMessage("Kullanıcı adı alanı 20 karakterden fazla olamaz");
            RuleFor(p => p.Sifre).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(p => p.Sifre).MinimumLength(6).WithMessage("Sifre alanı 6 karakterden az olamaz");
            RuleFor(p => p.Sifre).MaximumLength(12).WithMessage("Sifre alanı 12 karakterden fazla olamaz");
            RuleFor(p => p.Telefon).NotEmpty().WithMessage("Telefon alanı boş geçilemez");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez");

            RuleFor(p => p.Email).EmailAddress().WithMessage("Yanlış email adres formatı !");
        }
    }
}
