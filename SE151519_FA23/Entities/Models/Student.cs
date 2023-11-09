using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models;

public partial class Student
{
    public int Id { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [RegularExpression(@"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$", 
        ErrorMessage = "Full Name format is invalid. Each word should begin with a capital letter.")]
    //[StringLength(10, MinimumLength = 6, ErrorMessage = "FullName must be between 6 and 10 characters.")]
    public string? FullName { get; set; }
    //[Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
    public DateTime? DateOfBirth { get; set; }
    public int? GroupId { get; set; }
    [JsonIgnore]
    public virtual StudentGroup? Group { get; set; }
}
