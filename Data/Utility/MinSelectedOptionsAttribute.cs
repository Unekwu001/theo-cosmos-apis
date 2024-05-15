using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utility
{
    public class MinSelectedOptionsAttribute : ValidationAttribute
    {
        private readonly int _minSelectedOptions;

        public MinSelectedOptionsAttribute(int minSelectedOptions)
        {
            _minSelectedOptions = minSelectedOptions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var selectedOptions = value as ICollection<MultipleChoiceEnum>;

            if (selectedOptions == null || selectedOptions.Count < _minSelectedOptions)
            {
                return new ValidationResult($"You must select at least {_minSelectedOptions} options.");
            }

            return ValidationResult.Success;
        }
    }

}
