using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using VividEngine.Texture;
using VividEngine.Draw.Simple;
using VividEngine.Resonance2.Forms;

namespace VividEngine.Resonance2
{
    public class UserInterface
    {

        public static UserInterface ActiveInterface
        {
            get;
            set;
        }

        public ITheme Theme
        {
            get;
            set;
        }
        private Texture2D Cursor
        {
            get;
            set;
        }

        public IForm FormOver
        {
            get;
            set;
        }

        public IForm[] FormPressed
        {
            get;
            set;
        }

        private long[] PrevClick
        {
            get;
            set;
        }

        public IForm FormActive
        {
            get;
            set;
        }

        public static BasicDraw2D Draw;

        public IForm Root
        {
            get;
            set;
        }

        private Vector2 prev_mouse;

        public UserInterface()
        {

            Theme = new Themes.ThemeDark();
            Cursor = new Texture2D("Data/ui/cursor/normal.png", false);
            Draw = new BasicDraw2D();
            Root = new Forms.IGroup();
            Root.Set(0, 0, App.AppInfo.Width, App.AppInfo.Height);
            ActiveInterface = this;
            prev_mouse = new Vector2(0, 0);
            FormPressed = new IForm[32];
            PrevClick = new long[32];
        }

        public IForm Add(IForm form)
        {
            Root.Add(form);
            return form;
        }

        public IForm Add(params IForm[] forms)
        {
            foreach(var form in forms)
            {
                Add(form);
            }
            return forms[0];
        }
        int clicks = 0;
        int clicktime = 0;
        bool clicked = false;
        public void UpdateUI()
        {
            Vector2 cur_mouse = Input.AppInput.MousePosition;

            List<IForm> forms = new List<IForm>();

            AddForms(forms, Root);

            forms.Reverse();

            var form_over = GetFormOver(forms, (int)Input.AppInput.MousePosition.X, (int)Input.AppInput.MousePosition.Y);
            
            

            if (form_over != FormOver && form_over !=null)
            {

                if (FormPressed[0] != form_over)
                {
                    form_over.OnEnter();
                }

                if (FormOver != null)
                {
                    if (FormPressed[0] != FormOver)
                    {
                        FormOver.OnLeave();
                    }
                }
                FormOver = form_over;

            }
            else
            {

                

            }


            //check for double click
            

            if (Input.AppInput.MouseButton[0])
            {
                if (!clicked)
                {
                    clicked = true;
                    clicktime = Environment.TickCount;
                }
            }
            else
            {
                if (clicks > 0)
                {
                    int tt = Environment.TickCount - clicktime;
                    if (tt > 250)
                    {
                        clicks = 0;
                        clicked = false;
                    }
                }
                if (clicked)
                {
                   

                    
                    clicked = false;
                    int tt = Environment.TickCount - clicktime;
                    if (tt < 250)
                    {
                        clicks++;
                    }
                    else
                    {
                        clicks = 0;
                    }
                    //clicktime = Environment.TickCount;
                    if (clicks == 2)
                    {
                        form_over.OnDoubleClick(0);
                        clicks = 0;
                    }
                    
                }
            }

            Console.WriteLine("Clicks:" + clicks);

            for (int i = 0; i < 16; i++)
            {
                if (Input.AppInput.MouseButton[i])
                {
                    if (i == 0)
                    {
                      
                    }                    
                    if (FormPressed[i] == null)
                    {
                        form_over.OnMouseDown(i);
                        FormPressed[i] = form_over;
                        FormActive = form_over;
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (i == 0)
                    {
                       
                    }
                    if (FormPressed[i] !=null)
                    {
                        FormPressed[i].OnMouseUp(i);
                        FormPressed[i] = null;

                    }
                }

            }

            if (FormPressed[0] != null)
            {
                form_over = FormPressed[0];
            }
            else if (FormOver != null)
            {
                form_over = FormOver;
            }

            if (form_over != null)
            {
                if (prev_mouse != cur_mouse)
                {
                    Vector2 delta = cur_mouse - prev_mouse;
                    form_over.OnMouseMove((int)cur_mouse.X, (int)cur_mouse.Y, (int)delta.X, (int)delta.Y);

                }
            }

            prev_mouse = Input.AppInput.MousePosition;
        }

        private IForm GetFormOver(List<IForm> forms,int x,int y)
        {

            foreach (var form in forms)
            {
                if (form.InBounds(x,y))
                {
                    return form;
                }
            }
            return null;

        }


        private void AddForms(List<IForm> forms, IForm form)
        {
            forms.Add(form);
            foreach (var f in form.Child)
            {
                AddForms(forms, f);
            }   
        }

        public void RenderUI()
        {
            Root.Render();
            RenderCursor();

        }

        private void RenderCursor()
        {
            Draw.Rect((int)Input.AppInput.MousePosition.X, (int)Input.AppInput.MousePosition.Y, 32, 32, Cursor, new OpenTK.Mathematics.Vector4(1, 1, 1, 1));
        }
    }
}
