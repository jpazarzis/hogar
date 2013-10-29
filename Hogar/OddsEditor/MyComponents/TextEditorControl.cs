using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OddsEditor.MyComponents
{
    public partial class TextEditorControl : UserControl
    {
        public delegate void SaveTextDelegate(string newText);
        public SaveTextDelegate _saveTextDelegate;

        private bool _needsToBeSaved = false;

        public TextEditorControl()
        {
            InitializeComponent();
        }

        private void OnInitialLoad(object sender, EventArgs e)
        {
            _timer.Interval = 1000;
            _timer.Start();
            Form parent = GetParentForm(this);

            if (null != parent)
            {
                parent.Closing += new CancelEventHandler(ParentClosing);
            }

            
        }

      

        private void ParentClosing(object sender, CancelEventArgs e)
        {
            _timer.Stop();
            OnTimer(null, null);
        }

        private Form GetParentForm(Control control)
        {
            if (null == control.Parent)
            {
                return null;
            }
            else if (control.Parent is Form)
            {
                return control.Parent as Form;
            }
            else
            {
                return GetParentForm(control.Parent);
            }
        }

        public override string Text
        {
            get
            {
                //return _txtbox.Rtf;
                return _txtbox.Text;
            }
            set
            {
                //_txtbox.Rtf = value;
                _txtbox.Text = value;
                _needsToBeSaved = false;
            }
        }

        public void Save()
        {
            if (null != _saveTextDelegate && _needsToBeSaved)
            {
                //_saveTextDelegate(_txtbox.Rtf);
                _saveTextDelegate(_txtbox.Text);
                _needsToBeSaved = false;
            }
        }
        
        private void OnTimer(object sender, EventArgs e)
        {
            Save();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            _needsToBeSaved = true;
        }
    }
}
