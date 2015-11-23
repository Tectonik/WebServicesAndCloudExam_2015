namespace Teleimot.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<RealEstate> ads;

        public User()
        {
            this.ads = new HashSet<RealEstate>();
        }

        public int Rank { get; set; }

        public virtual ICollection<RealEstate> Guesses
        {
            get { return this.ads; }
            set { this.ads = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
