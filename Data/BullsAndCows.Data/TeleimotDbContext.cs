namespace Teleimot.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class TeleimotDbContext : IdentityDbContext<User>, ITeleimotDbContext
    {
        public TeleimotDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TeleimotDbContext Create()
        {
            return new TeleimotDbContext();
        }
    }
}
