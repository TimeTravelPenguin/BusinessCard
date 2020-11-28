#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: MonteCarloPi.cs
// 
// Current Data:
// 2020-11-28 5:18 PM
// 
// Creation Date:
// 2020-11-25 5:26 PM

#endregion

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using BusinessCard.BaseTypes;
using LiveCharts;
using LiveCharts.Wpf;

namespace BusinessCard.LiveChartModels
{
  internal class MonteCarloPi : PropertyChangedBase
  {
    private CartesianChart _chart = new CartesianChart
    {
      ChartLegend = new DefaultLegend
      {
        Margin = new Thickness(0, 10, 0, 0)
      }
    };

    private SeriesCollection _chartSeriesCollection = new SeriesCollection();
    private ObservableCollection<double> _piApprox = new ObservableCollection<double>();
    private int _seriesRange = 100;

    public CartesianChart Chart
    {
      get => _chart;
      set => SetValue(ref _chart, value);
    }

    public SeriesCollection ChartSeriesCollection
    {
      get => _chartSeriesCollection;
      set => SetValue(ref _chartSeriesCollection, value);
    }

    public int SeriesRange
    {
      get => _seriesRange;
      set => SetValue(ref _seriesRange, value);
    }

    public ObservableCollection<double> PiApprox
    {
      get => _piApprox;
      set => SetValue(ref _piApprox, value);
    }

    public MonteCarloPi()
    {
      Chart.LegendLocation = LegendLocation.Bottom;
      Chart.ChartLegend.FontFamily = new FontFamily("Segoe UI");
      Chart.ChartLegend.Foreground = new SolidColorBrush(Colors.White);
      Chart.Series = ChartSeriesCollection;
    }

    internal void ParseData()
    {
      var rand = new Random();

      const int n = 100000;
      Func<double> randPt = () => Math.Pow(rand.NextDouble(), 2) + Math.Pow(rand.NextDouble(), 2);

      PiApprox.Clear();

      var inside = 0;
      var outside = 0;
      for (var i = 0; i < n; i++)
      {
        ++outside;
        if (randPt.Invoke() < 1)
        {
          ++inside;
        }

        PiApprox.Add(4 * (double) inside / outside);
      }

      ChartSeriesCollection.Add(new LineSeries
      {
        Title = "Monte Carlo π approximation",
        Values = new ChartValues<double>(PiApprox.Skip(PiApprox.Count - SeriesRange)),
        PointGeometrySize = 0,
        PointForeground = Brushes.Transparent
      });

      UpdateAxes();

      OnPropertyChanged(nameof(ChartSeriesCollection));
      OnPropertyChanged(nameof(Chart));
    }

    private void UpdateAxes()
    {
      Chart.AxisX.Clear();
      Chart.AxisY.Clear();

      Chart.AxisX.Add(new Axis
      {
        MinValue = PiApprox[PiApprox.Count - SeriesRange],
        LabelFormatter = x => $"{PiApprox.Count} - {SeriesRange - x}",
        Separator = new Separator
        {
          StrokeDashArray = new DoubleCollection(new double[] {4})
        }
      });

      Chart.AxisY.Add(new Axis
      {
        LabelFormatter = x => $"{x}"
      });
    }

    public void NotifyChartRangeChange()
    {
      if (ChartSeriesCollection.Count > 0)
      {
        ChartSeriesCollection[0].Values = new ChartValues<double>(PiApprox.Skip(PiApprox.Count - SeriesRange));
        Chart.AxisX[0].MinValue = PiApprox[PiApprox.Count - SeriesRange];

        OnPropertyChanged(nameof(Chart));
        OnPropertyChanged(nameof(ChartSeriesCollection));
      }
    }
  }
}