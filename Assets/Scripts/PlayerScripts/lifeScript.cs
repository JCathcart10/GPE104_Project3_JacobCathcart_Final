using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class lifeScript : MonoBehaviour
{
    public int lives = 3;
    public Text life;


    public void UpdateLives()
    {
        life.text = lives.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateLives();

    }

   
}
