using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cadastro.DataAnnotations
{
    public class TelefoneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            foreach(var item in (dynamic)(value))
            {
                if (item == null)
                    return true;
                string telefone = Convert.ToString(item);
                var n = 0;
                for (int i = 0; i < telefone.Length; i++)
                {
                    if (Char.IsNumber(telefone[i])) { n++; }
                }
                if (n.Equals(11))
                {
                    if (telefone[0] != '(' || telefone[3] != ')' || telefone[10] != '-')
                        return false;
                }
                else if (n.Equals(10))
                {
                    if (telefone[0] != '(' || telefone[3] != ')' || telefone[9] != '-')
                        return false;
                }
                else
                {
                    return false;
                }
            }
            


            return true;
        }
    }
}
//(11) 95860-7051