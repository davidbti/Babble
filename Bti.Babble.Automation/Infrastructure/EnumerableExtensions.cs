using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Bti.Babble.Automation
{
    public static class EnumerableExtensions
    { 
        public static ObservableCollection<TSource> ToObservable<TSource>(this IEnumerable<TSource> source) 
        { 
            return new ObservableCollection<TSource>(source); 
        }
    }
}
