using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestEvent : MonoBehaviour
{
    public Text TestEventMessage;

    // Start is called before the first frame update
    void Start()
    {
        TestEventMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TestEventMessage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TestEventMessage.gameObject.SetActive(false);
        }
    }
}
