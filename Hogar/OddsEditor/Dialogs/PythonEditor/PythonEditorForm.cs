using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace OddsEditor.Dialogs.PythonEditor
{
    public partial class PythonEditorForm : Form
    {
        private ScriptEngine _scriptEngine = Python.CreateEngine();
        private ScriptScope _scriptScope = null;

        private Horse _dummyHorse;

        public PythonEditorForm()
        {
            InitializeComponent();
        }

        Horse GetDummyHorse()
        {
            if(null == _dummyHorse)
            {
                _dummyHorse = DailyCard.Load(DailyCard.ExistingFiles[0]).Races[0].Horses[0];    
            }
            return _dummyHorse;
        }

        private void PythonEditorForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _scriptScope = _scriptEngine.CreateScope();
            var h = GetDummyHorse();
            _scriptScope.SetVariable("horse", h);
            _scriptScope.SetVariable("horsex", h.CorrespondingBrisHorse);
            _scriptScope.SetVariable("race", h.Parent);
            _scriptScope.SetVariable("racex", h.Parent.CorrespondingBrisRace);


            this.Cursor = Cursors.Default;
        }

        private static string GetActiveParameter(string str)
        {
            int position = str.LastIndexOf('\n');

            if (position >= 0)
            {
                str = str.Substring(position + 1);
            }

            position = str.IndexOf(' ');

            while (position >= 0)
            {
                str = str.Substring(position + 1);
                position = str.IndexOf(' ');
            }

            return str;
        }


        private Point GetListBoxLocation()
        {
            var textBox = _tbCode;
            int start = textBox.SelectionStart; //character index.
            int curLine = textBox.GetLineFromCharIndex(start);
            textBox.ScrollToCaret();
            Graphics graphics = Graphics.FromHwnd(textBox.Handle);
            SizeF size = graphics.MeasureString(textBox.Lines[curLine], textBox.Font);
            Point p = textBox.Location;
            int numberOfVisibleLines = textBox.Height / (int)size.Height;
            p.Offset((int)size.Width, (curLine % numberOfVisibleLines) * (int)size.Height);

            return p;
        }


        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {

                int position = _tbCode.SelectionStart;
                string parameter = GetActiveParameter(_tbCode.Text.Substring(0, position));

                var cb = new ListBox { Cursor = Cursors.Arrow };

                var methods = new List<string>();


                if (AutoCompletion.GetProperties(_scriptScope, parameter, methods))
                {
                    methods.ForEach(m => cb.Items.Add(m));


                    var f = new Font("Microsoft Sans Serif", 9F);
                    cb.Width = 300;
                    _tbCode.Controls.Add(cb);

                    cb.Location = GetListBoxLocation();
                    cb.Focus();
                    cb.SelectedIndex = 0;
                    cb.Sorted = true;
                    cb.Height = 200;
                    cb.Font = f;
                    

                    cb.DoubleClick += (o, i) =>
                    {
                        var s = cb.SelectedItem.ToString();
                        _tbCode.Text = _tbCode.Text.Insert(position + 1, s);
                        _tbCode.Controls.Remove(cb);
                        _tbCode.SelectionStart = position + 1 + s.Length;
                        _tbCode.SelectionLength = 0;
                        _tbCode.ScrollToCaret();
                    };

                    cb.KeyPress += (o, ev) =>
                    {
                        if (ev.KeyChar == (int)Keys.Enter)
                        {
                            var s = cb.SelectedItem.ToString();
                            _tbCode.Text = _tbCode.Text.Insert(position + 1, s);
                            _tbCode.Controls.Remove(cb);
                            _tbCode.SelectionStart = position + 1 + s.Length;
                            _tbCode.SelectionLength = 0;
                            _tbCode.ScrollToCaret();
                        }
                    };
                }
            }
 
        }
    }
}
