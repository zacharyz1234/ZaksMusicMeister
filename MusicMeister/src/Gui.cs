namespace MusicMeister
{
    using Terminal.Gui;

    public class Gui //Houses the CLI elements of the player
    {

        //Start method builds the UI
        public void Start()
        {
            //Creates an instance of MainLoop to process input events, handle timers and other sources of data
            Application.Init();

            var top = Application.Top;
            var tframe = top.Frame;

            //Create the top level window
            var win = new Window("Zak's Music Meister")
            {
                X = 0,
                Y = 1, //Leave one row for the toplevel menu

                //This lets it auto resize without having to do so manually
                Width = Dim.Fill(),

                //Subtract one row for the statusbar
                Height = Dim.Fill() - 1,
            };

            var menu = new MenuBar(new MenuBarItem[]
            {
                new MenuBarItem("_File", new MenuItem[]
                {
                    new MenuItem("Open", "Open a music file", () => Player.PlayAudioFile()),
                
                    new MenuItem("_Open Stream", "Open a stream", () => Application.RequestStop()),

                    new MenuItem("_Quit", "Exit MusicSharp", () => Application.RequestStop()),
                }),

                new MenuBarItem("_Help", new MenuItem[]
                {
                    new MenuItem("_About", string.Empty, () => 
                    {
                        MessageBox.Query("Zak's Music Meister V1.0.0", "\nMusicMeister is a lightweight CLI\n music player written in C#. \n\nDeveloped by Zachary Zeldin", "Close");
                    }),
                }),
            });


            //Add the layout elements and run the app
            top.Add(menu);
            top.Add(win);
            Application.Run();
        }
    }
}