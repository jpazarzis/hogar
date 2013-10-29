using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Hogar.GeneticProgramming
{
    class Token
    {
        private readonly string _head;
        private readonly string _body;

        public Token(string s)
        {
            s = StripEnclosingParenthesis(s);
            int i = s.IndexOf(' ');
            if(i<0)
            {
                _head = s;
                _body = "";
            }
            else
            {
                _head = s.Substring(0, i).Trim();
                _body = s.Substring(i).Trim();
            }
        }

        static private string StripEnclosingParenthesis(string s)
        {
            s = s.Trim();

            if(s.Length >=2 && s[0] == '(' && s[s.Length-1] == ')')
            {
                s = s.Substring(1);
                s = s.Substring(0, s.Length - 1);
            }

            return s.Trim();
        }

        public string Head
        {
            get
            {
                return _head;
            }
        }

        

        public List<Token> Tokens
        {
            get
            {
                var t = new List<Token>();
                string s = _body;
                s = StripEnclosingParenthesis(s);

                int pos = -1;
                int openingPos = -1;
                
                bool insideAToken = false;
                int count = 0;

                while(++pos < s.Length)
                {
                    switch (s[pos])
                    {
                        case '(':
                            if (!insideAToken)
                            {
                                insideAToken = true;
                                openingPos = pos;
                                count = 1;
                            }
                            else
                            {
                                ++count;
                            }
                            break;
                        case ')':
                            Debug.Assert(insideAToken);
                            --count;
                            if(count <=0)
                            {
                                t.Add(new Token(s.Substring(openingPos,pos+1-openingPos)));
                                insideAToken = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
                return t;
            }
        }

        



        
    }
}
