using UnityEngine;

[CreateAssetMenu(menuName ="PlayerData")]
public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
{
    public string playerName;
    public int correctCalculation;
    public int maxResult = 10;
    public int countAttempts = 0;

    public void OnAfterDeserialize()
    {
        RestData();
    }

    public void OnBeforeSerialize(){}

    private void RestData()
    {
        playerName = "No-Name";
        ResetScore();
    }

    public void ResetScore()
    {
        correctCalculation = 0;
        maxResult = 10;
        countAttempts = 0;
    }
}
