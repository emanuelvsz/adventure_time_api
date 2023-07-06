using adventure_time_api.Models;

namespace adventure_time_api.Repository.Interfaces
{
    public interface CharacterLoader
    {
        Task<List<CharacterModel>> FindCharacters();
        Task<CharacterModel> FindCharacterByID(int id);
        Task<CharacterModel> AddCharacter(CharacterModel character);
        Task<CharacterModel> UpdateCharacter(CharacterModel character, int id);
        Task<bool> DeleteCharacter(int id);
    }
}