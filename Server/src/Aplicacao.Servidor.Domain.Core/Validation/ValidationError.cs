using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Servidor.Domain.Core.Validation
{

    public class ValidationError
    {
        public string Message { get; set; }
        public string PropertyName { get; set; }
        public ValidationError(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
    }
}
