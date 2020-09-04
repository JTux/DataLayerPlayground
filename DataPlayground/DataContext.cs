using DataPlayground.Entities.Cocktails;
using DataPlayground.Entities.JunctionTables;
using DataPlayground.Entities.Liquors;
using DataPlayground.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPlayground
{
    class DataContext : DbContext
    {
        public DataContext() : base("CocktailData") { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LiquorEntity> Liquors { get; set; }
        public DbSet<SpecificLiquorEntity> SpecificLiquors { get; set; }
        public DbSet<CocktailEntity> Cocktails { get; set; }
        public DbSet<CustomCocktailEntity> CustomCocktails { get; set; }
        public DbSet<LiquorUse> LiquorUses { get; set; }
        public DbSet<CocktailLiquor> CocktailLiquors { get; set; }
        public DbSet<CustomCocktailLiquor> CustomCocktailLiquors { get; set; }
    }
}
