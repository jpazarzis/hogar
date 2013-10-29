using System.Collections.Generic;

namespace Hogar.GeneticProgramming
{
    public interface Node
    {
        bool Evaluate(List<int> terminalValues);

        int NumberOfNodes { get; }

        List<Node> Children {get;}

        Node Parent { get; set; }

        void Add(List<Node> list);

        void SubstituteChild(Node child, Node newChild);

        Node Clone(Node parent);

        void Mutate(int minid, int maxid);

        bool Contains(Node child);

        bool IsEqual(Node other);

        string GetCodeAsScript();

        string GetCodeAsScriptUsingFullNames();

        Node Root {get;}
    }
}