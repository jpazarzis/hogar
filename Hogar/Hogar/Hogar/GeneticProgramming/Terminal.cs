using System;
using System.Collections.Generic;

namespace Hogar.GeneticProgramming
{
    public class Terminal : Node
    {
        private int _id;
        private Node _parent;


        static internal Terminal MakeNewTerminal(int id, Node parent)
        {
            return new Terminal(id,parent);
        }

        static internal Terminal MakeNewRandomTerminal(int minid, int maxid, Node parent)
        {
            return new Terminal(Randomizer.GetRandomInteger(maxid-minid+1),parent);
        }

        protected Terminal(int id, Node parent)
        {
            _id = id;
            _parent = parent;
        }

        

        public bool Evaluate(List<int> terminalValues)
        {
            if(_id >= 0 && _id < terminalValues.Count)
            {
                return terminalValues[_id] != 0;
            }
            else
            {
                throw new Exception("Node with invalid id was encountered");
            }
        }

        public int NumberOfNodes
        {
            get
            {
                return 1;
            }
        }

        public List<Node> Children
        {
            get
            {
                return null;
            }
        }
        public Node Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public void Add(List<Node> list)
        {
            list.Add(this);
        }

        public void SubstituteChild(Node child, Node newChild)
        {
            throw new NotImplementedException();
        }


        public string GetCodeAsScriptUsingFullNames()
        {
            List<string> list = DecisionTree.TerminalNames;

            if(null != list && list.Count > 0 && list.Count > _id)
            {
                return string.Format(" ( {0} ) ", list[_id]);
            }
            else
            {
                return GetCodeAsScript();
            }
        }


        public string GetCodeAsScript()
        {
            return string.Format(" ( {0} ) ", _id);
        }
        
        public override string ToString()
        {
            return _id.ToString();
        }

        

        public Node Clone(Node parent)
        {
            return new Terminal(_id, parent);
        }

        public bool IsEqual(Node other)
        {
            var f = other as Terminal;
            return null != f ? _id == f._id : false;
        }

        public void Mutate(int minid, int maxid)
        {
            _id = Randomizer.GetRandomInteger(maxid - minid + 1);
        }

        public Node Root
        {
            get
            {
                return _parent.Root;
            }
        }

        public bool Contains(Node child)
        {
            return false;
        }
    }
}