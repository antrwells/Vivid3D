using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VividEngine.Texture;
using VividEngine.Draw.Simple;
using VividEngine.Resonance2.Forms;

namespace VividEngine.Resonance2
{
    public class UserInterface
    {

        public static UserInterface ActiveInterface
        {
            get;
            set;
        }

        public ITheme Theme
        {
            get;
            set;
        }
        private Texture2D Cursor
        {
            get;
            set;
        }

        public static BasicDraw2D Draw;

        public IForm Root
        {
            get;
            set;
        }

        public UserInterface()
        {

            Theme = new Themes.ThemeDark();
            Cursor = new Texture2D("Data/ui/cursor/normal.png", false);
            Draw = new BasicDraw2D();
            Root = new Forms.IGroup();
            Root.Set(0, 0, App.AppInfo.Width, App.AppInfo.Height);
            ActiveInterface = this;

        }

        public IForm Add(IForm form)
        {
            Root.Add(form);
            return form;
        }

        public IForm Add(params IForm[] forms)
        {
            foreach(var form in forms)
            {
                Add(form);
            }
            return forms[0];
        }

        public void UpdateUI()
        {

        }

        public void RenderUI()
        {
            Root.Render();
            RenderCursor();

        }

        private void RenderCursor()
        {
            Draw.Rect((int)Input.AppInput.MousePosition.X, (int)Input.AppInput.MousePosition.Y, 32, 32, Cursor, new OpenTK.Mathematics.Vector4(1, 1, 1, 1));
        }
    }
}
