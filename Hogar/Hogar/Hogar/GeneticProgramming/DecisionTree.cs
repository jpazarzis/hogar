using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Hogar.GeneticProgramming
{
    public sealed class DecisionTree : Node
    {
        private DecisionTreeStatistics _statistics = DecisionTreeStatistics.Make();
        private  Node _node;

        // used to translate a terminal's id to it's name
        private static List<string> _terminalNames = null;

        static public List<string> TerminalNames
        {
            get
            {
                return _terminalNames;
            }
            set
            {
                _terminalNames = value;
            }
        }

        static public bool CanBeCrossOvered(Node left, Node right)
        {
            if(left is DecisionTree)
            {
                var dt = left as DecisionTree;
                left = dt._node;
            }

            if (right is DecisionTree)
            {
                var dt = right as DecisionTree;
                right = dt._node;
            }

            return false == left.IsEqual(right);
        }



        static public List<DecisionTree> CrossOver(DecisionTree dt1, DecisionTree dt2)
        {
            Debug.Assert(dt1 != dt2);

            Debug.Assert(CanBeCrossOvered(dt1,dt2));

            DecisionTree t1 = dt1.MakeACopy();
            Debug.Assert(t1.IsEqual(dt1));
            DecisionTree t2 = dt2.MakeACopy();
            Debug.Assert(t2.IsEqual(dt2));

            var nodes1 = new List<Node>();
            var nodes2 = new List<Node>();

            t1._node.Add(nodes1);
            t2._node.Add(nodes2);

            var list = new List<DecisionTree>();
            while (true)
            {
                int i1 = Randomizer.GetRandomInteger(nodes1.Count);
                int i2 = Randomizer.GetRandomInteger(nodes2.Count);

                Node n1 = nodes1[i1];
                Node n2 = nodes2[i2];

                if (CanBeCrossOvered(n1, n2))
                {
                  
                    int dt2Count = dt2.NumberOfNodes;

                    Node parent1 = n1.Parent;
                    Node parent2 = n2.Parent;
                    parent1.SubstituteChild(n1, n2);
                    parent2.SubstituteChild(n2, n1);
                    list.Add(t1);
                    list.Add(t2);

                    break;
                }
            }
            return list;
        }

        public bool IsEqual(Node other)
        {
            if(other is DecisionTree)
            {
                var dt = other as DecisionTree;
                return _node.IsEqual(dt._node);
            }
            else
            {
                return _node.IsEqual(other);    
            }
            
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


        

        public Node Clone(Node parent)
        {
            throw new NotImplementedException();
        }

        public DecisionTreeStatistics Statistics
        {
            get
            {
                return _statistics;
            }
        }

        public void Mutate(int minid, int maxid)
        {
            var nodes = new List<Node>();
            _node.Add(nodes);
            int i = Randomizer.GetRandomInteger(nodes.Count);
            nodes[i].Mutate(minid,maxid);
        }

        public bool Contains(Node child)
        {
            return child == _node;
        }

        static public DecisionTree Make(string s)
        {
            return new DecisionTree(s);
        }

        static public DecisionTree Make(int minTerminalId, int maxTerminalId)
        {
            return new DecisionTree(minTerminalId, maxTerminalId);
        }


        private DecisionTree(string script)
        {
            _node = NodeFactory.Make(script, this);
        }

        private DecisionTree(int minTerminalId, int maxTerminalId)
        {
            _node = NodeFactory.Make(minTerminalId, maxTerminalId,this);
        }

        private DecisionTree()
        {
            
        }

        public DecisionTree MakeACopy()
        {
            var newDt = new DecisionTree();
            newDt._node = _node.Clone(newDt);
            newDt._statistics = _statistics.MakeACopy();
            return newDt;
        }

     
        public bool Evaluate(List<int> terminalValues)
        {
            return _node.Evaluate(terminalValues);
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
                throw new NotImplementedException();
            }
        }
        public Node Parent
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(List<Node> list)
        {
            throw new NotImplementedException();
        }

        public Node Root
        {
            get
            {
                return _node;
            }

        }

        public string GetCodeAsScript()
        {
            return _node.GetCodeAsScript();
        }

        public string GetCodeAsScriptUsingFullNames()
        {
            return _node.GetCodeAsScriptUsingFullNames();
        }

        public override string ToString()
        {
            return _statistics.ToString();
        }
    }
}
