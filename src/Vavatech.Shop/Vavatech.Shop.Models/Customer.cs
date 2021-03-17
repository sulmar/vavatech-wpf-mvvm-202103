﻿using System;

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


    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public string FullName => $"{FirstName} {LastName}";
        public CustomerType CustomerType { get; set; }
        public string Avatar { get; set; }

        public decimal? CreditAmount { get; set; }

        public Coordinate Location { get; set; }

        public bool IsRemoved { get; set; }
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
