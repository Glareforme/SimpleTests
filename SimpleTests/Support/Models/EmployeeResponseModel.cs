using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTests.Support.Models
{
    internal class EmployeeResponseModel
    {
        public string status { get; set; }

        public EmployeeModel data { get; set; }

        public string message { get; set; }
    }
}
