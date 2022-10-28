using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    [SerializeField] private float waitTime = 2f;

    public GameObject star;

    private bool triggerActive = false;
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
            StartCoroutine(StarSpawn());
            //need to add rigidbody for star prefab and collision detection
        }
    }

    IEnumerator StarSpawn()
    {
        while (true)
        {
            Instantiate(star, transform.position, transform.rotation);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
