using EF6SQLWebApplication;
using EF6SQLWebApplication.Intergaces;
using EF6SQLWebApplication.Models;
using Moq;
using NUnit.Framework.Interfaces;

namespace EF6SQLWebApplicationTest.Controllers
{
    [TestFixture]
    public class RpgCharacterInventoryControllerStubTest
    {
        [Test]
        public void AddItemToInventory_ShouldAddItemToInventory()
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

            var repositoryStub = new RpgCharacterInventoryRepositoryStub();

            // Act
            repositoryStub.AddItemToInventory(item);

            // Assert
            Assert.IsTrue(repositoryStub.InventoryItems.Contains(item), "Item should be added to inventory");
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
                    ItemName = "Item1",
                    Quantity = 5
                },
                new RpgCharacterInventory {
                    Id = 2,
                    RpgCharacterId = 2,
                    ItemName = "Item2",
                    Quantity = 6
                }
            };

            var repositoryStub = new RpgCharacterInventoryRepositoryStub();

            foreach (var item in items)
            {
                repositoryStub.AddItemToInventory(item);
            }

            // Act
            var result = await repositoryStub.GetAllItems();

            // Assert
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

            var repositoryStub = new RpgCharacterInventoryRepositoryStub();
            repositoryStub.AddItemToInventory(item);


            // Act
            var result = await repositoryStub.GetItem(item.Id);

            // Assert
            Assert.That(result.Id, Is.EqualTo(item.Id), "Should return item with the correct ID");
        }

        public class RpgCharacterInventoryRepositoryStub : IRpgCharacterInventoryRepository
        {
            public List<RpgCharacterInventory> InventoryItems { get; private set; } = new List<RpgCharacterInventory>();

            public void AddItemToInventory(RpgCharacterInventory item)
            {
                InventoryItems.Add(item);
            }

            public Task<IEnumerable<RpgCharacterInventory>> GetAllItems()
            {
                return Task.FromResult(InventoryItems.AsEnumerable());
            }
            public Task<RpgCharacterInventory?> GetItem(int id)
            {
                var item = InventoryItems.FirstOrDefault(i => i.Id == id);
                return Task.FromResult(item);
            }
        }
    }
}
