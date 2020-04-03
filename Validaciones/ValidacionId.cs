using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace StudioEA.Validaciones
{
    public class ValidacionId : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null)
            {
                int id = 0;

                try
                {
                    id = Convert.ToInt32(value);
                }
                catch (Exception)
                {
                    return new ValidationResult(false, "No es un ID valido");
                }

                if (id >= 0)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "El ID debe ser mayor o igual a cero");
            }
            return new ValidationResult(false, "Debes poner un ID");
        }
    }
}
