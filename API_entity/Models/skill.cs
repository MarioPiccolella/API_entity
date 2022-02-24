using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API_entity.Models
{
    public class skill
    {
        [Key]
        public int pkid { get; set; }

        [Required]
        [MaxLength(150)]
        public string name { get; set; }
    }
}
