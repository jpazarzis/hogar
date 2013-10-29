using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using System.Data.SqlClient;

namespace OddsEditor.Dialogs
{
    public partial class HorseNotesForm : Form
    {
        readonly Horse _horse;
        bool _needsToBeSaved = false;


        public HorseNotesForm(Horse horse)
        {
            _horse = horse;
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _labelHorseName.Text = _horse.Name;
            SqlDataReader myReader = null;
            try
            {
                string sql = string.Format(@"SELECT NOTES FROM HORSE_NOTES WHERE HORSE_NAME = '{0}' ", _horse.Name);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myReader = myCommand.ExecuteReader();                
                while (myReader.Read())
                {
                    string junk = myReader["NOTES"].ToString();
                    _txtbox.Rtf = myReader["NOTES"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (null != myReader)
                {
                    myReader.Close();
                }
            }
        }

        private void OnMakeSelectionBoldClicked(object sender, EventArgs e)
        {
            if (_buttonMakeSelectionBold.ForeColor == Color.Gray)
            {
                FontStyle style = _txtbox.SelectionFont.Style ^ FontStyle.Bold;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                NeedsToBeSaved = true;
            }
            else
            {
                FontStyle style = _txtbox.SelectionFont.Style | FontStyle.Bold;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                NeedsToBeSaved = true;
            }
        }

        private void OnMakeUnderlinedCliked(object sender, EventArgs e)
        {
            if (_buttonUnderlined.ForeColor == Color.Gray)
            {
                FontStyle style = _txtbox.SelectionFont.Style ^ FontStyle.Underline;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                NeedsToBeSaved = true;
            }
            else
            {
                FontStyle style = _txtbox.SelectionFont.Style | FontStyle.Underline;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                NeedsToBeSaved = true;
            }
        }

        private void OnMakeItalicClicked(object sender, EventArgs e)
        {

            if (_buttonItalic.ForeColor == Color.Gray)
            {
                FontStyle style = _txtbox.SelectionFont.Style ^ FontStyle.Italic;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                NeedsToBeSaved = true;
            }
            else
            {
                FontStyle style = _txtbox.SelectionFont.Style | FontStyle.Italic;
                _txtbox.SelectionFont = new Font(_txtbox.SelectionFont, style);
                NeedsToBeSaved = true;
            }
        }

        private void OnSelectColorClicked(object sender, EventArgs e)
        {
            ColorDialog form = new ColorDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _txtbox.SelectionColor = form.Color;
                NeedsToBeSaved = true;
            }
        }

        private void OnSelectFontClicked(object sender, EventArgs e)
        {
            FontDialog form = new FontDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _txtbox.SelectionFont = form.Font;
                NeedsToBeSaved = true;
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

        private void OnSave(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format(@"EXEC UpdateHorseNotes '{0}', '{1}' ", _horse.Name, _txtbox.Rtf);
                SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();
                NeedsToBeSaved = false;
                _horse.HasNotes = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            if (NeedsToBeSaved)
            {
                if (MessageBox.Show("There are unsaved changes. You are sure that you want to exit?", "Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            DialogResult = DialogResult.Cancel;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            NeedsToBeSaved = true;
        }

        private bool NeedsToBeSaved
        {
            get
            {
                return _needsToBeSaved;
            }
            set
            {
                _needsToBeSaved = value;
                _buttonSave.Enabled = _needsToBeSaved;
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (NeedsToBeSaved)
            {
                if (MessageBox.Show("There are unsaved changes. You are sure that you want to exit?", "Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
            
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are sure that you want to delete the note?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = string.Format(@"DELETE HORSE_NOTES WHERE HORSE_NAME = '{0}' ", _horse.Name);
                    SqlCommand myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
                    myCommand.ExecuteNonQuery();
                    _txtbox.Rtf = "";
                    NeedsToBeSaved = false;
                    _horse.HasNotes = false;
                    DialogResult = DialogResult.Cancel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnSaveAndClose(object sender, EventArgs e)
        {
            OnSave(null, null);
            OnClose(null, null);
        }
    }
}
