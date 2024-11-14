using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGrandMa : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= 3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Chapter1Flow.Instance.HandleInteractWithGrandMa();
            }
        }
    }
}
