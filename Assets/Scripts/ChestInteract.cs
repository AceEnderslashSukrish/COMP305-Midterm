using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    [SerializeField] private float pushForce = 500.0f;

    private bool triggerActive = false;

    private bool instantiateActive = true;

    public GameObject star;

    private Rigidbody2D rBodyStar;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rBodyStar = star.GetComponent<Rigidbody2D>();
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
            int numOfStars = 0;
            Instantiate(star, transform.position, transform.rotation);
            numOfStars++;
            //need to add rigidbody for star prefab and collision detection
            if (numOfStars > 20)
            {
                Destroy(star);
                numOfStars--;
            }
        }
    }
}
