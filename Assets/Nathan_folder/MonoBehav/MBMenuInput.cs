using UnityEngine;

public class MBMenuInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IAMenuNavigation menuNav;
    [SerializeField] MBNewMenu menu;
    void OnEnable()
    {
        menuNav = new IAMenuNavigation();
        if (menuNav != null)
        {
            //input for nav
            menuNav.PlayerControlMap.Navigate.performed += (var) => menu.ChangeSelectedButton(var.ReadValue<Vector2>());
            menuNav.PlayerControlMap.Navigate.canceled += (var) => menu.ChangeSelectedButton(var.ReadValue<Vector2>());
            //input for select
            menuNav.PlayerControlMap.Select.performed += (var) => menu.SelectOption();
            menuNav.Enable();
        }
    }

    void OnDisable()
    {
      //  if (playerController != null)
      //  {
            
      //      menuNav.Disable();
      //  }

    }
}
