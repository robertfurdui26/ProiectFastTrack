using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFastTrack.Dto;
using ProiectFastTrack.Utils;
using System.ComponentModel.DataAnnotations;

namespace ProiectFastTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private readonly IDataAccesLayerService dal;
        public StudentiController(IDataAccesLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Returns all the students in the db
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentGetDto> GetAllStudents()
        {
            var allStudents = dal.GetAllStudents();

            return allStudents.Select(s => s.ToDto()).ToList();
        }


        /// <summary>
        /// Gets a student by id
        /// </summary>
        /// <param name="id">id of the student</param>
        /// <returns>student data</returns>
        [HttpGet("/id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public ActionResult<StudentGetDto> GetStudentById([Range(10, int.MaxValue)] int id) =>
            Ok(dal.GetStudentById(id).ToDto());



        /// <summary>
        /// Creates a student
        /// </summary>
        /// <param name="studentToCreate">student to create data</param>
        /// <returns>created student data</returns>
        [HttpPost]
        public StudentGetDto CreateStudent([FromBody] StudentCreateDto studentToCreate) =>
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        [HttpPatch]
        public StudentGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
            dal.UpdateStudent(studentToUpdate.ToEntity()).ToDto();


        /// <summary>
        /// sddshjjklasdjklasdkljjasldk
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressToUpdate"></param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateStudentAddress([FromRoute] int id, [FromBody] AddresToUpdateDto addressToUpdate)
        {

            if (dal.UpdateOrCreateStudentAddress(id, addressToUpdate.ToEntity()))
            {
                return Created("succeess", null);
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 0)
            {
                return BadRequest("id cannot be 0");
            }
            try
            {
                dal.DeleteStudent(id);
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }


    }
}
