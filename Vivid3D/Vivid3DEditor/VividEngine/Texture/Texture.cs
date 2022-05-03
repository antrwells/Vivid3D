using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;


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

        protected virtual void Bind(TextureUnit unit)
        { 

            
           

        }
        
        protected virtual void Release(TextureUnit unit)
        {
            
        }

    }
}
