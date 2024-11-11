using System;

namespace Models
{
    public class SubscriptionModel
    {
        public Guid Id { get; set; }
        public bool IsValid { get; set; }
        public bool IsBanned { get; set; }
        public DateTime DatePurchased { get; set; }
        public DateTime DateOfEnd { get; set; }
        public string SubscribtionType { get; set; } = string.Empty;
        public int SubscribtionDuration { get; set; } = 0;

        public Guid UserId { get; set; }
    }
}
