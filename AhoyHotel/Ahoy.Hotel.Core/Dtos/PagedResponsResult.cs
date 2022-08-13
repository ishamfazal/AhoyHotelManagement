using Ahoy.Hotel.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahoy.Hotel.Core.Dtos
{
    public class PagedResponsResult<T> : PagedResultDtoBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResponsResult()
        {
            Results = new List<T>();
        }
    }

    public abstract class PagedResultDtoBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }
}
