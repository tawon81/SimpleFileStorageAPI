using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleFileStorageAPI.Controllers;
using SimpleFileStorageAPI.Models;
using SimpleFileStorageAPI.Services;

namespace SimpleFileStorateAPITests
{
    public class FileStorageApiTests
    {
        [Test]
        public async Task UploadBinaryFile_Returns_OkResult() 
        {
            //Arrange
            Mock<IBinaryFileService> mockService = new Mock<IBinaryFileService>();
            BinaryFile binaryFile = new BinaryFile { ID = 100, FileName = "test.bin", FileData = new byte[] { 0x01, 0x02, 0x03 } };
            mockService.Setup(s => s.UploadFile(It.IsAny<IFormFile>()));
            FileController controller = new FileController(mockService.Object);
            Mock<IFormFile> fileMock = new Mock<IFormFile>();
            string fileName = "test.bin";
            byte[] filebytes = new byte[] { 0x01, 0x02, 0x03 };
            IFormFile file = new FormFile(new MemoryStream(filebytes), 0, filebytes.Length, "Data", fileName);

            //Act
            var result = await controller.Post(file);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            OkObjectResult okResult = (OkObjectResult)result;
            Assert.That(okResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }
    }
}