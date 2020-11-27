#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: ColorHelper.cs
// 
// Current Data:
// 2020-11-26 2:49 PM
// 
// Creation Date:
// 2020-11-26 2:33 PM

#endregion

using System;
using DColor = System.Drawing.Color;
using MColor = System.Windows.Media.Color;

namespace BusinessCard.LiveChartModels.DataReader
{
  internal static class ColorHelper
  {
    public static MColor ToMediaColor(this DColor colour)
    {
      return MColor.FromArgb(colour.A, colour.R, colour.G, colour.B);
    }

    public static DColor ToDrawingColor(this MColor colour)
    {
      return DColor.FromArgb(colour.A, colour.R, colour.G, colour.B);
    }

    #region HSV

    // See: https://stackoverflow.com/a/1335465

    public static void DrawingColorToHsv(this DColor color, out double hue, out double saturation, out double value)
    {
      int max = Math.Max(color.R, Math.Max(color.G, color.B));
      int min = Math.Min(color.R, Math.Min(color.G, color.B));

      hue = color.GetHue();
      saturation = max == 0 ? 0 : 1d - 1d * min / max;
      value = max / 255d;
    }

    public static void MediaColorToHsv(this MColor color, out double hue, out double saturation, out double value)
    {
      color.ToDrawingColor().DrawingColorToHsv(out hue, out saturation, out value);
    }

    public static DColor DrawingColorFromHsv(double hue, double saturation, double value)
    {
      var hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
      var f = hue / 60 - Math.Floor(hue / 60);

      value *= 255;
      var v = Convert.ToInt32(value);
      var p = Convert.ToInt32(value * (1 - saturation));
      var q = Convert.ToInt32(value * (1 - f * saturation));
      var t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

      return hi switch
      {
        0 => DColor.FromArgb(255, v, t, p),
        1 => DColor.FromArgb(255, q, v, p),
        2 => DColor.FromArgb(255, p, v, t),
        3 => DColor.FromArgb(255, p, q, v),
        4 => DColor.FromArgb(255, t, p, v),
        _ => DColor.FromArgb(255, v, p, q)
      };
    }

    public static MColor MediaColorFromHsv(double hue, double saturation, double value)
    {
      return DrawingColorFromHsv(hue, saturation, value).ToMediaColor();
    }

    #endregion
  }
}