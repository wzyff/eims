using System;

namespace Eims.Dto
{
    public class StaffDto
    {
        public Nullable<int> RoleId { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string IDcard { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Address { get; set; }
        public string Hometown { get; set; }
        public string GraduatedSchool { get; set; }
        public string EducationLevel { get; set; }
        public string PoliticalStatus { get; set; }
        public string MaritalStatus { get; set; }
        public string HealthStatus { get; set; }
        public string WorkingState { get; set; }
    }
}
