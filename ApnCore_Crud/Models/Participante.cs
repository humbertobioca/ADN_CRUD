using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnCore_Crud.Models
{
    [Table(V)]
    public class Participante
    {
        protected const string V = "PARTICIPANTES";

        [Key]
        public int PPCODPAT { get; set; }
        [Required]
        public string PPFULLNAME { get; set; }
        [Required]
        public string PPTOKEN { get; set; }
        [Required]
        public string PPQRCODE { get; set; }
    }
}
