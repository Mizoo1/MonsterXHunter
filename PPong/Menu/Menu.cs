using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster;

namespace MenuMonster.Menu
{
    public class Menu
    {
        private static int x = 500;
        public static App app = new App();
        public static Widget widgetHead = new Widget();
        public static Widget widgetTail = widgetHead;
        public static void InitDemo()
        {
            var w = CreateWidget("start");
            w.X = x;
            w.Y = 200;
            w.Label = "Start";

            app.ActiveWidget = w;

            w = CreateWidget("load");
            w.X = x;
            w.Y = 250;
            w.Label = "Load";
            w = CreateWidget("options");
            w.X = x;
            w.Y = 300;
            w.Label = "Options";

            w = CreateWidget("credits");
            w.X = x;
            w.Y = 350;
            w.Label = "Credits";

            w = CreateWidget("exit");
            w.X = x;
            w.Y = 400;
            w.Label = "Exit";
        }

        public static void DrawSubMenu()
        {
            // Löschen Sie das Hauptmenü
            widgetTail = widgetHead;
            app.ActiveWidget = widgetTail;

            // Zeichnen Sie den Submenu
            var w = CreateWidget("sound");
            w.X = 100;
            w.Y = 200;
            w.Label = "Sound";

            w = CreateWidget("level");
            w.X = 100;
            w.Y = 250;
            w.Label = "Level";

            w = CreateWidget("info");
            w.X = 100;
            w.Y = 300;
            w.Label = "Info";

            w = CreateWidget("back");
            w.X = 100;
            w.Y = 350;
            w.Label = "Back";
            w.Index = 1;
        }

        public static void DrawSubsubMenu()
        {
            widgetTail = widgetHead;
            app.ActiveWidget = widgetTail;
            var w = CreateWidget("sound On");
            w.X = 100;
            w.Y = 200;
            w.Label = "Sound On";

            w = CreateWidget("sound off");
            w.X = 100;
            w.Y = 250;
            w.Label = "Sound Off";

            w = CreateWidget("back");
            w.X = 100;
            w.Y = 300;
            w.Label = "Back";
            w.Index = 2;
        }
        private static Widget CreateWidget(string name)
        {
            var w = new Widget
            {
                Name = name,
                Prev = widgetTail,
            };

            widgetTail.Next = w;
            widgetTail = w;

            return w;
        }
        public static void ClearAndDrawSubmenu(Action drawSubmenu)
        {
            var w = widgetHead.Next;
            while (w != null)
            {
                var next = w.Next;
                w = next;
            }
            InitWidgets();
            drawSubmenu();
        }
        public static void InitWidgets()
        {
            widgetHead = new Widget();
            widgetTail = widgetHead;
        }
    }

}
