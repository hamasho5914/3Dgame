using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMap : MonoBehaviour
{
    public GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        icon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            icon.gameObject.SetActive(true);
        }
    }
}
