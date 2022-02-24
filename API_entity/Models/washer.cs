using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API_entity.Models
{
    public class washer
    {
        [Key]
        public int pkid { get; set; }


        [MaxLength(150)]
        [Required]
        public string name { get; set; }

        [MaxLength(50)]
        public string surname { get; set; }

    }
}
