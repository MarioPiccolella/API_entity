using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_entity.Models
{
    public class washer_skill
    {
        [Key]
        public int pkid { get; set; }


        [ForeignKey("washer")]
        public int washer_id { get; set; }
        public virtual washer washer { get; set; }


        [ForeignKey("skill")]
        public int skill_id { get; set; }
        public virtual skill Skill { get; set; }


    }
}
