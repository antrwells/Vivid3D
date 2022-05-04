using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Threading;


namespace VividEngine.Texture
{
    public enum TextureUnit
    {
        Unit0 = 0,
        Unit1,
        Unit2,
        Unit3,
        Unit4
      }
    public class Texture
    {

        protected TextureHandle Handle
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public byte[] Raw
        {
            get;
            set;
        }

        public bool Loading
        {
            get;
            set;
        }

        public bool DataBound
        {
            get;
            set;
        }

        public string LoadPath
        {
            get;
            set;
        }

        public Thread LoadThread
        {
            get;
            set;
        }

        public Texture()
        {
            Loading = false;
        }

        public static List<Texture2D> Threading
        {
            get;
            set;
        }

        public virtual void Bind(TextureUnit unit)
        { 

            
           

        }
        
        public virtual void Release(TextureUnit unit)
        {
            
        }

    }
}
