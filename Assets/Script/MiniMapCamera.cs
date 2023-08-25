using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public GameObject target;

    private Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {
        diff = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + diff;
    }
}
