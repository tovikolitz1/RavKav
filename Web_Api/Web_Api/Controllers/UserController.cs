using BLL.Logic;
using BLL.ModelDTO;
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
            return Ok(UsersLogic.IfExsistRavKav(ravKav, pass));
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

        [HttpGet]
        public IHttpActionResult forgotPassword(string ravkav)
        {
            return Ok(UsersLogic.forgotPassword(ravkav));
        }

        //[HttpGet]
        //public IHttpActionResult forgotPassword(string ravkav)
        //{
        //    return Ok(UsersLogic.forgotPassword(ravkav));
        //}
        [HttpGet]
        public IHttpActionResult changePassword(string ravkav,string tempPass, string newPass)
        {
            return Ok(UsersLogic.changePassword(ravkav,tempPass, newPass));
        }
        public IHttpActionResult updateAsManager(int mID, int uID)
        {
            return Ok(UsersLogic.updateAsManager(mID, uID));
        }
        
    }
}
