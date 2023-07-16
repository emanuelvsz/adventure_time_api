using adventure_time_api.src.domain.interfaces;
using adventure_time_api.src.domain.models;
using adventure_time_api.src.infra.database;
using Microsoft.EntityFrameworkCore;

namespace adventure_time_api.src.infra
{
    public class CharacterRepository : CharacterInterfaceRepository
    {
        private readonly CharacterDBContext _dbContext;
        public CharacterRepository(CharacterDBContext characterDBContext) 
        {
            _dbContext = characterDBContext;
        }
        public async Task<List<CharacterModel>> FindCharacters()
        {
            return await _dbContext.Characters.ToListAsync();
        }
        public async Task<CharacterModel> FindCharacterByID(int id)
        {
            return await _dbContext.Characters.FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<CharacterModel> CreateCharacter(CharacterModel character)
        {
            _dbContext.Characters.AddAsync(character);
            _dbContext.SaveChangesAsync();

            return character;
        }

        public async Task<CharacterModel> UpdateCharacter(CharacterModel character, int id)
        {
            CharacterModel characterPerID = await FindCharacterByID(id);

            if (characterPerID == null)
            {
                throw new Exception($"O personagem com o id {id} não foi encontrado no banco de dados.");
            }

            characterPerID.Name = character.Name;
            characterPerID.HasPower = character.HasPower;

            _dbContext.Characters.Update(characterPerID);
            await _dbContext.SaveChangesAsync();
            return characterPerID;
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            CharacterModel characterPerID = await FindCharacterByID(id);

            if (characterPerID == null)
            {
                throw new Exception($"O personagem com o id {id} não foi encontrado no banco de dados.");
            }
            _dbContext.Remove(characterPerID);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
