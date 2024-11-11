using System;

namespace Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public float Rating { get; set; } = 0;

        public int RatingAmount { get; set; } = 0;
        public int RatingTotal { get; set; } = 0;
        public string AvatarImage { get; set; } = string.Empty;
    }
}
