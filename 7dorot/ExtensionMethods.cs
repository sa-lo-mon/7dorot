using System;
using System.Collections.Generic;
using System.Linq;

namespace ShevaDorot
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method that runs a for loop on a collection but does not modify the data
        /// </summary>
        /// <typeparam name="T">Any type that can be part of a collection</typeparam>
        /// <param name="source">Object that extension method works from: IEnumerable and anything that inherits from that"/></param>
        /// <param name="whatFor">The Action to be done for each item in the collection</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> doWhat)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (doWhat == null) throw new ArgumentNullException("doWhat");
            foreach (var item in source) doWhat(item);
        }

        /// <summary>
        /// Extension method that takes a collection of one type and returns a collection of another type
        /// </summary>
        /// <typeparam name="TIn">Type of each input object item</typeparam>
        /// <typeparam name="TOut">Type of each output object item</typeparam>
        /// <param name="source">Object that extension method works from: IEnumerable and anything that inherits from that</param>
        /// <param name="change">Func that changes one type to another type</param>
        /// <returns></returns>
        public static IEnumerable<TOut> ChangeEach<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> change)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (change == null) throw new ArgumentNullException("change");
            var ChangedTo = new List<TOut>();
            source.ForEach(item => ChangedTo.Add(change(item)));
            return ChangedTo.AsEnumerable();
        }
    }
}
