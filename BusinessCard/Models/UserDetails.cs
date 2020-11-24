#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: UserDetails.cs
// 
// Current Data:
// 2020-11-24 5:50 PM
// 
// Creation Date:
// 2020-11-24 1:27 PM

#endregion

using System.Collections.ObjectModel;
using BusinessCard.BaseTypes;

namespace BusinessCard.Models
{
  internal class UserDetails : PropertyChangedBase
  {
    private ObservableCollection<string> _credentials;
    private string _email;
    private string _mobile;
    private string _name;

    public string Name
    {
      get => _name;
      set => SetValue(ref _name, value);
    }

    public string Email
    {
      get => _email;
      set => SetValue(ref _email, value);
    }

    public string Mobile
    {
      get => _mobile;
      set => SetValue(ref _mobile, value);
    }

    public ObservableCollection<string> Credentials
    {
      get => _credentials;
      set => SetValue(ref _credentials, value);
    }

    internal void Update(UserDetails user)
    {
      Name = user.Name;
      Email = user.Email;
      Mobile = user.Mobile;
      Credentials = user.Credentials;
    }
  }
}