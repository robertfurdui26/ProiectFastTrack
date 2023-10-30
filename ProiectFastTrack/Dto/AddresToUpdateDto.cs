using System.ComponentModel.DataAnnotations;

namespace ProiectFastTrack.Dto
{
    /// <summary>
    /// Addres the will be used for update
    /// </summary>
    public class AddresToUpdateDto
    {
        /// <summary>
        /// Street name
        /// </summary>
        /// 
        [Required(AllowEmptyStrings =false,ErrorMessage ="Strada nu poate fi goala")]
        public string Strada { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        /// 
        [Required(AllowEmptyStrings = false, ErrorMessage = "Orasul nu poate fi gol")]

        public string Oras { get; set; }
        /// <summary>
        /// Stree Name
        /// </summary>
        /// 
        [Range(1, int.MaxValue)]
        public int Numar { get; set; }
    }
}
