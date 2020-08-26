using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{

    [Table("contacts")]
    public partial class Contact : Entity<int>
    {
        public Info Info { set; get; } = new Info();
        
       
       
        [Column("client_id",  Order = 5)]
        public int ClientId { set; get; }
        
        public virtual Client Client { set; get; }
    }
}
