namespace HelpMyBook.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HelpMyBook.Common;
    using HelpMyBook.Data.Common.Models;

    public class BookFile : BaseModel<int>
    {
        public override int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public bool Downloadable { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.FileExtentionRegex, ErrorMessage = "File format not acceptable!")]
        public string FileExtension { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
