using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;
using VividEngine.Texture;
using VividEngine.Shader;

namespace VividEngine.App
{

    //opengl callback class
    //
 
    
    public class Application : GameWindow
    {

        public Application(GameWindowSettings window_settings, NativeWindowSettings native_settings) : base(window_settings,native_settings)
        {
            Console.WriteLine("Application Created");
            GL.Enable(EnableCap.DebugOutput);
            GL.Enable(EnableCap.DebugOutputSynchronous);
          //  GL.DebugMessageCallback(GLDebugProc.`   , null);
            uint[] ids = new uint[32];
            ids[0] = 0;
            GL.DebugMessageControl(DebugSource.DontCare, DebugType.DontCare, DebugSeverity.DontCare, ids, true); 
        }

        protected override void OnLoad()
        {
            //base.OnLoad();

            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.CullFace);
            GL.Viewport(0, 0, Size.X, Size.Y);
            Console.WriteLine("Setup OpenGL. Resolution X:" + Size.X + " Resolution Y:" + Size.Y);

        
            Texture2D tex = new Texture2D("data/test1.jpg", false);

            Effect fx = new Effect("engine/shader/basic_draw_vertex.glsl", "engine/shader/basic_draw_frag.glsl");

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            //base.OnRenderFrame(args);

            GL.ClearColor(1, 0, 0, 1);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            SwapBuffers();
            
        }



    }
}
