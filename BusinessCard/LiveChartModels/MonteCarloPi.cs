#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: MonteCarloPi.cs
// 
// Current Data:
// 2020-11-27 9:33 PM
// 
// Creation Date:
// 2020-11-25 5:26 PM

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using BusinessCard.BaseTypes;
using BusinessCard.Extensions;
using LiveCharts;
using LiveCharts.Wpf;

namespace BusinessCard.LiveChartModels
{
  internal class MonteCarloPi : PropertyChangedBase
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

    public MonteCarloPi()
    {
      Chart.LegendLocation = LegendLocation.Bottom;
      Chart.ChartLegend.FontFamily = new FontFamily("Segoe UI");
      Chart.ChartLegend.Foreground = new SolidColorBrush(Colors.White);
      Chart.Series = ScatterSeriesCollection;
    }

    internal void ParseData()
    {
      var rand = new Random();

      const int n = 1000000;
      Func<double> randPt = () => Math.Pow(rand.NextDouble(), 2) + Math.Pow(rand.NextDouble(), 2);

      var piApprox = new List<double>();

      var inside = 0;
      var outside = 0;
      for (var i = 0; i < n; i++)
      {
        ++outside;
        if (randPt.Invoke() < 1)
        {
          ++inside;
        }

        piApprox.Add(4 * (double) inside / outside);
      }

      const int seriesLength = 50;

      ScatterSeriesCollection.Add(new LineSeries
      {
        Title = "Monte Carlo Pi approximation",
        Values = new ChartValues<double>(piApprox.TakeLast(seriesLength)),
        PointGeometrySize = 0,
        PointForeground = Brushes.Transparent
      });

      UpdateAxes(piApprox.LastOrDefault(), piApprox[piApprox.Count - seriesLength]);

      OnPropertyChanged(nameof(ScatterSeriesCollection));
      OnPropertyChanged(nameof(Chart));
    }

    private void UpdateAxes(double maxX, double seriesLength)
    {
      Chart.AxisX.Clear();
      Chart.AxisY.Clear();

      Chart.AxisX.Add(new Axis
      {
        MinValue = maxX - seriesLength,
        Unit = 1
      });

      Chart.AxisY.Add(new Axis
      {
        LabelFormatter = x => $"{x}"
      });
    }
  }
}