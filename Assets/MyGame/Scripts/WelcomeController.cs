using UnityEngine;
using UnityEngine.UI;

public class WelcomeController : MonoBehaviour
{
    [SerializeField] private InputField ifieldPlayerName;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SwitchScene switchScene;
    
    private AudioSource audioPressBtn;

    // Start is called before the first frame update
    void Start()
    {
        ifieldPlayerName.text = playerData.playerName;
    }

    public void LoadNextScene()
    {
        switchScene.LoadScene();
    }
}
