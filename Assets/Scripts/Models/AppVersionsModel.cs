using System;

namespace Models
{
    public class AppVersionsModel
    {
        public Guid Id { get; set; }
        public float IOS { get; set; } = 0;
        public float Android { get; set; } = 0;
    }
}
