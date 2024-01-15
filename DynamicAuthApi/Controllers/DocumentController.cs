using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {

        private readonly IDocumentServicce document;
        private readonly IUnitOfWork unitOfWork;
        public DocumentController(IDocumentServicce document
            ,IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.document = document;
        }

        [HttpPost]
        public  ActionResult<ResultDTO> AddDocument([FromForm] AddDocumentDTO documentDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(document.AddDocument(documentDTO));
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetAllDocument()
        {
           
           //document =   unitOfWork.documentRepository.GetById(id);
            return Ok(document.GetDocuments());
        }

        [HttpGet("GetDocument")]
        public ActionResult<ResultDTO> GetDocument(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

            //document =   unitOfWork.documentRepository.GetById(id);
            return Ok(document.GetDocument(id));
        }
        [HttpDelete("DeleteDocument")]
        public ActionResult<ResultDTO> DeleteDocument(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

            //document =   unitOfWork.documentRepository.GetById(id);
            return Ok(document.DeleteDocument(id));
        }
        [HttpPut("UpdateDocument")]
        public ActionResult<ResultDTO> UpdateDocument([FromForm] UpdateDocumentDTO updateDocumentDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

            //document =   unitOfWork.documentRepository.GetById(id);
            return Ok(document.UpdateDocument(   updateDocumentDTO));
        }
        [HttpGet("download")]
        public IActionResult DownloadFile(string fileName)
        {
            // Get the full file path within the wwwroot directory
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", fileName);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Or handle the error in a way that fits your application
            }

            // Set the content type based on the file extension
            string contentType = GetContentType(fileName);

            // Use PhysicalFile method to send the file for download
            return PhysicalFile(filePath, contentType, fileName);
        }

        private string GetContentType(string fileName)
        {
            // You may want to enhance this method to handle various file types
            // For simplicity, this example assumes everything is an application/octet-stream
            return "application/octet-stream";
        }
        


    }
}
