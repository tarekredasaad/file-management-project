using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Modules.ECommerce.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DocumentServices : IDocumentServicce
    {
        private readonly IUnitOfWork _unitOfWork;
        public DocumentServices(IUnitOfWork unitOfWork) 
        {
         _unitOfWork = unitOfWork;
        }
        public async  Task<ResultDTO> AddDocument(AddDocumentDTO documentDTO)
        {
            if (documentDTO.Name != null )
            {
                Documents document = new Documents();
                document.Name = documentDTO.Name;
                document.CreatedDate = documentDTO.CreatedDate;
                Priorities priorities = new Priorities();
                priorities.Priority = documentDTO.PriorityLevel;
                if(documentDTO.File_Path != null)
                {
                    priorities.File_Path = FileHelper.UploadImg(documentDTO.File_Path,"Files");
                    priorities.Name = FileHelper.fileName;
                }
                _unitOfWork.PriorityRepository.Create(priorities);
                _unitOfWork.commit();
                document.PriorityId = priorities.Id;
                //document.name = documentDTO.name;
                //document.price = documentDTO.price;
                _unitOfWork.DocumentRepository.Create(document);
                _unitOfWork.commit();
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = "document Is Added successfully"
                };
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }

        public async Task<ResultDTO> DeleteDocument(int id)
        {
            if (id == 0)
            {
                return new ResultDTO()
                {
                    StatusCode = 400,
                    Data = null,
                    Message = "Invalid operation "

                };
            }
            else
            {
                _unitOfWork.DocumentRepository.Delete(id);
                _unitOfWork.commit();
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = "your document is deleted",
                    Message = "Invalid operation "

                };
            }
        }
        public async Task<ResultDTO> GetDocument(int id)
        {
           if(id == 0)
            {
                return new ResultDTO()
                {
                    StatusCode = 400,
                    Data = null,
                    Message = "Invalid operation "

                };
            }
            else
            {
                DocumentDTO documentDTO = new DocumentDTO();
                Documents document = new Documents();
                Priorities priority = new Priorities();
                document = _unitOfWork.DocumentRepository.GetById(id);
                _unitOfWork.commit();
                priority=_unitOfWork.PriorityRepository.GetById(document.PriorityId);
                _unitOfWork.commit();
                documentDTO.PriorityName=priority.Name;
                documentDTO.PriorityLevel = priority.Priority;
                documentDTO.File_Path=priority.File_Path;
                documentDTO.Name=document.Name;
                documentDTO.Id=document.Id;
               

                documentDTO.Due_Date= (DateTime)document.Due_Date;
               
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = documentDTO,
                    Message = "you get document successfully "

                };
            }
        }

        public async Task<ResultDTO> GetDocuments()
        {
            List<DocumentDTO> documents = new List<DocumentDTO>();
            List<Documents> Documents = (List<Documents>)_unitOfWork.DocumentRepository.GetAll();
            _unitOfWork.commit();
            if ( Documents == null)
            {
                return new ResultDTO()
                {
                    StatusCode = 400,
                    Data = null,
                    Message = "Invalid operation "

                };
            }
            foreach (Documents document in Documents)
            {
                DocumentDTO documentDTO = new DocumentDTO();
                Priorities priority = new Priorities();
                priority = _unitOfWork.PriorityRepository.GetById(document.PriorityId);
                _unitOfWork.commit();
                documentDTO.PriorityName = priority.Name;
                documentDTO.PriorityLevel = priority.Priority;
                documentDTO.File_Path = priority.File_Path;
                documentDTO.Name = document.Name;
                documentDTO.Id = document.Id;
                documentDTO.Due_Date = (DateTime)document.Due_Date;
                documents.Add(documentDTO);
            }
            return new ResultDTO()
            {
                StatusCode = 200,
                Data = documents,
                Message = "You get documents successfully"

            };
        }

        public async Task<ResultDTO> UpdateDocument(UpdateDocumentDTO documentDTO)
        {
           Documents document = _unitOfWork.DocumentRepository.GetById(documentDTO.Id);
            Priorities priority = _unitOfWork.PriorityRepository.GetById(document.PriorityId);
            document.Name = documentDTO.Name;
            document.Date = documentDTO.Date;
            priority.Priority = documentDTO.PriorityLevel;
            if (documentDTO.File_Path != null)
            {
                priority.File_Path = FileHelper.UploadImg(documentDTO.File_Path, "Files");
                priority.Name = FileHelper.fileName;
            }
            _unitOfWork.PriorityRepository.Update(priority); 
            _unitOfWork.commit();
            _unitOfWork.DocumentRepository.Update(document);
            _unitOfWork.commit();
            return new ResultDTO()
            {
                StatusCode = 200,
                Data = document,
                Message = "your document has been updated"
            };
        }
    }
}
