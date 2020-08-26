using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("view_count_max_contact")]
    public class ClientView : Entity<int>
    {
       

        [Column("counts", Order = 2)]
        public int Count { set; get; }

        [Column("names", Order = 3)]
        [Required]
        public string Names { set; get; }


        [Column("address", Order = 4)]
        [Required]
        public string Address { set; get; }

        [Column("phone", Order = 5)]
        [Required]
        [MaxLength(13)]
        [MinLength(10)]
        public string Phone { set; get; }


        [Column("created_at", TypeName = "DATETIME2", Order = 6)]
        [Required]
        public DateTime CreatedAt { set; get; }
    }
}
