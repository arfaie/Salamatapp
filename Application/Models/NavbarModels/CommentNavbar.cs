using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.ViewModels;

namespace Application.Models.NavbarModels
{
    public class CommentNavbar
    {
        public List<CommentListViewModel> commentListViewModels { get; set; }

        public List<View_Comment> CommentListNavbar { get; set; }

        public List<ViewComplaint> ComplaintsListNavbar { get; set; }

        public int commentcount { get; set; }
        public int complaintcount { get; set; }
    }
}
