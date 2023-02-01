using API_Exercise.Models;

namespace API_Exercise_Tests;

public class ErrorResponseFacts
{
    [Fact]
    public void Instantiate_ErrorResponse()
    {
        var error = new ErrorResponse("Test");
        Assert.IsType<ErrorResponse>(error);
    }

    [Fact]
    public void ErrorResponse_message()
    {
        var error = new ErrorResponse("Test");
        Assert.Matches("Test", error.message);
    }
}
