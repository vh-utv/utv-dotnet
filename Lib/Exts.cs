using System;
using System.Collections.Generic;

namespace UtvDotNet.Lib
{
    public static class Exts
    {
        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        public static IEnumerable<TResult> Map<TSource, TResult>(
            this IEnumerable<TSource> input,
            Func<TSource, TResult> mapper
        )
        {
            throw new NotImplementedException("TODO: implement this");
        }

        /// <summary>
        /// Filter the input collection for items matching the provided predicate
        /// </summary>
        public static IEnumerable<T> Filter<T>(
            this IEnumerable<T> input, 
            Func<T, bool> predicate
        )
        {
            throw new NotImplementedException("TODO: implement this");
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.
        /// </summary>
        public static TAccumulate Reduce<TSource, TAccumulate>(
            this IEnumerable<TSource> input,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> reducer
        )
        {
            throw new NotImplementedException("TODO: implement this");
        }
    }
}
