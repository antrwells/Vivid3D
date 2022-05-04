using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using VividEngine.Texture;


namespace VividEngine.Resonance2
{
    public class IForm
    {

        public IForm Root
        {
            get;
            set;
        }

        public List<IForm> Child
        {
            get;
            set;
        }

        public Vector2i Position
        {
            get;
            set;
        }

        public Vector2i Size
        {
            get;
            set;
        }

        public Vector4 Color
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public bool Focus
        {
            get;
            set;
        }

        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }
        private string _Text = "";

        public Vector2i RenderPosition
        {
            get
            {
                Vector2i pos = new Vector2i(0, 0);
                if (Root != null)
                {
                    pos = Root.RenderPosition;
                }
                return pos + Position;
            }
        }

        public IForm()
        {

            Root = null;
            Child = new List<IForm>();
            Set(0, 0, 0, 0);
            SetText("");
            SetColor(1, 1, 1, 1);

        }

        public IForm SetColor(float r,float g,float b,float a)
        {
            SetColor(new Vector4(r, g, b, a));
            return this;
        }
        public IForm SetColor(Vector4 color)
        {
            Color = color;
            return this;
        }

        public IForm Set(int x, int y, int w, int h)
        {
            Position = new Vector2i(x, y);
            Size = new Vector2i(w, h);
            return this;
        }

        public IForm SetText(string text)
        {
            Text = text;
            return this;
        }

        public IForm Add(params IForm[] forms)
        {
            foreach (var form in forms)
            {
                Add(form);
            }
            return forms[0];
        }

        public IForm Add(IForm form)
        {

            form.Root = this;
            Child.Add(form);
            return this;
        }

        public void Render()
        {

            RenderForm();
            RenderChildren();

        }

        public virtual void RenderForm()
        {

        }

        public void RenderChildren()
        {
            foreach (var form in Child)
            {
                form.Render();
            }
        }

        public bool InBounds(int x,int y)
        {
            if (x >= RenderPosition.X && x <= RenderPosition.X + Size.X && y >= RenderPosition.Y && y <= RenderPosition.Y + Size.Y)
            {
                return true;
            }
            return false;
        }


        public virtual void OnEnter()
        {

        }

        public virtual void OnLeave()
        {

        }

        public virtual void OnMouseMove(int x,int y,int x_delta,int y_delta)
        {
            
        }

        public virtual void OnMouseDown(int button)
        {
            
        }

        public virtual void OnMouseUp(int button)
        {
            
        }

        /// <summary>
        /// Drawing
        /// </summary>

        public void DrawButton()
        {
            Draw(UserInterface.ActiveInterface.Theme.Button);
        }
        
        public void DrawFrame()
        {
            Draw(UserInterface.ActiveInterface.Theme.Frame);
        }
    

        public void Draw(Texture2D image)
        {
            var render_pos = RenderPosition;
            UserInterface.Draw.Rect(render_pos.X, render_pos.Y, Size.X, Size.Y,image, Color);
        }
    }
    
}
