using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraWzorce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameCreator creator = new SnakeGameCreator();
            Form2 form=new Form2(creator.FactoryMethod());
            form.Activate();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameCreator creator = new ObstaclesGameCreator();
            Form2 form = new Form2(creator.FactoryMethod());
            form.Activate();
            form.Show();
        }
    }
}
