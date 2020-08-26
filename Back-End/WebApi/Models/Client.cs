using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Client : BaseModel<Domain.Entities.Client, Client>
    {
       
        public string Names { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }

        public List<Contact> Contacts { set; get; } = new List<Contact>();
         
        public DateTime CreatedAt { set; get; }


        public override Domain.Entities.Client GetEntity()
        {
            return new Domain.Entities.Client
            {
                Info = new Domain.ValueObjects.Info
                {
                    Address = Address,
                    Names = Names,
                    Phone = Phone
                }
            };
        }



        public override Client GetModel(Domain.Entities.Client entity)
        {

            if (entity == null) return null;

            List<Contact> contacts = new List<Contact>();

            if (entity?.Contacts?.ToList()?.Count > 0) {

                entity.Contacts.ToList().ForEach(x =>
                {
                    contacts.Add(new Contact().GetModel(x));
                });
            }
            return new Client
            {
                Address = entity?.Info?.Address,
                Phone = entity?.Info?.Phone,
                Names = entity?.Info?.Names,
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                Contacts = contacts,
            };
        }
    }
}