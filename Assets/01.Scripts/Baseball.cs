using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baseball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] GameObject joystick;

    [SerializeField] GameMgr gameMgr;

    [SerializeField] SpriteRenderer baseballImage;

    Vector3 throwingPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.activeSelf == true)
        {
            //Throwing();
        }
        
    }

    void Throwing()
    {
        throwingPoint.x = joystick.transform.localPosition.x * (-1);
        throwingPoint.y = joystick.transform.localPosition.y * (-1);

        float throwingPower = joystick.GetComponent<Joystick>().power;

        if (Input.GetMouseButtonUp(0))
        {
            rigidbody.AddForce(throwingPoint * throwingPower * Time.deltaTime);
            Debug.Log("AddForce");
        }
    }

    public void baseballImageChanging()
    {
        if (baseballImage.color == Color.white)
        {
            baseballImage.color = Color.red;
        }
        else if (baseballImage.color == Color.red)
        {
            baseballImage.color = Color.black;
        }
        else if (baseballImage.color == Color.black)
        {
            baseballImage.color = Color.white;
        }
    }

}
