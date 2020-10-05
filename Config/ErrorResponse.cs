using Newtonsoft.Json;

namespace CastGroup.Config
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


    public class ErrorResponseDetails
    {
        public string RequestId { get; set; }
    }
}
