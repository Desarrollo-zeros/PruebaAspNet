using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Contact : BaseModel<Domain.Entities.Contact, Contact>
    {
     
        public string Names { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public int ClientId { set; get; }


        public override Domain.Entities.Contact GetEntity()
        {
            return new Domain.Entities.Contact
            {
                Info = new Domain.ValueObjects.Info
                {
                    Address = Address,
                    Names = Names,
                    Phone = Phone
                },
                ClientId = ClientId
                
            };
        }



        public override Contact GetModel(Domain.Entities.Contact entity)
        {
            if (entity == null) return null;
            return new Contact
            {
                Address = entity?.Info.Address,
                Phone = entity?.Info.Phone,
                Names = entity?.Info.Names,
                Id = entity.Id,
                ClientId = entity.ClientId,
                
            };
        }

    }
}