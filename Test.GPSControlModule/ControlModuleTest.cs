using System;
using GPSControlModule;
using GPSControlModule.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.GPSControlModule
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
        public void Encender_modulo_de_control()
        {
            bool expected = true;

            bool result = this.cm.Start();

            Assert.AreEqual(expected, result, "El modulo no se ha encendido");
        }

        [TestMethod]
        public void Apagar_modulo_de_control()
        {
            bool expected = true;

            bool result = this.cm.Stop();

            Assert.AreEqual(expected, result, "El modulo no se ha apagado");
        }

        [TestMethod]
        public void Obtener_la_velocidad()
        {
            this.cm.Start();
            float speed = this.cm.GetSpeed();

            Assert.IsFalse(speed < 0, "La velocidad es negativa");
        }

        [TestMethod]
        public void Obtener_la_posicion()
        {
            this.cm.Start();
            Marker position = this.cm.GetPosition();

            Assert.IsNotNull(position, "El objeto de posicion es nulo");

            Assert.IsTrue(position.Altitude >= 0, "La altura es negativa");
            Assert.IsTrue(position.Altitude <= 3000, "La altura supera los 3000m");

            Assert.IsTrue(position.Latitude >= -90, "La latitud supera los 180º Oeste");
            Assert.IsTrue(position.Latitude <= 90, "La latitud supera los 180º Este");


            Assert.IsTrue(position.Longitude >= -180, "La longitud supera los 90º Sur");
            Assert.IsTrue(position.Longitude <= 180, "La longitud supera los 90º Norte");
        }
    }
}
