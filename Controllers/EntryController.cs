using Server.HelperClasses;
using Server.Models;
using Server.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Models;

namespace Server.Controllers
{
    [Route("api")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryRepository _entryRepository;

        public EntryController(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create([FromBody] EntryInModel data)
        {
            return Ok(_entryRepository.Create(data.ToEntryDBModel()));
        }

        [HttpPut]
        [Route("bind-new-borrower")]
        public ActionResult<bool> BindNewBorrower([FromHeader] int id, [FromBody] PersonInModel borrower)
        {
            return Ok(_entryRepository.BindNewBorrower(id, borrower.ToPersonDBModel()));
        }

        [HttpPatch]
        [Route("update-borrower-name")]
        public ActionResult<bool> UpdateBorrowerName([FromHeader] int id, [FromHeader] string expression, [FromHeader] string newName)
        {
            return Ok(_entryRepository.UpdateBorrowerName(id, expression, newName));
        }

        [HttpPatch]
        [Route("update-borrower-class")]
        public ActionResult<bool> UpdateBorrowerClass([FromHeader] int id, [FromHeader] string expression, [FromHeader] string className)
        {
            return Ok(_entryRepository.UpdateBorrowerClass(id, expression, className));
        }

        [HttpPatch]
        [Route("update-borrower-building")]
        public ActionResult<bool> UpdateBorrowerBuilding([FromHeader] int id, [FromHeader] string expression, [FromHeader] string building)
        {
            return Ok(_entryRepository.UpdateBorrowerBuilding(id, expression, building));
        }

        [HttpDelete]
        [Route("unbind-borrower")]
        public ActionResult<bool> UnbindBorrower([FromHeader] int entryId, [FromHeader] string expression)
        {
            return Ok(_entryRepository.UnbindBorrower(entryId, expression));
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult GetById([FromHeader] int id)
        {
            Entry entry = _entryRepository.GetById(id);

            if (entry != null)
            {
                EntryOutModel outModel = entry.ToEntryOutModel();
                return Ok(outModel);
            }

            return Ok("Пусто");
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            List<Entry> entries = _entryRepository.GetAll();

            List<EntryOutModel> converted = entries.ToEntryOutModelBulk().ToList();

            return Ok(converted);
        }

        [HttpGet]
        [Route("get-search")]
        public IActionResult Search([FromHeader] string seacrhTerm)
        {
            List<Entry> entries = _entryRepository.Search(seacrhTerm);

            List<EntryOutModel> converted = entries.ToEntryOutModelBulk().ToList();

            if (converted.Count == 0) return Ok("Пусто");
            else
            {
                return Ok(converted);
            }
        }

        [HttpPatch]
        [Route("update-state")]
        public ActionResult<bool> UpdateState([FromHeader] int id, [FromHeader] string state)
        {
            return Ok(_entryRepository.UpdateState(id, state));
        }

        [HttpPatch]
        [Route("update-name")]
        public ActionResult<bool> UpdateName([FromHeader] int id, [FromHeader] string name)
        {
            return Ok(_entryRepository.UpdateName(id, name));
        }

        [HttpPatch]
        [Route("update-quantity")]
        public ActionResult<bool> UpdateQuantity([FromHeader] int id, [FromHeader] uint quantity)
        {
            return Ok(_entryRepository.UpdateQuantity(id, quantity));
        }

        [HttpPatch]
        [Route("update-unit")]
        public ActionResult<bool> UpdateUnit([FromHeader] int id, [FromHeader] string unit)
        {
            return Ok(_entryRepository.UpdateUnit(id, unit));
        }

        [HttpPatch]
        [Route("update-desc")]
        public ActionResult<bool> UpdateDescription([FromHeader] int id, [FromBody] string description)
        {
            return Ok(_entryRepository.UpdateDescription(id, description));
        }

        [HttpPatch]
        [Route("update-owner")]
        public ActionResult<bool> UpdateOwner([FromHeader] int id, [FromHeader] string owner)
        {
            return Ok(_entryRepository.UpdateOwner(id, owner));
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<bool> Delete([FromHeader] int id)
        {
            return Ok(_entryRepository.Delete(id));
        }
    }
}

