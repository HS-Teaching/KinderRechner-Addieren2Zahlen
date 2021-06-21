using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private const string SceneName = "MainScene";
    public InputField playerName;
    public PlayerData playerData;

    public void LoadMainScene(string maxResult)
    {
        playerData.playerName = playerName.text;
        playerData.maxResult = int.Parse(maxResult);

        SceneManager.LoadScene(SceneName);
    }

}
