#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: DefaultPageView.cs
// 
// Current Data:
// 2020-11-24 5:50 PM
// 
// Creation Date:
// 2020-11-23 11:34 PM

#endregion

using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BusinessCard.Views.Pages
{
  /// <summary>
  ///   Interaction logic for MainPageView.xaml
  /// </summary>
  public partial class DefaultPageView : Page
  {
    public DefaultPageView()
    {
      InitializeComponent();
    }

    private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
      Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
      e.Handled = true;
    }
  }
}