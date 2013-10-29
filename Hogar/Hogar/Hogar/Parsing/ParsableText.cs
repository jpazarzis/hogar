using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Parsing
{
    public class ParsableText
    {
        readonly string _strg;

        const char _COMMA_DELIMETER = ',';
        
        static readonly string _STRING_DELIMETER = '"' + ",";
        
        readonly List<Token> _tokens = new List<Token>();
        
        int _index = 0;

        public ParsableText(string txt)
        {
            _strg = txt;
            MakeTokens();
        }

        private void MakeTokens()
        {
            _index = 0;

            int strLength = _strg.Length;

            while (_index < strLength)
            {
                _tokens.Add(GetNextToken());
            }
        }

        public List<Token> Tokens
        {
            get
            {
                return _tokens;
            }
        }

        Token GetNextToken()
        {
            // Let's see if the next token is a string


            bool nextTokenIsAString = false;

            if (_strg[_index] == '"')
            {
                nextTokenIsAString = true;
            }


            int pos = _strg.IndexOf(_COMMA_DELIMETER, _index);

            int moveIndexBy = 1;

            if (nextTokenIsAString)
            {
                // in this case instead of the comma search for the ", as the delimeter
                // just in case there are some commas within the field
                
                pos = _strg.IndexOf(_STRING_DELIMETER, _index);

                moveIndexBy = 2;
            }

            Token token = null;

            if (pos < 0)
            {
                token = new Token(_strg.Substring(_index));
                _index += token.Length + moveIndexBy;
            }
            else
            {
                token = new Token(_strg.Substring(_index, pos - _index));
                _index = pos + moveIndexBy;
            }

            return token;
        }
    }
}
