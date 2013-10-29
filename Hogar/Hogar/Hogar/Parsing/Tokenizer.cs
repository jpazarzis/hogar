using System.Collections.Generic;
using System.Text;

namespace Hogar.Parsing
{
    public class Tokenizer
    {
        private const char DELIMETER = (char)217;

        public Tokenizer(string txt)
        {
            Tokens = DelimitText(txt).Split(DELIMETER);
        }

        public string [] Tokens { get; private set;}

        public string this[int index]
        {
            get
            {
                return Tokens[index];
            }
        }


        static private string DelimitText(string txt)
        {
            var sb = new StringBuilder();

            bool insideAString = false;
            bool quote = false;
            foreach (char c in txt)
            {
                char currentChar = c;
                quote = false;

                if(c == '"')
                {
                    insideAString = !insideAString;
                    quote = true;
                }

                if(!insideAString && c == ',')
                {
                    currentChar = DELIMETER;
                }


                if (currentChar == '\'')
                {
                    currentChar =  '`';
                }
                
                if(false == quote)
                {
                    sb.Append(currentChar);
                }
                    
            }

            return sb.ToString();
        }
    }
}