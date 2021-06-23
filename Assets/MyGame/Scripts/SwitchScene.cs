using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private InputField playerName;
    [SerializeField] private PlayerData playerData;
    private Scene scene;
    private int sceneIndex; 

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
    }

    public void LoadScene()
    {
        if (sceneIndex == 2) //2 is EndScene, switch to welcome scene and reset score of player
        {
            playerData.ResetScore();
            SceneManager.LoadScene(0);
            return;
        }

        if (sceneIndex == 1 && playerData.countAttempts < 10) //1 is MainScene, every attempt is load main scene. After 10 attempts, switch to end scene
        {
            SceneManager.LoadScene(1);
            return;
        }

        if (sceneIndex == 0) //0 is WelcomeScene, save player name in scriptable object, then switch to main scene.
        {
            playerData.playerName = playerName.text;
        }

        sceneIndex++;
        SceneManager.LoadScene(sceneIndex);
    }
}
