using System.Linq;
using phungvm_btvn.Models;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;

namespace phungvm_btvn.Controllers
{
    public class UsersController : ApiController
    {
        private UserDbContext db = new UserDbContext();

        //POST
        [HttpPost]
        [Route("user/register")]
        public User Register(User userRequest)
        {
                var check = db.User.FirstOrDefault(u => u.Account.Equals(userRequest.Account));
                if (check == null)
                {
                    var usr = new User()
                    {
                        Account = userRequest.Account,
                        Password = Utilities.Utilities.PasswordHash(userRequest.Password),
                        Fullname = userRequest.Fullname,
                        Email = userRequest.Email,
                        Phone = userRequest.Phone,
                        Age = userRequest.Age
                    };
                    User addUser = db.User.Add(usr);
                    db.SaveChanges();
                    return addUser;
                }
                else
                {
                    return null;
                }
        }

        //POST
        [HttpGet]
        [Route("user/exist/{token}")]
        public Session Exist(string token)
        {
            var check = db.Session.FirstOrDefault(u => u.Token.Equals(token));
            if (check == null)
            {
                return null;
            }
            else
            {
                return check;
            }
        }
        
    }
}