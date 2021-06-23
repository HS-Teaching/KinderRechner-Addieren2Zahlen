using UnityEngine;
using UnityEngine.UI;

public class WelcomeController : MonoBehaviour
{
    [SerializeField] private InputField ifieldPlayerName;
    [SerializeField] private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        ifieldPlayerName.text = playerData.playerName;
    }
}
