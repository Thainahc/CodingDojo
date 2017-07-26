using System.Collections.Generic;
using Sommus.CodingDojo.Domain.Enums;

namespace Sommus.CodingDojo.Domain.Services
{
    public class ResponseService
    {
        private string _message = string.Empty;
        List<string> _fieldsInvalids = new List<string>();
        private ResponseTypeEnum _type;

        public string Message
        {
            get { return _message ?? string.Empty; }
            set { _message = value; }
        }
        public List<string> FieldsInvalids
        {
            get { return _fieldsInvalids ?? new List<string>(); }
            set { _fieldsInvalids = value; }
        }
        public ResponseTypeEnum Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}