using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public class DataAccesLayerSingleton
    {
        //addd singleton
        #region Singleton
        private DataAccesLayerSingleton()
        {
            
        }

        public static DataAccesLayerSingleton instance;

        public static DataAccesLayerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccesLayerSingleton();
                }
                return instance;
            }
        }

        

        #endregion

        #region seed
        public void Seed()
        {
            using var cdv = new StudentDbContext();
            cdv.Add(new Student
            {
                Nume = "Marin Chitac",
                Varstra = 43,
                Adresa = new Address
                {
                    Oras = "Iasi",
                    Strada = "Revolutiei",
                    Numar = 32
                }
            });

            cdv.Add(new Student
            {
                Nume = "Florin Dumitrescu",
                Varstra = 38,
                Adresa = new Address
                {
                    Oras = "Bucuresti",
                    Strada = "Pietei",
                    Numar = 13
                }
            });
            cdv.Add(new Student
            {
                Nume = "Ionel Lupu",
                Varstra = 23,
                Adresa = new Address
                {
                    Oras = "Cluuuj",
                    Strada = "Centrala",
                    Numar = 14
                }
            });
            cdv.Add(new Student
            {
                Nume = "Mihaela Popa",
                Varstra = 18,
                Adresa = new Address
                {
                    Oras = "Deva",
                    Strada = "Principala",
                    Numar = 4
                }
            });
            cdv.SaveChanges();
        }
        #endregion

        public IEnumerable<Student> GetAllStudents()
        {
            using var cdv = new StudentDbContext();
            return cdv.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            using var cdv = new StudentDbContext();
            return cdv.Students.FirstOrDefault(c => c.Id == id);
        }

        public Student CreateStudent(Student student)
        {
            using var cdv = new StudentDbContext();

            if(cdv.Students.Any(s=>s.Id == student.Id))
            {
                //todo thrw exception
            }
            cdv.Add(student);
            cdv.SaveChanges();
            return student;

        }
    }
}
