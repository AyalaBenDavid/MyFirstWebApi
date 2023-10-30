using Microsoft.AspNetCore.Mvc;
using Servicies;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Entities;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserServicies userServicies = new UserServicies();
       
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get([FromQuery] string userName, [FromQuery] string code)
        {
            Users user = userServicies.GetUserByPasswordAndUserName(code, userName);
            if (user == null)
                return NoContent();
            return Ok(user);
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api/<UserController>
        [HttpPost("makeuser")]
        //public IActionResult Post([FromBody] Users user)
        //{
        //    //var result = Zxcvbn.Core.EvaluatePassword(user.Code);
        //    //int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
        //    //user.UserId = numberOfUsers + 1;
        //    //if (result.Score <= 2) return BadRequest();
        //    //string userJson = JsonSerializer.Serialize(user);
        //    //System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
        //    //return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        //}

        [HttpPost("check")]
        public int check([FromBody] string Code)
        {
            var result = Zxcvbn.Core.EvaluatePassword(Code);
            return result.Score;
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users userToUpdate)
        {
            //string textToReplace = string.Empty;
            //using (StreamReader reader = System.IO.File.OpenText(filePath))
            //{
            //    string currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {

            //        Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
            //        if (user.UserId == id)
            //            textToReplace = currentUserInFile;
            //    }
            //}
            //if (textToReplace != string.Empty)
            //{
            //    string text = System.IO.File.ReadAllText(filePath);
            //    text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
            //    System.IO.File.WriteAllText(filePath, text);
            //}

        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
