using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;

namespace StringParser.UnitTests;

[TestFixture]
public class StringParserTests
{
    Services.StringParser parser;

    public string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        // Create a random number generator
        Random random = new Random();

        // Generate a random string of the specified length
        string randomString = new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());

        return randomString;
    }

    [SetUp]
    public void SetUp()
    {
        parser = new Services.StringParser();
    }

    [Test]
    public void Parse_StringIsNull_ReturnsNull()
    {
        //Arrange
        string s = null;

        //Act
        var result = parser.Parse(s);

        //Assert
        result.ShouldBeNull();
    }

    [Test]
    public void Parse_StringISEmpty_ReturnsNull()
    {
        //Arrange
        string s = "";

        //Act
        var result = parser.Parse(s);

        //Assert
        result.ShouldBeNull();
    }

    [Test]
    public void Parse_StringIsLongerThan15Chars_ReturnsFirst15Chars()
    {
        //Arrange
        string s = GenerateRandomString(20);

        //Act
        var result = parser.Parse(s);

        //Assert
        result.Length.ShouldBe(15);
    }

    [Test]
    public void Parse_StringIs15CharsLong_Returns15Chars()
    {
        //Arrange
        string s = GenerateRandomString(15);

        //Act
        var result = parser.Parse(s);

        //Assert
        result.Length.ShouldBe(15);
    }

    [Test]
    public void Parse_StringIsLessThan10Chars_Returns10Chars()
    {
        //Arrange
        string s = GenerateRandomString(10);

        //Act
        var result = parser.Parse(s);

        //Assert
        result.Length.ShouldBe(10);
    }

    [Test]
    public void Parse_StringContainsSameCaseDuplicates_TheyAreReplacedWithSameSingleChar()
    {
        //Arrange
        string s = "AAAbbb";

        //Act
        var result = parser.Parse(s);

        //Assert
        result.ShouldBe("Ab");
    }

    [Test]
    public void Parse_StringContainsDifferentCaseDuplicates_TheyStayTheSame()
    {
        //Arrange
        string s = "cCcCdDdDEeE";

        //Act
        var result = parser.Parse(s);

        //Assert
        result.ShouldBe("cCcCdDdDEeE");
    }

    [Test]
    public void Parse_StringContainsDollarSigns_TheyAreReplacedWithPounds()
    {
        //Arrange
        string s = "$blabla$£&%$";

        //Act
        var result = parser.Parse(s);

        //Assert
        result.ShouldBe("£blabla££&%£");
    }

    [Test]
    public void Parse_StringContainsUnderscoresOrFours_TheyGetRemoved()
    {
        //Arrange
        string s = "_123_sfvf___sdfc_";

        //Act
        var result = parser.Parse(s);

        //Assert
        result.ShouldBe("123sfvfsdfc");
    }

    [Test]
    public void Parse_AllConditionsApplied_OutputIsValid()
    {
        //Arrange
        string s = "AAAc$1%4cWwWkL_q$1ci3_848v3d__K";

        //Act
        var result = parser.Parse(s);

        //Assert
        result.ShouldBe("Ac£1%cWwWkLq£1c");
    }
}
