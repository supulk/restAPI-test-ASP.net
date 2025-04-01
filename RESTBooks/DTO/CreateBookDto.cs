using System.ComponentModel.DataAnnotations;

namespace RESTBooks.DTO
{
    public class CreateBookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
