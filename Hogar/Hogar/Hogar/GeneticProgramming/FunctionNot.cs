using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hogar.GeneticProgramming
{
    sealed class FunctionNot : Node
    {
        private Node _node;

        private Node _parent;


        internal static Node Make(Token token, Node parent)
        {
            return new FunctionNot(token, parent);
        }

        public static Node Make(int minid, int maxid, Node parent)
        {
            return new FunctionNot(minid, maxid, parent);
        }

        private FunctionNot(int minid, int maxid, Node parent)
        {
            _parent = parent;
            _node = NodeFactory.Make(minid, maxid, this);
        }

        private FunctionNot(FunctionNot other, Node parent)
        {
            _parent = parent;
            _node = other._node.Clone(this);
        }

        private FunctionNot(Token token, Node parent)
        {
            _parent = parent;
            _node = NodeFactory.Make(token, this);
        }

        public bool Evaluate(List<int> terminalValues)
        {
            return false ==_node.Evaluate(terminalValues) ;
        }

        public int NumberOfNodes
        {
            get
            {
                return _node.NumberOfNodes;
            }
        }

        public List<Node> Children
        {
            get
            {
                var l = new List<Node>();
                l.Add(_node);
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
            _node.Add(list);
        }
        public void SubstituteChild(Node child, Node newChild)
        {
            if (_node == child)
            {
                _node = newChild.Clone(this);
                Debug.Assert(_node.IsEqual(newChild));
            }
            else
            {
                throw new Exception("Attempt to substitute a non existing child");
            }
        }

        public bool IsEqual(Node other)
        {
            var f = other as FunctionNot;
            return null != f ? _node.IsEqual(f._node) : false;
        }
        public Node Clone(Node parent)
        {
            return new FunctionNot(this, parent);
        }

        public void Mutate(int minid, int maxid)
        {
            _node = NodeFactory.Make(minid, maxid, this);
        }

        public bool Contains(Node child)
        {
            return child == _node;
        }

        public string GetCodeAsScriptUsingFullNames()
        {
            return string.Format(" ( {0} ( {1} ) ) ", "NOT", _node.GetCodeAsScriptUsingFullNames());
        }

        public string GetCodeAsScript()
        {
            return string.Format(" ( {0} ( {1} ) ) ", "NOT", _node.GetCodeAsScript());
        }

        public override string ToString()
        {
            return "NOT";
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