using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{

    [TestFixture]
    partial class Contact
    {
        private Entities.Contact _contact;
        [SetUp]
        public void Initialize()
        {
            _contact = new Entities.Contact();
        }


   
        [Test]
        public void TestCreated()
        {
            _contact = new Entities.Contact()
            {
                Info = new ValueObjects.Info
                {
                    Address = "Cr 25 # 7B Bis",
                    Names = "Carlos Andrés Catilla García",
                    Phone = "+573043541475"
                },
            };
            Console.WriteLine(_contact.Info);
        }
    }
}
