using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO_s
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [Compare("Password")]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{6,}$", 
        //    ErrorMessage = "Passwoorden moeten minstens 8 karakters lang zijn en bevatten minstens 1 hoofdletter, 1 kleine letter, 1 nummer en 1 speciaal karakter")]
        public string PasswordConfirmation { get; set; }
    }
}
