using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using phungvm_btvn.Models;

namespace phungvm_btvn.Controllers
{
    public class CommentController : ApiController
    {
        private static IList<CommentModel> _comments;

        [HttpGet, Route("comment/getAll")]
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

        [HttpPost, Route("comment/addNew")]
        public IHttpActionResult AddComment(CommentModel commentModel)
        {
            commentModel.Id = _comments.Count + 1;
            _comments.Add(commentModel);
            return Json(new { result = "success" });
        }
    }
}
