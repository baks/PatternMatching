using System;
using System.Collections;
using System.Collections.Generic;

namespace SimplePatternMatching
{
    public sealed class Maybe<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> values; 
        
        public Maybe()
        {
            values = new T[0];
        }

        public Maybe(T element)
        {
            values = new []{element};
        }

        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class Maybe
    {
        public static Maybe<T> Nothing<T>() => new Maybe<T>();

        public static Maybe<T> With<T>(T element) => new Maybe<T>(element);
    }
}