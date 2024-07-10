using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Books(Title,Description,Writer,ISBNCode,Publisher,Price,Stock,Image,CategoryId) " +
            "VALUES('A menina que roubava livros', 'A menina gostava de roubar livros..','Markus Zusak','978-8598078175','Intrínseca',46,10,'menina roubando.jpg',1)");

            mb.Sql("INSERT INTO Books(Title,Description,Writer,ISBNCode,Publisher,Price,Stock,Image,CategoryId) " +
            "VALUES('Harry Potter e a Pedra Filosofal', 'Harry e seus amigos..','J. K. Rowling','978-8532530783','Rocco',109,11,'harry e uma pedra.jpg',1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Books");
        }
    }
}
