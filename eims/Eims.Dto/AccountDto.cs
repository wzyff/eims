using System;

namespace Eims.Dto
{
    public class AccountDto
    {
        public Nullable<int> RoleId { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
