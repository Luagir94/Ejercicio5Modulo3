using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Enums;

namespace Ejercicio5Modulo3.Infrastructure.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;

using System.Globalization;


    public  class UsuarioApiList
    {
        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }
    }

    public  class Info
    {
        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class Result
    {
        [JsonProperty("gender")] public string Gender { get; set; }

        [JsonProperty("name")] public Name Name { get; set; }

        [JsonProperty("location")] public Location Location { get; set; }

        [JsonProperty("email")] public string Email { get; set; }

        [JsonProperty("login")] public Login Login { get; set; }

        [JsonProperty("dob")] public Dob Dob { get; set; }

        [JsonProperty("registered")] public Dob Registered { get; set; }

        [JsonProperty("phone")] public string Phone { get; set; }

        [JsonProperty("cell")] public string Cell { get; set; }

        [JsonProperty("id")] public Id Id { get; set; }

        [JsonProperty("picture")] public Picture Picture { get; set; }

        [JsonProperty("nat")] public string Nat { get; set; }

        public static Usuario mapFromDto(Result x)
        {
            return new Usuario
            {
                Nombre = x.Name.First,
                Apellido = x.Name.Last,
                Email = x.Email,
                Edad = (int)x.Dob.Age,
                Nombre_Usuario = x.Login.Username,
                Password = x.Login.Password,
                Ciudad = x.Location.City,
                Estado = x.Location.State,
                Pais = x.Location.Country,
                Genero = x.Gender
            };
        }
    }

    public  class Dob
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }
    }

    public  class Id
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public  class Location
    {
        [JsonProperty("street")]
        public Street Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postcode")]
        public object Postcode { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }
    }

    public  class Coordinates
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public  class Street
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public  class Timezone
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public  class Login
    {
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("md5")]
        public string Md5 { get; set; }

        [JsonProperty("sha1")]
        public string Sha1 { get; set; }

        [JsonProperty("sha256")]
        public string Sha256 { get; set; }
    }

    public  class Name
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }
    }

    public  class Picture
    {
        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("medium")]
        public Uri Medium { get; set; }

        [JsonProperty("thumbnail")]
        public Uri Thumbnail { get; set; }
    }
