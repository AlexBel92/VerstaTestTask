using System;

namespace VerstaTestTask.Models
{
    public class PaginationViewModel
    {
        private int currentPage;

        public PaginationViewModel(int totalOrders, int pageSize = 5)
        {
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalOrders / PageSize);
            currentPage = 1;
        }

        public int PageSize { get; }
        public int TotalPages { get; }
        public int CurrentPage 
        {
            get => currentPage;
            set => currentPage = value < 1 ? 1 : value > TotalPages ? TotalPages : value; 
        }

        public bool IsLastPage => CurrentPage == TotalPages;
        public bool IsFirstPage => CurrentPage == 1;

        public int NextPage => IsLastPage ? TotalPages : CurrentPage + 1;
        public int PrevPage => IsFirstPage ? 1 : CurrentPage - 1;
    }
}
