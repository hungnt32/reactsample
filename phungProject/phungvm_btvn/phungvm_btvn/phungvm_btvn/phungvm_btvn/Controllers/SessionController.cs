using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using phungvm_btvn.Models;
using System.ServiceModel.Web;
using System.Web.Http.Description;

namespace phungvm_btvn.Controllers
{
    public class SessionController : ApiController
    {
        UserDbContext db = new UserDbContext();

        //GET
        [HttpPost]
        public User AuthenUser(Session sessionRequest) { 
            string hashedPassword = Utilities.Utilities.PasswordHash(sessionRequest.Password);
            User user = db.User.Where(u => u.Account == sessionRequest.Account && u.Password == hashedPassword).FirstOrDefault();
            return user;
        }

        //POST
        [HttpPost]
        [ResponseType(typeof(Session))]
        [Route("session/login")]
        public Session CreateSession(Session sessionRequest)
        {
            User user = AuthenUser(sessionRequest);
            //Session sessionExist;
            Session session = new Session();
            var exist = db.Session.FirstOrDefault(s => s.Account == sessionRequest.Account);
            if (exist == null)
            {
                session.Token = Guid.NewGuid().ToString();
                session.Account = user.Account;
                session.UserId = user.UserId;
                try
                {
                    db.Session.Add(session);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw new WebFaultException<string>("Internal Server Error", HttpStatusCode.InternalServerError);
                }
                return new Session()
                {
                    Account = session.Account,
                    Token = session.Token,
                    UserId = session.UserId
                };
            }
            else
            {
                session = exist;
                return session;
            }
            
        }


    }
}
