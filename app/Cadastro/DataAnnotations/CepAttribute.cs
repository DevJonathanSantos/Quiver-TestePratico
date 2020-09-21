using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cadastro.DataAnnotations
{
    public class CepAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string cep = Convert.ToString(value);
            var n = 0;
            for (int i = 0; i < cep.Length; i++)
            {
                if (Char.IsNumber(cep[i])) { n++; }
            }

            if (n != 8 || cep[5] != '-' || cep.Length > 9)
                return false;

            return true;
        }
    }
}
