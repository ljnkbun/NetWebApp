namespace Core.Models.Parameters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
        private List<string> SearchProps { get; set; }

        public bool BypassCache { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public RequestParameter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public void SetSearchProps(List<string> searchProps) => SearchProps = searchProps;
        public List<string> GetSearchProps() => SearchProps;
    }
}
