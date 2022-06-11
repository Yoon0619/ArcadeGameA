using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxcollider;

    public bool ballCatch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Baseball")
        {
            Rigidbody2D collisionRigidbody;
            collisionRigidbody = collision.GetComponent<Rigidbody2D>();

            //collision.GetComponent<Baseball>().baseballImageChanging();
            collisionRigidbody.gravityScale = 0;

            collision.gameObject.transform.position = this.transform.position;

            collisionRigidbody.velocity = Vector3.zero;
            collisionRigidbody.angularVelocity = 0;

            ballCatch = true;
        }
    }

}
