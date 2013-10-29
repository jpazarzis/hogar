

namespace OddsEditor.UITools
{
    public class FieldValidator<T> : IUndoableField, IValidableField where T : struct
    {
        static private readonly IValidableField _integerValidator = new FieldValidator<int>(int.TryParse);
        static private readonly IValidableField _doubleValidator = new FieldValidator<double>(double.TryParse);

        static public IValidableField Singelton
        {
            get
            {
                if (typeof(T) == typeof(int))
                {
                    return _integerValidator;
                }
                else if (typeof(T) == typeof(double))
                {
                    return _doubleValidator;
                }
                else
                {
                    return null;
                }

            }
        }

        private readonly UITools.FieldValidatorDelegate<T> _v;

        private FieldValidator(UITools.FieldValidatorDelegate<T> v)
        {
            _v = v;
        }

        public bool Validate(string s)
        {
            T temp;
            return _v != null ? _v(s, out temp) : false;
        }


        public string TextToUseForUndo { get; set; }
        
    }
}
