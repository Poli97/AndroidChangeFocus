using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragTest2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static BoxView box;
        AbsoluteLayout layout;
        Rectangle rect;
        public MainPage()
        {
            InitializeComponent();

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            layout = new AbsoluteLayout();

            box = new BoxView
            {
                BackgroundColor = Color.Green,
            };
            AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0.6, 0.6, 0.25, 0.25));
            AbsoluteLayout.SetLayoutFlags(box, AbsoluteLayoutFlags.All);

            layout.Children.Add(box);

            IDragLabel l1 = new IDragLabel("Dragme ", box);
            l1.BackgroundColor = Color.Red;
            AbsoluteLayout.SetLayoutBounds(l1, new Rectangle(0.2, 0.2, 0.15, 0.15));
            AbsoluteLayout.SetLayoutFlags(l1, AbsoluteLayoutFlags.All);

            layout.Children.Add(l1);

            Content = layout;

            Console.WriteLine($"PIPPO: coordinate box in MainPage: {box.X} {box.Y} {box.Width} {box.Height}");  //0 0 -1 -1
            l1.Destinazione = box;

        }
    }
}
