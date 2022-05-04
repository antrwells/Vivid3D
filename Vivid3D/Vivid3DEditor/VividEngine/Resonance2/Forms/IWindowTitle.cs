using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VividEngine.Resonance2.Forms
{
    public class IWindowTitle : IForm
    {

        public override void RenderForm()
        {
            //base.RenderForm();
            if (Over)
            {
                Color = new OpenTK.Mathematics.Vector4(1, 1, 1, 1);
            }
            else
            {
                Color = new OpenTK.Mathematics.Vector4(0.5f, 0.5f, 0.5f, 1);
            }
            DrawTitle();
            DrawText(Text, RenderPosition.X+6, RenderPosition.Y+5,new OpenTK.Mathematics.Vector4(1,1,1,1));
        }


        public override void OnEnter()
        {
            Over = true;
           
           // base.OnEnter();
        }

        public override void OnLeave()
        {
            Over = false;
            //base.OnLeave();

        }

        public override void OnMouseDown(int button)
        {
            //base.OnMouseDown(button);
            Drag = true;
        }

        public override void OnMouseUp(int button)
        {
           // base.OnMouseUp(button);
            Drag = false;
        }

        public override void OnMouseMove(int x, int y, int x_delta, int y_delta)
        {
            if (!Drag) return;     
            //base.OnMouseMove(x, y, x_delta, y_delta);
            Root.Position = new OpenTK.Mathematics.Vector2i(Root.Position.X + x_delta, Root.Position.Y + y_delta);
        }

    }
}
