using System.Diagnostics.CodeAnalysis;

namespace Merzigo.UserService.Application.Common.Models
{
    public interface IResult<out T> : IResult
    {
        T Value { get; }
    }

    public class Result<T> : Result, IResult<T>
    {
        internal Result(T value, bool isSuccess, params string[] errors) : base(isSuccess, errors)
        {
            Value = value!;
        }

        [NotNull]
        public T Value { get; }
    }
}