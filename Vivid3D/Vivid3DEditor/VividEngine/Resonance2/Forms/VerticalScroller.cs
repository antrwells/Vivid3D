using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VividEngine.Resonance2.Forms
{
    public  class VerticalScroller : IForm
    {

        public int CurrentValue
        {
            get;
            set;
        }

        public int MaxValue
        {
            get;
            set;
        }

        public override void OnMouseDown(int button)
        {
            base.OnMouseDown(button);
            Drag = true;
        }

        public override void OnMouseUp(int button)
        {
            base.OnMouseUp(button);
            Drag = false;
        }

        public override void OnMouseMove(int x, int y, int x_delta, int y_delta)
        {
            base.OnMouseMove(x, y, x_delta, y_delta);
            CurrentValue += y_delta;
            if (CurrentValue < 0) CurrentValue = 0;
            if (CurrentValue > MaxValue) CurrentValue = MaxValue;
            Root.ScrollPosition = new OpenTK.Mathematics.Vector2i(Root.ScrollPosition.X, CurrentValue);
        }

        public override void RenderForm()
        {

            float yi = (float)(CurrentValue) / (float)(MaxValue);


            int draw_y =(int)( (float)(Size.Y) * yi); ;
            int draw_h = 32;
            //base.RenderForm();
            DrawFrame();
            DrawOutline(new OpenTK.Mathematics.Vector4(1, 1, 1, 1));
            DrawFrame(RenderPosition.X+1, RenderPosition.Y + draw_y+1, Size.X-1, draw_h, new OpenTK.Mathematics.Vector4(1, 3, 3, 1));
;        }

    }
}
