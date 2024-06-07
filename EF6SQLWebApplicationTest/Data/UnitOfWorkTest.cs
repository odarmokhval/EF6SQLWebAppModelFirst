//using EF6SQLWebApplication.Data;
//using EF6SQLWebApplication.Intergaces;
//using Moq;

//namespace EF6SQLWebApplicationTest.Data
//{
//    [TestFixture]
//    public class UnitOfWorkTest
//    {
//        private Mock<DataContext> _mockDataContext;
//        private Mock<IRpgCharacterRepository> _rpgCharacterRepository;
//        private Mock<IRpgCharacterInventoryRepository> _rpgCharacterInventoryRepository;

//        [SetUp]
//        public void SetUp()
//        {
//            _mockDataContext = new Mock<DataContext>();
//            _rpgCharacterRepository = new Mock<IRpgCharacterRepository>();
//            _rpgCharacterInventoryRepository = new Mock<IRpgCharacterInventoryRepository>();
//        }

//        [Test]
//        public void RpgCharacterRepository_ShouldReturnCorrectRepository()
//        {
//            // Arrange
//            var uow = new UnitOfWork(_mockDataContext.Object, _rpgCharacterRepository.Object, _rpgCharacterInventoryRepository.Object);

//            // Act
//            var characterRepo = uow.RpgCharacterRepository;

//            // Assert
//            Assert.That(characterRepo, Is.SameAs(_rpgCharacterRepository.Object), "RpgCharacterRepository should return the provided repository");
//        }

//        [Test]
//        public void RpgCharacterInventoryRepository_ShouldReturnCorrectRepository()
//        {
//            // Arrange
//            var uow = new UnitOfWork(_mockDataContext.Object, _rpgCharacterRepository.Object, _rpgCharacterInventoryRepository.Object);

//            // Act
//            var inventoryRepo = uow.RpgCharacterInventoryRepository;

//            // Assert
//            Assert.That(inventoryRepo, Is.SameAs(_rpgCharacterInventoryRepository.Object), "RpgCharacterInventoryRepository should return the provided repository");
//        }

//        [Test]
//        public async Task SaveAsync_ShouldCallDataContextSaveChangesAsync()
//        {
//            // Arrange
//            var uow = new UnitOfWork(_mockDataContext.Object, _rpgCharacterRepository.Object, _rpgCharacterInventoryRepository.Object);
//            _mockDataContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

//            // Act
//            var result = await uow.SaveAsync();

//            // Assert
//            Assert.IsTrue(result, "SaveAsync should return true if SaveChangesAsync is successful");
//            _mockDataContext.Verify(x => x.SaveChangesAsync(default), Times.Once, "SaveChangesAsync should be called once");
//        }

//        [Test]
//        public void Dispose_ShouldCallDataContextDispose()
//        {
//            // Arrange
//            var uow = new UnitOfWork(_mockDataContext.Object, _rpgCharacterRepository.Object, _rpgCharacterInventoryRepository.Object);

//            // Act
//            uow.Dispose();

//            // Assert
//            _mockDataContext.Verify(x => x.Dispose(), Times.Once, "Dispose should call DataContext.Dispose once");
//        }
//    }
//}
