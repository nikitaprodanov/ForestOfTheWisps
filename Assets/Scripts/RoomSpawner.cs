using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private void Update()
    {
        if (openingDirection == 1)
        {
            // Need to spawn a room with BOTTOM door
        } else if (openingDirection == 2)
        {
            // Need to spawn a room with TOP door
        } else if (openingDirection == 3)
        {
            // Need to spawn a room with LEFT door
        } else if (openingDirection == 4)
        {
            // Need to spawn a room with RIGHT door
        }
    }
}
