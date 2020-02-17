using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using DragTest2;
using DragTest2.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IDragLabel), typeof(AndroidDragLabel))]
namespace DragTest2.Droid
{
    public class AndroidDragLabel : LabelRenderer
    {
        Context context;
        public AndroidDragLabel(Context context) : base(context)
        {
            this.context = context;
        }

        string nome;
        IDragLabel custom;
        Android.Views.View destinazione;
        Rect rect;

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            custom = e.NewElement as IDragLabel;
            nome = custom.Testo;
            //destinazione = Platform.CreateRendererWithContext(MainPage.box, Android.App.Application.Context).View;
            //Console.WriteLine($"PIPPO: coordinate view convertita {destinazione.GetX()} {destinazione.GetY()}");
            //destinazione.GetHitRect(rect);

            base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

            Control.Text = nome + " Android";
            Console.WriteLine("PIPPO created from Renderer");

        }


        float dX, dY;
        public override bool OnTouchEvent(MotionEvent e)
        {

            switch (e.Action)
            {
                case MotionEventActions.Down:
                    rect = new Rect((int)MainPage.box.X, (int)MainPage.box.Y, (int)(MainPage.box.X + MainPage.box.Width), (int)(MainPage.box.X + MainPage.box.Height));
                    dX = this.GetX() - e.RawX;
                    dY = this.GetY() - e.RawY;
                    destinazione = Platform.CreateRendererWithContext(MainPage.box, Android.App.Application.Context).View;
                    int[] test1 = new int[2];
                    destinazione.GetLocationInWindow(test1);
                    //Console.WriteLine($"PIPPO view convertita: {test1[0]} {test1[1]}");
                    Console.WriteLine($"PIPPO inizio tocco coordinate box destinazione Android = {MainPage.box.X} {MainPage.box.Y} {MainPage.box.Width} {MainPage.box.Height}");

                    break;

                case MotionEventActions.Move:
                    this.Animate().X(e.RawX + dX).Y(e.RawY + dY).SetDuration(0).Start();

                    break;

                case MotionEventActions.Up:
                    Console.WriteLine($"PIPPO tocco finito {e.RawX}, {e.RawY}");
                    dX = dY = 0;
                    if (rect.Contains((int)e.RawX, (int)e.RawY))
                    {
                        Console.WriteLine("PIPPO sono dentro");
                    }

                    break;
                default:
                    return false;
            }

            return true;

        }

    }

}
