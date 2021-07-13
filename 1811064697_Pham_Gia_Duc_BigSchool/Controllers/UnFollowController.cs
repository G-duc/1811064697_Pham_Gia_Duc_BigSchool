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
    public class UnFollowController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public UnFollowController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult UnFollow(FollowingDto followDto)
        {
            var userId = User.Identity.GetUserId();

            var DelFollowing = _dbContext
                .Followings
                .FirstOrDefault(a => a.FollowerId == userId && a.FolloweeId == followDto.FolloweeId);

            if (DelFollowing == null)
            {
                return BadRequest("The Follow  is not exists!");
            }
            _dbContext.Followings.Remove(DelFollowing);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}

