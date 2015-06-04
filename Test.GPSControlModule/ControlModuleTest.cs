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
            float speed = this.cm.GetSpeed();

            Assert.IsFalse(speed < 0, "La velocidad es negativa");
        }

        [TestMethod]
        public void Obtener_la_posicion()
        {
            Marker position = this.cm.GetPosition();

            Assert.IsNotNull(position, "El objeto de posicion es nulo");
            Assert.IsFalse(position.Altitude < 0, "La altura es negativa");
            Assert.IsFalse(position.Latitude < 0, "La latitud es negativa");
            Assert.IsFalse(position.Longitude < 0, "La longitud es negativa");
        }
    }
}
