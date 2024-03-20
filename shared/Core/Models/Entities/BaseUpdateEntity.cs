namespace Core.Models.Entities
{
    public class BaseUpdateEntity<T>
    {
        public IEnumerable<T> LstDataDelete { get; set; }
        public IEnumerable<T> LstDataAdd { get; set; }
        public IEnumerable<T> LstDataUpdate { get; set; }
    }
}
