using ExtraInheritance.Entities.Cocktails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraInheritance.Entities.JunctionTables
{
    abstract class LiquorUse
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Cocktail))]
        public int CocktailId { get; set; }
        public virtual CocktailEntity Cocktail { get; set; }
    }
}
