using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VividEngine.Resonance2.Forms
{
    public class IButton : IForm
    {
        bool drag = false;
        public override void RenderForm()
        {

            DrawButton();

        }

        public override void OnEnter()
        {
            Color = new OpenTK.Mathematics.Vector4(2,2,2, 1);
            //base.OnEnter();

        }

        public override void OnLeave()
        {
            Color = new OpenTK.Mathematics.Vector4(1, 1, 1, 1);
            //
            //base.OnLeave();
        }

        public override void OnMouseMove(int x, int y, int x_delta, int y_delta)
        {
            if (!drag) return;
            Random r = new Random(Environment.TickCount);
            Console.WriteLine("Mx:" + x + " MY:" + y + " DX:" + x_delta + " DY:" + y_delta);
            Position = new OpenTK.Mathematics.Vector2i(Position.X + x_delta, Position.Y + y_delta);
        }

        public override void OnDoubleClick(int button)
        {
            //base.OnDoubleClick(button);
            Position = new OpenTK.Mathematics.Vector2i(Position.X + 30, Position.Y);


                }

        public override void OnMouseDown(int button)
        {
            Color = new OpenTK.Mathematics.Vector4(2, 1, 1, 1);
            base.OnMouseDown(button);
            drag = true;
        }

        public override void OnMouseUp(int button)
        {
            Color = new OpenTK.Mathematics.Vector4(1, 1, 1, 1);
            drag = false;
            base.OnMouseUp(button);
        }

    }
}
