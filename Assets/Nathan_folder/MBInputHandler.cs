using UnityEngine;

public class MBInputHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] MBBasePlayerController playerController;
    void Start()
    {
      
        IAPlayerControls playerControls = new IAPlayerControls();
        playerControls.PlayerControlMap.Movement.performed += (var) => playerController.HandleMovement(var.ReadValue<Vector2>());
        playerControls.PlayerControlMap.Movement.canceled += (var) => playerController.HandleMovement(var.ReadValue<Vector2>());
        playerControls.PlayerControlMap.Attack.performed += (var) => playerController.HandleAttack();
        playerControls.Enable();
    }
}
