namespace proDuck.Application.DTOs;

public class ResponseDto<T>
{
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public object Data { get; set; }
    public ErrorDto Error { get; set; }

    public static ResponseDto<T> Success(int statusCode)
    {
        return new ResponseDto<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
    }

    public static ResponseDto<T> Success(T data, int statusCode)
    {
        return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
    }

    public static ResponseDto<T> Success(T data, string message, int statusCode)
    {
        return new ResponseDto<T> { Data = data, Message = message, StatusCode = statusCode, IsSuccessful = true };
    }
    public static ResponseDto<T> Fail(ErrorDto errorDto, int statusCode)
    {
        return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
    }

    public static ResponseDto<T> Fail(ErrorDto errorDto, string message, int statusCode)
    {
        return new ResponseDto<T> { Error = errorDto, Message = message, StatusCode = statusCode, IsSuccessful = false };
    }

    public static ResponseDto<T> Fail(string message, int statusCode, bool isShow)
    {
        return new ResponseDto<T> { Error = new ErrorDto(message, isShow), StatusCode = statusCode, IsSuccessful = false };
    }
}
