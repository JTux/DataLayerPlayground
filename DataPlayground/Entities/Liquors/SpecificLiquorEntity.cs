using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPlayground.Entities.Liquors
{
    class SpecificLiquorEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Liquor))]
        public int LiquorId { get; set; }
        public virtual LiquorEntity Liquor { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string CountryOfOrigin { get; set; }
    }
}
