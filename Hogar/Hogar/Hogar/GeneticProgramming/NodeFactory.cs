using System;
using System.Threading;

namespace Hogar.GeneticProgramming
{
    static class NodeFactory
    {
        static public Node Make(Token token, Node parent)
        {
            int id;

            if (int.TryParse(token.Head, out id))
            {
                return Terminal.MakeNewTerminal(id, parent);
            }
            else
            {
                string f = token.Head.ToUpper();

                var t = token.Tokens;

                if (f == "AND")
                {
                    return FunctionAnd.Make(t[0], t[1], parent);
                }
                else if (f == "OR")
                {
                    return FunctionOr.Make(t[0], t[1], parent);
                }
                else if (f == "NOT")
                {
                    return FunctionNot.Make(t[0], parent);
                }
                else
                {
                    throw new Exception(string.Format("Invalid token head: {0}", f));
                }
            }
        }

        static public Node Make(string s, Node parent)
        {
            var token = new Token(s);

            return Make(token, parent);

        }

        static public Node Make(int minid, int maxid, Node parent)
        {
            int seed = 2;

            if(parent.Parent == null)
            {
                seed = 5;
            }


            if (Randomizer.GetRandomInteger(seed) == 0 || (null != parent.Root && parent.Root.NumberOfNodes > 50))
            {
                return Terminal.MakeNewRandomTerminal(minid, maxid, parent);
            }
            else
            {
                return FunctionFactory.MakeRandomFunction(minid, maxid, parent);
            }
        }
    }
}