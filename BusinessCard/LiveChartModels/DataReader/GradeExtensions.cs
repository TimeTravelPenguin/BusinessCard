#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: GradeExtensions.cs
// 
// Current Data:
// 2020-11-25 5:02 PM
// 
// Creation Date:
// 2020-11-25 5:01 PM

#endregion

namespace BusinessCard.LiveChartModels.DataReader
{
  internal static class GradeExtensions
  {
    public static Grade GradeFromCsvLine(this string csvLine)
    {
      var line = csvLine.Split(',');

      // NOTE: Using int.Parse without proper error handling due to knowing exact input format
      // Proper implementation would use a proper reader, reading header information!

      return new Grade(double.Parse(line[0]), line[1], int.Parse(line[2]), line[3]);
    }
  }
}