#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: DefaultPageViewModel.cs
// 
// Current Data:
// 2020-11-24 7:59 PM
// 
// Creation Date:
// 2020-11-23 11:34 PM

#endregion

using System.Windows;
using BusinessCard.Models;
using Microsoft.Expression.Interactivity.Core;

namespace BusinessCard.ViewModels
{
  internal class DefaultPageViewModel : ViewModelBase
  {
    private UserDetails _userDetails = new UserDetails();
    public ActionCommand Ping { get; }

    public UserDetails UserDetails
    {
      get => _userDetails;
      set => SetValue(ref _userDetails, value);
    }

    public DefaultPageViewModel(Window window, ResizeMode resizeMode = ResizeMode.CanResizeWithGrip)
      : base(window, resizeMode)
    {
      // Please hire me :)
      Ping = new ActionCommand(PingPls);
    }

    public void PingPls()
    {
      MessageBox.Show(UserDetails.Email);
      OnPropertyChanged(nameof(UserDetails));
      OnPropertyChanged(nameof(UserDetails.Email));
    }
  }
}