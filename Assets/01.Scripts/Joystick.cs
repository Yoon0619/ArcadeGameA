using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.Mathematics;

public class Joystick : MonoBehaviour
{
    [SerializeField] GameObject joystickImage;

    [SerializeField] GameObject joystickRangeImage;

    [SerializeField] Text distanceMessage;

    public Vector3 StartingPoint = new Vector3(720, 1480);

    Vector3 MaximumPoint = new Vector3(0, 0);

    Vector3 StopPoint = new Vector3(0, 0);

    public float power = 0;

    float distance = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        Drag();
        if(Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
        
    }

    public void Drag()
    {
        distance = Vector3.Distance(StartingPoint, Input.mousePosition);

        power = Vector3.Distance(Vector3.zero, joystickImage.transform.localPosition);

        joystickImage.transform.position = Input.mousePosition;

        if (distance >= 300)
        {
            StopPoint = joystickImage.transform.position;

            float inclination = (Input.mousePosition.y - StartingPoint.y) / (Input.mousePosition.x - StartingPoint.x);

            float XCoordinate = math.sqrt(90000 / (math.pow(inclination, 2) + 1));

            float YCoordinate = math.sqrt(90000 - math.pow(math.sqrt(90000 / (math.pow(inclination, 2) + 1)), 2));

            if (inclination >= 0)
            {
                if ((Input.mousePosition.x - StartingPoint.x) >= 0)
                {
                    joystickImage.transform.position = new Vector3(StartingPoint.x + XCoordinate, StartingPoint.y + YCoordinate);

                }
                else
                {
                    joystickImage.transform.position = new Vector3(StartingPoint.x - XCoordinate, StartingPoint.y - YCoordinate);

                }
            }
            else
            {
                if ((Input.mousePosition.x - StartingPoint.x) >= 0)
                {
                    joystickImage.transform.position = new Vector3(StartingPoint.x + XCoordinate, StartingPoint.y - YCoordinate);
                }
                else
                {
                    joystickImage.transform.position = new Vector3(StartingPoint.x - XCoordinate, StartingPoint.y + YCoordinate);
                }
            }

        }

    }

    

    public void EndDrag()
    {
        joystickImage.SetActive(false);
        joystickRangeImage.SetActive(false);
    }


    private void OnGUI()
    {
        GUIStyle textcolor = new GUIStyle();
        textcolor.normal.textColor = Color.black;
        textcolor.fontSize = 50;
        GUI.Label(new Rect(0, 0, 150, 50), string.Format("{0}, {1}", Input.mousePosition.x, Input.mousePosition.y), textcolor);
        GUI.Label(new Rect(0, 50, 150, 50), string.Format("{0}, {1}", joystickImage.transform.position.x, joystickImage.transform.position.y), textcolor);
        GUI.Label(new Rect(0, 100, 150, 50), string.Format("{0}, {1}", MaximumPoint.x, MaximumPoint.y), textcolor);
    }

}
