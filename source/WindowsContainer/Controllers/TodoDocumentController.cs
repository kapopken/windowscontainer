using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsContainer.App.Models;
using WindowsContainer.App.Queries;

namespace WindowsContainer.Controllers
{
    [Route("api/[controller]")]
    public class TodoDocumentController: Controller
    {
        private readonly DocumentQuery _docQuery;

        public TodoDocumentController(DocumentQuery docQuery)
        {
            _docQuery = docQuery;
        }
        [HttpGet]
        public IEnumerable<TodoDocument> Get()
        {
            return _docQuery.GetData().ToList();
        }
    }
}
