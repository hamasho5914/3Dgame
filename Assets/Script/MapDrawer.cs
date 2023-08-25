using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDrawer : MonoBehaviour
{
    private Texture _texture;

    // Start is called before the first frame update
    void Start()
    {
        var texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();
        _texture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        var rect = new Rect(12, 12, 85, 70);
        GUI.DrawTexture(rect, _texture, ScaleMode.StretchToFill, true, 0);
    }
}
