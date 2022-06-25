using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
//using System.Windows.Forms;
//using UnityEngine.Windows.Forms;

public class GameMgr : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [SerializeField] GameObject startUi;

    [SerializeField] GameObject gameoverUi;

    [SerializeField] GameObject joystickUi;

    [SerializeField] GameObject gamesettingUi;

    [SerializeField] GameObject MainObj;

    [SerializeField] GameObject Joystick;

    [SerializeField] GameObject JoystickRange;

    [SerializeField] GameObject baseball;

    //[SerializeField] GameObject glove;

    [SerializeField] GameObject firstGlove;

    [SerializeField] GameObject secondGlove;


    GameObject gloveStoring;

    //bool ownBall = false;

    bool gamestart = false;

    public bool gameover = false;

    bool gloveMade = false;

    bool gloveMoving = false;

    public bool ballFlying = false;

    float yDecrease = 0;

    Vector3 firstGloveDestination = Vector3.zero;
    Vector3 secondGloveDestination = Vector3.zero;



    float newGloveXCoordinate = 0;
    float newGloveYCoordinate = 0;

    //Vector3 ballPosition = Vector3.zero;

    List<GameObject> gloveList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gloveList.Add(firstGlove);

        GameSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestart)
        {
            

            if (baseball.transform.position == firstGlove.transform.position)
            {
                ballFlying = false;
            }
            else
            {
                ballFlying = true;
            }

            if (baseball.transform.position == secondGlove.transform.position)
            {
                GloveMaking();
                ballFlying = false;

            }

            if (ballFlying == false && gloveMoving == false && gameover == false)
            {
                if (Input.GetMouseButton(0))
                {
                    JoystickMove();
                    //Debug.Log("JoystickMove");
                }
            }

            if (gloveMade)
            {
                GloveMoving();
                gloveMoving = true;

                if (firstGlove.transform.position == firstGloveDestination && secondGlove.transform.position == secondGloveDestination)
                {
                    gloveMoving = false;
                    gloveMade = false;
                }
            }

        }
    }

    public void Gameover()
    {
        gameoverUi.SetActive(true);
        gamesettingUi.SetActive(true);
        gameover = true;

        baseball.transform.position = Vector3.zero;
        baseball.SetActive(false);
    }

    public void GameSetting()
    {
        ActivateStartUi(true);

        joystickUi.SetActive(false);

        gamesettingUi.SetActive(true);

        ActivateMainObj(false);

        gamestart = false;
        baseball.transform.position = Vector3.zero;
        ballFlying = false;
    }

    void ActivateStartUi(bool _isActive)
    {
        startUi.SetActive(_isActive);
        gameoverUi.SetActive(!_isActive);
    }

    void ActivateJoyStick(bool _isActive)
    {
        Joystick.SetActive(_isActive);
        JoystickRange.SetActive(_isActive);
    }

    void ActivateMainObj(bool _isActive)
    {
        MainObj.SetActive(_isActive);

        if (_isActive)
        {
            firstGlove.transform.position = new Vector3(0, -1.75f);

            secondGlove.transform.position = new Vector3(1, 3.5f);
        }
    }


    public void OnClick_StartGame()
    {
        startUi.SetActive(false);

        gameoverUi.SetActive(false);

        gamesettingUi.SetActive(false);

        ActivateMainObj(true);

        gamestart = true;
    }

    public void JoystickMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //baseball.GetComponent<Rigidbody2D>().WakeUp();
            joystickUi.SetActive(true);

            //조이스틱 이동
            JoystickRange.transform.position = Input.mousePosition;
            Joystick.transform.localPosition = Vector3.zero;
            Joystick.GetComponent<Joystick>().StartingPoint = Input.mousePosition;
        }
    }



    void GloveMoving()
    {
        yDecrease = -1 - firstGlove.transform.position.y;

        firstGloveDestination = new Vector3(firstGlove.transform.position.x, firstGlove.transform.position.y + yDecrease);
        secondGloveDestination = new Vector3(secondGlove.transform.position.x, secondGlove.transform.position.y + yDecrease);


        firstGlove.transform.position = Vector3.MoveTowards(firstGlove.transform.position, firstGloveDestination, Time.deltaTime * 10);
        secondGlove.transform.position = Vector3.MoveTowards(secondGlove.transform.position, secondGloveDestination, Time.deltaTime * 10);
        baseball.transform.position = firstGlove.transform.position;
    }

    void GloveMaking()
    {
        gloveStoring = firstGlove;
        firstGlove = secondGlove;
        secondGlove = gloveStoring;
        newGloveXCoordinate = Random.Range(firstGlove.transform.position.x - 3.5f, firstGlove.transform.position.x + 3.5f);
        newGloveYCoordinate = Random.Range(firstGlove.transform.position.y + 2, firstGlove.transform.position.y + 6);
        if (newGloveXCoordinate > 1.75f)
            newGloveXCoordinate = 1.75f;
        if (newGloveXCoordinate < -1.75f)
            newGloveXCoordinate = -1.75f;

        secondGlove.transform.position = new Vector3(newGloveXCoordinate, newGloveYCoordinate);
        gloveMade = true;

        
    }


    public void OnClick_GameContinue()
    {
        //야구공 위치 초기화
        baseball.transform.position = firstGlove.transform.position;

        //UI정리
        gameoverUi.SetActive(false);
        gamesettingUi.SetActive(false);

        //변수 초기화
        gameover = false;
        ballFlying = false;

        //야구공 활성화
        baseball.SetActive(true);
    }

    public void OnClick_GameRestart()
    {
        Debug.Log("GameRestart");
        /* baseball이 중앙으로 이동
         * baseball의 힘 모두 제거
         * 글러브들이 제자리로 이동
         * 
         */
        Rigidbody2D bbrgd2D = baseball.GetComponent<Rigidbody2D>();

        //ActivateMainObj(true);

        //글러브 위치 초기화
        firstGlove.transform.position = new Vector3(0, -1.75f);
        secondGlove.transform.position = new Vector3(1, 3.5f);

        //UI정리
        gameoverUi.SetActive(false);
        gamesettingUi.SetActive(false);

        //야구공 힘 제거
        //bbrgd2D.velocity = Vector3.zero;
        bbrgd2D.angularVelocity = 0;
        //bbrgd2D.AddForce(Vector3.zero);

        //변수 초기화
        ballFlying = false;
        gameover = false;

        //야구공 중력 재적용
        //bbrgd2D.gravityScale = 1;

        //야구공 위치 초기화
        baseball.transform.position = Vector3.zero;

        //야구공 활성화
        baseball.SetActive(true);

    }

    private void OnGUI()
    {
        GUIStyle textcolor = new GUIStyle();
        textcolor.normal.textColor = Color.black;
        textcolor.fontSize = 50;
        GUI.Label(new Rect(0, 0, 150, 50), string.Format("{0}", ballFlying), textcolor);
    }
}
