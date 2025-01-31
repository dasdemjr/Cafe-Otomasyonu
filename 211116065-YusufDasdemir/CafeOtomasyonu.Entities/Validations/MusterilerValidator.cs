﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeOtomasyonu.Entities.Models;
using FluentValidation;

namespace CafeOtomasyonu.Entities.Validations
{
    public class MusterilerValidator:AbstractValidator<Musteriler>
    {
        public MusterilerValidator()
        {
            RuleFor(p => p.AdiSoyadi).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez");
            RuleFor(p => p.Telefon).NotEmpty().WithMessage("Telefon alanı boş geçilemez");
        }
    }
}
