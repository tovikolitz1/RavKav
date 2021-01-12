using BL;
using BL.ModelDTO;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Web_Api.Controllers
{
    //[RoutePrefix("api/user")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult IfExsistRavKav(string ravKav, string pass)
        {
            return Ok(UsersLogic.IfExsistRavKav(ravKav,pass));
        }
        [HttpGet]
        public IHttpActionResult GetNameById(int id)
        {
            return Ok(UsersLogic.GetNameById(id));
        }
        [HttpPost]
        public IHttpActionResult AddUser(UserDTO user)
        {
            return Ok(UsersLogic.AddUser(user));
        }
        [HttpGet]
        public IHttpActionResult AddUser(int id, string password)
        {
            var user = new UserDTO()
            {
                profileId = id,
                pass = password
            };
            return Ok(UsersLogic.AddUser(user));
        }
    }
}
