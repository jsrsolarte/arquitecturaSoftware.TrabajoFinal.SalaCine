using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Ports
{
    public interface IFileRepository
    {
        Task<string> Save(byte[] content, string extension, string contentType);
        Task<string> Update(byte[] content, string extension, string path, string contentType);
    }
}
