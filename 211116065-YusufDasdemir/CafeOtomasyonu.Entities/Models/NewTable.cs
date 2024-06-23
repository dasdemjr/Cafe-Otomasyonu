using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeOtomasyonu.Entities.Interfaces;

namespace CafeOtomasyonu.Entities.Models
{
    [Table("NewTable")]
    public class NewTable:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string LastName { get; set; }

    }
}
