namespace Core.Models.Entities
{
    public class BaseListCreateDeleteEntity<T>
    {
        public List<T> LstDataDelete { get; set; }
        public List<T> LstDataAdd { get; set; }
    }
}
