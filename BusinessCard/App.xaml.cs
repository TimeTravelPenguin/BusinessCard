#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: App.xaml.cs
// 
// Current Data:
// 2020-11-23 11:50 PM
// 
// Creation Date:
// 2020-11-23 11:33 PM

#endregion

using System.Windows;

namespace BusinessCard
{
  /// <summary>
  ///   Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
      ApplicationShell.Start();
    }
  }
}