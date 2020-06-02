using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblMenu
    {
        [Key]
        public int menuId { get; set; }
        public string menuName { get; set; }
        public int? menuFatherID { get; set; }
        public string link { get; set; }
        public int? order { get; set; }
        public string MenueDate { get; set; }
        public bool? flag { get; set; }
    }
}
