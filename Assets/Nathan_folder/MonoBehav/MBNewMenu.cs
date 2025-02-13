using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MBNewMenu : MonoBehaviour
{
    [SerializeField] Image[] menuButtons = new Image[3];
    [SerializeField] SOSelectedPres selectedPres;
    private int selectedIndex = 0;
    [SerializeField] float buttonIntensity;
    
    //0 is main menu, 1 is char select, 2 is options menu
    [SerializeField] int menuIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void ChangeSelectedButton(Vector2 input)
    {
        if(input.y < 0)
        {
            selectedIndex--;
            if(selectedIndex < 0)
            {
                selectedIndex = menuButtons.Length - 1;
            }
        }
        else if(input.y > 0)
        {
            selectedIndex++;
            if(selectedIndex >= menuButtons.Length)
            {
                selectedIndex = 0;
            }
        }
        for(int i = 0; i < menuButtons.Length; i++)
        {
            if(i == selectedIndex)
            {
                menuButtons[i].color = new Color(buttonIntensity,buttonIntensity,buttonIntensity);
            }
            else
            {
                menuButtons[i].color = new Color(1, 1, 1);
            }
        }
    }
    public void SelectOption()
    {
        //main menu functions
        if(menuIndex == 0)
        {
            if(selectedIndex == 0)
            {
                SceneManager.LoadScene("CharacterMenu");
            }
            else if (selectedIndex == 1)
            {
                SceneManager.LoadScene("OptionsMenu");
            }
            else if (selectedIndex == 2)
            {
                //quit game
            }
        }
        //char select functions
        else if(menuIndex == 1)
        {
            if(selectedIndex == 0)
            {
                //wash
            }
            else if(selectedIndex == 1)
            {
                //abe
            }
            else if(selectedIndex == 2)
            {
                //teddy
            }
            else if(selectedIndex == 3)
            {
                //jeffy
            }
        }

        //options menu functions
        else if(menuIndex == 2)
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
