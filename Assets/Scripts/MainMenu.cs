using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to start the game (loads the next scene)
    public void PlayGame()
    {
        // Loads the SampleScene (this is the game scene)
        SceneManager.LoadScene("Fry Fields");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");  
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Game is quitting!");
        Application.Quit();
    }

    public void PlayStoryBeginning()
    {
        SceneManager.LoadScene("StoryBeginning");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
