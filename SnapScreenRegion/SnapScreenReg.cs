using System;
using System.IO;
using System.Threading.Tasks;
using Cairo;
using Gtk;

namespace SnapScreenRegion
{
    public class SnapScreenReg
    {
        public SnapScreenReg()
        {
        }

        public void SnapShot(Gdk.Window window)
        {
            Gdk.Pixbuf pixBuf = new Gdk.Pixbuf(Gdk.Colorspace.Rgb, false, 8,
                                   window.Screen.Width, window.Screen.Height);
            pixBuf.GetFromDrawable(window, Gdk.Colormap.System, 0, 0, 0, 0,
                                   window.Screen.Width, window.Screen.Height);
            PixBufImage = pixBuf;
            //pixBuf.ScaleSimple(400, 300, Gdk.InterpType.Hyper);
            //pixBuf.Save("/home/mike/Desktop/screenshot0.jpeg", "jpeg");
            //pixBuf.Savev("/home/mike/Desktop/screenshot0_" + DateTime.Now.Second + ".jpeg", "jpeg", new string[] { "quality" }, new string[] { "10" });

        }

        public void SnapShot2(Gdk.Window window)
        {
            Gdk.Pixbuf pixBuf = new Gdk.Pixbuf(Gdk.Colorspace.Rgb, false, 8,
                                       window.Screen.Width, window.Screen.Height);
            pixBuf.GetFromDrawable(window, Gdk.Colormap.System, 0, 0, 0, 0,
                                   window.Screen.Width, window.Screen.Height);
            pixBuf.ScaleSimple(400, 300, Gdk.InterpType.Hyper);
            //pixBuf.Save("/home/mike/Desktop/screenshot0.jpeg", "jpeg");
            pixBuf.Savev("/home/mike/Desktop/screenshot0_" + DateTime.Now.Second + ".jpeg", "jpeg", new string[] { "quality" }, new string[] { "100" });

        }

        public void PutImageInWindow(Gdk.Window window)
        {
            double xSize = (double)window.Screen.Width * 0.8;
            double ySize = (double)window.Screen.Height * 0.8;

            Window myWin = new Window("");
            myWin.Resize((int)xSize, (int)ySize);

            Image image = new Image();
            myWin.Add(image);
            image.Pixbuf = PixBufImage;
            //image.Get(pixbuf.GetFr, null);

            myWin.Show();
            image.Show();
        }

        //public async Task SnapShot(Gdk.Window window)
        //{
        //    try
        //    {
        //        await Task.Run(() =>
        //        {
        //            Gdk.Pixbuf pixBuf = new Gdk.Pixbuf(Gdk.Colorspace.Rgb, false, 8,
        //                                   window.Screen.Width, window.Screen.Height);
        //            pixBuf.GetFromDrawable(window, Gdk.Colormap.System, 0, 0, 0, 0,
        //                                   window.Screen.Width, window.Screen.Height);
        //            PixBufImage = pixBuf;
        //            //pixBuf.ScaleSimple(400, 300, Gdk.InterpType.Hyper);
        //            //pixBuf.Save("/home/mike/Desktop/screenshot0.jpeg", "jpeg");
        //            //pixBuf.Savev("/home/mike/Desktop/screenshot0_" + DateTime.Now.Second + ".jpeg", "jpeg", new string[] { "quality" }, new string[] { "10" });
        //        });
        //    }
        //    catch (Exception excp)
        //    {
        //        Console.WriteLine(excp.ToString() + " ...issue");
        //    }
        //    //Image image;

        //}

        //public async Task PutImageInWindow(Gdk.Window window)
        //{
        //    await Task.Run(() =>
        //    {
        //        double xSize = (double)window.Screen.Width * 0.8;
        //        double ySize = (double)window.Screen.Height * 0.8;

        //        Window myWin = new Window("");
        //        myWin.Resize((int)xSize, (int)ySize);

        //        Image image = new Image();
        //        myWin.Add(image);
        //        image.Pixbuf = PixBufImage;
        //        //image.Get(pixbuf.GetFr, null);

        //        myWin.Show();
        //        image.Show();
        //    });
        //}

        public Gdk.Pixbuf PixBufImage { get; set; }
    }
}
