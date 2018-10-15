using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultarCEP.Domain
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
