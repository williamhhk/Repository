using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.UnitOfWork;
using Repository.Respository;
using Demo.Entities.Models;


namespace Repository.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            using (IUnitOfWork uow = new UnitOfWork<DemoDbContext>())
            {
                IRepository<Customer> customerRepository = new Repository<Customer>(uow);

                customerRepository.Insert(
                new Customer
                {
                    Id = 123,
                    Name = "Hello",
                    Address = "2964 E Shannon",
                    City = "Gilbert, AZ",
                    Country = "USA",
                    Age = 20
                });
                uow.SaveChanges();

            }
        }
    }
}
