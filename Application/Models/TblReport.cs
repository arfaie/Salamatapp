using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblReport
    {
        [Key]
        public byte ReportID { get; set; }
        public string ReportName { get; set; }
        public string ReportURL { get; set; }
    }
}
