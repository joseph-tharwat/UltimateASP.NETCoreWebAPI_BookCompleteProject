﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id {  get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        [MaxLength(60,ErrorMessage ="Company name should be less than 60 chars")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string? Address {  get; set; }

        public string? Country { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
