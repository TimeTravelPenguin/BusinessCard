#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: GradesReader.cs
// 
// Current Data:
// 2020-11-25 5:02 PM
// 
// Creation Date:
// 2020-11-25 5:01 PM

#endregion

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessCard.LiveChartModels.DataReader
{
  internal class GradesReader : IReader<Grade>
  {
    public IEnumerable<Grade> Read(string path)
    {
      return File.ReadAllLines(path)
        .Skip(1)
        .Select(v => v.GradeFromCsvLine());
    }
  }
}