using System;

namespace CleanAPI.Core.DTOs
{
    public class UserfilterDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
