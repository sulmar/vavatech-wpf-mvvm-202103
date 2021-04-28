using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public static class BindingListExtensions
    {
        public static BindingList<T> ToBindingList<T>(this IEnumerable<T> collection)
        {
            return new BindingList<T>(collection.ToList());
        }

        public static SortableBindingList<T> ToSortableBindingList<T>(this IEnumerable<T> collection)
        {
            return new SortableBindingList<T>(collection.ToList());
        }
    }

    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }


    public static class EnumHelper
    {
        public static IEnumerable<T> GetValues<T>()
            where T : Enum => Enum.GetValues(typeof(T)).Cast<T>();
    }
}
