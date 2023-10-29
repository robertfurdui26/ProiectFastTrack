using Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFastTrack.Dto;
using ProiectFastTrack.Utils;

namespace ProiectFastTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        /// <summary>
        /// Instaleaza Db-ul
        /// </summary>

        [HttpPost("seed")]
        public void Seed() => DataAccesLayerSingleton.Instance.Seed();


        /// <summary>
        /// Returns all student in the db
        /// </summary>

        [HttpGet]

        public IEnumerable<StudentGetDto> GetAllStudenst()
        {
            var allStudents = DataAccesLayerSingleton.Instance.GetAllStudents();
            return allStudents.Select(s => s.ToDto()).ToList();


        }

        /// <summary>
        /// Get Student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>student data</returns>

        [HttpGet("/id/{id}")]
        public StudentGetDto GetStudentById(int id) =>
        
             DataAccesLayerSingleton.Instance.GetStudentById(id).ToDto();


        /// <summary>
        /// Create Student
        /// </summary>
        /// <returns>create student</returns>

        [HttpPost]

        public StudentGetDto CreateStudent([FromBody] StudentCreateDto studentToCreate) =>
        
            DataAccesLayerSingleton.Instance.CreateStudent(studentToCreate.ToEntity()).ToDto();
        
        
    }
}
