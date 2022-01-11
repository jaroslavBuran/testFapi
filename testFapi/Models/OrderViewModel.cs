using System.ComponentModel.DataAnnotations;

namespace testFapi.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Jméno musí být vyplněno!")]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Příjmení musí být vyplněno!")]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Eamilová adresa musí být vyplněna!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefonní číslo musí být vyplněno!")]
        [Display(Name = "Telefonní číslo")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Ulice musí být vyplněna!")]
        [Display(Name = "Ulice")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Číslo popisné musí být vyplněno!")]
        [Display(Name = "Č.p.")]
        [RegularExpression("^[0-9]+[/]*[0-9]*$", ErrorMessage = "Může obsahovat pouze číslice nebo symbol '/'!")]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Město musí být vyplněno!")]
        [Display(Name = "Město")]
        public string City { get; set; }
        [Required(ErrorMessage = "PSČ musí být vyplněno!")]
        [Display(Name = "PSČ")]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "PSČ musí obsahovat pouze číselné hodnoty!")]
        public string PostalCode { get; set; }

        /////////////////////////////////////////////////////////////

        [Required(ErrorMessage = "Název produktu musí být vyplněn!")]
        [Display(Name = "Název produktu")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Množství musí být vyplněno!")]
        [Display(Name = "Množství (ks)")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Cena za kus musí být vyplněna!")]
        [Display(Name = "Cena za kus v Kč")]
        [DataType(DataType.Currency)]
        [RegularExpression("^[0-9]+(.[0-9][0-9]?)?$", ErrorMessage = "Cena za kus musí mít číselnou hodnotu!")]
        public decimal Price { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Celková cena v Kč (bez DPH)")]
        public decimal TotalPrice { get; set; }
        [Required(ErrorMessage = "Sazba DPH musí být vyplněna!")]
        [Display(Name = "DPH (%)")]
        public int TaxRate { get; set; }
        [Display(Name = "DPH")]
        [DataType(DataType.Currency)]
        public decimal DPH { get; set; }
        [Display(Name = "Cena celkem")]
        [DataType(DataType.Currency)]
        public decimal FinalPrice { get; set; }
        [Display(Name = "Cena celkem v EUR")]
        public decimal FinalPriceEuro { get; set; }
    }
}
