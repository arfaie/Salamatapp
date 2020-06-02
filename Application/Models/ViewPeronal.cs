using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ViewPeronal
    {
        public string ExpertName { get; set; }
        public string reshtehName { get; set; }
        public string MadarekName { get; set; }
        public string Role_type_Name { get; set; }
        public int id_personal { get; set; }
        public int? codeOrgan { get; set; }
        public string nezamId { get; set; }
        public string DRName { get; set; }
        public int? Id_ROLETYPE { get; set; }
        public string DrFamily { get; set; }
        public int? Id_MADRAK { get; set; }
        public int? Id_RESHTEH { get; set; }
        public int? Id_EXPERT { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
        public string passWord { get; set; }
    }
}
