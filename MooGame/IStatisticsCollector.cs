namespace MooGame;

public interface IStatisticsCollector
{
    void SavePlayerData(string name, int nGuess);
    List<PlayerData> LoadPlayerData();
    void ShowTopList(List<PlayerData> results);
}
