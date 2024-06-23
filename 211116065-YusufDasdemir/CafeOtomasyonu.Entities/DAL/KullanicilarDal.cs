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
    public class KullanicilarDal : EntityRepositoryBase<CafeContext, Kullanicilar,KullanicilarValidator>
    {

    }
}
