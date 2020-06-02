using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ROLE_TYPE_
    {
        [Key]
        public int id_Role_type { get; set; }
        public string Role_type_Name { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
    }
}
