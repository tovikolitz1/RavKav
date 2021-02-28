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
            date=date.AddMonths(-1);
            return Ok(TravelLogic.CalaulateThePayment(id, date));
        }
        [HttpGet]
        public IHttpActionResult CalaulateThePayment(int id, DateTime date)
        {
            return Ok(TravelLogic.CalaulateThePayment(id, date));
        }
        public IHttpActionResult CalaulateThePayment(int idManager,int idUser)
        {
            DateTime date = DateTime.Today;
            date = date.AddMonths(-1);
            return Ok(TravelLogic.CalaulateThePayment(idUser, date));
        }
        public IHttpActionResult getTravels(int id,int date)
        {
            return Ok(TravelLogic.getTravels(id, date / 100, date % 100));
        }
        public IHttpActionResult getTravelsForManager(int idManager, int idUser, int date)
        {
            return Ok(TravelLogic.getTravelsForManager(idManager, idUser, date / 100, date % 100));
        }
    }
}