using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.UnitOfWork;
using Demo.Entities.Models;
using Moq;
using Repository.Web.Controllers;

namespace Repository.UnitTests
{
    [TestClass]
    public class UnitAboutControllerTestsTest1
    {
        [TestMethod]
        public void AboutControllerTests()
        {
            var mockUow = new Mock<IUnitOfWork<DemoDbContext>>();
            var mockUow1 = new Mock<IUnitOfWork<HomeCinemaDbContext>>();
            var controller = new ValuesController(mockUow.Object, mockUow1.Object);
            var result = controller.TestOne();
        }
    }
}
