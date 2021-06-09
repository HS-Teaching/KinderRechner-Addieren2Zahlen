using UnityEngine;

[CreateAssetMenu(menuName ="PlayerData")]
public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
{
    public string playerName;
    public int correctCalculation;
    public int maxResult = 10;

    public void OnAfterDeserialize()
    {
        playerName = "empty";
        correctCalculation = 0;
        maxResult = 10;
}

    public void OnBeforeSerialize(){}
}
