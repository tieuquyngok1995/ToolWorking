namespace WorkBuddy.Helpers;

public static class UIHelper
{
    public static class ColorHelper
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Randomly select any background color and return a text color (black/white) ensuring the best contrast.
        /// </summary>
        public static (Color background, Color foreground) CreateColorPair()
        {
            Color background = Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256));
            Color foreground = GetReadableTextColor(background);

            return (background, foreground);
        }

        /// <summary>
        /// Calculates relative luminance according to WCAG standard
        /// and returns black or white depending on whether the background color is light or dark
        /// </summary>
        private static Color GetReadableTextColor(Color background) => GetRelativeLuminance(background) > 0.5 ? Color.Black : Color.White;

        private static double GetRelativeLuminance(Color c) => 0.2126 * LinearizeChannel(c.R / 255.0) + 0.7152 * LinearizeChannel(c.G / 255.0) + 0.0722 * LinearizeChannel(c.B / 255.0);

        private static double LinearizeChannel(double channel) => channel <= 0.03928 ? channel / 12.92 : Math.Pow((channel + 0.055) / 1.055, 2.4);
    }
}
