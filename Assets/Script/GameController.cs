using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    public PlayerController playerController;
    public Floor floor;

    public Text stateText;
    public Text openDoor;
    public Text operationExplanation;
    public Text restate;
    public Text treasure;
    public Image miniMap;
    public Image fullMap;


    // Start is called before the first frame update
    void Start()
    {
        Ready();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetKeyDown("space")) GameStart();
                break;
            case State.Play:
                if(playerController.DetectionTreasure() == true)
                {
                    if (Input.GetKeyDown("space"))
                    {
                        GameOver();
                    }
                }

                if(playerController.DetectionStairs() == true)
                {
                    if (Input.GetKeyDown("space"))
                    {
                        SceneManager.LoadScene("Floor2FScene");
                    }
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Debug.Log("ReStart");
                    string currentSceneName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(currentSceneName);

                }

                if (Input.GetKeyDown(KeyCode.M))
                {
                    playerController.SetSteerActive(false);
                    FullMapOpen();
                }

                if (Input.GetKeyDown(KeyCode.C))
                {
                    FullMapClose();
                    playerController.SetSteerActive(true);
                }



                break;
            case State.GameOver:
                if (Input.GetKeyDown("space")) Reload();
                break;
        }

        Door();

        if(state != State.GameOver)
        {
            Treasure();
        }
        

    }

    void Ready()
    {
        state = State.Ready;
        playerController.SetSteerActive(false);

        stateText.gameObject.SetActive(true);
        stateText.text = "Press the space key to start.";
        openDoor.gameObject.SetActive(false);
        operationExplanation.gameObject.SetActive(false);
        restate.gameObject.SetActive(false);
        treasure.gameObject.SetActive(false);

        miniMap.gameObject.SetActive(false);
        fullMap.gameObject.SetActive(false);
    }

    void GameStart()
    {
        state = State.Play;

        playerController.SetSteerActive(true);
        stateText.gameObject.SetActive(false);
        stateText.text = "";
        operationExplanation.gameObject.SetActive(true);
        miniMap.gameObject.SetActive(true);

        
    }

    void GameOver()
    {
        state = State.GameOver;
        playerController.SetSteerActive(false);

        operationExplanation.gameObject.SetActive(false);

        openDoor.gameObject.SetActive(false);
        treasure.gameObject.SetActive(false);

        stateText.gameObject.SetActive(true);
        stateText.text = "congratulations!";
        restate.gameObject.SetActive(true);
        FullMapClose();

    }

    void Reload()
    {
        SceneManager.LoadScene("Floor1FScene");
    }

    void Door()
    {
        if (playerController.DetectionDoor() == true)
        {
            openDoor.text = "Space open the door";
            openDoor.gameObject.SetActive(true);
        }
        else
        {
            openDoor.gameObject.SetActive(false);
        }
    }

    void Treasure()
    {
        if (playerController.DetectionTreasure() == true || playerController.DetectionStairs() == true)
        {
            treasure.text = "Press to Space";
            treasure.gameObject.SetActive(true);
        }
        else
        {
            treasure.gameObject.SetActive(false);
        }
    }

    void FullMapOpen()
    {
        fullMap.gameObject.SetActive(true);
    }

    void FullMapClose()
    {
        fullMap.gameObject.SetActive(false);  
    }

    void SceneMove()
    {
        SceneManager.LoadScene("Floor2FScene");
    }
}
