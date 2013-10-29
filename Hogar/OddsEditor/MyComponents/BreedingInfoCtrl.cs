using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar;
using Hogar.SireStats;

namespace OddsEditor.MyComponents
{
    public partial class BreedingInfoCtrl : UserControl
    {
        public BreedingInfoCtrl()
        {
            InitializeComponent();
        }

        public void BindHorse(Horse horse)
        {
            string sire1 = horse.CorrespondingBrisHorse.Sire;
            string sire2 = horse.CorrespondingBrisHorse.DamSire;

            DataTable dt = Sire.GetSiresInfo(sire1, sire2);
            
            _grid.Columns.Clear();

            _grid.Columns.Add("S-DS", "S-DS");
            _grid.Columns.Add("Name", "Name");
            _grid.Columns.Add("FTS", "FTS");
            _grid.Columns.Add("MUD", "MUD");
            _grid.Columns.Add("TURF", "TURF");
            _grid.Columns.Add("AWS", "AWS");
            _grid.Columns.Add("DIST", "DIST");

            int index = _grid.Rows.Add();

            Font boldFont = new Font(_grid.DefaultCellStyle.Font, FontStyle.Bold);
            _grid.Rows[index].DefaultCellStyle.Font = boldFont;

            _grid["FTS", index].Value = "FTS";
            _grid["MUD", index].Value = "M";
            _grid["TURF", index].Value = "T";
            _grid["AWS", index].Value = "AWS";
            _grid["DIST", index].Value = "D";

            foreach (DataRow dr in dt.Rows)
            {
                index = _grid.Rows.Add();
                DataGridViewCellCollection cells = _grid.Rows[index].Cells;
                
                cells[0].Value = dr["S/DS"].ToString();
                cells[0].Style.Font = boldFont;
                cells[1].Value = dr["Name"].ToString();
                cells[2].Value = dr["FTS"].ToString();
                cells[3].Value = dr["MUD"].ToString();
                cells[4].Value = dr["TURF"].ToString();
                cells[5].Value = dr["AWS"].ToString();
                cells[6].Value = dr["DIST"].ToString();
            }
            
            for(int i =0; i < _grid.Columns.Count; ++i)
            {
                _grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            _grid.BorderStyle = BorderStyle.None;
            _grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            _grid.DefaultCellStyle.BackColor = Color.Beige;
            _grid.DefaultCellStyle.SelectionBackColor = Color.Beige;
            _grid.RowHeadersVisible = false;
            _grid.ColumnHeadersVisible = false;

            _grid.BackgroundColor = Color.Beige;
        }
    }
}
