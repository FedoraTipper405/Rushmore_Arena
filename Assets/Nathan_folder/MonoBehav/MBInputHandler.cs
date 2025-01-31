using UnityEngine;

public class MBInputHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] MBBasePlayerController playerController;
    [SerializeField] MBUpgradeManager upgradeManager;
    void Start()
    {
      
        IAPlayerControls playerControls = new IAPlayerControls();
        //input for movement
        playerControls.PlayerControlMap.Movement.performed += (var) => playerController.HandleMovement(var.ReadValue<Vector2>());
        playerControls.PlayerControlMap.Movement.canceled += (var) => playerController.HandleMovement(var.ReadValue<Vector2>());
        //input for attack
        playerControls.PlayerControlMap.Attack.performed += (var) => playerController.HandleAttack(true);
        playerControls.PlayerControlMap.Attack.canceled += (var) => playerController.HandleAttack(false);
        //input for upgrades
        playerControls.PlayerControlMap.Movement.performed += (var) => upgradeManager.ChangeSelectedUpgrade(var.ReadValue<Vector2>());
        playerControls.PlayerControlMap.Attack.performed += (var) => upgradeManager.ConfirmUpgrade();
        playerControls.Enable();
    }
   
}
