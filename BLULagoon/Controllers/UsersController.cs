using BLULagoon.Models;
using BLULagoon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLULagoon.Controllers
{
    /// <summary>
    /// Controller for user requests.
    /// </summary>
    [Route("BLULagoon/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersRepository repository = new UsersRepository();
        
        /// <summary>
        /// Request to get all users from the database.
        /// 
        /// <c>GET: BLULagoon/Users (All users)</c>
        /// </summary>
        /// <returns>Returns all existing users</returns>
        [HttpGet]
        public List<User> Get()
        {
            return UsersRepository.GetAllUsers();
        }

        /// <summary>
        /// Request to add a new user to the database.
        /// 
        /// <c>POST: BLULagoon/Users</c>
        /// </summary>
        /// <param name="newUser">newUser object which comes from the request with required information</param>
        /// <returns>Returns the added user</returns>
        [HttpPost]
        public User PostNewUser([FromBody] User newUser)
        {
            repository.AddNewUser(newUser);

            return newUser;
        }

        /// <summary>
        /// Request to delete a user from the database.
        /// 
        /// <c>DELETE: BLULagoon/Users/{userid}</c>
        /// </summary>
        /// <param name="userid">userid which comes from the request</param>
        /// <returns>Returns all users after deletion</returns>
        [HttpDelete("{userid}")]
        public List<User> Delete(int userid)
        {
            repository.DeleteUser(userid);

            return Get();
        }
    }
}
