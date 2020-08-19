using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Client;

namespace Tests
{
    [TestClass]
    public class HelloWorld
    {
        [TestMethod]
        public void Send_Message()
        {
            //Arrange
            var s = new Send.Send();

            //RabbitMQ.Client.;

            //Act
            //var message = s.SendMessage("Hello World");

            //Assert
            //Assert.AreEqual("Hello World", message);
        }

        [TestMethod]
        public void Receive_Message()
        {
            //Arrange
            var s = new Send.Send();
            var r = new Receive.Receive();

            //Act
            //var message = s.SendMessage("Hello World");

            //Assert
            //Assert.AreEqual("Hello World", r.ReceiveMessage());
        }
    }
}
