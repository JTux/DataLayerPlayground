using DataPlayground.Entities.Liquors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPlayground.Entities.JunctionTables
{
    class CustomCocktailLiquor : LiquorUse
    {
        [ForeignKey(nameof(Specific))]
        public int SpecificId { get; set; }
        public virtual SpecificLiquorEntity Specific { get; set; }
    }
}
