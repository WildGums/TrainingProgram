namespace CollectionRules
{
    using System;
    using System.Collections;

    public static class ListExtensions
    {
        public static bool Move(this IEnumerable enumerable, int oldIndex, int newIndex, out object item)
        {
            item = null;

            if (Equals(oldIndex, newIndex))
            {
                return false;
            }

            if (!(enumerable is IList source))
            {
                return false;
            }

            if (source is Array)
            {
                return false;
            }

            if (newIndex < 0 || newIndex >= source.Count)
            {
                return false;
            }

            item = source[oldIndex];

            source.RemoveAt(oldIndex);
            source.Insert(newIndex, item);

            return true;
        }

    }
}
