using Behavior.DesignPatterns;
using System;

namespace Behavior
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Linked list

            var filter = new LinkedFilterChain();
            filter.AddFilter(new SexyFilter());
            filter.AddFilter(new AdFilter());
            filter.AddFilter(new ViolenceFilter());

            filter.DoFilter("it is sexy content");
            filter.DoFilter("it is ad content");
            filter.DoFilter("it is violence content");
            filter.DoFilter("it is clear content");

            #endregion

            #region List

            //var filter = new ListFilterChain();
            //filter.AddFilter(new SexyFilter());
            //filter.AddFilter(new AdFilter());
            //filter.AddFilter(new ViolenceFilter());

            //Console.WriteLine(filter.DoFilter("it is sexy content"));
            //Console.WriteLine(filter.DoFilter("it is ad content"));
            //Console.WriteLine(filter.DoFilter("it is violence content"));
            //Console.WriteLine(filter.DoFilter("it is clear content"));

            #endregion
        }
    }
}
