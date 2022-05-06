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

        public float Value
        {
            get
            {
                return av2;
            }
        }
        float av2;


        public VerticalScroller()
        {
            Scroll = false;
            //OnMouseDown(0);
            //OnMouseMove(0, 0, 0, 1);
            //OnMouseUp(0);
            CurrentValue = 0;
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
            if (Drag)
            {
                CurrentValue += y_delta;
                if (CurrentValue < 0) CurrentValue = 0;
                if (CurrentValue > Size.Y) CurrentValue = Size.Y;

            }
          //  Root.ScrollPosition = new OpenTK.Mathematics.Vector2i(0, (int)av);
            
            // Root.ScrollPosition = new OpenTK.Mathematics.Vector2i(Root.ScrollPosition.X, CurrentValue);
        }

        public override void RenderForm()
        {

            float yi = (float)(CurrentValue) / (float)(MaxValue);

            float hd = Size.Y / (float)(MaxValue);

            float av = CurrentValue * hd;

            float ov = (float)Size.Y / (float)(MaxValue);

            if (ov > 1) ov = 1;


            float dh = Size.Y * ov;

            float nm = Size.Y - dh;

            float ay = CurrentValue;

            if (CurrentValue + dh > Size.Y) {
                if (dh != float.PositiveInfinity)
                {
                    CurrentValue = Size.Y - (int)dh;
                    if (CurrentValue < 0) CurrentValue = 0;
                }
            }



            float max_V = Size.Y - (dh);
            //float yd = Size.Y - (CurrentValue + dh);
          av2 = CurrentValue / max_V;
            

          //  Console.WriteLine("AV:" + av2);

            //yd = yd / MaxValue;


            //int draw_y = (int)Size.Y 
            //int draw_h = (int)((float)Size.Y * ov);

            //base.RenderForm();
            DrawFrame();
            DrawOutline(new OpenTK.Mathematics.Vector4(1, 1, 1, 1));
            DrawFrame(RenderPosition.X+1, RenderPosition.Y+CurrentValue , Size.X-1, (int)dh, new OpenTK.Mathematics.Vector4(1, 3, 3, 1));
;        }

    }
}
