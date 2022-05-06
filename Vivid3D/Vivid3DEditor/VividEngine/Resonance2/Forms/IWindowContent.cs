﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VividEngine.Resonance2.Forms
{
    public class IWindowContent : IForm
     {

        private bool resizeLeft, resizeRight, resizeBottom, resizeTop, resizeCorner;
        private bool resizing = false;

        public VerticalScroller VerticalScroll
        {
            get;
            set;
        }
        
        public HorizontalScroller HorizontalScroll
        {
            get;
            set;
        }
        

        public IWindowContent()
        {
            resizeLeft = resizeRight = resizeBottom = resizeTop = resizeCorner = false;
            Color = new OpenTK.Mathematics.Vector4(0.6f, 0.6f, 0.6f, 1.0f);
            ChildScroll = true;
            VerticalScroll = new VerticalScroller();
            VerticalScroll.Scroll = false;
            HorizontalScroll = new HorizontalScroller();
            HorizontalScroll.Scroll = false;
            Add(VerticalScroll);
            Add(HorizontalScroll);

        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            int max_y = ContentSize.Y;
            int max_X = ContentSize.X;

            VerticalScroll.MaxValue = max_y;
            HorizontalScroll.MaxValue = max_X;

            ScrollPosition = new OpenTK.Mathematics.Vector2i((int)(HorizontalScroll.Value*max_X),(int)(VerticalScroll.Value * max_y));
            if(ScrollPosition.Y<0)
            {
                ScrollPosition = new OpenTK.Mathematics.Vector2i(ScrollPosition.X, 0);
            }
            if (ScrollPosition.X < 0)
            {
                ScrollPosition = new OpenTK.Mathematics.Vector2i(0, ScrollPosition.Y);
            }
         //   Console.Write("AV:" + VerticalScroll.Value);

            
        }

        public override void Resized()
        {
            VerticalScroll.Set(Size.X - 10,0, 10, Size.Y-10);
            HorizontalScroll.Set(0, Size.Y - 10, Size.X-10, 10);
        }

        public override void OnMouseMove(int x, int y, int x_delta, int y_delta)
        {
            base.OnMouseMove(x, y, x_delta, y_delta);

            if (!resizing)
            {
                if (Within(x, y, RenderPosition.X, RenderPosition.Y, 5, Size.Y))
                {
                    resizeLeft = true;
                    resizeTop = false;
                    resizeBottom = false;
                    resizeRight = false;
                    resizeCorner = false;
                }
                if (Within(x, y, RenderPosition.X, RenderPosition.Y + Size.Y - 5, Size.X - 8, 5))
                {
                    resizeBottom = true;
                    resizeTop = false;
                    resizeLeft = false;
                    resizeRight = false;
                    resizeCorner = false;
                }
                if (Within(x, y, RenderPosition.X + Size.X - 5, RenderPosition.Y, 5, Size.Y - 8))
                {
                    resizeRight = true;
                    resizeTop = false;
                    resizeBottom = false;
                    resizeCorner = false;
                    resizeLeft = false;
                }
                if (Within(x, y, RenderPosition.X, RenderPosition.Y, Size.X, 5))
                {
                    resizeTop = true;
                    resizeBottom = false;
                    resizeLeft = false;
                    resizeRight = false;
                    resizeCorner = false;
                }
                if (Within(x, y, RenderPosition.X + Size.X - 8, RenderPosition.Y + Size.Y - 8, 8, 8))
                {
                    resizeCorner = true;
                    resizeTop = false;
                    resizeBottom = false;
                    resizeLeft = false;
                    resizeRight = false;


                }

            }

            if (resizing)
            {

                int ra = 0;

                ra = ra + (resizeLeft ? 1 : 0);
                ra = ra + (resizeRight ? 1 : 0);
                ra = ra + (resizeBottom ? 1 : 0);
                ra = ra + (resizeTop ? 1 : 0);
                ra = ra + (resizeCorner ? 1 : 0);
                if (ra>1)
                {
                    int a = 5;
                }

                if (resizeLeft)
                {

                    Root.Position = new OpenTK.Mathematics.Vector2i(Root.Position.X + x_delta, Root.Position.Y);
                    Root.Size = new OpenTK.Mathematics.Vector2i(Root.Size.X - x_delta, Root.Size.Y);

                }else 
                if(resizeBottom)
                {
                    Root.Size = new OpenTK.Mathematics.Vector2i(Root.Size.X, Root.Size.Y + y_delta);
                }else
                if (resizeRight)
                {
                    Root.Size = new OpenTK.Mathematics.Vector2i(Root.Size.X + x_delta, Root.Size.Y);
                }else
                if (resizeTop)
                {
                    Root.Position = new OpenTK.Mathematics.Vector2i(Root.Position.X, Root.Position.Y + y_delta);
                    Root.Size = new OpenTK.Mathematics.Vector2i(Root.Size.X, Root.Size.Y - y_delta);
                }
                if (resizeCorner)
                {
                    Root.Size = new OpenTK.Mathematics.Vector2i(Root.Size.X + x_delta, Root.Size.Y + y_delta);
                }

            }
            
        }

        public override void OnMouseDown(int button)
        {
            base.OnMouseDown(button);
            if (resizeLeft || resizeRight || resizeBottom || resizeTop || resizeCorner)
            {
                resizing = true;
            }
            Console.WriteLine("Mouse Down Window.");
        }

        public override void OnMouseUp(int button)
        {
            base.OnMouseUp(button);
            resizing = false;
            //resizeLeft = resizeRight = resizeBottom = resizeTop = false;
            resizeLeft = false;
            resizeRight = false;
            resizeTop = false;
            resizeCorner = false;
            resizeBottom = false;
            Console.WriteLine("Mouse up window.");
        }

        public override void RenderForm()
        {
            //base.RenderForm();
            Color = new OpenTK.Mathematics.Vector4(1, 1, 1, 1);
            DrawFrame();
            Color = new OpenTK.Mathematics.Vector4(0.6f, 0.6f, 0.6f, 1.0f);
            DrawLine(RenderPosition.X, RenderPosition.Y, RenderPosition.X + Size.X, RenderPosition.Y, Color);
            DrawLine(RenderPosition.X, RenderPosition.Y, RenderPosition.X, RenderPosition.Y + Size.Y,Color);
            DrawLine(RenderPosition.X, RenderPosition.Y+Size.Y, RenderPosition.X+Size.X, RenderPosition.Y + Size.Y,Color);
            DrawLine(RenderPosition.X+Size.X, RenderPosition.Y, RenderPosition.X+Size.X, RenderPosition.Y + Size.Y,Color);

          //  DrawFrame(RenderPosition.X, RenderPosition.Y, ContentSize.X, ContentSize.Y, new OpenTK.Mathematics.Vector4(1, 1, 1, 0.7f));

        }

    }
}
