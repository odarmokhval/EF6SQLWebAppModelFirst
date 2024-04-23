using EF6SQLWebApplication;
using EF6SQLWebApplication.Data;
using EF6SQLWebApplication.Data.Repo;
using Microsoft.EntityFrameworkCore;

[TestFixture]
public class RpgCharacterRepositoryTests
{
    private DataContext _dataContext;
    private RpgCharacterRepository _repository;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        _dataContext = new DataContext(options);
        _repository = new RpgCharacterRepository(_dataContext);
    }

    [Test]
    public void AddCharacter_ShouldAddCharacterToDatabase()
    {
        // Arrange
        var character = new RpgCharacter
        {
            Id = 1,
            Name = "FirstOne",
            CharacterClass = 1,
            HitPoints  = 100
        };

        // Act
        _repository.AddCharacter(character);
        _dataContext.SaveChanges();

        // Assert
        var retrievedCharacter = _dataContext.RpgCharacters.FirstOrDefault(c => c == character);
        Assert.IsNotNull(retrievedCharacter, "Character should be added to the database");
    }

    [Test]
    public async Task GetAllCharacters_ShouldReturnAllCharacters()
    {
        // Arrange
        var characters = new List<RpgCharacter>
        {
            new RpgCharacter { Id = 1, Name = "FirstOne", CharacterClass = 1, HitPoints  = 100 },
            new RpgCharacter { Id = 2, Name = "SecondOne", CharacterClass = 1, HitPoints  = 500 }
        };

        _dataContext.RpgCharacters.AddRange(characters);
        await _dataContext.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllCharacters();

        // Assert
        Assert.AreEqual(2, result.Count(), "Should return all characters");
    }

    [Test]
    public async Task GetCharacter_ShouldReturnCharacter()
    {
        // Arrange
        var character = new RpgCharacter
        {
            Id = 1,
            Name = "FirstOne",
            CharacterClass = 1,
            HitPoints = 100
        };

        _dataContext.RpgCharacters.Add(character);
        await _dataContext.SaveChangesAsync();

        // Act
        var result = await _repository.GetCharacter(character.Id);

        // Assert
        Assert.AreEqual(1, result.Id, "Should return character id");
    }
}