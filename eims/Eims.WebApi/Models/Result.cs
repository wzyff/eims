using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eims.WebApi.Models
{
    public class Result
    {
        public int Code { get; set; }//1和0
        public object Data { get; set; }
        public string ErrorMessage { get; set; }

        public static Result Success(object data)
        {
            return new Result()
            {
                Code = 1,
                Data = data
            };
        }

        public static Result Fail(string errorMessage)
        {
            return new Result()
            {
                Code = 0,
                Data = errorMessage
            };
        }
    }
}