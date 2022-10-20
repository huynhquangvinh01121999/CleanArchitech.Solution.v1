using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? Deleted { get; set; } = false;
    }
}
