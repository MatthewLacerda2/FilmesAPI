using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models {
    public class Sessao {

        [Key]
        [Required]
        public int id { get; set; }

        public int filmeID { get; set; }
        public virtual Filme filme { get; set; }
    }
}
