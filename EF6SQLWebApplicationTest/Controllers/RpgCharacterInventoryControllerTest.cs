using EF6SQLWebApplication;
using EF6SQLWebApplication.Data;
using EF6SQLWebApplication.Data.Repo;
using EF6SQLWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLWebApplicationTest.Controllers
{
    public class RpgCharacterInventoryControllerTest
    {
        private DataContext _dataContext;
        private RpgCharacterInventoryRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _dataContext = new DataContext(options);
            _repository = new RpgCharacterInventoryRepository(_dataContext);
        }

        [Test]
        public void AddItemToInventory_ShouldAddItemToDatabase()
        {
            // Arrange
            var item = new RpgCharacterInventory
            {
                Id = 1,
                RpgCharacterId = 1,
                RpgCharacter = new RpgCharacter { Id = 1, Name = "FirstOne", CharacterClass = 1, HitPoints = 100 },
                ItemName = "Item1",
                Quantity = 5
            };

            // Act
            _repository.AddItemToInventory(item);
            _dataContext.SaveChanges();

            // Assert
            var retrievedCharacter = _dataContext.RpgCharacterInventory.FirstOrDefault(c => c == item);
            Assert.IsNotNull(retrievedCharacter, "Item should be added to the database");
        }

        [Test]
        public async Task GetAllItems_ShouldReturnAllItems()
        {
            // Arrange
            var items = new List<RpgCharacterInventory>
            {
                new RpgCharacterInventory {
                    Id = 1,
                    RpgCharacterId = 1,
                    RpgCharacter = new RpgCharacter { Id = 1, Name = "FirstOne", CharacterClass = 1, HitPoints = 100 },
                    ItemName = "Item1",
                    Quantity = 5
                },
                new RpgCharacterInventory {
                    Id = 2,
                    RpgCharacterId = 2,
                    RpgCharacter = new RpgCharacter { Id = 2, Name = "SecondOne", CharacterClass = 1, HitPoints = 500 },
                    ItemName = "Item2",
                    Quantity = 6
                }
            };

            _dataContext.RpgCharacterInventory.AddRange(items);
            await _dataContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllItems();

            // Assert
            Assert.AreEqual(2, result.Count(), "Should return all items");
        }

        [Test]
        public async Task GetItem_ShouldReturnItem()
        {
            // Arrange
            var item = new RpgCharacterInventory
            {
                Id = 8,
                RpgCharacterId = 1,
                RpgCharacter = new RpgCharacter { Id = 1, Name = "FirstOne", CharacterClass = 1, HitPoints = 100 },
                ItemName = "Item1",
                Quantity = 5
            };

            _dataContext.RpgCharacterInventory.Add(item);
            await _dataContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetItem(item.Id);

            // Assert
            Assert.AreEqual(8, result.Id, "Should return item id");
        }
    }
}
