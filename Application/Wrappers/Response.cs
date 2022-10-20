using System.Collections.Generic;

namespace Application.Wrappers
{
    public class Response<T>
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public IList<string> Errors { get; set; }

        public Response<T> Successed(string mess, T obj)
            => new Response<T> { IsSuccessed = true, Message = mess, Data = obj };

        public Response<T> Successed(string mess)
           => new Response<T> { IsSuccessed = true, Message = mess };

        public Response<T> Failed(string mess)
            => new Response<T> { IsSuccessed = false, Message = mess };
    }
}
