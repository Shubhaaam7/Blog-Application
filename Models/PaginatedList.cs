using Microsoft.Identity.Client;

namespace BlogApplication.Models
{
    public class PaginatedList
    {

        public int PageIndex { get; set; }
       
        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public PaginatedList() { }

        public PaginatedList(int totalItem,int page,int pageSize=50)
        {
            int totalPages=(int)Math.Ceiling((double)totalItem / pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if(startPage<=0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if(endPage> totalPages)
            {
                endPage = startPage;
                if (endPage > 10)
                    startPage = endPage - 9;
            }


            TotalItems = totalItem;
            CurrentPage = currentPage;
            PageSize = pageSize; ;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;

               
        }


    }
}
