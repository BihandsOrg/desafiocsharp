using Bookstore.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bookstore.Application.DTOs;

public class BookDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Title is Required")]
    [MinLength(3)]
    [MaxLength(200)]
    [DisplayName("Title")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(5)]
    [MaxLength(300)]
    [DisplayName("Description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The Writer is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Writer")]
    public string? Writer { get; set; }

    [Required(ErrorMessage = "The ISBNCode is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("ISBNCode")]
    public string? ISBNCode { get; set; }

    [Required(ErrorMessage = "The Publisher is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Publisher")]
    public string? Publisher { get; set; }

    [Required(ErrorMessage = "The Price is Required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1, 9999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }

    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string? Image { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }

    [DisplayName("Categories")]
    public int CategoryId { get; set; }
}
