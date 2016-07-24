using Demo.Entities.Models;
using Repository.Extensions;
using Repository.Respository;
using Repository.UnitOfWork;
using System;
using System.Linq;

using System.Web.Mvc;

namespace MVC.Web.Controllers
{    public class HomeController : Controller
    {
        private IRepository<Customer> _repoCustomer;
        private IReadOnlyRepository<Stock> _repoStock;
        public HomeController(IUnitOfWork<DemoDbContext> uow1, IUnitOfWork<HomeCinemaDbContext> uow2)
        {
            _repoCustomer = new Repository<Customer>(uow1);
            _repoStock = new ReadOnlyRepository<Stock>(uow2);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var userId = User.Identity.Name;

            var customers = _repoCustomer.Find(2);
            var stock = _repoStock.Find(2);
            var stock1 = _repoStock.SqlQuery("select Id, MovieId from [dbo].[Stock]");

            Converter<double, DateTime> converter = d => new DateTime(2010, 1, 1).AddDays(d);
            
            return View();
        }

        public ActionResult Contact()
        {

            //using (IUnitOfWork uow = new UnitOfWork<DemoDbContext>())
            //{
            //    IRepository<Customer> customerRepository = new Repository<Customer>(uow);

            //    var test = customerRepository.Find(1); 

            //}
            return View();
        }
    }
}