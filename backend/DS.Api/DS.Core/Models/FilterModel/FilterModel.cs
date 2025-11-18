namespace DS.Core.Models.FilterModel
{
    public class FilterModel
    {
        public string? FilterKey { get; set; }
        public string Sort { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; }

        public string SortExpression()
        {
            return $"{Sort} {Order}";
        }

        public int RecordToSkip()
        {
            if (PageSize == 0)
            {
                PageSize = 10;
            }
            return PageIndex * PageSize;
        }
    }
}
