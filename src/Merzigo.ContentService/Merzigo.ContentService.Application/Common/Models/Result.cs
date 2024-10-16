namespace Merzigo.ContentService.Application.Common.Models
{
    public interface IResult
    {
        /// <summary>
        ///     Gets the success status of the result.
        /// </summary>
        /// <example>false</example>
        bool IsSuccess { get; set; }

        /// <summary>
        ///     Represents the result of an operation, indicating whether the operation was successful or failed.
        /// </summary>
        string[] Errors { get; set; }
    }

    public class Result : IResult
    {
        protected Result(bool isSuccess, params string[] errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        /// <summary>
        ///     Gets the success status of the result.
        /// </summary>
        /// <example>false</example>
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Represents the result of an operation, indicating whether the operation was successful or failed.
        /// </summary>
        public string[] Errors { get; set; }

        public static IResult Fail(params string[] errors)
        {
            return new Result(false, errors);
        }

        public static IResult<T?> Fail<T>(params string[] errors)
        {
            return new Result<T?>(default, false, errors);
        }

        public static IResult Ok()
        {
            return new Result(true, Array.Empty<string>());
        }

        public static IResult<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, Array.Empty<string>());
        }

        public static implicit operator bool(Result result)
        {
            return result.IsSuccess;
        }

        public override string ToString()
        {
            return IsSuccess ? "success" : $"failure: {string.Join(", ", Errors.Select(e => e))}";
        }
    }
}
