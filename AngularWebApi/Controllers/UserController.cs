using Repositories;
using System.Linq;
using System.Web.Http;

namespace VehicleTracking.Controllers
{
    public class UserController : ApiController
    {

        internal readonly IUserRepository UserRepository;

        public UserController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;

        }
        [Route("api/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            var Users = UserRepository.GetAll().OrderBy(p => p.FirstName);
            return Ok(Users.ToList());
        }

        [Route("api/GetUser")]
        public IHttpActionResult GetUser(int id)
        {
            var User = UserRepository.GetById(id);
            return Ok(User);
        }

        [Route("api/SaveUser")]
        public IHttpActionResult SaveUser(User User)
        {
            UserRepository.InsertAndSubmit(User);
            return Ok();
        }
        [Route("api/UpdateUser")]
        public IHttpActionResult UpdateUser(User User)
        {
            UserRepository.UpdateAndSubmit(User);
            return Ok();
        }
        [Route("api/DeleteUser")]
        public IHttpActionResult DeleteUser(User User)
        {
            UserRepository.DeleteAndSubmit(User);
            return Ok();
        }
        [Route("api/SoftDeleteUser")]
        public IHttpActionResult SoftDeleteUser(User User)
        {
            UserRepository.SoftDeleteAndSubmit(User);
            return Ok();
        }
    }
}
