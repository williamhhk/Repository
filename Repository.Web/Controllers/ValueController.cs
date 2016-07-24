using Demo.Entities.Models;
using Repository.Respository;
using Repository.UnitOfWork;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Repository.Web.Controllers
{

    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private IRepository<Customer> _repoCustomer;
        private IReadOnlyRepository<Stock> _repoStock;
        public ValuesController(IUnitOfWork<DemoDbContext> uow1, IUnitOfWork<HomeCinemaDbContext> uow2)
        {
            _repoCustomer = new Repository<Customer>(uow1);
            _repoStock = new ReadOnlyRepository<Stock>(uow2);
        }



        //// http://localhost:49407/api/values/example1?id=2
        //[Route("TestOne")]
        //[HttpGet]
        //public HttpResponseMessage TestOne(HttpRequestMessage request)
        //{

        //    var test = _repoCustomer.Find(2);

        //    return  request.CreateResponse(HttpStatusCode.OK, "Hello World");
        //}

        [Route("TestOne")]
        [HttpGet]
        public IHttpActionResult TestOne()
        {
            // Do some work (not shown).
            return Content(HttpStatusCode.OK, _repoCustomer.Find(2));
        }

    }
}