using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public BoxCollider2D Bounds;
    private float width, height;

    //day 6 added ----------------------------------------------------------
    public Vector2 Margin;
    public Vector2 Smoothing = new Vector2(1, 1);
    private Vector2 minBounds, maxBounds;
    private bool isFollowing = true;
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        //width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
        //height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 0.5f);
        SetBounds(Bounds);
        height = cam.orthographicSize;
        width = height * ((float)Screen.width / Screen.height);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Player)
    //    {
    //        float x = Player.position.x;
    //        float y = Player.position.y;
    //        x = Mathf.Clamp(x, Bounds.bounds.min.x + width / 2, Bounds.bounds.max.x - width / 2);
    //        y = Mathf.Clamp(y, Bounds.bounds.min.y + height / 2, Bounds.bounds.max.y - height / 2);
    //        transform.position = new Vector3(x, y, transform.position.z);
    //    }
    //}
    private void FixedUpdate()
    {
        if (isFollowing && Player)
        {
            float x = transform.position.x;
            float y = transform.position.y;

            if(Mathf.Abs(x - Player.position.x) > Margin.x)
            {
                x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);
            }
            if (Mathf.Abs(y - Player.position.y) > Margin.y)
            {
                y = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);
            }
            x = Mathf.Clamp(x, minBounds.x + width, maxBounds.x - width);
            y = Mathf.Clamp(y, minBounds.y + height, maxBounds.y - height);

            transform.position = new Vector3(x, y, transform.position.z);
        }

       
    }

    public void SetBounds(BoxCollider2D Bounds)
    {
        this.Bounds = Bounds;
        minBounds = Bounds.bounds.min;
        maxBounds = Bounds.bounds.max;
    }

    public void SetTarget(Transform Target)
    {
        Player = Target;
        isFollowing = true;
    }
}
