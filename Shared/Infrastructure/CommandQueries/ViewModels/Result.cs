namespace Infrastructure.CommandQueries.Models
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToList();
        }

        public bool Succeeded { get; set; }

        public List<string> Errors { get; set; }

        public static Result Success()
        {
            return new Result(true, new List<string>());
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}
