using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBModels
{
    [Table("Campuses")]
    public class Campus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string? Street { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(50)]
        public string? State { get; set; }

        public int? ZipCode { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public int Students { get; set; }

        public float Lat { get; set; }

        public float Lng { get; set; }
    }
}
