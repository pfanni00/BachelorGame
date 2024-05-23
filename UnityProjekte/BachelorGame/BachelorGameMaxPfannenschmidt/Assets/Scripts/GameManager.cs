using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
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

    public void StartEnding1()
    {
        Debug.Log("Ende1 Wird Gestarted");
    }

    public void StartEnding2()
    {
        Debug.Log("Ende2 Wird Gestarted");
    }
}
