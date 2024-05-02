using EF6SQLWebApplication;
using EF6SQLWebApplication.Data;
using EF6SQLWebApplication.Intergaces;
using EF6SQLWebApplication.Models;
using Moq;

namespace EF6SQLWebApplicationTest.Controllers
{
    public class RpgCharacterInventoryControllerMockTest
    {
        private Mock<DataContext> _mockDataContext;
        private Mock<IRpgCharacterRepository> _rpgCharacterRepository;
        private Mock<IRpgCharacterInventoryRepository> _rpgCharacterInventoryRepository;

        [SetUp]
        public void SetUp()
        {
            _mockDataContext = new Mock<DataContext>();
            _rpgCharacterRepository = new Mock<IRpgCharacterRepository>();
            _rpgCharacterInventoryRepository = new Mock<IRpgCharacterInventoryRepository>();
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

            var repositoryMock = new Mock<IRpgCharacterInventoryRepository>();

            // Act
            repositoryMock.Object.AddItemToInventory(item);

            // Assert
            repositoryMock.Verify(r => r.AddItemToInventory(It.Is<RpgCharacterInventory>(i => i == item)), Times.Once);
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

            var repositoryMock = new Mock<IRpgCharacterInventoryRepository>();
            repositoryMock.Setup(repo => repo.GetAllItems()).ReturnsAsync(items);

            // Act
            var result = await repositoryMock.Object.GetAllItems();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2), "Should return all items");
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

            var repositoryMock = new Mock<IRpgCharacterInventoryRepository>();
            repositoryMock.Setup(repo => repo.GetItem(item.Id)).ReturnsAsync(item);

            // Act
            var result = await repositoryMock.Object.GetItem(item.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(item.Id), "Should return item with the correct ID");
        }
    }
}