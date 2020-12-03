using Microsoft.EntityFrameworkCore;
using ZepteritTask.Database.Entities;

namespace ZepteritTask.Database
{
    public class ZepteritTaskContenxt : DbContext
    {
        public ZepteritTaskContenxt(DbContextOptions<ZepteritTaskContenxt> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //entities, indexes, relations configure
            
            base.OnModelCreating(modelBuilder);
        }
    }
}