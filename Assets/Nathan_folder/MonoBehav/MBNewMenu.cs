using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MBNewMenu : MonoBehaviour
{
    [SerializeField] Image[] menuButtons = new Image[0];
    [SerializeField] Sprite[] framesForCharselect = new Sprite[0];
    [SerializeField] Image charSelectState;
    [SerializeField] Image charSelectBackButton;
    [SerializeField] SOSelectedPres selectedPres;
    [SerializeField] SODifficulty soDifficulty;

    [SerializeField] SOVolumeSettings volumeSettings;

    [SerializeField] Slider[] sliders;
    private int selectedIndex = 0;
    [SerializeField] float buttonIntensity;
    [SerializeField] TMP_Text difficultyText;
    private int difficultyValue = 0;
    
    //0 is main menu, 1 is char select, 2 is options menu
    [SerializeField] int menuIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if(menuButtons.Length > 0)
        {
            for (int i = 0; i < menuButtons.Length; i++)
            {
                if (i == selectedIndex)
                {
                    menuButtons[i].color = new Color(buttonIntensity, buttonIntensity, buttonIntensity);
                }
                else
                {
                    menuButtons[i].color = new Color(1, 1, 1);
                }
            }
        }
        if(sliders.Length > 0)
        {
            sliders[0].value = volumeSettings.playerVolume;
            sliders[1].value = volumeSettings.backgroundVolume;
        }
        if(soDifficulty != null)
        {
            difficultyValue = soDifficulty.difficultyIndex;
            if (soDifficulty.difficultyIndex == 0)
            {

                difficultyText.SetText("Difficulty: Easy");
            }
            if (soDifficulty.difficultyIndex == 1)
            {

                difficultyText.SetText("Difficulty: Medium");
            }
            if (soDifficulty.difficultyIndex == 2)
            {

                difficultyText.SetText("Difficulty: Hard");
            }
        }
        
    }
    public void ChangeSelectedButton(Vector2 input)
    {
        if(menuIndex == 0 || menuIndex == 2)
        {
            if (input.y > 0)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = menuButtons.Length - 1;
                }
            }
            else if (input.y < 0)
            {
                selectedIndex++;
                if (selectedIndex >= menuButtons.Length)
                {
                    selectedIndex = 0;
                }
            }
            for (int i = 0; i < menuButtons.Length; i++)
            {
                if (i == selectedIndex)
                {
                    menuButtons[i].color = new Color(buttonIntensity, buttonIntensity, buttonIntensity);
                }
                else
                {
                    menuButtons[i].color = new Color(1, 1, 1);
                }
            }
                if(menuIndex == 2)
                {
                    if(selectedIndex == 0)
                    {
                        if (input.x < 0)
                        {
                            sliders[selectedIndex].value -= 0.1f;
                        }
                        else if (input.x > 0 && sliders[selectedIndex].value < 1)
                        {
                            sliders[selectedIndex].value += 0.1f;
                        }
                        volumeSettings.playerVolume = sliders[selectedIndex].value;
                    }
                    else if(selectedIndex == 1)
                    {
                        if (input.x < 0)
                        {
                            sliders[selectedIndex].value -= 0.1f;
                        }
                        else if (input.x > 0 && sliders[selectedIndex].value < 1)
                        {
                            sliders[selectedIndex].value += 0.1f;
                        }
                        volumeSettings.backgroundVolume = sliders[selectedIndex].value;
                    }
                    else if (selectedIndex == 2)
                    {
                    if (input.x < 0)
                    {
                        difficultyValue--;
                        
                        if (difficultyValue < 0)
                        {
                            difficultyValue = 2;
                        }
                        soDifficulty.difficultyIndex = difficultyValue;
                    }
                    else if (input.x > 0)
                    {
                        difficultyValue++;
                        
                        if (difficultyValue > 2)
                        {
                            difficultyValue = 0;
                        }
                        soDifficulty.difficultyIndex = difficultyValue;
                    }
                    if(difficultyValue == 0)
                    {
                        difficultyText.SetText("Difficulty: Easy");
                    }
                    else if(difficultyValue == 1)
                    {

                        difficultyText.SetText("Difficulty: Medium");
                    }
                    else
                    {

                        difficultyText.SetText("Difficulty: Hard");

                    }
                    
                }
                
            }
        }else if(menuIndex == 1)
        {
            if (input.x < 0)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = framesForCharselect.Length - 1;
                }
            }
            else if (input.x > 0)
            {
                selectedIndex++;
                if (selectedIndex >= framesForCharselect.Length)
                {
                    selectedIndex = 0;
                }
            }
            if(input.y != 0)
            {
                
                if(selectedIndex < 4)
                {
                    selectedIndex = 4;
                    charSelectBackButton.color = new Color(buttonIntensity, buttonIntensity, buttonIntensity);
                }
                else
                {
                    selectedIndex = 0;
                    charSelectBackButton.color = new Color(1, 1, 1);
                }
            }
            if(selectedIndex != 4)
            {
                charSelectState.sprite = framesForCharselect[selectedIndex];
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
                selectedPres.selectedPresidentIndex = 0;
                SceneManager.LoadScene("FinalGameScene");
            }
            else if(selectedIndex == 1)
            {
                selectedPres.selectedPresidentIndex = 1;
                SceneManager.LoadScene("FinalGameScene");
            }
            else if(selectedIndex == 2)
            {
                selectedPres.selectedPresidentIndex = 3;
                SceneManager.LoadScene("FinalGameScene");
            }
            else if(selectedIndex == 3)
            {
                selectedPres.selectedPresidentIndex = 2;
                SceneManager.LoadScene("FinalGameScene");
            }
        }

        //options menu functions
        else if(menuIndex == 2)
        {
            if(selectedIndex == 3)
            {
                SceneManager.LoadScene("RushmoreMainMenu");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
