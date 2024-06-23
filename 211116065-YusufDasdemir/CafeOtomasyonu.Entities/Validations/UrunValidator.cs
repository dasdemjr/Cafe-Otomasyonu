﻿using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    public class UrunValidator : AbstractValidator<Urun>
    {
        public UrunValidator()
        {
            RuleFor(p => p.UrunKodu).NotEmpty().WithMessage("Ürün kodu alanı boş geçilemez");
            RuleFor(p => p.UrunAdi).NotEmpty().WithMessage("Ürün Adı alanı boş geçilemez");

            RuleFor(p => p.BirimFiyati1).NotEmpty().WithMessage("BirimFiyatı1 alanı boş geçilemez");
            RuleFor(p => p.BirimFiyati2).NotEmpty().WithMessage("BirimFiyatı2 alanı boş geçilemez");
            RuleFor(p => p.BirimFiyati3).NotEmpty().WithMessage("BirimFiyatı3 alanı boş geçilemez");
        }
    }
}
