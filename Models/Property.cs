using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Swapartment.Areas.Identity.Data;

namespace Swapartment.Models
{

  [Table("Properties")]
  public class Property
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string Title { get; set; } = default!;

    [Required]
    [StringLength(500, MinimumLength = 25)]
    public string Description { get; set; } = default!;

    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Daily Rate")]
    public decimal DailyRate { get; set; }

    [Required]
    [RegularExpression(@"[0-9]*")]
    [Display(Name = "Bedrooms")]
    public string NumberOfBedrooms { get; set; } = default!;

    [Required]
    [RegularExpression(@"[0-9]*")]
    [Display(Name = "Bathrooms")]
    public string NumberOfBathrooms { get; set; } = default!;

    [RegularExpression(@"[0-9]*")]
    [Display(Name = "Unit Number")]
    public string? UnitNumber { get; set; } = default!;

    [Required]
    [StringLength(75, MinimumLength = 5)]
    [Display(Name = "Street Address")]
    public string StreetAddress { get; set; } = default!;

    [Required]
    [StringLength(50, MinimumLength = 2)] // min 2 in case we use initials
    public string State { get; set; } = default!;

    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string City { get; set; } = default!;

    [Required]
    [StringLength(10, MinimumLength = 5)]
    [Display(Name = "Postal Code")]
    public string PostalCode { get; set; } = default!;

    [Required]
    [StringLength(50, MinimumLength = 2)] // min 2 in case we use initials
    public string Country { get; set; } = default!;

    [Required]
    [Display(Name = "Owner")]
    public virtual SwapartmentUser SwapartmentUser { get; set; } = default!;

    [Display(Name = "Property Tags")]
    public virtual ICollection<PropertyTag> PropertyTags { get; set; } = default!;

    public virtual ICollection<PropertyImage> Images { get; set; } = default!;
  }
}