using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Player;
    public BoxCollider2D Bounds;
    private Vector2 camsize;
    private float width, height;
    
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 0.5f) + transform.position.y;
        Debug.Log(width + " " + height);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            float x = Player.position.x;
            float y = Player.position.y;
            x = Mathf.Clamp(x, Bounds.bounds.min.x + width / 2, Bounds.bounds.max.x - width / 2);
            y = Mathf.Clamp(y, Bounds.bounds.min.y + height / 2, Bounds.bounds.max.y - height / 2);
            transform.position = new Vector3(x, y, transform.position.z);
        }
        
    }
}
