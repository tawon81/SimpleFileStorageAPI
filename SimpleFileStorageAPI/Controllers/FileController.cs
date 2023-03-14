using Microsoft.AspNetCore.Mvc;
using SimpleFileStorageAPI.Models;
using SimpleFileStorageAPI.Services;

namespace SimpleFileStorageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IBinaryFileService _binaryFileService;

        public FileController(IBinaryFileService binaryFileService)
        {
            _binaryFileService = binaryFileService;
        }

        [HttpPost("Upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            BinaryFile? newBinaryFile = null;

            try
            {
                newBinaryFile = await _binaryFileService.UploadFile(file);
            }
            catch (Exception e)
            {
                return BadRequest("There was an error uploading file: " + e.InnerException);
            }

            return Ok(newBinaryFile);
        }

        [HttpGet("GetFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            BinaryFile? file;

            try
            {
                file = await _binaryFileService.GetFile(id);

                if (file == null)
                {
                    return NotFound();
                }

                return Ok(file);
            }
            catch (Exception e)
            {
                return BadRequest("There was an error retrieving the file requested. " + e.InnerException);
            }
        }

        [HttpGet("GetFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFiles()
        {
            IEnumerable<BinaryFile> files;

            try
            {
                files = await _binaryFileService.GetFiles();

                if (files == null)
                {
                    return NotFound();
                }

                return Ok(files);
            }
            catch (Exception e)
            {
                return BadRequest("There was an error retrieving the files. " + e.InnerException);
            }
        }

        [HttpGet("GetFilesByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFilesByName(string FileName)
        {
            IEnumerable<BinaryFile> files;

            try
            {
                files = await _binaryFileService.GetFiles(FileName);

                if (files == null)
                {
                    return NotFound();
                }

                return Ok(files);
            }
            catch (Exception e)
            {
                return BadRequest("There was an error retrieving the files. " + e.InnerException);
            }
        }


        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFile(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            try
            {
                bool result = await _binaryFileService.UpdateFile(id, file);

                if (!result)
                {
                    return BadRequest("The file was not updated.");
                }

                return Ok("The file was updated successfully!");
            }
            catch (Exception e)
            {
                return BadRequest("The was an error updating the file: " + e.InnerException);
            }
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _binaryFileService.DeleteFile(id);

                if (!result)
                {
                    return BadRequest("The file was not deleted.");
                }

                return Ok("The file was deleted successfully!");
            }
            catch (Exception e)
            {
                return BadRequest("The was an error updating the file: " + e.InnerException);
            }
        }
    }
}
