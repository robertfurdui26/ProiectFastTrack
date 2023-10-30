using Data.Models;
using ProiectFastTrack.Dto;

namespace ProiectFastTrack.Utils
{
    public static class StudentUtils
    {
        public static StudentGetDto ToDto( this Student student)
        {
            if(student == null)
            {
                return null;
            }
          return   new StudentGetDto { Id = student.Id, Nume = student.Nume, Varstra = student.Varstra };
        }

        public static Student ToEntity( this StudentCreateDto student )
        {
            if(student == null)
            {
                return null;
            }

            return new Student
            {
                Nume = student.Nume,
                Varstra = student.Varstra,
            };
          
        }

        public static Student ToEntity(this StudentToUpdateDto student)
        {
            if (student == null)
            {
                return null;
            }

            return new Student
            {
                Id = student.Id,
                Nume = student.Nume,
                Varstra = student.Varstra,
            };

        }

        public static Address ToEntity(this AddresToUpdateDto addresToUpdate)
        {
            if(addresToUpdate == null)
            {
                return null;
            }
            return new Address
            {
                Numar = addresToUpdate.Numar,
                Oras = addresToUpdate.Oras,
                Strada = addresToUpdate.Strada
            };
        }

        
    };

}

