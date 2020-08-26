using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Domain.Abstracts;
using Infraestructure.Data;
using Infraestructure.Data.Base;
using Infraestructure.Data.Repositories;
using Infraestructure.Data.UOW;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactsController : ApiController
    {

        private readonly IDbContext _dbContext;
        private readonly IGenericRepository<Domain.Entities.Contact> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactsController()
        {

            _dbContext = new DBContext();
            _unitOfWork = new UnitOfWork(_dbContext);
            _genericRepository = new GenericRepository<Domain.Entities.Contact>(_dbContext);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Contact contact = new Contact().GetModel(_genericRepository.FindBy(x => x.Id == id, includeProperties: "contacts").FirstOrDefault());
            return Ok(new
            {
                Status = true,
                Message = "Ok",
                contact
            }) ;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {


            List<Contact> contact = new List<Contact>();

            _genericRepository.GetAll().ToList().ForEach(x =>
            {
                contact.Add(new Contact().GetModel(x));
            });

            return Ok(new
            {
                Status = true,
                Message = "Ok",
                contact
            });

        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Contact contact)
        {
            try
            {
                contact = contact.GetModel(_genericRepository.Add(contact.GetEntity()));
                if (_unitOfWork.Commit() > 0)
                {
                    return Ok(new
                    {
                        contact,
                        message = "Contacto Guardado con exito",
                        status = true
                    }) ;
                }
                return Ok(new
                {
                    contact,
                    message = "Contacto No se pudo guardar",
                    status = false
                });
            }
            catch(Exception e)
            {
                return Ok(new
                {
                    contact,
                    message = e.Message,
                    status = false
                });
            }
        }


        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Update(int id ,Contact contact)
        {
            try
            {
                var contact1 = _genericRepository.Find(id);
                contact1.Info = new Domain.ValueObjects.Info
                {
                    Phone = contact.Phone,
                    Names = contact.Names,
                    Address = contact.Address,
                    
                };
                if (_unitOfWork.Commit() > 0)
                {
                    return Ok(new
                    {
                        contact1,
                        message = "Contacto Actualizando con exito",
                        status = true
                    });
                }
                return Ok(new
                {
                    contact1,
                    message = "Contacto No se pudo Actualizanrse",
                    status = false
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    contact,
                    message = e.Message,
                    status = false
                });
            }
        }



        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var contact = _genericRepository.Find(id);
                _genericRepository.Delete(contact);
                if (_unitOfWork.Commit() > 0)
                {
                    return Ok(new
                    {
                       
                        message = "Contacto Eliminado con exito",
                        status = true
                    });
                }
                return Ok(new
                {
                  
                    message = "Contacto No se pudo Eliminarse",
                    status = false
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                  
                    message = e.Message,
                    status = false
                });
            }
        }


       


    }
}