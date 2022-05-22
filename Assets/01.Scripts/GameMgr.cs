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

    [SerializeField] GameObject baseball;

    [SerializeField] GameObject glove;

    bool gamestart = false;

    List<GameObject> gloveList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestart)
            JoystickMove();
    }

    public void GameSetting()
    {
        startUi.SetActive(true);
        gameoverUi.SetActive(true);
        sliderUi.SetActive(false);
        changeupUi.SetActive(false);
        MainObj.SetActive(false);
        Joystick.SetActive(false);
        JoystickRange.SetActive(false);
        gamestart = false;
        baseball.transform.position = Vector3.zero;
    }


    public void StartGame()
    {
        startUi.SetActive(false);
        gameoverUi.SetActive(false);
        MainObj.SetActive(true);
        gamestart = true;
        GloveMaking();
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

    void GloveMaking()
    {
        Instantiate(glove);
    }

}
