using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Text labelPlayerName;
    [SerializeField] private Text fixTermA, fixTermB, fixSum;
    [SerializeField] private InputField inputTermA, inputTermB, inputSum;

    private GameObject[] additionUIElements;
    private GameObject[] fixAdditionElements;
    private GameObject[] inputAdditionElements;
    private int[] values;

    // Start is called before the first frame update
    void Start()
    {
        labelPlayerName.text = playerData.playerName;
       
        //maxResult = playerData.maxResult;

        fixAdditionElements = new GameObject[] { fixTermA.gameObject, fixTermB.gameObject, fixSum.gameObject };
        inputAdditionElements = new GameObject[] { inputTermA.gameObject, inputTermB.gameObject, inputSum.gameObject };

        SetupAdditionTask(fixAdditionElements, inputAdditionElements);
 
        
    }

    private void SetupAdditionTask(GameObject[] fixElements, GameObject[] inputElements)
    {
        bool[] additionInputMarker = new bool[3];
        for (int i = 0; i < additionInputMarker.Length; i++)
        {
            additionInputMarker[i] = UnityEngine.Random.value > 0.5f;
        }

        additionUIElements = GetActiveAdditionUIElements(additionInputMarker, fixElements, inputElements);
        values = GetValues(additionInputMarker);


        foreach(int elem in values)
        {
            Debug.Log(elem);
        }
        
        
        for(int i = 0; i < additionUIElements.Length; i++)
        {
            if(additionUIElements[i].GetComponent<Text>() != null)
            {
                additionUIElements[i].GetComponent<Text>().text = values[i].ToString();
            }
        }
    }

    private int[] GetValues(bool[] inputMarker)
    {
        int[] tmpVals = new int[inputMarker.Length];

        for (int i = 0; i < inputMarker.Length; i++)
        {
            tmpVals[i] = inputMarker[i] ? -1 : (int)UnityEngine.Random.Range(0,playerData.maxResult);
        }

        return tmpVals; 
    }



    public void CheckResult()
    {
        int count = 0;
        bool correct = false;

        for (int i = 0; i<values.Length-1; i++)
        {
            count += values[i] == -1 ? int.Parse(additionUIElements[i].gameObject.GetComponent<InputField>().text) : values[i];
        }

        correct = (values[values.Length - 1] != -1) ? (count == values[values.Length - 1]) : (count == int.Parse(additionUIElements[values.Length - 1].gameObject.GetComponent<InputField>().text));

        Debug.Log("Berechnugn korrekt: " + correct);

        SetupAdditionTask(fixAdditionElements, inputAdditionElements);

    }

    private GameObject[] GetActiveAdditionUIElements(bool[] inputMarker, GameObject[] fixElements, GameObject[] inputElements)
    {
        GameObject[] mixedAdditionElements = new GameObject[3];

        SetAdditionsUIElementsInactive(fixElements, inputElements);

        if (IsEqualLength(inputMarker, fixElements, inputElements, mixedAdditionElements))
        {
            for (int i = 0; i < mixedAdditionElements.Length; i++)
            {
                mixedAdditionElements[i] = inputMarker[i] ? inputElements[i].gameObject : fixElements[i].gameObject;
            }
        }

        foreach (GameObject elem in mixedAdditionElements)
        {
            elem.SetActive(true);
        }

        return mixedAdditionElements;
    }

    private bool IsEqualLength(bool[] inputMarker, GameObject[] fixElements, GameObject[] inputElements, GameObject[] mixedAdditionElements)
    {
        return (fixElements.Length == inputElements.Length) &&
                     (inputElements.Length == mixedAdditionElements.Length) &&
                     (mixedAdditionElements.Length == inputMarker.Length);
    }

    private void SetAdditionsUIElementsInactive(GameObject[] fixElements, GameObject[] inputElements)
    {
        foreach (GameObject elem in fixElements)
        {
            elem.SetActive(false);
        }

        foreach (GameObject elem in inputElements)
        {
            elem.SetActive(false);
        }
    }
}
