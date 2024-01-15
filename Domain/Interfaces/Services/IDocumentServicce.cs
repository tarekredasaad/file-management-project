using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IDocumentServicce
    {
        Task<ResultDTO> AddDocument(AddDocumentDTO documentDTO);
        Task<ResultDTO> UpdateDocument( UpdateDocumentDTO documentDTO);
        Task<ResultDTO> GetDocuments();
        //Task<ResultDTO> updateDocuments(int id,AddDocumentDTO addDocumentDTO);
        Task<ResultDTO> GetDocument(int id);
        Task<ResultDTO> DeleteDocument(int id);

    }
}
