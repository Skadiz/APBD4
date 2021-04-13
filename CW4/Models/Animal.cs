
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CW4.Models
{
    public class Animal
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string IdAnimal { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Area { get; set; }


        public override string ToString()
        {
            return $"'{Name}','{Description}','{IdAnimal}','{Category}','{Area}'";
        }

        public bool CheckForNull()
        {
            if (this.Name == null) return false;
            if (this.Description == null) return false;
            if (this.IdAnimal == null) return false;
            if (this.Category == null) return false;
            if (this.Area == null) return false;
            return true;
        }
    }
}
