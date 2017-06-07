using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace phungvm_btvn.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please enter Department name")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Please enter department size")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int Size { get; set; }


        public string Description { get; set; }
    }
}