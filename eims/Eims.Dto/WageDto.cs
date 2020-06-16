using System;

namespace Eims.Dto
{
    public class WageDto
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<int> StaffId { get; set; }
        public string AttendanceName { get; set; }
        public Nullable<double> AttendanceMoney { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Times { get; set; }
    }
}
