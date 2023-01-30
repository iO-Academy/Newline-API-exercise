using System;
namespace API_Exercise.Models
{
	public class ErrorResponse
	{
		public string message { get; }

		public ErrorResponse(string error)
		{
			this.message = error;
		}
	}
}

