using System.Linq;
using System.Web.Http;
using phungvm_btvn.Models;


namespace phungvm_btvn.Controllers
{
    public class DepartmentsController : ApiController
    {
        UserDbContext db = new UserDbContext();

        [HttpPost]
        [Route("department/new")]
        public Department AddDepartment(Department departmentReq)
        {
            var check = db.Department.FirstOrDefault(u => u.DepartmentName.Equals(departmentReq.DepartmentName));
            if (check == null)
            {
                var dep = new Department()
                {
                    DepartmentName = departmentReq.DepartmentName,
                    Size = departmentReq.Size,
                    Description = departmentReq.Description
                };
                Department addDep = db.Department.Add(dep);
                db.SaveChanges();
                return addDep;
            }
            else
            {
                return null;
            }
        }
    }
}
