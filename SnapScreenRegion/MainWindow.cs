using System;
using Atk;
using Gtk;
using SnapScreenRegion;
using System.Threading.Tasks;
using System.Threading;

public partial class MainWindow : Gtk.Window
{
    SnapScreenReg snapScren;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        snapScren = new SnapScreenReg();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnSnapScreenButtonClicked(object sender, EventArgs e)
    {
        SnapScreenButton.ModifyBg(Gtk.StateType.Normal ,new Gdk.Color(200, 1, 1));
        SnapScreenButton.ModifyFg(Gtk.StateType.Normal, new Gdk.Color(200, 1, 1));
        TopLabel.ModifyFg(Gtk.StateType.Normal, new Gdk.Color(200, 23, 54));

        this.Hide();

        

        //await Task.Delay(1000);
        Thread.Sleep(1000); 

        snapScren.SnapShot(Gdk.Global.DefaultRootWindow);

        //await Task.Delay(1000);

        this.Show();


        // Remove From RAM

        int ident = GC.GetGeneration(ImageCanvasPic);
        GC.Collect(ident, GCCollectionMode.Forced);

        // PUT IMAGE IN A CANVAS

        ImageCanvasPic.Pixbuf = snapScren.PixBufImage;
        ImageCanvasPic.Show();

        snapScren.PutImageInWindow(Gdk.Global.DefaultRootWindow);
    }

    //protected async void OnSnapScreenButtonClicked(object sender, EventArgs e)
    //{
    //    SnapScreenButton.ModifyBg(Gtk.StateType.Normal, new Gdk.Color(200, 1, 1));
    //    SnapScreenButton.ModifyFg(Gtk.StateType.Normal, new Gdk.Color(200, 1, 1));
    //    TopLabel.ModifyFg(Gtk.StateType.Normal, new Gdk.Color(200, 23, 54));

    //    this.Hide();



    //    //await Task.Delay(1000);
    //    Thread.Sleep(1000);

    //    await snapScren.SnapShot(Gdk.Global.DefaultRootWindow);

    //    //await Task.Delay(1000);

    //    this.Show();


    //    // Remove From RAM

    //    int ident = GC.GetGeneration(ImageCanvasPic);
    //    GC.Collect(ident, GCCollectionMode.Forced);

    //    // PUT IMAGE IN A CANVAS

    //    ImageCanvasPic.Pixbuf = snapScren.PixBufImage;
    //    ImageCanvasPic.Show();

    //    await snapScren.PutImageInWindow(Gdk.Global.DefaultRootWindow);
    //}

    //protected void OnMotionNotifyEvent(object o, MotionNotifyEventArgs args)
    //{
    //    TopLabel.Text = args.Event.X.ToString();
    //}
}
