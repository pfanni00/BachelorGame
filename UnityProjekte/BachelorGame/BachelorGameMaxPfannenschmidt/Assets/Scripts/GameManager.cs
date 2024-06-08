using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
      public bool InteractionEnabled;
    public static GameManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        InteractionEnabled = false;
        Instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialiseEndingChoices()
    {
        EndingAnimation.Instance.StartEndingAnimation();
    }

     public void StartGame()
    {
          SceneManager.LoadScene(1);
    }

    public void StartEnding1()
    {
          SceneManager.LoadScene(2);
    }

    public void StartEnding2()
    {
          SceneManager.LoadScene(3);
    }

    public void LoadMainMenu()
    {
          SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
      Application.Quit();
    }
}
