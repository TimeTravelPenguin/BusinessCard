using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessCard.ViewModels;
using BusinessCard.Views;
using BusinessCard.Views.Pages;

namespace BusinessCard
{
  internal static class ApplicationShell
  {
    public static void Start()
    {
      var view = new ViewBase();
      var vm = new DefaultPageViewModel(view)
      {
        WindowTitle = "Phillip Employment Manager",
        CurrentPage = new DefaultPageView()
      };

      view.DataContext = vm;

      view.Show();
    }
  }
}
