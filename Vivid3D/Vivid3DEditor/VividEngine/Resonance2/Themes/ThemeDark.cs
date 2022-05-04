using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VividEngine.Resonance2.Themes
{
    public class ThemeDark : ITheme
    {

        public ThemeDark()
        {

            Button = new Texture.Texture2D("Data/UI/Theme/DarkTheme/Button1.png",false);
            Frame = new Texture.Texture2D("Data/UI/Theme/DarkTheme/Frame1.png", false);
            WindowTitle = new Texture.Texture2D("Data/UI/Theme/DarkTheme/WindowTitle1.png", false);
            SystemFont = new Font.FontTTF("Data/UI/Theme/DarkTheme/DarkSys.ttf", 13);
        }

    }
}
