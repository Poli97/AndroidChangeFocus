using System;
using Xamarin.Forms;

namespace DragTest2
{
    public class IDragLabel : Label
    {
        public string Testo;
        public BoxView Destinazione { get; set; }
        public IDragLabel(string text, BoxView box)
        {
            Testo = text;
            //Destinazione = box;
        }
    }
}
