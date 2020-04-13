using System.Text.RegularExpressions;

namespace Aplicacao.Servidor.Domain.Entities.ValueObjects
{
    public class EmailValueObject
    {
        public static bool IsValid(string email)
        {
            return Regex.IsMatch(email,
         @"^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
         RegexOptions.IgnoreCase); ;
        }
    }
}
