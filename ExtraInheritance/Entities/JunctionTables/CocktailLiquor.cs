using ExtraInheritance.Entities.Liquors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraInheritance.Entities.JunctionTables
{
    class CocktailLiquor : LiquorUse
    {
        [ForeignKey(nameof(Liquor))]
        public int LiquorId { get; set; }
        public virtual LiquorEntity Liquor { get; set; }
    }
}
