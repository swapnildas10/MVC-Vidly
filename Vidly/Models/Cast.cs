using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Cast
    {
        public int Id { get; set; }
        public string Character { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Profile_Path { get; set; }
    }
}