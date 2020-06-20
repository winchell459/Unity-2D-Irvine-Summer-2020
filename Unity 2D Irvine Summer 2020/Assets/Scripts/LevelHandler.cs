using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public PlayerController Player;
    public Transform Spawnpoint;
    public CameraController Camera;

    public GameObject PlayerPrefab;
    public Animator CheckpointSetUI; //UI panel that displays the checkpoint set message

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player)
        {
            Player = Instantiate(PlayerPrefab, Spawnpoint.position, Quaternion.identity).GetComponent<PlayerController>();
            Camera.Player = Player.transform;
        }
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        Spawnpoint = checkpoint;
        if(CheckpointSetUI) CheckpointSetUI.SetTrigger("CheckpointSet");
    }
}
