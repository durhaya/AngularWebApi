using Repositories;
using System.Linq;
using System.Web.Http;

namespace VehicleTracking.Controllers
{
    public class RoleController : ApiController
    {

        internal readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;

        }
        [Route("api/GetRoles")]
        public IHttpActionResult GetRoles()
        {
            var roles = roleRepository.GetAll().OrderBy(p => p.Name);
            return Ok(roles.ToList());
        }

        [Route("api/GetRole")]
        public IHttpActionResult GetRole(int id)
        {
            var role = roleRepository.GetById(id);
            return Ok(role);
        }

        [Route("api/SaveRole")]
        public IHttpActionResult SaveRole(Role role)
        {
            roleRepository.InsertAndSubmit(role);
            return Ok();
        }
        [Route("api/UpdateRole")]
        public IHttpActionResult UpdateRole(Role role)
        {
            roleRepository.UpdateAndSubmit(role);
            return Ok();
        }
        [Route("api/DeleteRole")]
        public IHttpActionResult DeleteRole(Role role)
        {
            roleRepository.DeleteAndSubmit(role);
            return Ok();
        }
        [Route("api/SoftDeleteRole")]
        public IHttpActionResult SoftDeleteRole(Role role)
        {
            roleRepository.SoftDeleteAndSubmit(role);
            return Ok();
        }
    }
}
