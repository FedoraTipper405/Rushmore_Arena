using UnityEngine;

[CreateAssetMenu(fileName = "SODifficulty", menuName = "Scriptable Objects/SODifficulty")]
public class SODifficulty : ScriptableObject
{
    public int difficultyIndex;
    public int[] wavesForDifficulty;
}
