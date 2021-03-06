using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ServidorApostas.Models
{
    public partial class Bet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Chave { get; set; }
        [Required]
        [StringLength(250)]
        public string DataRegisto { get; set; }
        public bool Arquivada { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
