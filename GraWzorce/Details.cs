namespace GraWzorce
{
    public class Details
    {
        private string type;
        private IFigureLibrary figureLibrary;
        private int size;
        public Details(string type)
        {
            this.type = type;
            this.size = Settings.Size;
            LoadIFigureLibrary(this.type);
        }
        public int GetSize()
        {
            return this.size;
        }
        public IFigureLibrary GetIFigureLibrary()
        {
            return this.figureLibrary;
        }
        private void LoadIFigureLibrary(string t)
        {
            switch (t)
            {
                case "GraWzorce.PurpleFigureLibrary":
                    this.figureLibrary = new PurpleFigureLibrary();
                    break;
                case "GraWzorce.GreenFigureLibrary":
                    this.figureLibrary = new GreenFigureLibrary();
                    break;
                case "GraWzorce.PinkFigureLibrary":
                    this.figureLibrary = new PinkFigureLibrary();
                    break;
                case "GraWzorce.RedFigureLibrary":
                    this.figureLibrary = new RedFigureLibrary();
                    break;
                case "GraWzorce.BlackFigureLibrary":
                    this.figureLibrary = new BlackFigureLibrary();
                    break;
            }
        }
    }
}
