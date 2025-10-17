using System.ComponentModel.DataAnnotations;

namespace BussinessDomains
{
    public record Herois
    {
        [Key]
        public int Id {  get; set; }

        [Required, MaxLength(120)]
        public string Nome { get; set; } = string.Empty;
        [Required, MaxLength(120)]
        public string NomeHeroi { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
        [Required]
        public float Altura { get; set; }
        [Required]
        public float Peso { get; set; }


        public Herois(int id, string nome, string nomeHeroi, DateTime dataNascimento, float altura, float peso)
        {
            Id = id;
            Nome = nome;
            NomeHeroi = nomeHeroi;
            DataNascimento = dataNascimento;
            Altura = altura;
            Peso = peso;
        }
    }
}
