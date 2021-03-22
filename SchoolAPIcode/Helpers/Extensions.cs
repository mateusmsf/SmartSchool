using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SchoolAPIcode.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response,
            int currentPage, int itensPerPage, int totalItens, int totalPage)
        {
            var paginationHeader = new PaginationHeader(currentPage, itensPerPage, totalItens, totalPage);

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}