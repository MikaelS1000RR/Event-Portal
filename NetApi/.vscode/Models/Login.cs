using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Event_Portal.Models
{
    public record Login
    {

    [Required]
    public string Email { get; init; }

    [Required]
    public string Password { get; init; }
        
    }
}