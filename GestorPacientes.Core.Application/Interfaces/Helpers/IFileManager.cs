using Microsoft.AspNetCore.Http;

namespace GestorPacientes.Core.Application.Interfaces.Helpers
{
    public interface IFileManager
    {
        Task<string> Save(IFormFile archivo, string file);
        Task<string> Update(IFormFile archivo, string file, string imagen);
        void Delete(string file, string imagen);
    }
}
