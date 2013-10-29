using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hogar.GeneticProgramming
{
    sealed class FunctionAnd : Node
    {
        private Node _left;
        private Node _right;
        private Node _parent;

        internal static Node Make(Token left, Token right,  Node parent)
        {
            return new FunctionAnd(left,right, parent);
        }
        
        internal static Node Make(int minid, int maxid, Node parent)
        {
            return new FunctionAnd(minid, maxid,parent);
        }

        private FunctionAnd(int minid, int maxid, Node parent)
        {
            _parent = parent;
            _left = NodeFactory.Make(minid, maxid,this);
            _right = NodeFactory.Make(minid, maxid,this);
        }

        private FunctionAnd(Token left, Token right, Node parent)
        {
            _parent = parent;

            _left = NodeFactory.Make(left, this);
            _right = NodeFactory.Make(right, this);
        }

        private FunctionAnd(FunctionAnd other, Node parent)
        {
            _parent = parent;
            _left = other._left.Clone(this);
            _right = other._right.Clone(this);
        }

        public bool Evaluate(List<int> terminalValues)
        {
            return _left.Evaluate(terminalValues) && _right.Evaluate(terminalValues);
        }

        public int NumberOfNodes
        {
            get
            {
                return _left.NumberOfNodes + _right.NumberOfNodes;
            }
        }

        public List<Node> Children
        {
            get
            {
                var l = new List<Node>();
                l.Add(_left);
                l.Add(_right);
                return l;
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
            _left.Add(list);
            _right.Add(list);
        }

        public void SubstituteChild(Node child, Node newChild)
        {
            if(_left == child)
            {
                _left = newChild.Clone(this);    
                Debug.Assert(_left.IsEqual(newChild));
            }
            else if (_right == child)
            {
                _right = newChild.Clone(this);
                Debug.Assert(_right.IsEqual(newChild));
            }
            else
            {
                throw new Exception("Attempt to substitute a non existing child");
            }
        }

        public Node Clone(Node parent)
        {
            return new FunctionAnd(this, parent);
        }

        public void Mutate(int minid, int maxid)
        {
            _left = NodeFactory.Make(minid, maxid, this);
            _right = NodeFactory.Make(minid, maxid, this);
        }

        public bool Contains(Node child)
        {
            return child == _right || child == _left;
        }

        public bool IsEqual(Node other)
        {
            var f = other as FunctionAnd;
            return null != f ? _right.IsEqual(f._right) && _left.IsEqual(f._left) :false;
        }

        public string GetCodeAsScriptUsingFullNames()
        {
            return string.Format(" ( {0} ({1} {2}) ) ", "AND", _left.GetCodeAsScriptUsingFullNames(), _right.GetCodeAsScriptUsingFullNames());
        }

        public string GetCodeAsScript()
        {
            return string.Format(" ( {0} ({1} {2}) ) ", "AND",_left.GetCodeAsScript(),_right.GetCodeAsScript());
        }

        public override string ToString()
        {
            return "AND";
        }

        public Node Root
        {
            get
            {
                return _parent.Root;
            }
        }
    }
}