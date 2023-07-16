using adventure_time_api.src.domain.models;

namespace adventure_time_api.src.domain.interfaces
{
    public interface CharacterInterfaceRepository
    {
        Task<List<CharacterModel>> FindCharacters();
        Task<CharacterModel> FindCharacterByID(int id);
        Task<CharacterModel> CreateCharacter(CharacterModel character);
        Task<CharacterModel> UpdateCharacter(CharacterModel character, int id);

        Task<bool> DeleteCharacter(int id);
    }
}
