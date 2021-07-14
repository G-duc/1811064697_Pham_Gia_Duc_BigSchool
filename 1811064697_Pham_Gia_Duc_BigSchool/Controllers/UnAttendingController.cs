using _1811064697_Pham_Gia_Duc_BigSchool.DTOs;
using _1811064697_Pham_Gia_Duc_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1811064697_Pham_Gia_Duc_BigSchool.Controllers
{
    public class UnAttendingController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public UnAttendingController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Unatteding(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();

            var DelAttend = _dbContext.Attendances
                .FirstOrDefault(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId);

            if(DelAttend == null)
            {
                return BadRequest("The Attendance does not exsists !");
            }
            _dbContext.Attendances.Remove(DelAttend);
            _dbContext.SaveChanges();

            return Ok();

        }

    }
}
