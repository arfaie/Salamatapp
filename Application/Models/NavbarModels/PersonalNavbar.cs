using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.NavbarModels
{
    public class PersonalNavbar
    {
        public List<TblPersonal> tblPersonals { get; set; }

        public List<View_Comment> CommentListNavbar { get; set; }

        public List<ViewComplaint> ComplaintsListNavbar { get; set; }

        public int commentcount { get; set; }
        public int complaintcount { get; set; }
    }
}
