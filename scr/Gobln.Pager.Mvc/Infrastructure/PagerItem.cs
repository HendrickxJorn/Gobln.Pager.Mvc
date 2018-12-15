namespace Gobln.Pager.Mvc.Infrastructure
{
    internal class PagerItem
    {
        public string CssClass { get; set; }

        internal string Label { get; set; }

        internal int PageIndex { get; set; }

        internal bool Disabled { get; set; }
    }
}