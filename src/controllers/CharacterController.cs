using adventure_time_api.src.domain.models;
using adventure_time_api.src.domain.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace adventure_time_api.src.controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterInterfaceRepository _characterRepository;

        public CharacterController(CharacterInterfaceRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharacterModel>>> ListAllCharacters()
        {
            List<CharacterModel> characters = await _characterRepository.FindCharacters();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterModel>> GetCharacterByID(int id)
        {
            CharacterModel character = await _characterRepository.FindCharacterByID(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [HttpPost("{new}")]
        public async Task<ActionResult<CharacterModel>> CreateCharacter([FromBody] CharacterModel character)
        {
            CharacterModel createdCharacter = await _characterRepository.CreateCharacter(character);
            return CreatedAtAction(nameof(GetCharacterByID), new { id = createdCharacter.ID }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterModel>> UpdateCharacter(int id, [FromBody] CharacterModel character)
        {
            try
            {
                CharacterModel updatedCharacter = await _characterRepository.UpdateCharacter(character, id);
                return Ok(updatedCharacter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            try
            {
                bool result = await _characterRepository.DeleteCharacter(id);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
