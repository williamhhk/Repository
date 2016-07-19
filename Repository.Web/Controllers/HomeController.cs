using Demo.Entities.Models;
using Repository.Respository;
using Repository.UnitOfWork;

using System.Web.Mvc;

namespace Repository.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var test = new DemoDbContext())
            {
                //Trace.WriteLine(test1);

            }
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            using (IUnitOfWork uow = new UnitOfWork<DemoDbContext>())
            {
                IRepository<Customer> customerRepository = new Repository<Customer>(uow);
                
                customerRepository.Insert(
                new Customer
                {
                    Id = 10000,
                    Name = "Hello",
                    Address = "1234 E 1st Street",
                    City = "LalaLand, LALA",
                    Country = "USA",
                    Age = 20
                });
                uow.SaveChanges();

            }


            return View();
        }

        public ActionResult Contact()
        {

            using (IUnitOfWork uow = new UnitOfWork<DemoDbContext>())
            {
                IRepository<Customer> customerRepository = new Repository<Customer>(uow);

                var test = customerRepository.Find(1); 

            }
            return View();
        }
    }
}