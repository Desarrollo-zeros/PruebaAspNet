using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.ValueObjects
{
    public partial class Info
    {

        [Column("names",  Order = 2)]
        [Required]
        public string Names { set; get; }


        [Column("address", Order = 3)]
        [Required]
        public string Address { set; get; }

        [Column("phone", Order = 4)]
        [Required]
        [MaxLength(13)]
        [MinLength(10)]
        public string Phone { set; get; }

    }
}
