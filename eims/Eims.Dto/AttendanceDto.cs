using System;

namespace Eims.Dto
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Money { get; set; }
        public string Remarks { get; set; }
    }
}
