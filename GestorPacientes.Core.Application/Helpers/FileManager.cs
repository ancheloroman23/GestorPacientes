using GestorPacientes.Core.Application.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;

namespace GestorPacientes.Core.Application.Helpers
{
    public class FileManager : IFileManager
    {
        private string root = "wwwroot/images/";

        public void Delete(string file, string imagen)
        {
            var deleteRoot = root + file;
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), deleteRoot);
            var fileRoot = Path.Combine(directoryPath, imagen);

            if (File.Exists(fileRoot))
            {
                File.Delete(fileRoot);
            }
        }

        public async Task<string> Save(IFormFile archivo, string file)
        {
            var saveroot = root + file;

            if (archivo == null || archivo.Length == 0)
            {
                throw new ArgumentException("El archivo no es valido.");
            }

            var name = Guid.NewGuid().ToString() + Path.GetExtension(archivo.FileName);

            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), saveroot);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var destiny = Path.Combine(directoryPath, name);

            using (var stream = new FileStream(destiny, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }
            return name;
        }

        public async Task<string> Update(IFormFile archivo, string file, string imagen)
        {
            Delete(file, imagen);

            return await Save(archivo, file);
        }
    }
}
