namespace PackageHandler.Tests;


//Innebär att data hämtas från packagecollection klassen i konstruktorn så att alla tester kan köras paralellt
[Collection(nameof(PackageCollection))]
public class PackageTests
{
    Package _sut;

    public PackageTests(PackageFixture packageFixture)
    {
        _sut = packageFixture.Normal;
    }

    [Fact]
    public void CanCalculateVolumeOfNormalSizedCylinder()
    {
        // Arrange
     
        // We always round up because we are stingy
        var expected = 4713;
        
        // Act 
        var actual = _sut.Volume();

        // Assert
        Assert.Equal(expected, actual);
            
    }

    [Theory]
    [InlineData(0, 3770)]
    [InlineData(1, 3770)]
    [InlineData(2, 3770)]
    [InlineData(3, 5655)]
    [InlineData(6, 11310)]
    [InlineData(8, 15080)]
    [InlineData(20, 37700)]
    public void CanCalculatePriceOfNormalSizedCylinderInline(int weight, int expected)
    {
        // Arrange
        _sut.Weight = weight;

        // Act 
        var actual = _sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }


    [Theory]
    [ClassData(typeof(ClassData))]
    public void CanCalculatePriceOfNormalSizedCylinderClassData(int weight, int expected)
    {
        // Arrange
        _sut.Weight = weight;

        // Act 
        var actual = _sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    /* In summary, this code attribute [MemberData(nameof(TestData.FromCsv), 
     * MemberType = typeof(TestData))] is telling xUnit to use the FromCsv method in the TestData class as the source of test data for the parameterized test method where this attribute is applied. 
     * The FromCsv method likely returns a collection of test data that will be used to run the parameterized test method with various inputs.*/
    [MemberData(nameof(TestData.FromCsv), MemberType = typeof(TestData))]
    public void CanCalculatePriceOfNormalSizedCylinderMemberData(int weight, int expected)
    {
        // Arrange
        _sut.Weight = weight;

        // Act 
        var actual = _sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PriceDoesNotMutatePackage()
    {
        // Arrange
        _sut.Weight = 1;

        var radius = _sut.Radius;
        var len = _sut.Length;
        var weight = _sut.Weight;
        
        // Act 
        _sut.Price();

        // Assert
        // Compare original to values after calculating price
        Assert.Equal(radius, _sut.Radius);
        Assert.Equal(len, _sut.Length);
        Assert.Equal(weight, _sut.Weight);
    }

    [Fact]
    public void PriceThrowsPackageTooHeavyExceptionWhenOver20kg()
    {

    }

    //[Fact]
    //public void Price_Over20kg_ThrowsInvalidOperationException()
    //{
    //    // Arrange
    //    _sut.Weight = 21;

    //    // Act
    //    // Assert
    //    Assert.ThrowsAny<InvalidOperationException>(() => _sut.Price());
    //}

    [Theory]
    [MemberData(nameof(TestData.FromCsv2), MemberType = typeof(TestData))]
    public void CheckIfSocialSecurityNumberIsValid(string number)
    {

        string pattern = @"^(?:19|20)\d{6}\d{4}$";

        Assert.Matches(pattern, number);

        //här skriver jag regex 
    }


    //public static IEnumerable<object[]> PackageTestWeights()
    //{
    //    var list = new List<object[]>
    //        {
    //            new object[] { 0, 3770 },
    //            new object[] { 1, 3770 },
    //            new object[] { 2, 3770 },
    //            new object[] { 3, 5655 },
    //            new object[] { 8, 15080 },
    //            new object[] { 20, 37700 }
    //        };

    //    return list;
    //}
}
