using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Common
{
    public class Result
    {
        protected Result(bool isSuccess, IReadOnlyList<Error> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public bool IsSuccess { get; }
        public IReadOnlyList<Error> Errors { get; }

        public static Result Ok() => new Result(true, new List<Error>());
        public static Result Fail(Error error) => new Result(false, new[] {error});
        public static Result Fail(IReadOnlyList<Error> errors) => new Result(false, errors);



    }
    public class Result<T> : Result
    {
        private readonly T _value;

        public T Data => IsSuccess ? _value : default;
        private Result(T value) : base(true, new List<Error>())
        {
            _value = value;
        }
        private Result(Error error) : base(false, new[] {error})
        {
            _value = default!;
        }
        private Result(IReadOnlyList<Error> errors) : base(false, errors)
        {
            _value = default!;
        }
        public static Result<T> Ok(T value) => new Result<T>(value);
        public static new Result<T> Fail(Error error) => new Result<T>(new[] { error });
        public static new Result<T> Fail(IReadOnlyList<Error> errors) => new Result<T>( errors);
    }
}
