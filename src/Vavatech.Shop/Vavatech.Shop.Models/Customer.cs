using System;
using System.ComponentModel;
using Vavatech.Shop.Models.Attributes;

namespace Vavatech.Shop.Models
{

    //public class Customer : BaseEntity
    //{
    //    private string firstName;
    //    private string lastName;
    //    private CustomerType customerType;

    //    public string FirstName
    //    {
    //        get => firstName; set
    //        {
    //            firstName = value;
    //            OnPropertyChanged();
    //            OnPropertyChanged(nameof(FullName));
    //        }
    //    }
    //    public string LastName
    //    {
    //        get => lastName; set
    //        {
    //            lastName = value;
    //            OnPropertyChanged();
    //            OnPropertyChanged(nameof(FullName));
    //        }
    //    }
    //    public string FullName => $"{FirstName} {LastName}";
    //    public CustomerType CustomerType
    //    {
    //        get => customerType; set
    //        {
    //            customerType = value;
    //            OnPropertyChanged();
    //        }
    //    }
    //    public string Avatar { get; set; }
    //    public bool IsRemoved { get; set; }
    //}


    // PM> Install-Package Fody
    // PM> Install-Package PropertyChanged.Fody



    // IDataErrorInfo -> ValidatesOnDataErrors=True


    public enum Country
    {
        Poland,
        Germany,
        Italy,
        USA
    }

    public class Customer : BaseEntity, IDataErrorInfo
    {
     

        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public string FullName => $"{FirstName} {LastName}";
        public CustomerType CustomerType { get; set; }
        public string Avatar { get; set; }

        public decimal? CreditAmount { get; set; }

        public Coordinate Location { get; set; }
        
        public Country Country { get; set; }

        [Country("Poland")]
        public string Pesel { get; set; }
        [Country("Poland")]
        public string Regon { get; set; }
        
        public string TaxId { get; set; }

        [Country("Germany")]
        public string Land { get; set; }

        public bool IsRemoved { get; set; }

        #region IDataErrorInfo
        public string this[string columnName] => Validate(columnName);

        private string Validate(string columnName)
        {
            if (columnName == nameof(FirstName))
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    return "Imię nie może być puste";
                }
            }

            if (columnName == nameof(LastName))
            {
                if (string.IsNullOrEmpty(LastName))
                {
                    return "Nazwisko nie może być puste";
                }
            }

            if (columnName == nameof(CreditAmount))
            {
                if (CreditAmount < 0 || CreditAmount > 1000)
                    return "Wartość CreditAmount jest poza zakresem";
            }

            return string.Empty;    // brak błędu
        }

        public string Error => null;
        #endregion

    }

    public class Coordinate : Base
    {

        public Coordinate()
        {

        }

        public Coordinate(double latitude, double longitude)
            : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
