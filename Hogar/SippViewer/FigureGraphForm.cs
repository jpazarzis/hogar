using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sipp;

namespace SippViewer
{
    public partial class FigureGraphForm : Form
    {
        private readonly SippRace _race;
        public FigureGraphForm(SippRace race)
        {
            _race = race;
            InitializeComponent();
        }

        private void FigureGraphForm_Load(object sender, EventArgs e)
        {

        }

        private void FigureGraphForm_Paint(object sender, PaintEventArgs e)
        {
            this.AutoScrollMinSize = new Size(1000, 1000);

            if(null == _race)
                return;

            int x = 10, y = 10, dy =3;

            var borderPen = new Pen(Color.Black);

            var innerBorderPen = new Pen(Color.DarkGray);

            int horseNameWidth = 150;
            int periodWidth = 80;
            int height = 120;

            var horseNameFont = new Font("Arial", 10F,FontStyle.Bold);
            var nameFont = new Font("Arial", 8F);

            var brush = Brushes.Navy;


            foreach (var horse in _race)
            {
                x = 10;
                y += dy;

                e.Graphics.DrawRectangle(borderPen, x, y, horseNameWidth + periodWidth * 15, height);
                e.Graphics.DrawString(string.Format("{0}. {1}",horse.ProgramNumber, horse.Name),horseNameFont,brush, x+2,y+8);

                e.Graphics.DrawString(horse.Jockey, nameFont, brush, x + 2, y + 30);
                e.Graphics.DrawString(horse.Trainer, nameFont, brush, x + 2, y + 50);
                e.Graphics.DrawString(horse.LifeTimeRecord, nameFont, brush, x + 2, y + 70);


                x += horseNameWidth;

                for (int i = 0; i < 15; ++i )
                {
                    e.Graphics.DrawRectangle(innerBorderPen, x, y, periodWidth, height);
                    x += periodWidth;
                }

                foreach (var pp in horse.PastPerformances)
                {
                    int daysBefore = pp.DaysSinceTodaysRace;

                    if(daysBefore <=360)
                    {
                        int index = daysBefore/15;

                        x = index*periodWidth + horseNameWidth;

                        if( daysBefore % 15 <=5)
                        {
                            x += periodWidth / 4;
                        }
                        else if (daysBefore % 15 <= 10)
                        {
                            x += periodWidth / 2;
                        }
                        else 
                        {
                            x += (periodWidth * 3) / 4;
                        }

                        e.Graphics.DrawString(pp.SpeedFigure.ToString(), nameFont, brush, x , y + 30);

                    }
                }

                y += height;
            }

            
        }

        
    }
}
