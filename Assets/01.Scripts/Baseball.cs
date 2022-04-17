using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] float power;

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
        //키보드 입력 받아오기
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody.AddForce(Vector2.up * power * Time.deltaTime);
        }
    }



}
