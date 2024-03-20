namespace Core.Settings
{
    public record CacheSettings
    {
        public int SlidingExpiration { get; set; }
    }
}
