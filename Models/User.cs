using System.ComponentModel.DataAnnotations.Schema;

namespace expense_tracker.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set;  }
        public string username {  get; set; }
        public string password { get; set; }    
        public string email { get; set;  }
        public bool isPremium { get; set; }

        public DateTime CreatedAt { get; set;  }
        public DateTime UpdatedAt { get; set; }
        public DateTime LastLoginAt { get; set; }

    }
}
