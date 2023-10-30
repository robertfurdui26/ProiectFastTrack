using System.ComponentModel.DataAnnotations;

namespace ProiectFastTrack.Dto
{
    public class StudentCreateDto
    {
        [Required(AllowEmptyStrings = false,ErrorMessage ="Numele nu poate fi gol")]
        public string Nume { get; set; }

        [Range(1, int.MaxValue)]
        public int Varstra { get; set; }

        
    }
}
