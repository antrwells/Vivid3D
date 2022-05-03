using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

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

            byte[] raw = new byte[image_width * image_height * 3];

            int raw_os = 0;

            for(int y = 0; y < image_height; y++)
            {
                for(int x = 0; x < image_width; x++)
                {

                    var pix = image_data.GetPixel(x, y);

                    raw[raw_os++] = pix.R;
                    raw[raw_os++] = pix.G;
                    raw[raw_os++] = pix.B;


                }
            }


            Handle = GL.CreateTexture(TextureTarget.Texture2d);
            GL.TextureStorage2D(Handle, 1, SizedInternalFormat.Rgba32f, image_width, image_height);

             GL.TextureSubImage2D(Handle, 0, 0, 0, image_width, image_height, PixelFormat.Bgra, PixelType.UnsignedByte, image_data.LockBits(new Rectangle(0, 0, image_width, image_height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb).Scan0);
            Console.WriteLine("Created texture2D. W:" + image_width + " H:" + image_height + " Handle:" + Handle.Handle);

        }

        protected override void Bind(TextureUnit unit)
        {
            base.Bind(unit);
        }

        protected override void Release(TextureUnit unit)
        {
            base.Release(unit);
        }

    }
}
