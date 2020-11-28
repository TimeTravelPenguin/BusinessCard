#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: DefaultPageViewModel.cs
// 
// Current Data:
// 2020-11-28 5:05 PM
// 
// Creation Date:
// 2020-11-23 11:34 PM

#endregion

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using BusinessCard.LiveChartModels;
using BusinessCard.LiveChartModels.DataReader;
using BusinessCard.Models;
using Microsoft.Expression.Interactivity.Core;

namespace BusinessCard.ViewModels
{
  internal class DefaultPageViewModel : ViewModelBase
  {
    private MonteCarloPi _gradesScatterChart = new MonteCarloPi();
    private UserDetails _userDetails = new UserDetails();
    private ObservableCollection<Grade> _userGrades = new ObservableCollection<Grade>();
    public ActionCommand UpdateGradesCommand { get; }

    public UserDetails UserDetails
    {
      get => _userDetails;
      set => SetValue(ref _userDetails, value);
    }

    public ObservableCollection<Grade> UserGrades
    {
      get => _userGrades;
      set => SetValue(ref _userGrades, value);
    }

    public MonteCarloPi GradesScatterChart
    {
      get => _gradesScatterChart;
      set => SetValue(ref _gradesScatterChart, value);
    }

    public ICommand UpdateChartRangeCommand { get; }

    public DefaultPageViewModel(Window window, ResizeMode resizeMode = ResizeMode.CanResizeWithGrip)
      : base(window, resizeMode)
    {
      // Please hire me :)
      UpdateGradesCommand = new ActionCommand(UpdateGrades);
      UpdateChartRangeCommand = new ActionCommand(UpdateChartRange);
    }

    private void UpdateChartRange()
    {
      GradesScatterChart.NotifyChartRangeChange();
    }

    public void UpdateGrades()
    {
      GradesScatterChart.ChartSeriesCollection.Clear();

      GradesScatterChart.ParseData();
      OnPropertyChanged(nameof(GradesScatterChart));
    }
  }
}