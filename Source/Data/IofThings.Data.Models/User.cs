namespace IofThings.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    [Table("Users")]
    public class User : BaseDbModel
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}