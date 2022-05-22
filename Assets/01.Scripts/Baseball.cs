using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] GameObject joystick;

    Vector3 throwingPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Throwing();
    }

    void Throwing()
    {
        throwingPoint.x = joystick.transform.localPosition.x * (-1);
        throwingPoint.y = joystick.transform.localPosition.y * (-1);

        float throwingPower = joystick.GetComponent<Joystick>().power;

        if (Input.GetMouseButtonUp(0))
        {
            rigidbody.AddForce(throwingPoint * throwingPower * Time.deltaTime);
        }
    }



}
