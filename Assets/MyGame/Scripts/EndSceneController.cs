using UnityEngine;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    //praise text depending on corret answers;
    private const string NothingCorrect = "Nächstes Mal geht es besser :)";
    private const string SomeCorret = "Es ist ein Anfang :)";
    private const string MostCorret = "Rechnen ist deine Stärke :)";
    private const string AllCorrect = "Dich kann nichts mehr aufhalten :)";

    [SerializeField] private Text txtPlayerName;
    [SerializeField] private Text txtCorrectCalculations;
    [SerializeField] private Text txtPraise;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SpriteRenderer[] success;

    // Start is called before the first frame update
    void Start()
    {
        txtPlayerName.text = playerData.playerName;
        txtCorrectCalculations.text = playerData.correctCalculation.ToString();
        SetSuccessSprite(playerData.correctCalculation);

        //Depending on the success, the correct answers given, a motivational message will be displayed.
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

    private void SetSuccessSprite(int nbrCorrAnswers)
    {
        SetAllSuccessSpritesInactive();

        switch (nbrCorrAnswers)
        {
            case 0:
                success[0].gameObject.SetActive(true);
                break;
            case 1:
                success[1].gameObject.SetActive(true);
                break;
            case 2:
                success[2].gameObject.SetActive(true);
                break;
            case 3:
                success[3].gameObject.SetActive(true);
                break;
            case 4:
                success[4].gameObject.SetActive(true);
                break;
            case 5:
                success[5].gameObject.SetActive(true);
                break;
            case 6:
                success[6].gameObject.SetActive(true);
                break;
            case 7:
                success[7].gameObject.SetActive(true);
                break;
            case 8:
                success[8].gameObject.SetActive(true);
                break;
            case 9:
                success[9].gameObject.SetActive(true);
                break;
            case 10:
                success[10].gameObject.SetActive(true);
                break;
        }
    }
         

private void SetAllSuccessSpritesInactive()
    {
    foreach (SpriteRenderer elem in success)
    {
        elem.gameObject.SetActive(false);
    }
}
}
