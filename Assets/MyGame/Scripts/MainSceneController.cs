using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    enum CalulationUIElement{Text, InputField};
    enum AdditionTerms {SummandA, SummandB, Sum};
    enum AdditionCase {SummandAUnknown, SummandBUnknown, SumUnknown, SummandASummandBUnknown};

    public PlayerData playerData;
    public Text labelPlayerName;
    public Text textTermA, textTermB, textTermResult;
    public InputField inputFieldTermA, inputFieldTermB, inputFieldTermResult;
    public Image bgimg;
    
    private GameObject[] additionUIElements;
    private int[] termValues;
    private AdditionCase randomCase;

    // Start is called before the first frame update
    void Start()
    {
        labelPlayerName.text = playerData.playerName;

        additionUIElements = new GameObject[3];
        SetAddition();
    }

    private void SetAddition()
    {
       
        randomCase = GetRandomAdditionCase();
        //randomCase = AdditionCase.SummandASummandBUnknown;
        SetupUIAddition(randomCase);
        SetKnownAdditionValues(randomCase);
    }

    private void SetKnownAdditionValues(AdditionCase randCase)
    {
        termValues = GenerateThreeTerms(10);

        int i = 0;
        foreach(int x in termValues)
        {
            Debug.Log(i + " " +x);
            i++;
        }

        switch (randCase)
        {
            case AdditionCase.SummandAUnknown:
                textTermA.text = termValues[(int)AdditionTerms.SummandA].ToString("0.##");
                textTermResult.text = termValues[(int)AdditionTerms.Sum].ToString("0.##");
                break;
            case AdditionCase.SummandBUnknown:
                textTermB.text = termValues[(int)AdditionTerms.SummandB].ToString("0.##");
                textTermResult.text = termValues[(int)AdditionTerms.Sum].ToString("0.##");
                break;
            case AdditionCase.SumUnknown:
                textTermA.text = termValues[(int)AdditionTerms.SummandA].ToString("0.##");
                textTermB.text = termValues[(int)AdditionTerms.SummandB].ToString("0.##");
                break;
            case AdditionCase.SummandASummandBUnknown:
                textTermResult.text = termValues[(int)AdditionTerms.Sum].ToString("0.##");
                break;
        }
    }

    private int[] GenerateThreeTerms(int maxSum)
    {
        int[] terms = new int[3];
        terms[(int)AdditionTerms.Sum] = UnityEngine.Random.Range(0,maxSum);
        terms[(int)AdditionTerms.SummandA] = UnityEngine.Random.Range(0, terms[(int)AdditionTerms.Sum]);
        terms[(int)AdditionTerms.SummandB] = terms[(int)AdditionTerms.Sum] - terms[(int)AdditionTerms.SummandA];

        return terms;
    }

    public void CheckAddition()
    {
        if (IsAdditionCorrect())
        {
            bgimg.color = Color.green;
        }
        else
        {
            bgimg.color = Color.red;
        }
    }

    public bool IsAdditionCorrect()
    {
        int summandA = -1, summandB =  -1, sum = -1 ;

        switch (randomCase)
        {
            case AdditionCase.SummandAUnknown:
                 summandA = ParseSummandA();
                 summandB = termValues[(int)AdditionTerms.SummandB];
                 sum = termValues[(int)AdditionTerms.Sum];
                 break;
            case AdditionCase.SummandBUnknown:
                summandA = termValues[(int)AdditionTerms.SummandA];
                summandB = ParseSummandB();
                sum = termValues[(int)AdditionTerms.Sum];
                break;
            case AdditionCase.SumUnknown:
                summandA = termValues[(int)AdditionTerms.SummandA];
                summandB = termValues[(int)AdditionTerms.SummandB];
                sum = ParseSum();
                break;
            case AdditionCase.SummandASummandBUnknown:
                summandA = ParseSummandA();
                summandB = ParseSummandB();
                sum = termValues[(int)AdditionTerms.Sum];
                break;
        }

        return (summandA + summandB) == sum ? true : false;
    }

    private AdditionCase GetRandomAdditionCase()
    {
        return (AdditionCase)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(AdditionCase)).Length);
    }

    private int ParseSummandA()
    {
        try
        {
            string summandA = additionUIElements[(int)AdditionTerms.SummandA].GetComponent<InputField>().text;
            Debug.Log("Summand A parse " + summandA);
            return int.Parse(summandA);
        }
        catch
        {
            Debug.Log("number frmat");
            return -1;
        }
    }

    private int ParseSummandB()
    {
        try
        {
            string summandB = additionUIElements[(int)AdditionTerms.SummandB].GetComponent<InputField>().text;
            Debug.Log("Summand B parse " + summandB);
            return int.Parse(summandB);
        }
        catch
        {
            Debug.Log("number frmat");
            return -1;
        }
    }

    private int ParseSum()
    {
        try
        {
            string sum = additionUIElements[(int)AdditionTerms.Sum].GetComponent<InputField>().text;
            Debug.Log("Summand Sum parse " + sum);
            return int.Parse(sum);
        }
        catch
        {
            Debug.Log("number frmat");
            return -1;
        }
    }

    private void SetAllAdditionUIElementsInactive()
    {
        textTermA.gameObject.SetActive(false);
        textTermB.gameObject.SetActive(false); 
        textTermResult.gameObject.SetActive(false);

        inputFieldTermA.gameObject.SetActive(false); 
        inputFieldTermB.gameObject.SetActive(false);
        inputFieldTermResult.gameObject.SetActive(false);
    }

    private void SetupUIAddition(AdditionCase curCase)
    {
        SetAllAdditionUIElementsInactive();
        Debug.Log(curCase);
        switch (curCase)
        {
            case AdditionCase.SummandAUnknown:
                AddAdditionUIElement(AdditionTerms.SummandA, CalulationUIElement.InputField);
                AddAdditionUIElement(AdditionTerms.SummandB, CalulationUIElement.Text);
                AddAdditionUIElement(AdditionTerms.Sum, CalulationUIElement.Text);
                break;
            case AdditionCase.SummandBUnknown:
                AddAdditionUIElement(AdditionTerms.SummandA, CalulationUIElement.Text);
                AddAdditionUIElement(AdditionTerms.SummandB, CalulationUIElement.InputField);
                AddAdditionUIElement(AdditionTerms.Sum, CalulationUIElement.Text);
                break;
            case AdditionCase.SumUnknown:
                AddAdditionUIElement(AdditionTerms.SummandA, CalulationUIElement.Text);
                AddAdditionUIElement(AdditionTerms.SummandB, CalulationUIElement.Text);
                AddAdditionUIElement(AdditionTerms.Sum, CalulationUIElement.InputField);
                break;
            case AdditionCase.SummandASummandBUnknown:
                AddAdditionUIElement(AdditionTerms.SummandA, CalulationUIElement.InputField);
                AddAdditionUIElement(AdditionTerms.SummandB, CalulationUIElement.InputField);
                AddAdditionUIElement(AdditionTerms.Sum, CalulationUIElement.Text);
                break;
        }

        //Activate elements used in Addition
        foreach(GameObject elem in additionUIElements)
        {
            elem.SetActive(true);
        }

    }

    private void AddAdditionUIElement(AdditionTerms term, CalulationUIElement inputtype)
    {
        switch (term)
        {
            case AdditionTerms.SummandA: AddSummandA(inputtype); break;
            case AdditionTerms.SummandB: AddSummandB(inputtype); break;
            case AdditionTerms.Sum: AddSum(inputtype);  break;
        }
    }

    private void AddSummandB(CalulationUIElement inputtype)
    {
        if (inputtype == CalulationUIElement.InputField)
        {
            additionUIElements[(int)AdditionTerms.SummandB] = inputFieldTermB.gameObject;
            return;
        }
   
        additionUIElements[(int)AdditionTerms.SummandB] = textTermB.gameObject;
    }

    private void AddSummandA(CalulationUIElement inputtype)
    {
        if (inputtype == CalulationUIElement.InputField)
        {
            additionUIElements[(int)AdditionTerms.SummandA] = inputFieldTermA.gameObject;
            return;
        }

        additionUIElements[(int)AdditionTerms.SummandA] = textTermA.gameObject;
    }

    private void AddSum(CalulationUIElement inputtype)
    {
        if (inputtype == CalulationUIElement.InputField)
        {
            additionUIElements[(int)AdditionTerms.Sum] = inputFieldTermResult.gameObject;
            return;
        }

        additionUIElements[(int)AdditionTerms.Sum] = textTermResult.gameObject;
    }
}
