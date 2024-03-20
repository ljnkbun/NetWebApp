namespace Core.Extensions.Objects
{
    public static class ExceptionExtension
    {
        public static string FullMessage(this Exception ex)
        {
            var errors = new List<string>();
            var exrun = ex;
            while (exrun != null)
            {
                errors.Add(exrun.Message);
                exrun = exrun.InnerException;
            }
            return string.Join(Environment.NewLine, errors);
        }
    }
}
