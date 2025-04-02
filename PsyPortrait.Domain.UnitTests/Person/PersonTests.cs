using PsyPortrait.Bot.Entities;

namespace PsyPortrait.Domain.UnitTests.Person;

public class PersonTests
{
    [Theory]
    [InlineData("1992-07-26", Card.Emperor, Card.Chariot, Card.World, Card.Justice, Card.Lovers, Card.Star)] // Test case 1
    [InlineData("2022-11-19", Card.Sun, Card.Justice, Card.Lovers, Card.Strength, Card.Star, Card.Empress)] // Test case 2
    [InlineData("1989-03-07", Card.Chariot, Card.Empress, Card.Hierophant, Card.WheelOfFortune, Card.Strength, Card.Moon)] // Test case 3
    public void Person_Should_CalculatePositions(string dateString, Card expectedFirstPos, Card expectedSecondPos,
        Card expectedThirdPos, Card expectedFourthPos,
        Card expectedFifthPos, Card expectedSixthPos)
    {
        // Arrange
        DateOnly birthDay =  DateOnly.ParseExact(dateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

        // Act
        var person = new Bot.Entities.Person(birthDay);

        // Assert
        Assert.Equal(expectedFirstPos, person.FirstPosition);
        Assert.Equal(expectedSecondPos, person.SecondPosition);
        Assert.Equal(expectedThirdPos, person.ThirdPosition);
        Assert.Equal(expectedFourthPos, person.FourthPosition);
        Assert.Equal(expectedFifthPos, person.FifthPosition);
        Assert.Equal(expectedSixthPos, person.SixthPosition);
    }
}