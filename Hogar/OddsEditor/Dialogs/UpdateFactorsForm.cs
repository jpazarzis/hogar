using System;
using System.IO;
using System.Windows.Forms;
using Hogar;
using Hogar.DbTools;

namespace OddsEditor.Dialogs
{
    public partial class UpdateFactorsForm : Form
    {

#region FileNameInfo
        private class FileNameInfo
        {
            readonly string _fullpath;

            public FileNameInfo(string fullpath)
            {
                _fullpath = fullpath;
            }

            public override string  ToString()
            {
 	             return Path.GetFileName(_fullpath);
            }

            public string FullPath
            {
                get
                {
                    return _fullpath;
                }
            }
        }
#endregion

        public UpdateFactorsForm()
        {
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            LoadListBox();
        }

        private void LoadListBox()
        {
            _listbox.Items.Clear();
            foreach (string fullpath in DailyCard.FilesToUpdateFactors)
            {
                _listbox.Items.Add(new FileNameInfo(fullpath));     
            }
            _buttonUpdateAll.Enabled = _listbox.Items.Count > 0;
        }

        public void ShowMessage(string txt)
        {
            _txtboxMessages.Text += txt + Environment.NewLine;
            if (_txtboxMessages.Text.Length + txt.Length >= _txtboxMessages.MaxLength)
            {
                _txtboxMessages.Text = _txtboxMessages.Text.Substring(10000);
            }
            _txtboxMessages.Select(_txtboxMessages.Text.Length + 1, 2);
            _txtboxMessages.ScrollToCaret();
        }

        private void OnUpdateAll(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int count = 0;
            try
            {
                for (int i = 0; i < _listbox.Items.Count; ++i)
                {
                    var fni = (FileNameInfo)_listbox.Items[i];
                    DailyCard dc = DailyCard.Load(fni.FullPath);
                    dc.UpdateObserverEvent += ShowMessage;
                    dc.SaveFactorsToDb();
                    ++count;
                    DailyCard.ResetCache();
                }

                DbReader.ExecuteNonQuery("Exec UpdateFactorStatistics");
                DbReader.ExecuteNonQuery("Exec UpdateFieldSize");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowMessage(string.Format("Successfully processed {0} files...", count));
                LoadListBox();
                Cursor = Cursors.Default;
            }            
        }
    }
}
