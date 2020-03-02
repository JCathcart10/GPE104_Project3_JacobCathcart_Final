using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float detectRange = 1f;
    public float fov = 110;



    // Update is called once per frame
    void Update()
    {
        if (canSee() == true)//checks if the enemy can see the player
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            //changes the position of the enemy to move towards the player. the speed is determined by a float devided by the number of frames in a second
        }
    }

    private bool canSee()//a true/false statement that checks the enemy can detect the player
    {
        float range = Vector2.Distance(transform.position, player.position);// a variable that finds the distance between the position of the enemy and the position of the player

        if (range >= detectRange)//checks if the distance between the 2 objects is greater than the detection range this statement will fire
        {
            return false;//and return a false
        }
        Vector2 vectorToTarget = player.position - transform.position;// finds a vector between the position of the player and the position of the enemy
        if (Vector2.Angle(vectorToTarget, transform.right) >= (fov / 2))//if the angle between the target and the forward facing line is greater than half of the field of veiw then this statement will fire
        {
            return false;//and return a false
        }
        return true;// if the player is within range and in the field of view then it will return true
    }
}
