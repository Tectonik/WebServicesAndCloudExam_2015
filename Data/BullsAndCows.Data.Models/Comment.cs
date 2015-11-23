namespace Teleimot.Data.Models
{
    using System;

    public class Comment
    {
        public Comment(DateTime createdOn, string userName, string content)
        {
            this.CreatedOn = createdOn;
            this.UserName = userName;
            this.Content = content;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public RealEstate Estate { get; set; }
    }
}
