using System;
using System.Windows.Forms;

namespace GraWzorce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GameCreator creator = new SnakeGameCreator();
            Form2 form = new Form2(creator.FactoryMethod());
            form.Activate();
            form.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            GameCreator creator = new ObstaclesGameCreator();
            Form2 form = new Form2(creator.FactoryMethod());
            form.Activate();
            form.Show();
        }
    }
}
