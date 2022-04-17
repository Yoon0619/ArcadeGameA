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

    // Start is called before the first frame update
    void Start()
    {
        sliderUi.SetActive(false);
        changeupUi.SetActive(false);
        MainObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startUi.SetActive(false);
        gameoverUi.SetActive(false);
        MainObj.SetActive(true);
    }
}
