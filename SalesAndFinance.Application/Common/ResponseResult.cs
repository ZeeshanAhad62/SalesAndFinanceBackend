namespace SalesAndFinance.Application.Common
{
    public class ResponseResult<T>
    {
        public ResponseStatuses ResponseStatus { get; set; }
        public T? Result { get; set; }
        public string Error { get; set; }
    }

    public enum ResponseStatuses : byte
    {
        Pending,
        Created,
        Updated,
        Deleted,
        Success,
        NotFound,
        BadRequest,
        InternalServerError,
        Unauthorized
    }
}
