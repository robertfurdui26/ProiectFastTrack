using ProiectFastTrack.Dto;

namespace ProiectFastTrack.Utils
{
    public static class CursUtil
    {
        public static CursGetDto ToCursDto(this CursGetDto cursGetDto)
        {
            if (cursGetDto == null)
            {
                return null;
            }
            return new CursGetDto { Id = cursGetDto.Id, Nume = cursGetDto.Nume };
        }
    }
}
