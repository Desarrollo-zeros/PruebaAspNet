using Domain.Abstracts;
using Domain.Entities;
using Infraestructure.Data.Base;
using Infraestructure.Data.Repositories;
using Infraestructure.Data.UOW;
using NUnit.Framework;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Infraestructure.Data.Test
{

    [TestFixture]
    partial class ContactClient
    {


        private IGenericRepository<Contact> _contactRepository;
        private IDbContext _dbContext;
        private IUnitOfWork _unitOfWork;


        [SetUp]
        public void Setup()
        {
            _dbContext = new DBContextTest();
            _unitOfWork = new UnitOfWork(_dbContext);
            _contactRepository = new GenericRepository<Contact>(_dbContext);
           
        }

        [Test]
        public void TestAdd()
        {

            try
            {

                int id = (int) _dbContext?.Set<Client>()?.FirstOrDefault()?.Id;

                if(id > 0)
                {
                    var client = _contactRepository.Add(new Contact
                    {
                        Info = new Domain.ValueObjects.Info
                        {
                            Address = "Cr 25 #7B Bis",
                            Names = "Carlos Andrés Castilla García",
                            Phone = "+573043541475"
                        },
                        ClientId = id,

                    });

                    Assert.AreEqual(_unitOfWork.Commit(), 1);
                    Assert.IsNotNull(client);
                    Assert.IsTrue(client.Id > 0);
                    Assert.AreEqual(client.Info.Names, "Carlos Andrés Castilla García");
                    Console.WriteLine(client.Id);

                }

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);

                        Console.WriteLine(validationError.ErrorMessage);
                    }
                }
            }

           
        }


        [Test]
        public void TestEdit()
        {
            var client = _contactRepository.FindBy(x => x.Info.Names == "Carlos Andrés Castilla García").FirstOrDefault();
           
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
            var client = _contactRepository.FindBy(x => x.Info.Names == "Carlos Andrés Castilla García").FirstOrDefault();
            if(client != null)
            {
                _contactRepository.Delete(client);
                Assert.AreEqual(_unitOfWork.Commit(), 1);
            }
           
        }
    }
}