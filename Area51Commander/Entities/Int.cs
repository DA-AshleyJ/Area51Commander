using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Commander.Entities
{
    public abstract class Entity
    {
        [Key]
        
        public int id { get; set; }
       
    }
}

