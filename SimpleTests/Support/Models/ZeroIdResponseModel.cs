using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTests.Support.Models
{
    internal class ZeroIdResponseModel
    {
        public string status { get; set; }

        public string message { get; set; }

        public int code { get; set; }

        public string errors { get; set; }
    }
}
