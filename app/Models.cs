using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProgrammingLanguagesDatabase.Models
{
    [Table("lang", Schema = "plang")]
    public class Language
    {
        [Key]
        [Column("idlang")]
        public int Id { get; set; }

        [Required]
        [Column("designation")]
        [StringLength(30)]
        public string Name { get; set; }

        [Column("created")]
        public int? YearCreated { get; set; }

        public ICollection<CreatedBy> CreatedBy { get; set; }
    }

    [Table("author", Schema = "plang")]
    public class Author
    {
        [Key]
        [Column("idauthor")]
        public int Id { get; set; }

        [Column("firstname")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Column("surname")]
        [StringLength(40)]
        public string Surname { get; set; }

        [Column("company")]
        [StringLength(40)]
        public string Company { get; set; }

        public ICollection<CreatedBy> CreatedBy { get; set; }
    }

    [Table("createdby", Schema = "plang")]
    public class CreatedBy
    {
        [Key]
        [Column("idcreatedby")]
        public int Id { get; set; }

        [Column("lang_idlang")]
        public int LanguageId { get; set; }

        [Column("author_idauthor")]
        public int AuthorId { get; set; }

        public Language Language { get; set; }
        public Author Author { get; set; }
    }
}
