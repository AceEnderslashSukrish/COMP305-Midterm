using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private float pushForce = 500.0f;

    public GameObject star;

    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.AddForce(new Vector2(Random.Range(-100, 100), pushForce));
        Destroy(this.gameObject, 5);
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return rBody;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
