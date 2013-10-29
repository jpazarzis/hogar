using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OddsEditor.Dialogs;

namespace OddsEditor
{
    // April 29 2009
    // Use this class as the base for all the Windows Forms
    // to assign the same application icon to all of them....
    public partial class GenericForm  : Form
    {

        static string _copyrightString = " (c) John Pazarzis 2008-2011 Ver. 2.01";

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                if (!base.Text.Contains(_copyrightString))
                {
                    base.Text += _copyrightString;
                }
            }
        }
        public GenericForm()
        {
            InitializeComponent();
        }

        private void GenericForm_Load(object sender, EventArgs e)
        {

        }
    }
}
