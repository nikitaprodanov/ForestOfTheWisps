using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public RoomTemplates templates;
    private int rand;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rand = Random.Range(0, templates.rooms.Count);
            collision.gameObject.transform.position = templates.rooms[rand].transform.position;
            Destroy(this.gameObject);
        }
    }
}
