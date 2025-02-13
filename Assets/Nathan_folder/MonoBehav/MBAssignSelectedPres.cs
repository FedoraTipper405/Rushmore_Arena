using UnityEngine;

public class MBAssignSelectedPres : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] MBBasePlayerController[] presList = new MBBasePlayerController[4];
    [SerializeField] MBBasePlayerController currentSelectedPres;
    [SerializeField] SOSelectedPres SOSelectedPres;

    [SerializeField] MBWaveManager waveManager;

    void OnEnable()
    {
        currentSelectedPres = presList[SOSelectedPres.selectedPresidentIndex];
        currentSelectedPres.gameObject.SetActive(true);
        waveManager.playerController = currentSelectedPres;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
