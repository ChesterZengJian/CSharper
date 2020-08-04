using System;
using System.Collections.Generic;
using System.Threading;

namespace Behavior.DesignPatterns
{
    #region Linked List

    public interface IFilter
    {
        IFilter NextFilter { get; set; }
        bool DoFilter(string content);
    }

    public class SexyFilter : IFilter
    {
        public IFilter NextFilter { get; set; }
        public bool DoFilter(string content)
        {
            var success = !content.Contains("sexy", System.StringComparison.OrdinalIgnoreCase);

            if (success && NextFilter != null) return NextFilter.DoFilter(content);
            if (success && NextFilter == null) return true;
            Console.WriteLine("have sexy");

            return false;
        }
    }

    public class AdFilter : IFilter
    {
        public IFilter NextFilter { get; set; }
        public bool DoFilter(string content)
        {
            var success = !content.Contains("ad", System.StringComparison.OrdinalIgnoreCase);

            if (success && NextFilter != null) return NextFilter.DoFilter(content);
            if (success && NextFilter == null) return true;
            Console.WriteLine("have ad");
            return false;

        }
    }
    public class ViolenceFilter : IFilter
    {
        public IFilter NextFilter { get; set; }
        public bool DoFilter(string content)
        {
            var success = !content.Contains("violence", System.StringComparison.OrdinalIgnoreCase);

            if (success && NextFilter != null) return NextFilter.DoFilter(content);
            if (success && NextFilter == null) return true;
            Console.WriteLine("have violence");
            return false;
        }
    }

    public class LinkedFilterChain
    {
        private IFilter m_head;
        private IFilter m_tail;

        public void AddFilter(IFilter filter)
        {
            filter.NextFilter = null;
            if (m_head == null)
            {
                m_head = filter;
                m_tail = filter;
                return;
            }

            m_tail.NextFilter = filter;
            m_tail = filter;
        }

        public void DoFilter(string content)
        {
            if (m_head != null && m_head.DoFilter(content))
            {
                Console.WriteLine("It is a very nice content");
                return;
            }

            Console.WriteLine("It is a bad content");
        }
    }

    #endregion

    #region List

    //public interface IFilter
    //{
    //    string DoFilter(string content);
    //}

    //public class SexyFilter : IFilter
    //{
    //    public IFilter NextFilter { get; set; }
    //    public string DoFilter(string content)
    //    {
    //        return content.Replace("sexy", "****");
    //    }
    //}

    //public class AdFilter : IFilter
    //{
    //    public IFilter NextFilter { get; set; }
    //    public string DoFilter(string content)
    //    {
    //        return content.Replace("ad", "**");
    //    }
    //}
    //public class ViolenceFilter : IFilter
    //{
    //    public IFilter NextFilter { get; set; }
    //    public string DoFilter(string content)
    //    {
    //        return content.Replace("violence", "********");
    //    }
    //}

    //public class ListFilterChain
    //{
    //    private readonly List<IFilter> m_filters = new List<IFilter>();

    //    public void AddFilter(IFilter filter)
    //    {
    //        m_filters.Add(filter);
    //    }

    //    public string DoFilter(string content)
    //    {
    //        foreach (var filter in m_filters)
    //        {
    //            content = filter.DoFilter(content);
    //        }

    //        return content;
    //    }
    //}

    #endregion
}