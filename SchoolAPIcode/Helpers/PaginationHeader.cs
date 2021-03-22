namespace SchoolAPIcode.Helpers
{
    public class PaginationHeader
    {
        
        public int CurrentPage { get; set; }
        public int ItensPerPage { get; set; }
        public int TotalItens { get; set; }
        public int TotalPages { get; set; }

        public PaginationHeader(int currentPage, int itensPerPage, int totalItens, int totalPages)
        {
            this.CurrentPage = currentPage;
            this.ItensPerPage = itensPerPage;
            this.TotalItens = totalItens;
            this.TotalPages = totalPages;

        }
    }
}