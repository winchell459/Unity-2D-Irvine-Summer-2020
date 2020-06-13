using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public PlayerController Player;
    public Transform SpawnPoint;
    public CameraController Camera;

    public GameObject PlayerPrefab;
    public Animator CheckpointUISet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player)
        {
            Player = Instantiate(PlayerPrefab, SpawnPoint.transform.position, Quaternion.identity).GetComponent<PlayerController>();
            Camera.Player = Player.transform;
        }
        
    }

    public void SetCheckpoint(Transform checkPoint)
    {
        SpawnPoint = checkPoint;
        CheckpointUISet.SetTrigger("CheckpointSet");
    }
}
