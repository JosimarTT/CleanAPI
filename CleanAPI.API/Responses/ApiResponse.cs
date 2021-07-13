using CleanAPI.Core.CustomEntities;

namespace CleanAPI.API.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public MetaData MetaData { get; set; }
    }
}
