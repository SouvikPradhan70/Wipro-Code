﻿using System.ComponentModel.DataAnnotations;

namespace MvcBindingDemo.Models
{
    public class Address
    {
        [Required] public string Street { get; set; } = string.Empty;
        [Required] public string City { get; set; } = string.Empty;
        [Required] public string ZipCode { get; set; } = string.Empty;
    }
}

