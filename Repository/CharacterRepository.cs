using Microsoft.EntityFrameworkCore;
using adventure_time_api.Repository.Interfaces;
using adventure_time_api.Models;
using adventure_time_api.Data;

namespace adventure_time_api.Repository
{
    public class CharacterRepository : CharacterLoader
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

        public async Task<CharacterModel> AddCharacter(CharacterModel character)
        {
            await _dbContext.Characters.AddAsync(character);
            await _dbContext.SaveChangesAsync();

            return character;
        }

        public async Task<CharacterModel> UpdateCharacter(CharacterModel character, int id)
        {
            CharacterModel characterByID = await FindCharacterByID(id);

            if (characterByID == null)
            {
                throw new Exception($"Personagem para o ID: {id} não foi encontrado");
            }

            characterByID.Name = character.Name;
            characterByID.Age = character.Age;
            characterByID.HavePowers = character.HavePowers;

            await _dbContext.SaveChangesAsync();

            return characterByID;
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            CharacterModel characterByID = await FindCharacterByID(id);

            if (characterByID == null)
            {
                throw new Exception($"Personagem para o ID: {id} não foi encontrado");
            }

            _dbContext.Characters.Remove(characterByID);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
