#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: IReader.cs
// 
// Current Data:
// 2020-11-25 5:02 PM
// 
// Creation Date:
// 2020-11-25 5:01 PM

#endregion

using System.Collections.Generic;

namespace BusinessCard.LiveChartModels.DataReader
{
  internal interface IReader<out T>
  {
    IEnumerable<T> Read(string path);
  }
}