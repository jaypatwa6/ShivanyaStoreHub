using System.Diagnostics.Contracts;

namespace SSH.Framework.Model.QueryObjects
{
    public class PagedList<T> : PageInfo
    {
        #region Fields

        public int FirstItemOnPage { get; protected set; }

        public bool HasNextPage { get; protected set; }

        public bool HasPreviousPage { get; protected set; }

        public bool IsFirstPage { get; protected set; }

        public bool IsLastPage { get; protected set; }

        public int LastItemOnPage { get; protected set; }

        public int PageCount { get; protected set; }

        public int TotalItemCount { get; protected set; }

        public List<T> Subset { get; set; }

        #endregion

        #region Constructors and Destructors

        public PagedList(List<T> subset, PageInfo pageInfo, int totalItemCount)
            : this(subset, pageInfo.PageNumber, pageInfo.PageSize, totalItemCount)
        {

        }

        public PagedList(List<T> subset, int pageNumber, int pageSize, int totalItemCount)
        {
            Contract.Assert(pageNumber >= 1);
            Contract.Assert(pageSize >= 1);

            Initialize(pageNumber, pageSize, totalItemCount);

            Subset = subset;
        }

        public PagedList(IQueryable<T> superset, PageInfo pageInfo)
            : this(superset, pageInfo.PageNumber, pageInfo.PageSize)
        {
        }

        public PagedList(IQueryable<T> superset, int pageNumber, int pageSize)
        {
            Contract.Assert(pageNumber >= 1);
            Contract.Assert(pageSize >= 1);

            var totalItemCount = superset?.Count() ?? 0;
            Initialize(pageNumber, pageSize, totalItemCount);

            // add items to internal list
            Paging(superset, pageNumber, pageSize);
        }


        private void Paging(IQueryable<T> superset, int pageNumber, int pageSize)
        {
            Subset = new List<T>();
            // add items to internal list
            if (superset != null && TotalItemCount > 0)
            {
                int skipCount = (pageNumber - 1) * pageSize;
                Subset = superset.Skip(skipCount).Take(pageSize).ToList();
            }
        }

        protected internal void Initialize(int pageNumber, int pageSize, int totalItemCount)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
            }

            if ((totalItemCount > 0) && (pageSize < 1))
            {
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");
            }

            // set source to blank list if superset is null to prevent exceptions
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = TotalItemCount > 0
                ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
                : 0;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < PageCount;
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber >= PageCount;
            FirstItemOnPage = ((PageNumber - 1) * PageSize) + 1;
            var numberOfLastItemOnPage = FirstItemOnPage + PageSize - 1;
            LastItemOnPage = numberOfLastItemOnPage > TotalItemCount
                ? TotalItemCount
                : numberOfLastItemOnPage;
        }

        #endregion
    }
}
