namespace Sat.Recruitment.Api.Common
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public ResultStatus Status { get; protected set; }
        public string Errors { get; protected set; }

        public Result Success()
        {
            return new Result
            {
                IsSuccess = true,
                Status = ResultStatus.Success
            };
        }

        public Result BadRequest(string errors)
        {
            return new Result
            {
                IsSuccess = false,
                Status = ResultStatus.BadRequest,
                Errors = errors
            };
        }

        public Result Failed(string errors)
        {
            return new Result
            {
                IsSuccess = false,
                Status = ResultStatus.Failed,
                Errors = errors
            };
        }

        public Result NotFound(string errors)
        {
            return new Result
            {
                IsSuccess = false,
                Status = ResultStatus.NotFound,
                Errors = errors
            };
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; private set; }

        public new Result<T> Success(T data)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Status = ResultStatus.Success,
                Data = data
            };
        }

        public new Result<T> BadRequest(string errors)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Status = ResultStatus.BadRequest,
                Errors = errors
            };
        }

        public new Result<T> Failed(string errors)
        {
            return new Result<T>
            {
                IsSuccess= false,
                Status = ResultStatus.Failed,
                Errors = errors
            };
        }

        public Result<T> NotFound(string errors)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Status = ResultStatus.NotFound,
                Errors = errors
            };
        }
    }

    public enum ResultStatus
    {
        Success, BadRequest, Failed, NotFound
    }
}
