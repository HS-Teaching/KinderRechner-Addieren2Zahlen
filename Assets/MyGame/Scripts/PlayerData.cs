using UnityEngine;

[CreateAssetMenu(menuName ="PlayerData")]
public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
{
    public string playerName;
    public int correctCalculation;
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
        countAttempts = 0;
    }
}
