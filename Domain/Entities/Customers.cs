using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Customers : BaseEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Contact { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
    }
}
