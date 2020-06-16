using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eims.WebApi.Models
{
    public class UserViewModel
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public int Role { get; set; }
    }
}