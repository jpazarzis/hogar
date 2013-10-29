using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;

namespace OddsEditor.MyComponents
{
    public partial class RaceCommentsCtrl : UserControl
    {
        Race _race = null;
        bool _needsToBeSaved = false;

        public RaceCommentsCtrl()
        {
            InitializeComponent();
        }

        public void BindRace(Race race)
        {
            _race = race;
            _txtbox.Rtf = _race.Comments;
            _txtbox.AcceptsTab = true;
            CreateContextMenu();
            _timer.Interval = 5000;
            _needsToBeSaved = false;
            _timer.Start();
        }

        void CreateContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();

            int index = 0;
            foreach (Horse h in _race.Horses)
            {
                if (!h.Scratched)
                {
                    MenuItem menuItem = new System.Windows.Forms.MenuItem();
                    menuItem.Index = index++;
                    menuItem.Text = string.Format("{0} {1}", h.ProgramNumber, h.Name);
                    menuItem.Click += new EventHandler(OnMenuItemClicked);
                    contextMenu.MenuItems.Add(menuItem);
                }

            }

            _txtbox.ContextMenu = contextMenu;
        }



        private void OnMenuItemClicked(object sender, System.EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            string horseName = "[#" + item.Text + " ] ";
            InsertHorseName(horseName);
        }

        void HighlightSelection(int from, int length, Color foreColor, Color backColor)
        {
            _txtbox.Select(from, length);
            _txtbox.SelectionColor = foreColor;
            _txtbox.SelectionBackColor = backColor;
            _needsToBeSaved = true;
            
        }

        void InsertHorseName(string name)
        {
            Color normalForeColor = Color.White;
            Color normalBackColor = Color.Black;

            if (_txtbox.Text.Length == 0)
            {
                _txtbox.Text = name;
                HighlightSelection(0, name.Length, Color.Blue, Color.White);
                return;
            }

            int selectionStartingPosition = _txtbox.SelectionStart;
            if (selectionStartingPosition < _txtbox.Text.Length - 1)
            {
                string s = _txtbox.Text.Substring(0, selectionStartingPosition) + name + " " + _txtbox.Text.Substring(selectionStartingPosition);
                _txtbox.Text = s;
                HighlightSelection(selectionStartingPosition, name.Length, Color.Blue, Color.White);
                

            }
            else // Appending in the end of the string
            {
                string s = _txtbox.Text.Substring(0, selectionStartingPosition) + name + " ";
                _txtbox.Text = s;
                HighlightSelection(selectionStartingPosition, name.Length, Color.Blue, Color.White);
            }
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
            FontStyle style = _buttonItalic.Font.Style | FontStyle.Bold;
            _buttonItalic.Font = new Font(_buttonItalic.Font, style);
        }

        void UpdateButtons()
        {
            Font font = _txtbox.SelectionFont;

            if ((font.Style & FontStyle.Bold) == FontStyle.Bold)
            {
                _buttonMakeSelectionBold.ForeColor = Color.Gray;
            }
            else
            {
                _buttonMakeSelectionBold.ForeColor = Color.Black;
            }

            if ((font.Style & FontStyle.Underline) == FontStyle.Underline)
            {
                _buttonUnderlined.ForeColor = Color.Gray;
            }
            else
            {
                _buttonUnderlined.ForeColor = Color.Black;
            }

            if ((font.Style & FontStyle.Italic) == FontStyle.Italic)
            {
                _buttonItalic.ForeColor = Color.Gray;
            }
            else
            {
                _buttonItalic.ForeColor = Color.Black;
            }
        }

        private void OnMakeUnderlinedCliked(object sender, EventArgs e)
        {

            if (_buttonUnderlined.ForeColor == Color.Gray)
            {
                FontStyle style = _txtbox.SelectionFont.Style ^ FontStyle.Underline;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                _needsToBeSaved = true;
            }
            else
            {
                FontStyle style = _txtbox.SelectionFont.Style | FontStyle.Underline;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                _needsToBeSaved = true;
            }
        }

        private void OnMakeSelectionBoldClicked(object sender, EventArgs e)
        {
            if (_buttonMakeSelectionBold.ForeColor == Color.Gray)
            {
                FontStyle style = _txtbox.SelectionFont.Style ^ FontStyle.Bold;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                _needsToBeSaved = true;
            }
            else
            {
                FontStyle style = _txtbox.SelectionFont.Style | FontStyle.Bold;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                _needsToBeSaved = true;
            }
        }

        private void OnMakeItalicClicked(object sender, EventArgs e)
        {

            if (_buttonItalic.ForeColor == Color.Gray)
            {
                FontStyle style = _txtbox.SelectionFont.Style ^ FontStyle.Italic;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                _needsToBeSaved = true;
            }
            else
            {
                FontStyle style = _txtbox.SelectionFont.Style | FontStyle.Italic;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                _needsToBeSaved = true;
            }
        }

        private void OnSelectColorClicked(object sender, EventArgs e)
        {
            ColorDialog form = new ColorDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _txtbox.SelectionColor = form.Color;
                _needsToBeSaved = true;
            }
        }

        private void OnSelectFontClicked(object sender, EventArgs e)
        {
            FontDialog form = new FontDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _txtbox.SelectionFont = form.Font;
                _needsToBeSaved = true;
            }
        }

        public void Save()
        {
            if (_needsToBeSaved)
            {
                _race.Comments = _txtbox.Rtf;
                _needsToBeSaved = false;
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            Save();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            _needsToBeSaved = true;
        }
    }
}
