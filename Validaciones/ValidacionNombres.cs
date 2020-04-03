using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace StudioEA.Validaciones
{
    public class ValidacionNombres : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value as string;

            if (!string.IsNullOrWhiteSpace(cadena))
            {
                if (cadena.Length <= 0)
                    return new ValidationResult(false, "Debes poner un nombre");

                foreach(var caracter in cadena)
                {
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                        return new ValidationResult(false, "El nombre solo puede tener letras");
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Debes poner un nombre");
        }
    }
}
