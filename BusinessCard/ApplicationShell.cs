#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: ApplicationShell.cs
// 
// Current Data:
// 2020-11-24 8:06 PM
// 
// Creation Date:
// 2020-11-23 11:46 PM

#endregion

using System;
using System.IO;
using System.Windows;
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
      UserDetails userDetails;

      var workingDirectory = Environment.CurrentDirectory; // directory is: \bin\Debug
      var projectDirectory = Directory.GetParent(workingDirectory).Parent!.Parent!.FullName;

      var file = $@"{projectDirectory}\BusinessCard\Assets\MyDetails.txt";
      using (var reader = new StreamReader(file))
      {
        userDetails = JsonConvert.DeserializeObject<UserDetails>(reader.ReadToEnd());
      }

      var window = NewMainWindow(userDetails, "Phillip Smith Business Contact");

      window.Show();
    }

    private static Window NewMainWindow(UserDetails user, string title)
    {
      // TODO: Make a builder or factory to do this more abstractly

      var view = new ViewBase();

      var currentPageVm = new DefaultPageViewModel(view);

      var viewModel = new ViewModelBase(view)
      {
        CurrentPage = new DefaultPageView
        {
          DataContext = currentPageVm
        },
        WindowTitle = title
      };

      currentPageVm.UserDetails.Update(user);

      view.DataContext = viewModel;

      return view;
    }
  }
}