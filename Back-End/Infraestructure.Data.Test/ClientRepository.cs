using Domain.Abstracts;
using Domain.Entities;
using Infraestructure.Data.Base;
using Infraestructure.Data.Repositories;
using Infraestructure.Data.UOW;
using NUnit.Framework;
using System;
using System.Linq;

namespace Infraestructure.Data.Test
{

    [TestFixture]
    partial class ClientTest
    {


        private IGenericRepository<Client> _clientRepository;
        private IDbContext _dbContext;
        private IUnitOfWork _unitOfWork;


        [SetUp]
        public void Setup()
        {
            _dbContext = new DBContextTest();
            _unitOfWork = new UnitOfWork(_dbContext);
            _clientRepository = new GenericRepository<Client>(_dbContext);
           
        }

        
        [Test]
        public void TestAdd()
        {

           
           var client =  _clientRepository.Add(new Client
            {
                Info = new Domain.ValueObjects.Info
                {
                    Address = "Cr 25 #7B Bis",
                    Names = "Carlos Andrés Castilla García",
                    Phone = "+573043541475"
                }
            });
           
            Assert.AreEqual(_unitOfWork.Commit(), 1);
            Assert.IsNotNull(client);
            Assert.IsTrue(client.Id > 0);
            Assert.AreEqual(client.Info.Names, "Carlos Andrés Castilla García");
            Console.WriteLine(client.Id);
        }


        [Test]
        public void TestEdit()
        {
            var client = _clientRepository.FindBy(x => x.Info.Names == "Carlos Andrés Castilla García").FirstOrDefault();
           
            if(client != null)
            {
                client.Info.Address = "Cr 25 #7B";
                Assert.AreEqual(_unitOfWork.Commit(), 1);
                Assert.IsNotNull(client);
                Assert.IsTrue(client.Id > 0);
                Assert.AreEqual(client.Info.Address, "Cr 25 #7B");
            }
        }

        [Test]
        public void TestRemove()
        {
            var client = _clientRepository.FindBy(x => x.Info.Names == "Carlos Andrés Castilla García").FirstOrDefault();
            if(client != null)
            {
                _clientRepository.Delete(client);
                Assert.AreEqual(_unitOfWork.Commit(), 1);
            }
           
        }
    }
}