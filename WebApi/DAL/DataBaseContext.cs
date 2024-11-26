using Microsoft.EntityFrameworkCore;
using WebApi.DAL.Entities;

namespace WebApi.DAL
{
    //Instalar(importante)
    //Microsoft.EntityFrameworkCore V6.0.22
    //Microsoft.EntityFrameworkCore.Tools V6.0.22
    //Microsoft.EntityFrameworkCore.SqlServer V6.0.22
    //Microsoft.EntityFrameworkCore.Design V6.0.22
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext > options) : base(options) //Asi me conecto a la base de datos por medio de este constructor
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //Aqui creo un indice del campo Name para la tabla Countries

            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); //Significa que estoy haciendo un indice compuesto
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        #endregion
    }
}
