using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTIme;
    private bool spawnedBoss = false;
    public GameObject boss;

    public GameObject ball;

    private int rand;
    public GameObject portal;

    private void Start()
    {
        Invoke("InstantiateBalls", waitTIme);
        Invoke("InstantiatePortals", waitTIme);
    }

    private void Update()
    {
        if (waitTIme <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        } else
        {
            waitTIme -= Time.deltaTime;
        }
    }

    private void InstantiateBalls()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            Instantiate(ball, rooms[i].transform.position, Quaternion.identity);
        }
    }

    private void InstantiatePortals()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            rand = Random.Range(0, 6);
            if (rand == 4)
            {
                float newX = rooms[i].transform.position.x + 5;
                float newY = rooms[i].transform.position.y + 5;
                Vector2 newPos = new Vector2(newX, newY);

                Instantiate(portal, newPos, Quaternion.identity);
            }
        }
    }
}