using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppDataAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Author author = new Author();
            author.FirstName = "Joydip";
            author.LastName = "";
            author.PhoneNumber = "1234567890";
            author.Email = "joydipkanjilal@yahoo.com";

            ValidationContext context = new ValidationContext(author, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool valid = Validator.TryValidateObject(author, context, validationResults, true);

            if (!valid)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine($"{validationResult.ErrorMessage}");
                }
            }
                

            Console.ReadKey();
        }
    }

    public class Author
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50,MinimumLength = 3,ErrorMessage = "First Name should be minimum 3 characters")]
        [DataType(DataType.Text)]
        [IsEmpty(ErrorMessage = "Should not be null or empty")]
        public string FirstName { get; set; }
        
       
        [StringLength(50,MinimumLength = 3,ErrorMessage = "Last Name should be minimum 3 characters")]
        [DataType(DataType.Text)]
        [IsEmpty(ErrorMessage = "Should not be null or empty")]
        public string LastName { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Currency)]
     
        public decimal Salary { get; set; }
        
    }

    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false, Inherited = false)]
    public class IsEmptyAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            return !string.IsNullOrEmpty(inputValue);
        }
    }
    
    
}