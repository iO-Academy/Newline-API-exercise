using System;
using System.IO;
using Newtonsoft.Json;

namespace API_Exercise.Services
{
	public class JsonFileReader
	{
		public T ReadAndParse<T>(string jsonFile) where T: class
		{
			T? result;
			try
			{
				string json = File.ReadAllText(jsonFile);
				result = JsonConvert.DeserializeObject<T>(json);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error reading JSON file: " + e.Message);
				result = null;
			}
			return result;
		}
	}
}

