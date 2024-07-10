using Bookstore.Domain.Validation;
using System.Xml.Linq;

namespace Bookstore.Domain.Entities;

public sealed class Book : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Writer { get; private set; }
    public string ISBNCode { get; private set; }
    public string Publisher { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }


    public Book(string title, string description, string writer, string iSBNCode, string publisher, decimal price, int stock, string image)
    {
        ValidateDomain(title, description, writer, iSBNCode, publisher, price, stock, image);
    }

    public Book(int id, string title, string description, string writer, string iSBNCode, string publisher, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(title, description, writer, iSBNCode, publisher, price, stock, image);
    }

    public void Update(string title, string description, string writer, string iSBNCode, string publisher, decimal price, int stock, string image, int categodyId)
    {
        ValidateDomain(title, description, writer, iSBNCode, publisher, price, stock, image);
        CategoryId = categodyId;
    }

    private void ValidateDomain(string title, string description, string writer, string iSBNCode, string publisher, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(title),
            "Invalid title. Title is required");

        DomainExceptionValidation.When(title.Length < 3,
            "Invalid title, too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(writer),
           "Invalid writer. Writer is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(iSBNCode),
           "Invalid iSBNCode. ISBNCode is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(publisher),
           "Invalid publisher. Publisher is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description),
           "Invalid description. Description is required");

        DomainExceptionValidation.When(price < 0, "Invalid price value");

        DomainExceptionValidation.When(stock < 0, "Invalid stock value");

        DomainExceptionValidation.When(image?.Length > 250,
            "Invalid image name, too long, maximum 250 characters");

        Title = title;
        Description = description;
        Writer = writer;
        ISBNCode = iSBNCode;
        Publisher = publisher;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
