using System;
using System.Collections.Generic;

namespace UtvDotNet.Lib
{
    public static class Exts
    {
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, TResult> mapper)
        {
            throw new NotImplementedException("TODO: implement this");
        }

        public static IEnumerable<TResult> FlatMap<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, IEnumerable<TResult>> mapper)
        {
            throw new NotImplementedException("TODO: implement this");
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, Func<T, bool> filter)
        {
            throw new NotImplementedException("TODO: implement this");
        }

        public static TAccumulate Reduce<T, TAccumulate>(this IEnumerable<T> input, T seed, Func<TAccumulate, T, TAccumulate> func)
        {
            throw new NotImplementedException("TODO: implement this");
        }
    }
}