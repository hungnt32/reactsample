using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace phungvm_btvn.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }

        public int UserId { get; set; }
        public String Account { get; set; }

        public String Password { get; set; }

        public String Token { get; set; }

        //public virtual List<Right> RightList { get; set; }
    }
}