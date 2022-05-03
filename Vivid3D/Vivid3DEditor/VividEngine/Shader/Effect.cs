using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace VividEngine.Shader
{
    public class Effect
    {
        
        protected ProgramHandle ProgramHandle
        {
            get;
            set;
        }

        protected ShaderHandle VertexHandle
        {
            get;
            set;
        }
        
        protected ShaderHandle FragHandle
        {
            get;
            set;
        }

        protected ShaderHandle GeoHandle
        {
            get;
            set;
        }

        public Effect(string vertex_path,string frag_path)
        {
            ProgramHandle = GL.CreateProgram();
            GL.ObjectLabel(ObjectIdentifier.Program, (uint)ProgramHandle.Handle,-1,"Effect:"+vertex_path);

            AttachShader(ShaderType.VertexShader, vertex_path);
            AttachShader(ShaderType.FragmentShader, frag_path);
            GL.LinkProgram(ProgramHandle);
            int pars = 255;
            unsafe
            {
                int* parp = &pars;

                GL.GetProgramiv(ProgramHandle, ProgramPropertyARB.LinkStatus, parp);
            }
            GL.GetProgramInfoLog(ProgramHandle, out string info);
            Console.WriteLine("ProgramStatus:" + info);
            Console.WriteLine("Link:" + pars);

        }
        
        ShaderHandle AttachShader(ShaderType type,string path)
        {
            string text = File.ReadAllText(path);
            ShaderHandle handle = GL.CreateShader(type);
            GL.ShaderSource(handle, text);
            GL.CompileShader(handle);
            GL.AttachShader(ProgramHandle, handle);
            GL.DeleteShader(handle);
            return handle;
            
        }

        

    }
}
