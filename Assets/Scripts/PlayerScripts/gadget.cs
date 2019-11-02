using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gadget : MonoBehaviour
{
    public float rayRange = 10f;
    public float gadgetAimAngle = 5f;
    Transform target;
    Rigidbody2D rb;
    bool isFacing;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rayHit();
        }
    }
    private void rayHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.up);
        if (hit.collider.gameObject.tag == "Distract")
        {
            Debug.Log("the ray hit home");
        }
        else
        {
            Debug.Log("the ray did not hit home");
        }
        
    }
    
}
