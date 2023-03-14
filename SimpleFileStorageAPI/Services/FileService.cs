using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SimpleFileStorageAPI.Data;
using SimpleFileStorageAPI.Models;
using System.IO;
using System.Security.Cryptography;

namespace SimpleFileStorageAPI.Services
{
    public interface IBinaryFileService
    {
        Task<BinaryFile> UploadFile(IFormFile file);
        Task<bool> UpdateFile(int id, IFormFile file);
        Task<bool> DeleteFile(int id);
        Task<IEnumerable<BinaryFile>> GetFiles();
        Task<IEnumerable<BinaryFile>> GetFiles(string FileName);
        Task<BinaryFile?> GetFile(int id);
    }

    public class BinaryFileService : IBinaryFileService
    {
        private readonly ApiContext _dbContext;

        public BinaryFileService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BinaryFile> UploadFile(IFormFile file)
        {
            BinaryFile binaryFile;
            decimal version = 1.0m;

            try
            {
                byte[] fileBytes;

                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    fileBytes = ms.ToArray();
                }

                //If duplicate file with same name exists, new record will be created with incremented version property. 
                BinaryFile? binaryFileDb = _dbContext.ApiFiles.Where(a => a.FileName == file.FileName).FirstOrDefault();

                binaryFile = new BinaryFile();

                binaryFile.FileName = file.FileName;
                binaryFile.FileData = fileBytes;
                binaryFile.FileType = file.ContentType;
                binaryFile.Version = binaryFileDb == null ? version : binaryFileDb.Version + .10m;

                _dbContext.ApiFiles.Add(binaryFile);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }

            return binaryFile;
        }

        public async Task<BinaryFile?> GetFile(int id)
        {
            try
            {
                BinaryFile? fileFromDb = await _dbContext.ApiFiles.Where(f => f.ID == id).FirstOrDefaultAsync();

                return fileFromDb;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BinaryFile>> GetFiles()
        {
            return await _dbContext.ApiFiles.ToListAsync();
        }

        public async Task<IEnumerable<BinaryFile>> GetFiles(string FileName)
        {
            return await _dbContext.ApiFiles.Where(a => a.FileName.Contains(FileName)).ToListAsync();
        }

        public async Task<bool> UpdateFile(int id, IFormFile file)
        {
            bool result = false;

            try
            {
                byte[] fileBytes;

                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    fileBytes = ms.ToArray();
                }

                BinaryFile? fileFromDB = _dbContext.ApiFiles.Where(x => x.ID == id).FirstOrDefault();

                if (fileFromDB == null)
                {
                    return result;
                }

                fileFromDB.FileName = file.FileName;
                fileFromDB.FileData = fileBytes;
                fileFromDB.FileType = file.ContentType;
                fileFromDB.Version = fileFromDB.FileData != fileBytes ? fileFromDB.Version + .10m : fileFromDB.Version

                await _dbContext.SaveChangesAsync();

                result = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return result;
        }

        public async Task<bool> DeleteFile(int Id)
        {
            bool result = false;

            try
            {
                await _dbContext.ApiFiles.Where(x => x.ID == Id).ExecuteDeleteAsync(); 
                result = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return result;
        }
    }
}
