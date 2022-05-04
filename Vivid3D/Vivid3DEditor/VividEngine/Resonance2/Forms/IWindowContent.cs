using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VividEngine.Resonance2.Forms
{
    public class IWindowContent : IForm
     {
        public IWindowContent()
        {
            Color = new OpenTK.Mathematics.Vector4(0.6f, 0.6f, 0.6f, 1.0f);
        }
        public override void RenderForm()
        {
            //base.RenderForm();
            Color = new OpenTK.Mathematics.Vector4(1, 1, 1, 1);
            DrawFrame();
            Color = new OpenTK.Mathematics.Vector4(0.6f, 0.6f, 0.6f, 1.0f);
            DrawLine(RenderPosition.X, RenderPosition.Y, RenderPosition.X, RenderPosition.Y + Size.Y,Color);
            DrawLine(RenderPosition.X, RenderPosition.Y+Size.Y, RenderPosition.X+Size.X, RenderPosition.Y + Size.Y,Color);
            DrawLine(RenderPosition.X+Size.X, RenderPosition.Y, RenderPosition.X+Size.X, RenderPosition.Y + Size.Y,Color);

        }

    }
}
