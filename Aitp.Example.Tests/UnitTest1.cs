using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Aitp.Example.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void Program1BreaksTest()
        {
            var container = new IoC.Container();

            // create a fake repository
            var repo = Mock.Of<IRepository<Outage>>();
            
            // tell the fake object to fail when Insert method is called
            Mock.Get(repo).Setup(m => m.Insert(It.IsAny<Outage>())).Throws<Exception>();
            
            // put the faked object in the Factory
            container.Register<IRepository<Outage>>().To(repo);

            // Run the test
            Program1.Execute(container);
        }




        [TestMethod]
        public void Program2BreaksTest()
        {
            var container = new IoC.Container();
            var repo = Mock.Of<IRepository<Outage>>();
            Mock.Get(repo).Setup(m => m.Insert(It.IsAny<Outage>())).Throws<Exception>();
            container.Register<IRepository<Outage>>().To(repo);

            Program2.Execute(container);
        }
    }
}
