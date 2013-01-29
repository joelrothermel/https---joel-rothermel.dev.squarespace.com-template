using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CNM.Web.ViewModels.Account
{
    public class LoginViewModel : ViewModelBase, IValidatableObject
    {
        public LoginViewModel()
        {
            Type = "board";
        }

        [DisplayName("Email Address:")]
        public string BoardEmail { get; set; }

        [DisplayName("Password:")]
        public string BoardPassword { get; set; }

        [DisplayName("Username:")]
        public string CharityUsername { get; set; }

        [DisplayName("Password:")]
        public string CharityPassword { get; set; }

        public string Type { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Type == "board")
            {
                if (String.IsNullOrWhiteSpace(BoardEmail))
                    results.Add(new ValidationResult("You must enter an email address.", new string[] { "BoardEmail" }));
                if (String.IsNullOrWhiteSpace(BoardPassword))
                    results.Add(new ValidationResult("You must enter a password.", new string[] { "BoardPassword" }));
            }
            else
            {
                if (String.IsNullOrWhiteSpace(CharityUsername))
                    results.Add(new ValidationResult("You must enter a username.", new string[] { "CharityUsername" }));
                if (String.IsNullOrWhiteSpace(CharityPassword))
                    results.Add(new ValidationResult("You must enter a password.", new string[] { "CharityPassword" }));
            }

            return results;
        }
    }
}