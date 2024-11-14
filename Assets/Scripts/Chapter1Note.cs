using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Note : MonoBehaviour
{
    private GameObject player;
    public GameObject Icon;
    public GameObject Note;
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
            Icon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Chapter1Flow.Instance.HandleInteractWithNote();
                Icon.SetActive(false);
                Note.SetActive(false);
                this.enabled = false;
            }
        }
        else
        {
            Icon.SetActive(false);
        }
    }
}
