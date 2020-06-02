using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblRepDevice
    {
        [Key]
        public int idDevice { get; set; }
        public string IMEI { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string API { get; set; }
        public string SDK { get; set; }
        public string Date { get; set; }
    }
}
