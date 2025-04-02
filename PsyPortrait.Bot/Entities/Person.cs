namespace PsyPortrait.Bot.Entities;

public sealed class Person
{
    public Person(DateOnly dateOfBirth)
    {
        Id = Guid.NewGuid();
        DateOfBirth = dateOfBirth;
        CalculatePositions();
    }

    public Guid Id { get; private set; }

    private DateOnly DateOfBirth { get; }

    public Card FirstPosition { get; private set; }
    public Card SecondPosition { get; private set; }
    public Card ThirdPosition { get; private set; }
    public Card FourthPosition { get; private set; }
    public Card FifthPosition { get; private set; }
    public Card SixthPosition { get; private set; }

    private void CalculatePositions()
    {
        const int overflow = 22;

        int day = DateOfBirth.Day;
        int month = DateOfBirth.Month;
        int[] year = DateOfBirth.Year.ToString()
            .Select(digit => int.Parse(digit.ToString()))
            .ToArray();


        FirstPosition = (Card) (day > overflow ? day - overflow : day);
        SecondPosition = (Card) (month > overflow ? month - overflow : month);

        int yearSum = year.Sum();
        ThirdPosition = (Card) (yearSum > overflow ? yearSum - overflow : yearSum);

        int firstWithSecondSum = (int)FirstPosition + (int)SecondPosition;
        FourthPosition = (Card) (firstWithSecondSum > overflow ? firstWithSecondSum - overflow : firstWithSecondSum);

        int secondWithThirdSum = (int)SecondPosition + (int)ThirdPosition;
        FifthPosition = (Card) (secondWithThirdSum > overflow ? secondWithThirdSum - overflow : secondWithThirdSum);

        int fourthWithFifth = (int)FourthPosition + (int)FifthPosition;
        SixthPosition = (Card) (fourthWithFifth > overflow ? fourthWithFifth - overflow : fourthWithFifth);
    }
}