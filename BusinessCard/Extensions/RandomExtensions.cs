#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: RandomExtensions.cs
// 
// Current Data:
// 2020-11-25 8:14 PM
// 
// Creation Date:
// 2020-11-25 8:11 PM

#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessCard.Extensions
{
  internal static class RandomExtensions
  {
    private static readonly Random Random = new Random();
    private static readonly object SyncLock = new object();

    public static T RandomIn<T>(this IEnumerable<T> collection)
    {
      var enumerable = collection as T[] ?? collection.ToArray();
      var length = enumerable.Count();

      lock (SyncLock)
      {
        return enumerable[Random.Next(length)];
      }
    }
  }
}