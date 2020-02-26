using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform tf;

    //keep track of target location
    public Transform target;

    //stores current state as string
    public string AIState;

    //Current HP
    public float health;

    //Max HP
    public float maxHealth = 10.0f;

    //how far enemy can see
    public float attackRange = 5.0f;
    
    //the point at which enemy stops chasing to heal
    public float HPCutoff;

    //enemy speed
    public float Speed = 5.0f;

    //how fast it heals
    public float restHealRate = 1.0f;
    void Start()
    {
        AIState = "Idle";

        tf = gameObject.GetComponent < Transform >();
    }

    // Update is called once per frame
    void Update()
    {
        if (AIState == "Idle")
        {
            Idle();

            //check for transitions

        }
        else if (AIState == "Rest")
        {
            Rest();

            //check for transitions
        }
        else if (AIState == "Seek")
        {
            Seek();

            //check for transitions
        }
        else
        {
            Debug.LogError("Error: State Does Not Exist: " + AIState);
        }
    }

    public void Idle()
    {
        //do nothing

        if (IsInRange)
        {
            ChangeState("Seek");
        }
    }

    public void Rest()
    {
        //stand still
        //heal
        health += restHealRate * Time.deltaTime;

        health = Mathf.Min(health, maxHealth);

        if(health == maxHealth)
        {
            ChangeState("Idle");
        }
    }

    public void Seek()
    {
        //move towards player
        Vector3 vectorToTarget = target.position - tf.position;

        tf.position += vectorToTarget.normalized * Speed * Time.deltaTime;

        if (health <= HPCutoff)
        {
            ChangeState("Rest");
        }
    }

    public void ChangeState(string newString)
    {
        AIState = newString;
    }

    public bool IsInRange()
    {
        return (Vector3.Distance(tf.position, target.position) <= attackRange);
    }
}
