namespace CleanArchitecture.Core.Interfaces
{
    public class Page
    {
        public Page(int pageSize, int pageNumber)
        {
            Take = pageSize;
            Skip = (pageNumber - 1) * pageSize;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}
