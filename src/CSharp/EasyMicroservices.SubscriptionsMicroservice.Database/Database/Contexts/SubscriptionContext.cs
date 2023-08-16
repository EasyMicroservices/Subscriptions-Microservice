using EasyMicroservices.SubscriptionsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.SubscriptionsMicroservice.Database.Contexts
{
    public class SubscriptionContext : RelationalCoreContext
    {
        IDatabaseBuilder _builder;
        public SubscriptionContext(IDatabaseBuilder builder)
        {
            _builder = builder;
        }

        public DbSet<SubscriptionEntity> Subscriptions { get; set; }
        public DbSet<SubscriptionUserEntity> SubscriptionUser { get; set; }
        public DbSet<SubscriptionParameterEntity> SubscriptionParameter { get; set; }
        public DbSet<SubscriptionParameterValueEntity> SubscriptionParameterValue { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_builder != null)
                _builder.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubscriptionEntity>(model =>
            {
                model.HasKey(x => x.Id);
            });

            modelBuilder.Entity<SubscriptionUserEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(x => x.Subscriptions)
                .WithMany(x => x.SubscriptionUsers)
                .HasForeignKey(x => x.SubscriptionId);

            });

            modelBuilder.Entity<SubscriptionParameterEntity>(model =>
            {
                model.HasKey(x => x.Id);

                 model.HasOne(x => x.Subscriptions)
                .WithMany(x => x.SubscriptionParameters)
                .HasForeignKey(x => x.SubscriptionId);

                 model.HasOne(x => x.SubscriptionUsers)
                .WithMany(x => x.SubscriptionParameters)
                .HasForeignKey(x => x.SubscriptionId);
            });
            
            modelBuilder.Entity<SubscriptionParameterValueEntity>(model =>
            {
                model.HasKey(x => x.Id);
                
                model.HasOne(x => x.SubscriptionParameters)
               .WithMany(x => x.Values)
               .HasForeignKey(x => x.SubscriptionParameterId);
            });

        }
    }
}