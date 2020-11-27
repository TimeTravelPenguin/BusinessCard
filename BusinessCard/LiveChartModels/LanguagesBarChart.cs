#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: LanguagesBarChart.cs
// 
// Current Data:
// 2020-11-27 6:53 PM
// 
// Creation Date:
// 2020-11-27 6:02 PM

#endregion

using System.Collections.Generic;
using System.Linq;
using BusinessCard.BaseTypes;
using LiveCharts;
using LiveCharts.Wpf;

namespace BusinessCard.LiveChartModels
{
  internal class LanguagesBarChart : PropertyChangedBase
  {
    private CartesianChart _chart = new CartesianChart();
    private SeriesCollection _scatterSeriesCollection = new SeriesCollection();

    public CartesianChart Chart
    {
      get => _chart;
      set => SetValue(ref _chart, value);
    }

    public SeriesCollection ScatterSeriesCollection
    {
      get => _scatterSeriesCollection;
      set => SetValue(ref _scatterSeriesCollection, value);
    }

    public LanguagesBarChart()
    {
      Chart.LegendLocation = LegendLocation.None;
      Chart.Series = ScatterSeriesCollection;
    }

    internal void ParseData()
    {
      var dataDict = new Dictionary<string, double>
      {
        ["C#"] = 100,
        ["Python"] = 75,
        ["Julia"] = 40,
        ["C++"] = 30,
        ["HTML/CSS"] = 35,
        ["JavaScript"] = 20
      };

      ScatterSeriesCollection.Add(new RowSeries
      {
        Title = "Language skills",
        Values = new ChartValues<double>(dataDict.Values)
      });

      UpdateAxes(dataDict.Keys.ToArray(), dataDict.Values.Max());

      OnPropertyChanged(nameof(ScatterSeriesCollection));
      OnPropertyChanged(nameof(Chart));
    }

    private void UpdateAxes(IList<string> labels, double xMax)
    {
      Chart.AxisX.Clear();
      Chart.AxisY.Clear();

      Chart.AxisY.Add(new Axis
      {
        Labels = labels,
        Unit = 1
      });

      Chart.AxisX.Add(new Axis
      {
        // BUG: Using string.Empty causes x-axis labels to cut off
        // Issue: https://github.com/Live-Charts/Live-Charts/issues/619
        LabelFormatter = x => " ",
        MaxValue = xMax + 3
      });
    }
  }
}