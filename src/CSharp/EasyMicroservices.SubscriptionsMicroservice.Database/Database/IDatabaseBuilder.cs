using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.SubscriptionsMicroservice.Database
{
    public interface IDatabaseBuilder
    {
        void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}
