using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSzenetimer : MonoBehaviour
{

    public float SequenceDuration;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= SequenceDuration)
        {
            GameManager.Instance.LoadMainMenu();
        }

    }
}
