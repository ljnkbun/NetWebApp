namespace Core.Extensions.Objects
{
    public static class DecimalExtension
    {
        public static decimal Value(this decimal? obj)
        {
            return obj ?? 0;
        }
        public static decimal ValueIgnoreZero(this decimal? obj)
        {
            return obj == null || obj == 0 ? 1 : obj.Value;
        }
        public static decimal ValueIgnoreZero(this decimal obj)
        {
            return obj == 0 ? 1 : obj;
        }
    }
}
