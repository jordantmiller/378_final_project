using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLineScript : MonoBehaviour
{
    public TimeController timeController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Start Line Trigger");
        timeController.StartTimer();
    }
}
