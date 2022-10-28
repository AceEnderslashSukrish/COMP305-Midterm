using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    private bool triggerActive = false;

    private bool instantiate = true;

    public GameObject star;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isPressed", true);
            while (instantiate)
            {
                Instantiate(star, transform.position, transform.rotation);
                //need to add rigidbody for star prefab and collision detection
            }
        }
    }
}
