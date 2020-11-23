#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: ViewModelBase.cs
// 
// Current Data:
// 2020-11-23 11:38 PM
// 
// Creation Date:
// 2020-11-23 11:34 PM

#endregion

using System.Windows;
using System.Windows.Controls;
using BusinessCard.BaseTypes;
using Microsoft.Expression.Interactivity.Core;

namespace BusinessCard.ViewModels
{
  internal class ViewModelBase : PropertyChangedBase
  {
    private Page _currentPage;
    private ResizeMode _resizeMode;
    private string _windowTitle;

    public ResizeMode ResizeMode
    {
      get => _resizeMode;
      set => SetValue(ref _resizeMode, value);
    }

    public string WindowTitle
    {
      get => _windowTitle;
      set => SetValue(ref _windowTitle, value);
    }

    public Page CurrentPage
    {
      get => _currentPage;
      set => SetValue(ref _currentPage, value);
    }

    public ActionCommand CloseWindow { get; }
    public ActionCommand MinimizeWindow { get; }
    public ActionCommand MaximizeWindow { get; }

    protected ViewModelBase(Window window, ResizeMode resizeMode = ResizeMode.CanResizeWithGrip)
    {
      CloseWindow = new ActionCommand(window.Close);
      MinimizeWindow = new ActionCommand(() => window.WindowState = WindowState.Minimized);
      MaximizeWindow = new ActionCommand(() => window.WindowState = WindowState.Maximized);
      ResizeMode = resizeMode;
    }
  }
}