using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    public PlayerData playerData;
    public Text labelPlayerName;
    public Text labelRandomA, labelRandomB, labelRandomResult;
    public InputField inputFieldA, inputFieldB, inputFieldResult;

    private int maxResult;
    private int currentCase;
    private GameObject[] additionElements;

    // Start is called before the first frame update
    void Start()
    {
        labelPlayerName.text = playerData.playerName;
        maxResult = playerData.maxResult;

        SetCase();
        
    }

    private void SetCase()
    {
        currentCase = GetRandomAdditionCase();
        SetCalcUIElements(currentCase);
    }

    public void CheckResult()
    {
        if (additionElements[0].gameObject.GetComponent<Text>() != null)
        {
            Debug.Log(int.Parse(additionElements[0].gameObject.GetComponent<Text>().text));
        }


        SetCase();
    }

    private int GetRandomAdditionCase()
    {
        return UnityEngine.Random.Range(1, 5); ;
    }

    private void SetCalcUIElements(int curCase)
    {
        if(curCase == 1)
        {
            SelectCalculationUIElements(true, false, false);
        }
        else if (curCase == 2)
        {
            SelectCalculationUIElements(false, true, false);
        }
        else if (curCase == 3)
        {
            SelectCalculationUIElements(true, true, false);
        }
        else if (curCase == 4)
        {
            SelectCalculationUIElements(false, false, true);
        }
    }

    private void SelectCalculationUIElements(bool inputA, bool inputB, bool inputResult)
    {
        additionElements = new GameObject[3];

        if (inputA)
        {
            labelRandomA.gameObject.SetActive(false);
            inputFieldA.gameObject.SetActive(true);
            additionElements[0] = inputFieldA.gameObject;
        }
        else
        {
            labelRandomA.gameObject.SetActive(true);
            inputFieldA.gameObject.SetActive(false);
            additionElements[0] = labelRandomA.gameObject;
        }

        if (inputB)
        {
            labelRandomB.gameObject.SetActive(false);
            inputFieldB.gameObject.SetActive(true);
            additionElements[1] = inputFieldB.gameObject;
        }
        else
        {
            labelRandomB.gameObject.SetActive(true);
            inputFieldB.gameObject.SetActive(false);
            additionElements[1] = labelRandomB.gameObject;
        }

        if (inputResult)
        {
            labelRandomResult.gameObject.SetActive(false);
            inputFieldResult.gameObject.SetActive(true);
            additionElements[2] = inputFieldResult.gameObject;
        }
        else
        {
            labelRandomResult.gameObject.SetActive(true);
            inputFieldResult.gameObject.SetActive(false);
            additionElements[2] = inputFieldResult.gameObject;
        }
    }
}
