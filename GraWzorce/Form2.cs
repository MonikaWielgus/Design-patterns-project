using System.Windows.Forms;

namespace GraWzorce
{
    public partial class Form2 : Form
    {
        readonly Game game;
        public Form2(Game g)
        {
            InitializeComponent();
            new Settings();
            game = g;
            SetSettings();

        }
        public void SetSettings()
        {
            game.GetReferences(endLabel, scoreLabel, countScoreLabel, pictureBox1);
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += game.UpdateScreen;
            gameTimer.Start();
            game.StartGame();
        }

        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            PressKey pressKey = new PressKey();
            pressKey.Execute(e.KeyCode);
        }

        public void KeyIsUp(object sender, KeyEventArgs e)
        {
            ReleaseKey releaseKey = new ReleaseKey();
            releaseKey.Execute(e.KeyCode);
        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            game.UpdateGraphics(sender, e);
        }
    }
}
