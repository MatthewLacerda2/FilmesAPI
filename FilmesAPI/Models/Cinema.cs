using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models {
    
    public class Cinema {

        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }=string.Empty;

        public int preco { get; set; }

        public int EnderecoID { get; set; }
        public virtual Endereco endereco { get; set; }
        public virtual ICollection<Sessao> sessoes { get; set; }
    }
}