using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Traffic
{
    public static class EnumerableExtensions
    { 
        public static ObservableCollection<TSource> ToObservable<TSource>(this IEnumerable<TSource> source) 
        { 
            return new ObservableCollection<TSource>(source); 
        }
    }
}
