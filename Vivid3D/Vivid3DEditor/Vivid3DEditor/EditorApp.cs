using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VividEngine.App;
using VividEngine.Shader;
using VividEngine.Texture;
using VividEngine.Shader._2D;
using OpenTK.Windowing.Desktop;
using VividEngine.Draw.Simple;

namespace Vivid3DEditor
{
    public class EditorApp : Application
    {
        Texture2D tex1;
      
        BasicDraw2D draw1;
        public EditorApp(GameWindowSettings window_settings,NativeWindowSettings native_settings) : base(window_settings,native_settings)
        {
            
        }

        public override void InitApp()
        {
            base.InitApp();
            tex1 = new Texture2D("data/test1.jpg", false);
          
            draw1 = new BasicDraw2D();

        }

        public override void RenderApp()
        {
            //base.RenderApp();
            Random rnd = new Random(Environment.TickCount);
            for (int i = 0; i < 50; i++)
            {
                int x = rnd.Next(0, 512);
                int y = rnd.Next(0, 512);
                draw1.Rect(x,y, 200, 200, tex1);
            }
                //fx1.Bind();

            //tex1.Bind(TextureUnit.Unit0);

           //fx1.Release();
        }

    }
}
