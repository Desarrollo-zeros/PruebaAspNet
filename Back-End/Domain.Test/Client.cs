using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    [TestFixture]
    partial class Client
    {
        private Entities.Client _client;
        [SetUp]
        public void Initialize()
        {
            _client = new Entities.Client();
        }


        /*Test created Client -> CreatedDate default*/
        [Test]
        public void TestCreated()
        {
            _client = new Entities.Client()
            {
                Info = new ValueObjects.Info
                {
                    Address = "Cr 25 # 7B Bis",
                    Names = "Carlos Andrés Catilla García",
                    Phone = "+573043541475"
                },
            };
            Console.WriteLine(_client.CreatedAt);
        }


    }
}
