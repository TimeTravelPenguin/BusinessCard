#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: ApplicationShell.cs
// 
// Current Data:
// 2020-11-25 5:18 PM
// 
// Creation Date:
// 2020-11-23 11:46 PM

#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using BusinessCard.LiveChartModels.DataReader;
using BusinessCard.Models;
using BusinessCard.ViewModels;
using BusinessCard.Views;
using BusinessCard.Views.Pages;
using Newtonsoft.Json;

namespace BusinessCard
{
  internal static class ApplicationShell
  {
    public static void Start()
    {
      var workingDirectory = Environment.CurrentDirectory; // directory is: \bin\Debug
      var projectDirectory = Directory.GetParent(workingDirectory).Parent!.Parent!.FullName;

      var userDataFile = $@"{projectDirectory}\BusinessCard\Assets\MyDetails.txt";
      var csvPath = $@"{projectDirectory}\BusinessCard\Assets\MyGrades.csv";

      var userDetails = GetUserDetails(userDataFile);
      var userGrades = ReadCsvData(csvPath);

      var window = NewMainWindow(userDetails, userGrades, "Phillip Smith Business Contact");

      window.Show();
    }


    private static Window NewMainWindow(UserDetails user, IEnumerable<Grade> userGrades, string title)
    {
      // TODO: Make a builder or factory to do this more abstractly

      var view = new ViewBase();

      var currentPageVm = new DefaultPageViewModel(view)
      {
        UserDetails = user,
        UserGrades = new ObservableCollection<Grade>(userGrades)
      };

      currentPageVm.GradesScatterChart.ParseData();

      var viewModel = new ViewModelBase(view)
      {
        CurrentPage = new DefaultPageView
        {
          DataContext = currentPageVm
        },
        WindowTitle = title
      };

      view.DataContext = viewModel;

      return view;
    }

    private static UserDetails GetUserDetails(string userDataFile)
    {
      using var reader = new StreamReader(userDataFile);
      return JsonConvert.DeserializeObject<UserDetails>(reader.ReadToEnd());
    }

    private static IEnumerable<Grade> ReadCsvData(string csvPath)
    {
      // For other type, a factory method can be used to return IReader type
      var reader = new GradesReader();

      return reader.Read(csvPath);
    }
  }
}