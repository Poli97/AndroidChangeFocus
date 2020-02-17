using System;
using CoreGraphics;
using DragTest2;
using DragTest2.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IDragLabel), typeof(IOSDragLabel))]
namespace DragTest2.iOS
{
    public class IOSDragLabel : LabelRenderer
    {
        CGRect coordDest;
        UIView destinazione;
        public IOSDragLabel()
        {
        }

        string nome;
        IDragLabel custom;
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            custom = e.NewElement as IDragLabel;
            nome = custom.Testo;
            //Console.WriteLine($"PIPPO: coordinate destinazione = {custom.Destinazione.X} {custom.Destinazione.Y}");

            base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

            Control.Text = nome + " IOS";
            Console.WriteLine("PIPPO created from Renderer");
            

        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            //coordDest = new CGRect(custom.Destinazione.X, custom.Destinazione.Y, custom.Destinazione.Width, custom.Destinazione.Height);
            coordDest = new CGRect(MainPage.box.X, MainPage.box.Y, MainPage.box.Width, MainPage.box.Height);
            destinazione = new UIView(coordDest);
            Console.WriteLine("PIPPO: tocco iniziato");
            Console.WriteLine($"PIPPO: coordinate box destinazione in iOS = {coordDest.X} {coordDest.Y}");
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            this.Center = touch.LocationInView(this.Superview);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            Console.WriteLine($"PIPPO: tocco finito {touch.LocationInView(this.Superview)}");
            if (destinazione.Frame.Contains(touch.LocationInView(this.Superview)))
            {
                Console.WriteLine("PIPPO sono dentro");
                this.Frame = destinazione.Frame;
            }

        }
    }

}
