using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class MainSceneController : MonoBehaviour
{
    private enum AdditionTerms {SummandA, SummandB, Sum};
    private enum AdditionCase {SummandAUnknown, SummandBUnknown, SumUnknown, SummandASummandBUnknown};
    private int maxAdditionCases = System.Enum.GetValues(typeof(AdditionCase)).Length;

    //UI Elements Drag & Drop in UnityEditor onto MainSceneController
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Text labelPlayerName;
    [SerializeField] private Text textTermA, textTermB, textTermResult;
    [SerializeField] private InputField inputFieldTermA, inputFieldTermB, inputFieldTermResult;
    [SerializeField] private Image bgimg;
    [SerializeField] private Text labelCorrectionTermA, labelCorrectionTermB, labelCorrectionSum;
    [SerializeField] private SpriteRenderer[] progress;
    [SerializeField] private Button checkCalc, nextCalc;
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip clipCalcError, clipCalcOk;


    //Private variables needed in this script
    private GameObject[] dynamicUIElements; // contains for 3 positions (A, B, Sum) either input field or text depending on AdditionCase
    private int[] termValues; // contains integer values of the 3 terms
    private AdditionCase randomCase; // randomly chosen case (which fields need to be filled in?)
    private const int MaxSum = 10; // computations do not exceed this value
    private const string FormatValues = "0.##";
    private Color32 correctAnswerColor = new Color32(112, 196, 48, 255);
    private Color32 wrongAnswerColor = new Color32(238, 0, 65, 255);

    SwitchScene switchScene;

    // Start is called before the first frame update
    void Start()
    {
        switchScene = GameObject.FindObjectOfType<SwitchScene>();

        //Set/Get ScriptableObject Data
        playerData.countAttempts++;
        SetProgressSprite(playerData.countAttempts); //Progress will be only be set here, because every attempt is a new loaded scene
        labelPlayerName.text = playerData.playerName;

        nextCalc.gameObject.SetActive(false);

        dynamicUIElements = new GameObject[3];
        
        SetAddition();
    }

    private void SetProgressSprite(int attempt)
    {
        SetAllProgessSpritesInactive();

        switch (attempt)
        {
            case 1: progress[0].gameObject.SetActive(true);
                break;
            case 2:
                progress[1].gameObject.SetActive(true);
                break;
            case 3:
                progress[2].gameObject.SetActive(true);
                break;
            case 4:
                progress[3].gameObject.SetActive(true);
                break;
            case 5:
                progress[4].gameObject.SetActive(true);
                break;
            case 6:
                progress[5].gameObject.SetActive(true);
                break;
            case 7:
                progress[6].gameObject.SetActive(true);
                break;
            case 8:
                progress[7].gameObject.SetActive(true);
                break;
            case 9:
                progress[8].gameObject.SetActive(true);
                break;
            case 10:
                progress[9].gameObject.SetActive(true);
                break;
        }
    } 

    private void SetAllProgessSpritesInactive()
    {
        foreach (SpriteRenderer elem in progress)
        {
            elem.gameObject.SetActive(false);
        }
    }

    private void SetAddition()
    {
        randomCase = GetRandomAdditionCase();
        // for debugging, use to fix case
        // randomCase = AdditionCase.SummandAUnknown;
        SetupAdditionUI(randomCase);
        SetGeneratedAdditionValues(randomCase);
        SetCorrectionLabelsActive(false);
    }

    private AdditionCase GetRandomAdditionCase()
    {
        return (AdditionCase)UnityEngine.Random.Range(0, maxAdditionCases);
    }

    private void SetupAdditionUI(AdditionCase curCase)
    {
        SetDynamicUIElementsInactive(); //Text and InputFields are invisible/inactive

        switch (curCase)
        {
            case AdditionCase.SummandAUnknown:
                AddAdditionUIElement(AdditionTerms.SummandA, inputFieldTermA.gameObject);
                AddAdditionUIElement(AdditionTerms.SummandB, textTermB.gameObject);
                AddAdditionUIElement(AdditionTerms.Sum, textTermResult.gameObject);
                break;
            case AdditionCase.SummandBUnknown:
                AddAdditionUIElement(AdditionTerms.SummandA, textTermA.gameObject);
                AddAdditionUIElement(AdditionTerms.SummandB, inputFieldTermB.gameObject);
                AddAdditionUIElement(AdditionTerms.Sum, textTermResult.gameObject);
                break;
            case AdditionCase.SumUnknown:
                AddAdditionUIElement(AdditionTerms.SummandA, textTermA.gameObject);
                AddAdditionUIElement(AdditionTerms.SummandB, textTermB.gameObject);
                AddAdditionUIElement(AdditionTerms.Sum, inputFieldTermResult.gameObject);
                break;
            case AdditionCase.SummandASummandBUnknown:
                AddAdditionUIElement(AdditionTerms.SummandA, inputFieldTermA.gameObject);
                AddAdditionUIElement(AdditionTerms.SummandB, inputFieldTermB.gameObject);
                AddAdditionUIElement(AdditionTerms.Sum, textTermResult.gameObject);
                break;
        }

        //Activate all elements added to dynamicUIElements
        foreach (GameObject elem in dynamicUIElements)
        {
            elem.SetActive(true);
        }
    }

    private void AddAdditionUIElement(AdditionTerms term, GameObject uiElement)
    {
        dynamicUIElements[(int)term] = uiElement;
    }

    private void SetGeneratedAdditionValues(AdditionCase randCase)
    {
        termValues = GenerateThreeAdditionTerms(MaxSum);

        switch (randCase)
        {
            case AdditionCase.SummandAUnknown:
                textTermB.text = termValues[(int)AdditionTerms.SummandB].ToString("0.##");
                textTermResult.text = termValues[(int)AdditionTerms.Sum].ToString("0.##");
                break;
            case AdditionCase.SummandBUnknown:
                textTermA.text = termValues[(int)AdditionTerms.SummandA].ToString("0.##");
                textTermResult.text = termValues[(int)AdditionTerms.Sum].ToString("0.##");
                break;
            case AdditionCase.SumUnknown:
                textTermA.text = termValues[(int)AdditionTerms.SummandA].ToString(FormatValues);
                textTermB.text = termValues[(int)AdditionTerms.SummandB].ToString("0.##");
                break;
            case AdditionCase.SummandASummandBUnknown:
                textTermResult.text = termValues[(int)AdditionTerms.Sum].ToString("0.##");
                break;
        }
    }

     private void SetCorrectionLabelsActive(bool isActive)
    {
        if (isActive)
        {
            labelCorrectionTermA.GetComponent<Text>().text = termValues[(int)AdditionTerms.SummandA].ToString(FormatValues);
            labelCorrectionTermB.GetComponent<Text>().text = termValues[(int)AdditionTerms.SummandB].ToString(FormatValues);
            labelCorrectionSum.GetComponent<Text>().text = termValues[(int)AdditionTerms.Sum].ToString(FormatValues);
        }

        labelCorrectionTermA.gameObject.SetActive(isActive);
        labelCorrectionTermB.gameObject.SetActive(isActive);
        labelCorrectionSum.gameObject.SetActive(isActive);
    }

    private void SetDynamicUIElementsInactive()
    {
        textTermA.gameObject.SetActive(false);
        textTermB.gameObject.SetActive(false);
        textTermResult.gameObject.SetActive(false);

        inputFieldTermA.gameObject.SetActive(false);
        inputFieldTermB.gameObject.SetActive(false);
        inputFieldTermResult.gameObject.SetActive(false);
    }

    private void EnalbeAllInputFieldsInteraction(bool enableInteraction, bool answerCorrect)
    {
        inputFieldTermA.enabled = enableInteraction;
        inputFieldTermB.enabled = enableInteraction;
        inputFieldTermResult.enabled = enableInteraction;

        if (answerCorrect)
        {
            inputFieldTermA.image.color = correctAnswerColor;
            inputFieldTermB.image.color = correctAnswerColor;
            inputFieldTermResult.image.color = correctAnswerColor;

            Color32 corrColortxtInputField = Color.white;
            inputFieldTermA.textComponent.color = corrColortxtInputField;
            inputFieldTermB.textComponent.color = corrColortxtInputField;
            inputFieldTermResult.textComponent.color = corrColortxtInputField;

        }
        else
        {
            inputFieldTermA.image.color = wrongAnswerColor;
            inputFieldTermB.image.color = wrongAnswerColor;
            inputFieldTermResult.image.color = wrongAnswerColor;

            Color32 incorrColortxtInputField = new Color32(177,0,48,255);
            inputFieldTermA.textComponent.color = incorrColortxtInputField;
            inputFieldTermB.textComponent.color = incorrColortxtInputField;
            inputFieldTermResult.textComponent.color = incorrColortxtInputField;
        }

        

    }

    private int[] GenerateThreeAdditionTerms(int maxSum)
    {
        int[] terms = new int[3];
        terms[(int)AdditionTerms.Sum] = UnityEngine.Random.Range(0,maxSum);
        terms[(int)AdditionTerms.SummandA] = UnityEngine.Random.Range(0, terms[(int)AdditionTerms.Sum]);
        terms[(int)AdditionTerms.SummandB] = terms[(int)AdditionTerms.Sum] - terms[(int)AdditionTerms.SummandA];

        return terms;
    }

    public void CheckAdditionAndLoadScene()
    {
        if (IsAdditionCorrect())
        {
            playerData.correctCalculation++;
        }

        switchScene.LoadScene();
    }

    public void CheckAddition()
    {
        //EnalbeAllInputFieldsInteraction(false, ); //Inputfields are still visible, but interaction is disabled
        nextCalc.gameObject.SetActive(true);
        checkCalc.gameObject.SetActive(false);

        if (IsAdditionCorrect())
        {
            audioSrc.PlayOneShot(clipCalcOk);
            EnalbeAllInputFieldsInteraction(false, true); //Inputfields are still visible, but interaction is disabled
            bgimg.color = correctAnswerColor;
            
        }
        else
        {
            audioSrc.PlayOneShot(clipCalcError);
            EnalbeAllInputFieldsInteraction(false, false); //Inputfields are still visible, but interaction is disabled
            bgimg.color = wrongAnswerColor;
            SetCorrectionLabelsActive(true);
        }
    }

    public bool IsAdditionCorrect()
    {
        int summandA = -1, summandB = -1, sum = -1;

        switch (randomCase)
        {
            case AdditionCase.SummandAUnknown:
                 summandA = ParseTerm(AdditionTerms.SummandA);
                 summandB = termValues[(int)AdditionTerms.SummandB];
                 sum = termValues[(int)AdditionTerms.Sum];
                 break;
            case AdditionCase.SummandBUnknown:
                summandA = termValues[(int)AdditionTerms.SummandA];
                summandB = ParseTerm(AdditionTerms.SummandB);
                sum = termValues[(int)AdditionTerms.Sum];
                break;
            case AdditionCase.SumUnknown:
                summandA = termValues[(int)AdditionTerms.SummandA];
                summandB = termValues[(int)AdditionTerms.SummandB];
                sum = ParseTerm(AdditionTerms.Sum);
                break;
            case AdditionCase.SummandASummandBUnknown:
                summandA = ParseTerm(AdditionTerms.SummandA);
                summandB = ParseTerm(AdditionTerms.SummandB);
                sum = termValues[(int)AdditionTerms.Sum];
                break;
        }

        return (summandA + summandB) == sum ? true : false;
    }

    private int ParseTerm(AdditionTerms term)
    {
        try
        {
            string termVal = dynamicUIElements[(int)term].GetComponent<InputField>().text;
            return int.Parse(termVal);
        }
        catch (System.Exception)
        {
            return -1;
        }
    }
}
