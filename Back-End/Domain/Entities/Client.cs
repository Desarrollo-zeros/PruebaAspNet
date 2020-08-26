using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace Domain.Entities
{
    [Table("clients")]
    public partial class Client : Entity<int>
    {

        public Client()
        {
            Contacts = new HashSet<Contact>();
        }

        //ValueObjects -> Ef lo toma como valores en la tablas
        public Info Info { set; get; } = new Info();

        [Column("created_at", TypeName = "DATETIME2", Order = 5)]
        [Required]
        public DateTime CreatedAt {

            get
            {
                return dateCreated ?? DateTime.Now;
            }
            set 
            {
                this.dateCreated = value;
            }
        }
        private DateTime? dateCreated = null;

        public virtual ICollection<Contact> Contacts { set; get; }
    }
}
