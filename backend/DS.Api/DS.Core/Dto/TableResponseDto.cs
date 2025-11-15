namespace DS.Core.Dto
{
    public class TableResponseDto<T> where T : class
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; } = [];
    }
}
