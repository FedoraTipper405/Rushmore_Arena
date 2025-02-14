using UnityEngine;

[CreateAssetMenu(fileName = "SOFixedDifficulty", menuName = "Scriptable Objects/SOFixedDifficulty")]
public class SOFixedDifficulty : ScriptableObject
{
    public int difficultyIndex;
    public int[] wavesForDifficulty;
}
