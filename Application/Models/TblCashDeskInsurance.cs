using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblCashDeskInsurance
    {
        [Key]
        public int idCashDeskInsurance { get; set; }
        public string namelCashDeskInsurance { get; set; }
    }
}
