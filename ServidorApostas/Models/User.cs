using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ServidorApostas.Models
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nome { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}
