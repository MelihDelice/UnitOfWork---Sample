using System;

namespace PocketBook.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public int IsActiveStatus { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.MinValue;
        public DateTime RemovedDate { get; set; } = DateTime.MinValue;
    }
}