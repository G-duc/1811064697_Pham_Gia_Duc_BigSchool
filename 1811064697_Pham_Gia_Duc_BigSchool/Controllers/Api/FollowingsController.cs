using System.Linq;
using System.Web.Http;
using _1811064697_Pham_Gia_Duc_BigSchool.DTOs;
using _1811064697_Pham_Gia_Duc_BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace _1811064697_Pham_Gia_Duc_BigSchool.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
