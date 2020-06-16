using System;

namespace Eims.Dto
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public Nullable<int> StaffId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
