#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: EnumerableExtensions.cs
// 
// Current Data:
// 2020-11-27 7:52 PM
// 
// Creation Date:
// 2020-11-27 7:49 PM

#endregion

using System;
using System.Collections.Generic;

namespace BusinessCard.Extensions
{
  internal static class EnumerableExtensions
  {
    public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> collection, int n)
    {
      // Source: https://stackoverflow.com/a/3453310

      if (collection == null)
      {
        throw new ArgumentNullException(nameof(collection));
      }

      if (n < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)} must be 0 or greater");
      }

      var temp = new LinkedList<T>();

      foreach (var value in collection)
      {
        temp.AddLast(value);
        if (temp.Count > n)
        {
          temp.RemoveFirst();
        }
      }

      return temp;
    }
  }
}