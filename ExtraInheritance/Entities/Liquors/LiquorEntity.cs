using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraInheritance.Entities.Liquors
{
    class LiquorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public string SubType { get; set; }
    }
}
