namespace HelpMyBook.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HelpMyBook.Common;
    using HelpMyBook.Data.Common.Models;

    public class BookFile : BaseModel<int>
    {
        // [Key]
        // [ForeignKey("Book")]
        public override int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.FileExtentionRegex, ErrorMessage = "File format not acceptable!")]
        public string FileExtension { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        //[ForeignKey("Book")]
        //public virtual Book Book { get; set; }

        //public int BookId { get; set; }
    }
}
