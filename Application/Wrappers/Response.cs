namespace Application.Wrappers
{
    public class Response<T>
    {
        public bool isSuccess { get; set; }

        public string Message { get; set; }

        public T Object { get; set; }

        public Response<T> Successed(string mess, T obj)
            => new Response<T> { isSuccess = true, Message = mess, Object = obj };

        public Response<T> Successed(string mess)
           => new Response<T> { isSuccess = true, Message = mess };

        public Response<T> Failed(string mess)
            => new Response<T> { isSuccess = false, Message = mess };
    }
}
