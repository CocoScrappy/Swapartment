using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Swapartment.Areas.Identity.Data;

namespace Swapartment.Models
{
  [Table("Rentals")]
  public class Rental
  {
    public int Id { get; set; }

    [Required]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime StartDate { get; set; }

    [Required]
    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime EndDate { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Price Total")]
    public decimal PriceTotal { get; set; }

    [Required]
    public Boolean isPaid { get; set; } = false;

    [StringLength(5000, MinimumLength = 10)]
    public string? Feedback { get; set; } = default!;


    public virtual Property? Property { get; set; } = default!;


    public virtual SwapartmentUser? Renter { get; set; } = default!;

  }
}