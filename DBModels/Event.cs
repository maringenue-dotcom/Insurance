using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBModels
{
    [Table("Events")]

    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UniId { get; set; }

        public string EventPlace { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public float Lat { get; set; }

        [Required]
        public float Lng { get; set; }
    }
}
