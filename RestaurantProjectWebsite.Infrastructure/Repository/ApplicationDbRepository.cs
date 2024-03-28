using RestauranProjectWebsite.Infrastructure.Data;

namespace RestauranProjectWebsite.Infrastructure.Repositories
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}