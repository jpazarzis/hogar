using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.DbTools;

namespace OddsEditor.Dialogs.SelectCard
{
    class RaceStarter
    {
        private readonly string _programNumber;
        private readonly string _name;
        private readonly int _officalPosition;
        public RaceStarter(DbReader dbr)
        {
            _officalPosition = dbr.GetValue<int>("official_position");
            _name = dbr.GetValue<string>("horse_name");
            _programNumber = dbr.GetValue<string>("program_number");
        }

        public void AddToNode(TreeNode node)
        {
            //node.Nodes.Add(string.Format("{0} {1}", _programNumber, _name));
            node.Nodes.Add(_name);
        }
    }
}
