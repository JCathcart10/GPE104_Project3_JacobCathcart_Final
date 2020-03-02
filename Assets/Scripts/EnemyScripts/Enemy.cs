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

    //field of veiw
    public float fov = 110;
    void Start()
    {
        AIState = "Idle";

        tf = gameObject.GetComponent < Transform >();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        CanHear(GameManager.instance.player);
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

        if (IsInRange() == true)
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

    public bool CanHear(GameObject target)
    {
        //get noisemaker from target
        NoiseMaker noise = target.GetComponent<NoiseMaker>();
        if(noise != null)
        {
            float adjustedVolumeDistance = noise.volumeDistance - Vector3.Distance(tf.position, target.transform.position);
            if (adjustedVolumeDistance > 0)
            {
                Debug.Log("I heard a noise!");
                return true;
            }
        }
        
        return false;
    }

    public bool CanSee(GameObject target)
    {
        Vector3 vectorToTarger = target.transform.position - tf.position;

        float angleToTarger = Vector3.Angle(vectorToTarger, tf.up);

        if(angleToTarger <= (fov / 2))
        {
            return true;
        }

        return false;
    }
}
