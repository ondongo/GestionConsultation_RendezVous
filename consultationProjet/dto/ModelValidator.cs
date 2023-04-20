using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.dto
{
    public class ModelValidator
    {

        public static void validate(object model)
        {
            string ErrorMessage = "";
            List<ValidationResult> validationResults = new List<ValidationResult>();

            ValidationContext context = new ValidationContext(model);



            bool isValid = Validator.TryValidateObject(model, context, validationResults, true);

            if (isValid)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    ErrorMessage += validationResult.ErrorMessage + "\n";

                    throw new Exception(ErrorMessage);
                }
            }

        }






    }
}
