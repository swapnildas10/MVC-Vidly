using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vidly.Controllers;

namespace VidlyTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PrivateObject obj = new PrivateObject(typeof(CustomersController));
            bool boolresult =  Convert.ToBoolean(obj.Invoke("IsNegative", -1));
            Assert.AreEqual("true",boolresult);
            //var controller = new CustomersController();
            //var result = controller.Edit(2) as ViewResult;


        }

        public void TestMethod2()
        {
            CustomersController obj = new CustomersController();
            ViewResult var =  obj.Edit(2) as ViewResult;
        }
    }
}
