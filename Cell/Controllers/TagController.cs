﻿using Cell.Models;
using Cell.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tags = _tagRepository.GetAllTags();
            return Ok(tags);
        }

        [HttpPost]
        public IActionResult Post(Tag tag)
        {
            _tagRepository.AddTag(tag);

            return CreatedAtAction("Get", new { id = tag.Id }, tag);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            _tagRepository.UpdateTag(tag);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tag = _tagRepository.GetTagByTagId(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tagRepository.DeleteTag(id);
            return NoContent();
        }
    }
}
