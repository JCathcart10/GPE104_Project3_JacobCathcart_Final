using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public GameObject player;
    public GameObject hUDCanvus;
    public GameObject gameOverCanvus;
    public GameObject titleBackgroundImage;
    public GameObject titleText;
    public GameObject gameStartButton;
    
      

    void Awake()
    {
        // As long as there is not an instance already set
        if (instance == null)
        {
            instance = this; // Store THIS instance of the class (component) in the instance variable
            DontDestroyOnLoad(gameObject); // Don't delete this object if we load a new scene
        }
        else
        {
            Destroy(this.gameObject); // There can only be one - this new object must die
            Debug.Log("Warning: A second game manager was detected and destroyed.");
        }
    }

    public void StartGame()
    {
        titleBackgroundImage.SetActive(false);
        titleText.SetActive(false);
        gameStartButton.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
   
}
