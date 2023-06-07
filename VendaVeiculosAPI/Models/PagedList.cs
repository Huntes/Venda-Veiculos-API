namespace VendaVeiculosAPI.Models
{
    public class PagedList<T>
    {
        public IReadOnlyList<T> Data { get; set; } = new List<T>().AsReadOnly();
        public int Total { get; set; } = 0;
        public int Pages { get; set; } = 0;
    }
}
