using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.DataAnnotations
{
    public class CpfAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string cpf = Convert.ToString(value);
            var n = 0;
            for (int i = 0; i < cpf.Length; i++)
            {
                if (Char.IsNumber(cpf[i])) { n++; }
            }

            if (n != 11 || cpf[3] != '.' || cpf[7] != '.' || cpf[11] != '-' || cpf.Length > 14)
                return false;

            return true;
        }
    }
}
