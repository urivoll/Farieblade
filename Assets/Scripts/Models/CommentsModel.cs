using System;

namespace Models
{
    public class CommentsModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        
        public int Rating { get; set; } = 0;

        public string AvatarImage { get; set; } = string.Empty;

        public Guid CommentUserId { get; set; }
        public Guid UserId { get; set; }
    }
}
