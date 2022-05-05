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
using VividEngine.Resonance2;
using VividEngine.Resonance2.Forms;
    
namespace Vivid3DEditor
{
    public class EditorApp : Application
    {
       

        UserInterface UI;

        public EditorApp(GameWindowSettings window_settings,NativeWindowSettings native_settings) : base(window_settings,native_settings)
        {
            
        }

        public override void InitApp()
        {
            UI = new UserInterface();

            var menu = UI.AddMainMenu() as IMainMenu;

            var file = menu.AddItem("File");
            var edit = menu.AddItem("Edit");
            var help = menu.AddItem("Help");
            
            var load_map  = file.AddItem("Load Map");

            var lm_2 = load_map.AddItem("Load original.");
            load_map.AddItem("Load copy.");
            load_map.AddItem("Load other.");

            var save_map = file.AddItem("Save Map");

            lm_2.CLick = (item) =>
            {

                Environment.Exit(1);

            };

            file.AddItem("--------");
            file.AddItem("Exit App");

            load_map.CLick = (button) =>
            {
                //Environment.Exit(1);

            };


            var frame1 = new IFrame().Set(20, 20, 300, 500);
            var but1 = new IButton().Set(20, 20, 200, 35).SetText("Button 1") as IButton;
            var win = new IWindow().Set(20, 20, 300, 500).SetText("Test Window") as IWindow;
            var text = new ITextEdit().Set(20, 200, 200, 35).SetText("Test Text") as ITextEdit;

            but1.Click = (button) =>
            {
                Console.WriteLine("Button Clicked!");
            };

            but1.DoubleClick = (button) =>
            {

                Console.WriteLine("Double clicked!");

            };

            win.Content.Add(but1);
            win.Content.Add(text);
            UI.Add(win);
            
            base.InitApp();
            //tex1 = new Texture2D("data/t1.png", false);
            //tex2 = new Texture2D("data/test2.jpg", false);
          
            //draw1 = new BasicDraw2D();


        }

        public override void UpdateApp()
        {
            base.UpdateApp();
            UI.UpdateUI();
        }

        public override void RenderApp()
        {

            UI.RenderUI();
           

           // draw1.Rect(20, 20, 300, 300, tex1, new OpenTK.Mathematics.Vector4(1, 1, 1, 1));
            //draw1.Rect(120, 120, 300, 300, tex1, new OpenTK.Mathematics.Vector4(1, 1, 1, 0.4f));
            return;
         
        }

    }
}
