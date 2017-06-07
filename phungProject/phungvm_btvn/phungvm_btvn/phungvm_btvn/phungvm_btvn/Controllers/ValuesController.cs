using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using phungvm_btvn.Models;

namespace phungvm_btvn.Controllers
{
    public class ValuesController : ApiController
    {
        private static IList<CommentModel> _comments; 
        
        [HttpGet, Route("api/comments")]
        public JsonResult<IList<CommentModel>> GetAllComment()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Thuan",
                    Description = "Day la Thuan"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Phung",
                    Description = "Day la Phung"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Hung",
                    Description = "Day la Hung"
                },
                new CommentModel
                {
                    Id = 4,
                    Author = "Anh",
                    Description = "Day la Anh"
                },
            };
            return Json(_comments);
        }

        [HttpPost, Route("api/addComment")]
        public IHttpActionResult AddComment(CommentModel commentModel)
        {
            commentModel.Id = _comments.Count + 1;
            _comments.Add(commentModel);
            return Json(new { result = "success"});
        } 

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
