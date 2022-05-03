using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Runtime.InteropServices;

namespace VividEngine.Texture
{
    public class Texture2D : Texture
    {

        public Texture2D(string path,bool force_alpha = false)
        {

            int image_width=64;
            int image_height=64;

            Bitmap image_data = new Bitmap(path);

            image_width = image_data.Width;
            image_height = image_data.Height;

            byte[] raw = new byte[image_width * image_height * 4];

            int raw_os = 0;

            for(int y = 0; y < image_height; y++)
            {
                for(int x = 0; x < image_width; x++)
                {

                    var pix = image_data.GetPixel(x, y);

                    raw[raw_os++] = (byte)pix.R;
                    raw[raw_os++] = (byte)pix.G;
                    raw[raw_os++] = (byte)pix.B;
                    raw[raw_os++] = (byte)255;


                }
            }

            
            Handle = GL.CreateTexture(TextureTarget.Texture2d);
            GL.TextureStorage2D(Handle, 1, SizedInternalFormat.Rgba8, image_width, image_height);

            unsafe
            {
                GCHandle pinnedArray = GCHandle.Alloc(raw, GCHandleType.Pinned);
                IntPtr pointer = pinnedArray.AddrOfPinnedObject();
                GL.TextureSubImage2D(Handle, 0, 0, 0, image_width, image_height, PixelFormat.Rgba, PixelType.UnsignedByte,pointer);
                Console.WriteLine("Created texture2D. W:" + image_width + " H:" + image_height + " Handle:" + Handle.Handle);
            }
            GL.TextureParameteri(Handle, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TextureParameteri(Handle, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TextureParameteri(Handle, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TextureParameteri(Handle, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.GenerateTextureMipmap(Handle);
        }

        public override void Bind(TextureUnit unit)
        {

            uint t_unit = (uint)unit;

            GL.BindImageTexture(t_unit, Handle, 0, false, 0, BufferAccessARB.ReadOnly, InternalFormat.Rgba8);
             
            base.Bind(unit);
        }

        public override void Release(TextureUnit unit)
        {
            base.Release(unit);
        }

    }
}
