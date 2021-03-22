using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SchoolAPIcode.Helpers
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }


        public PageList(List<T> itens, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPage = (int)Math.Ceiling(count /(double)pageSize);
            this.AddRange(itens);
        }

        public static async Task<PageList<T>> CreateAsync(
            IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var itens = await source.Skip((pageNumber-1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return new PageList<T>(itens, count, pageNumber, pageSize);
        }



    }
}