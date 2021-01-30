using BLL.Logic;
using System;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Web_Api.Controllers
{
    //[RoutePrefix("api/travel")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class TravelController : ApiController
    {

        [HttpGet]
        public IHttpActionResult CalaulateThePayment(int id)

        {
            DateTime date = DateTime.Today;

            return Ok(TravelLogic.CalaulateThePayment(id, date));
        }
        [HttpGet]
        public IHttpActionResult CalaulateThePayment(int id, DateTime date)
        {
            return Ok(TravelLogic.CalaulateThePayment(id, date));
        }
    }
}