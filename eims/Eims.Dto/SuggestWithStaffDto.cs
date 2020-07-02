using System;

namespace Eims.Dto
{
    public class SuggestWithStaffDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<int> StaffId { get; set; }
        public Nullable<System.DateTime> SuggestTime { get; set; }
        public string Reply { get; set; }
        public Nullable<System.DateTime> ReplyTime { get; set; }
        public string Staff_Name { get; set; }
    }
}
