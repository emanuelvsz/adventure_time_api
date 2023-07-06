using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using adventure_time_api.Models;
using adventure_time_api.Repository.Interfaces;

namespace adventure_time_api.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterLoader _characterLoader;

        public CharacterController(CharacterLoader characterRepository)
        {
            _characterLoader = characterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharacterModel>>> FindCharacters()
        {
            List<CharacterModel> characters = await _characterLoader.FindCharacters();
            return Ok(characters);
        }
    }
}
