using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [SerializeField] GameObject startUi;

    [SerializeField] GameObject gameoverUi;

    [SerializeField] GameObject sliderUi;

    [SerializeField] GameObject changeupUi;

    [SerializeField] GameObject MainObj;

    [SerializeField] GameObject Joystick;

    [SerializeField] GameObject JoystickRange;

    bool gamestart = false;

    // Start is called before the first frame update
    void Start()
    {
        sliderUi.SetActive(false);
        changeupUi.SetActive(false);
        MainObj.SetActive(false);
        Joystick.SetActive(false);
        JoystickRange.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (gamestart)
            JoystickMove();
    }

    public void StartGame()
    {
        startUi.SetActive(false);
        gameoverUi.SetActive(false);
        MainObj.SetActive(true);
        gamestart = true;
    }

    public void JoystickMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Joystick.SetActive(true);
            JoystickRange.SetActive(true);
            JoystickRange.transform.position = Input.mousePosition;
            Joystick.transform.localPosition = Vector3.zero;
            Joystick.GetComponent<Joystick>().StartingPoint = Input.mousePosition;
        }
    }

}
