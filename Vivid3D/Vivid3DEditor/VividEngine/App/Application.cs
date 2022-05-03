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
            this.VSync = VSyncMode.On;
            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.CullFace);
            GL.Viewport(0, 0, Size.X, Size.Y);
            Console.WriteLine("Setup OpenGL. Resolution X:" + Size.X + " Resolution Y:" + Size.Y);

            InitApp();
            
            //Texture2D tex = new Texture2D("data/test1.jpg", false);

           // Effect fx = new Effect("engine/shader/basic_draw_vertex.glsl", "engine/shader/basic_draw_frag.glsl");

        }
        
        public virtual void InitApp()
        {
            
        }

        public virtual void UpdateApp()
        {
            
        }

        public virtual void RenderApp()
        {

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            UpdateApp();
        }


        int frame = 0;
        int fps = 0;
        int n_frame;
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            //base.OnRenderFrame(args);

            int ctick = Environment.TickCount;
            if (ctick > n_frame)
            {
                n_frame = ctick + 1000;
                fps = frame;
                frame = 0;
                Console.WriteLine("Fps:" + fps);
            }
            frame++;
            

            GL.ClearColor(1, 0, 0, 1);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            RenderApp();

            SwapBuffers();
            
        }



    }
}
