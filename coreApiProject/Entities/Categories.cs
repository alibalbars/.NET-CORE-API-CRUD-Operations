using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreApiProject.Entities
{
    [Table("Categories")]
    public class Categories
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public Boolean Hidden { get; set; }
    }
}
