using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
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
    [RoutePrefix("api/Client")]
    public class ClientsController : ApiController
    {

        private readonly IDbContext _dbContext;
        private readonly IGenericRepository<Domain.Entities.Client> _genericRepository;
        private readonly IGenericRepository<Domain.Entities.Contact> _genericRepository1;
      

        private readonly IUnitOfWork _unitOfWork;

        public ClientsController()
        {

            _dbContext = new DBContext();
            _unitOfWork = new UnitOfWork(_dbContext);
            _genericRepository = new GenericRepository<Domain.Entities.Client>(_dbContext);
            _genericRepository1 = new GenericRepository<Domain.Entities.Contact>(_dbContext);
            
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Client client =  new Client().GetModel( _genericRepository.FindBy(x => x.Id == id, includeProperties: "contacts").FirstOrDefault());
            return Ok(new
            {

                Status = true,
                Message = "Ok",
                client = new List<Client>
                {
                    client
                }
            });
        }

       

        [HttpGet]
        [Route("like")]
        public IHttpActionResult GetLikeName(string like = "carl")
        {

            List<Client> client = new List<Client>();
            /*select DISTINCT c.id, c.names, c.address, c.phone,c.created_at from clients c inner join contacts co on c.id = co.client_id where UPPER(co.names) like UPPER('carl%'); */
            _genericRepository.FindBy(x => x.Contacts.Any(y => y.Info.Names.Trim().ToLower().StartsWith(like)),includeProperties: "contacts").OrderBy(x => x.CreatedAt).ToList().ForEach(x =>
            {
                client.Add(new Client().GetModel(x));
            });
            return Ok(new { 
                
                Status = true,
                Message = "Ok",
                client
            });
        }


        [HttpGet]
        [Route("count")]
        public IHttpActionResult GetCountMaxClient()
        {
           Client client = new Client();
            /*
             * select TOP 1 count(co.client_id) as counts, c.id, c.names, c.address, c.phone,c.created_at from clients c 
                inner join contacts co on c.id = co.client_id
                GROUP BY c.id, c.names, c.address, c.phone,c.created_at
                ORDER BY counts desc

             */

            Domain.Entities.ClientView ClientView = new DBContext().Database.SqlQuery<Domain.Entities.ClientView>("select TOP 1 count(co.client_id) as counts, c.id, c.names, c.address, c.phone,c.created_at from clients c inner join contacts co on c.id = co.client_id GROUP BY c.id, c.names, c.address, c.phone,c.created_at ORDER BY counts desc")?.FirstOrDefault();
            if(ClientView !=  null)
            {
                client = client.GetModel(_genericRepository.FindBy(x => x.Id == ClientView.Id, includeProperties: "contacts").FirstOrDefault());
            }
            return Ok(new
            {

                Status = true,
                Message = "Ok",
                client = new List<Client>
                {
                    client
                }
            });
        }


        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            List<Client> client = new List<Client>();
            //select * from clients order by created_at asc
            _genericRepository.FindBy(includeProperties: "contacts").OrderBy(x => x.CreatedAt).ToList().ForEach(x =>
            {
                client.Add(new Client().GetModel(x));
            });
            return Ok(new
            {

                Status = true,
                Message = "Ok",
                client
            });
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Client client)
        {
            try
            {
                client = client.GetModel(_genericRepository.Add(client.GetEntity()));
                if (_unitOfWork.Commit() > 0)
                {
                    return Ok(new
                    {
                        client,
                        message = "Cliente Guardado con exito",
                        status = true
                    }) ;
                }
                return Ok(new
                {
                    client,
                    message = "Cliente No se pudo guardar",
                    status = false
                });
            }
            catch(Exception e)
            {
                return Ok(new
                {
                    client,
                    message = e.Message,
                    status = false
                });
            }
        }


        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Update(int id ,Client client)
        {
            try
            {
                var client1 = _genericRepository.Find(id);
                client1.Info = new Domain.ValueObjects.Info
                {
                    Address = client.Address,
                    Names = client.Names,
                    Phone = client.Phone,
                };
                if (_unitOfWork.Commit() > 0)
                {
                    return Ok(new
                    {
                        client1,
                        message = "Cliente Actualizando con exito",
                        status = true
                    });
                }
                return Ok(new
                {
                    client1,
                    message = "Cliente No se pudo Actualizanrse",
                    status = false
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    client,
                    message = e.Message,
                    status = false
                });
            }
        }



        [HttpDelete]
        [Route("deleteAll/{ids}")]
        public IHttpActionResult DeleteAll(string ids)
        {
            try
            {
                var contacts = _genericRepository.FindBy(x => ids.Contains(x.Id.ToString()));
                _genericRepository.DeleteRange(contacts.ToList());
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


        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var client = _genericRepository.Find(id);
                _genericRepository.Delete(client);
                if (_unitOfWork.Commit() > 0)
                {
                    return Ok(new
                    {
                     
                        message = "Cliente Elimando con exito",
                        status = true
                    });
                }
                return Ok(new
                {
                    
                    message = "Cliente No se pudo Eliminarse",
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