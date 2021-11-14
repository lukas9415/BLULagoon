using BLULagoon.Models;
using BLULagoon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLULagoon.Controllers
{
    [Route("BLULagoon/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersRepository repository = new UsersRepository();


        [HttpGet]
        public List<User> Get()
        {
            return UsersRepository.GetAllUsers();
        }


        [HttpPost]
        public User PostNewUser([FromBody] User newUser)
        {
            repository.AddNewUser(newUser);

            return newUser;
        }


        [HttpDelete("{userid}")]
        public List<User> Delete(int userid)
        {
            repository.DeleteUser(userid);

            return Get();
        }
    }
}
