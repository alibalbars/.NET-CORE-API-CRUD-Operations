using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreApiProject.Entities
{
    [Table("Todos")]
    public class Todos
    { 
        public int ID { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public Boolean Hidden { get; set; }
    }
}
