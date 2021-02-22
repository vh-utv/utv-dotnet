using System;
using System.Collections.Generic;

namespace UtvDotNet.Lib
{
    public static class Exts
    {
        // Transform the input collection to another collection that can be of a different type
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, TResult> mapper)
        {
            throw new NotImplementedException("TODO: implement this");
        }

        // Filter the input collection for items matching the provided predicate
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, Func<T, bool> predicate)
        {
            throw new NotImplementedException("TODO: implement this");
        }

        // Enumerate over the input and fold its elements into a single output
        public static TAccumulate Reduce<TSource, TAccumulate, TResult>(this IEnumerable<TSource> input, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> reducer)
        {
            throw new NotImplementedException("TODO: implement this");
        }

        // Transform or flatten the input collection into another collection
        public static IEnumerable<TResult> FlatMap<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, IEnumerable<TResult>> mapper)
        {
            throw new NotImplementedException("TODO: implement this");
        }
    }
}