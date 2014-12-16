using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Firma.Models
{
    public class Klient
    {
        public int Id { get; set; }

        [Required(ErrorMessage="{0} jest wymagane")]
        [MinLength(2, ErrorMessage="Minimalna długość imienia to 2 znaki")]
        [MaxLength(16, ErrorMessage="Maksymalna długość imienia to 16 znaków")]
        [DisplayName("Imię")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "{0} jest wymagane")]
        [MinLength(2, ErrorMessage = "Minimalna długość imienia to 2 znaki")]
        [MaxLength(32, ErrorMessage = "Maksymalna długość imienia to 16 znaków")]
        [DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "{0} jest wymagany")]
        [MinLength(6, ErrorMessage = "Minimalna długość adresu to 6 znaków")]
        [MaxLength(32, ErrorMessage = "Maksymalna długość adresu email to 32 znaki")]
        [DisplayName("Adres")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "{0} jest wymagany")]
        [MinLength(6, ErrorMessage = "Minimalna długość kodu pocztowego to 6 znaków")]
        [MaxLength(6, ErrorMessage = "Maksymalna długość kodu pocztowego to 6 znaków")]
        [DisplayName("Kod pocztowy")]
        [DataType(DataType.PostalCode)]
        public string KodPocztowy { get; set; }

        [Required(ErrorMessage = "{0} jest wymagany")]
        //[MinLength(6, ErrorMessage = "Minimalna długość numeru telefonu to 9 znaków")]
        //[MaxLength(32, ErrorMessage = "Maksymalna długość numeru telefonu to 16 znaków")]
        [DisplayName("Numer telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string NumerTelefonu { get; set; }

        [Required(ErrorMessage = "{0} jest wymagany")]
        [MinLength(6, ErrorMessage = "Minimalna długość adresu email to 6 znaków")]
        [MaxLength(32, ErrorMessage = "Maksymalna długość adresu email to 32 znaki")]
        [DisplayName("Adres email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} jest wymagana")]
        [DisplayName("Data urodzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:D}")]
        public System.DateTime DataUrodzenia { get; set; }

        [Required(ErrorMessage = "{0} jest wymagana")]
        [DisplayName("Data rejestracji")]
        [CustomValidation(typeof(Klient),"SprawdzPoprawnoscDatyRejestracji")]
        [DataType(DataType.Date)]
        public System.DateTime DataRejestracji { get; set; }

        public static ValidationResult SprawdzPoprawnoscDatyRejestracji(System.DateTime data)
        {
            if (data.Date > System.DateTime.Now.Date)
                return new ValidationResult("Data rejestracji nie może być późniejsza od daty dzisiejszej");
            else
                return ValidationResult.Success;
        }
    }
}