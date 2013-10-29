using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Filter;

namespace OddsEditor.Dialogs.Filter
{
    public partial class FiltersForm : Form
    {

        List<Hogar.Filter.Filter> _filters = new List<Hogar.Filter.Filter>();
        public FiltersForm()
        {
            InitializeComponent();
        }

        private void FiltersForm_Load(object sender, EventArgs e)
        {
            foreach (var filter in FilterCollection.MakeNew())
            {
                _listFilters.Items.Add(filter);
            }
        }

        public List<Hogar.Filter.Filter> SelectedFilters
        {
            get
            {
                return _filters;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (var item in _listFilters.CheckedItems)
            {
                _filters.Add((Hogar.Filter.Filter)item);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
