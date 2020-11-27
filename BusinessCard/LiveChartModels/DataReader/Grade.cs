#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: Grade.cs
// 
// Current Data:
// 2020-11-25 5:02 PM
// 
// Creation Date:
// 2020-11-25 4:26 PM

#endregion

namespace BusinessCard.LiveChartModels.DataReader
{
  internal class Grade
  {
    public string Course { get; }
    public double Year { get; }
    public int Mark { get; }
    public string OfficialGrade { get; }

    public Grade(double year, string course, int mark, string officialGrade)
    {
      Course = course;
      Year = year;
      Mark = mark;
      OfficialGrade = officialGrade;
    }
  }
}