using UnityEngine;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    //praise text depending on corret answers;
    private const string NothingCorrect = "Das nächste Mal geht es besser :)";
    private const string SomeCorret = "Das ist ein Anfang :)";
    private const string MostCorret = "Rechnen ist deine Stärke :)";
    private const string AllCorrect = "Dich kann nichts mehr aufhalten :)";

    [SerializeField] private Text txtPlayerName;
    [SerializeField] private Text txtCorrectCalculations;
    [SerializeField] private Text txtPraise;
    [SerializeField] private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        txtPlayerName.text = playerData.playerName;
        txtCorrectCalculations.text = playerData.correctCalculation.ToString();   

        if (playerData.correctCalculation == 0)
        {
            txtPraise.text = NothingCorrect;
        } else if (playerData.correctCalculation > 0 && playerData.correctCalculation < 6)
        {
            txtPraise.text = SomeCorret;
        } else if (playerData.correctCalculation > 6 && playerData.correctCalculation < 10)
        {
            txtPraise.text = MostCorret;
        }
        else if (playerData.correctCalculation == 10)
        {
            txtPraise.text = AllCorrect;
        }
    }

}
