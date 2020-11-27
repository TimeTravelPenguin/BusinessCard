#region Title Header

// Name: Phillip Smith
// 
// Solution: BusinessCard
// Project: BusinessCard
// File Name: Colours.cs
// 
// Current Data:
// 2020-11-26 2:50 PM
// 
// Creation Date:
// 2020-11-25 8:07 PM

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using BusinessCard.Extensions;
using BusinessCard.LiveChartModels.DataReader;

namespace BusinessCard.LiveChartModels
{
  internal static class Colours
  {
    public static readonly Color BrickRed = Color.FromRgb(206, 66, 87);
    public static readonly Color Coral = Color.FromRgb(255, 127, 81);
    public static readonly Color DarkOrchid = Color.FromRgb(150, 73, 203);
    public static readonly Color Iris = Color.FromRgb(97, 83, 204);
    public static readonly Color StarCommandBlue = Color.FromRgb(34, 116, 165);

    public static IEnumerable<Color> GetColours()
    {
      return typeof(Colours).GetFields(BindingFlags.Static | BindingFlags.Public)
        .Select(x => (Color) x.GetValue(null));
    }

    public static Color GetRandomColour()
    {
      return GetColours().RandomIn();
    }

    public static Color Darken(this Color colour, double newBrightness)
    {
      colour.MediaColorToHsv(out var h, out var s, out var v);
      return ColorHelper.MediaColorFromHsv(h, s, newBrightness);
    }

    public static Color ToMediaColor(this Color colour)
    {
      return Color.FromRgb(colour.R, colour.G, colour.B);
    }
  }
}