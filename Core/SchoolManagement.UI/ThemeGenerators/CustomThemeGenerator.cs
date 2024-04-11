using ActiproSoftware.UI.Avalonia.Themes;
using ActiproSoftware.UI.Avalonia.Themes.Generation;
using Avalonia.Media;

namespace SchoolManagement.UI.ThemeGenerators
{
    public class CustomThemeGenerator : ThemeGenerator
    {
        protected override Brush? GetBrushResource(ThemeGeneratorSession session, ThemeResourceKind resourceKind)
        {
            return resourceKind switch
            {
                ThemeResourceKind.CheckerboardPrimaryBrush => new SolidColorBrush(Colors.Yellow),
                ThemeResourceKind.CheckerboardSecondaryBrush => new SolidColorBrush(Colors.Black),

                _ => base.GetBrushResource(session, resourceKind)
            };
        }

        protected override void OnSessionCompleted(ThemeGeneratorSession session)
        {
            if (session.ThemeVariant is not null)
            {
                // Add a custom "MyBrush" resource brush
                session.ResourceDictionary.Add("MyBrush",
                    new SolidColorBrush(session.IsDark ? Colors.LightBlue : Colors.DarkBlue));
            }
        }
    }
}