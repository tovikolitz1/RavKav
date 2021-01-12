
using BL.Logic;
using System;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Web_Api.Controllers
{
    //[RoutePrefix("api/travel")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class TravelController:ApiController
    {

        [HttpGet]
        public IHttpActionResult calaulateThePayment(int id, DateTime time)
        {
            return Ok(TravelLogic.calaulateThePayment(id,time));
        }

    }
}