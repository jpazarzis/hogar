using System;
using System.Windows.Forms;

namespace OddsEditor.Dialogs
{
    public partial class EditCommentsForm : GenericForm
    {

        string _comments = "";
        string _caption = "";

        public EditCommentsForm(string comments, string caption)
        {
            _caption = caption;
            _comments = comments;
            InitializeComponent();
        }

        public string Comments
        {
            get
            {
                return _comments;
            }
        }

        private void OnOK(object sender, EventArgs e)
        {
            _comments = _tbComments.Text;

            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnLoadForm(object sender, EventArgs e)
        {
            this.Text = _caption;
            _tbComments.Text = _comments;
            _tbComments.Select(_tbComments.Text.Length, _tbComments.Text.Length);
            _bOK.Focus();
        }
    }
}
