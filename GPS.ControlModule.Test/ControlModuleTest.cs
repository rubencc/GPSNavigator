using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPSControlModule;

namespace GPS.ControlModule.Test
{
    [TestClass]
    public class ControlModuleTest
    {
        private ControlModule cm;

        [TestInitialize]
        public void Setup()
        {
            this.cm = new ControlModule();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
