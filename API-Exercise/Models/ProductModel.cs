using System;
using API_Exercise.Services;

namespace API_Exercise.Models;

public interface IProduct
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public double price { get; set; }
    public float discountPercentage { get; set; }
    public float rating { get; set; }
    public int stock { get; set; }
    public string brand { get; set; }
    public string category { get; set; }
    public string thumbnail { get; set; }
    public List<string> images { get; set; }
}

public class Product : IProduct
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    private double _price;
    public double price
    {
        get { return CurrencyConverter.ConvertCurrency(_price); }
        set { _price = value; }
    }
    public float discountPercentage { get; set; }
    public float rating { get; set; }
    public int stock { get; set; }
    public string brand { get; set; }
    public string category { get; set; }
    public string thumbnail { get; set; }
    public List<string> images { get; set; }
}

