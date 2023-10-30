using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    /// <summary>
    /// Data Access layer - implemented with C#
    /// </summary>
    internal class DataAccesLayerService
    {
        private readonly StudentDbContext cdv;
        public DataAccesLayerService(StudentDbContext cdv)
        {
            this.cdv = cdv;
        }

        public IEnumerable<Student> GetAllStudent() => cdv.Studenti.ToList();
        public Student GetStudentById(int id)
        {
            var student = cdv.Studenti.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                //throw exception
            }
            return student;
        }

        public Student CreateStudent(Student student)
        {
            if (cdv.Studenti.Any(s => s.Id == student.Id))
            {
                //throw exception
            }
            cdv.Studenti.Add(student);
            cdv.SaveChanges();
            return student;
        }

        public Student UpdateStudent(Student studentToUpdate)
        {
            var student = cdv.Studenti.FirstOrDefault(x => x.Id == studentToUpdate.Id);
            if (student == null)
            {
                //thrpw exception
            }

            student.Nume = studentToUpdate.Nume;
            student.Varstra = studentToUpdate.Varstra;

            cdv.SaveChanges();
            return student;
        }

        public bool UpdateOrCreateAddress(int studentId, Address nouaAdresa)
        {
            var student = cdv.Studenti.Include(s => s.Adresa).FirstOrDefault(x => x.Id == studentId);
            if (student == null)
            {
                //throw exception
            }

            var created = false;

            if (student.Adresa == null)
            {
                student.Adresa = new Address();
                created = true;
            }

            student.Adresa.Numar = nouaAdresa.Numar;
            student.Adresa.Strada = nouaAdresa.Strada;
            student.Adresa.Oras = nouaAdresa.Oras;

            cdv.SaveChanges();
            return created;
        }

        public void DeleteStudent(int studentId)
        {
            var student = cdv.Studenti.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                //throw exception
            }

            cdv.Studenti.Remove(student);

            cdv.SaveChanges();
        }
    }

}
