using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Models.ViewModels
{
    public class ClsNavbar
    {
        private readonly ApplicationDbContext _context;

        public ClsNavbar(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<View_Comment>> Comment()
        {

            var select =await _context.View_Comment.Where(x => x.flag == false).OrderByDescending(v => v.idComment).ToListAsync();
            List<View_Comment> viewComments = new List<View_Comment>();

            foreach (var item in select)
            {
                View_Comment model = new View_Comment
                {
                    idComment = item.idComment,
                   
                    CommentText = item.CommentText,
                    ComTime = item.ComTime,
                    ComDate = item.ComDate,
                    BimeType =item.BimeType,
                    StateName = item.StateName

                };

                viewComments.Add(model);
            }

            return viewComments;
        }
        public async Task<List<ViewComplaint>> Complaint()
        {

            //commentInformingViewModel.commentListViewModels = select;
            //return select;

            var select =await _context.ViewComplaint.Where(x => x.readed == false).OrderByDescending(x => x.idComplaint).ToListAsync();
            List<ViewComplaint> viewComplaints = new List<ViewComplaint>();

            foreach (var item in select)
            {
                ViewComplaint model = new ViewComplaint
                {
                    idComplaint = item.idComplaint,
                    dateSend = item.dateSend,
                    timeSend = item.timeSend,
                    lName = item.lName,
                    fName = item.fName,
                    des = item.des,
                    CityName=item.CityName


                };

                viewComplaints.Add(model);
            }

            return viewComplaints;
        }
    }
}
