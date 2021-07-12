using System;

namespace CleanAPI.Core.QueryFilters
{
    public class PostQueryFilter
    {
        public int? UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
