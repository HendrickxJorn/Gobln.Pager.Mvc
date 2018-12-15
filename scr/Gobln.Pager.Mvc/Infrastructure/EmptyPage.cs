namespace Gobln.Pager.Mvc.Infrastructure
{
    internal class EmptyPage : IPage
    {
        public int CurrentPageIndex { get { return 1; } }

        public bool HasMultiplePages { get { return false; } }

        public bool IsEmpty { get { return true; } }

        public int PageSize { get { return 1; } }

        public int TotalItemCount { get { return 0; } }

        public int TotalPageCount { get { return 1; } }

        public int StartRecordIndex { get { return 0; } }

        public int EndRecordIndex { get { return 0; } }

        public bool HasPaging { get { return false; } }
    }
}