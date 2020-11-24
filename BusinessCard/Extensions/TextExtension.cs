#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: TextExtension.cs
// 
// Current Data:
// 2020-11-24 5:50 PM
// 
// Creation Date:
// 2020-11-24 12:07 PM

#endregion

using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Markup;

namespace BusinessCard.Extensions
{
  public class TextExtension : MarkupExtension
  {
    private readonly string _fileName;

    public TextExtension(string fileName)
    {
      _fileName = fileName;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      if (_fileName is null)
      {
        // Simple error handling
        return string.Empty;
      }

      var uri = new Uri("pack://application:,,,/" + _fileName);
      using (var stream = Application.GetResourceStream(uri)?.Stream)
      {
        using (var reader = new StreamReader(stream ?? throw new InvalidOperationException(), Encoding.UTF8))
        {
          return reader.ReadToEnd();
        }
      }
    }
  }
}