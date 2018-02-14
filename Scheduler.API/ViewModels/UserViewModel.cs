﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scheduler.API.ViewModels.Validation;
using System.ComponentModel.DataAnnotations;


namespace Scheduler.API.ViewModels
{
    public class UserViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Profession { get; set; }
        public int SchedulesCreated { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new UserViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
