using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface IDataAccesLayerService
    {
        Student CreateStudent(Student student);
        void DeleteStudent(int studentId);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void Seed();
        bool UpdateOrCreateStudentAddress(int studentId, Address nouaAdresa);
        Student UpdateStudent(Student studentToUpdate);
    }
}
