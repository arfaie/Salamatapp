using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Tbl_YearsOfService
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
