using System;

namespace Part3_BuilderPattern
{
    public class AddressBuilder
    {
        internal string Street;
        internal string City;
        internal string State;
        internal string ZipCode;
        internal string Country;

        public AddressBuilder WithStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street cannot be empty.");
            Street = street;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City cannot be empty.");
            City = city;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            State = state;
            return this;
        }

        public AddressBuilder WithZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentException("ZipCode cannot be empty.");
            ZipCode = zipCode;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Country cannot be empty.");
            Country = country;
            return this;
        }
    }
}