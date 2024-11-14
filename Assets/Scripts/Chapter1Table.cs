using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Table : MonoBehaviour
{
    public GameObject GiftBox;
    public GameObject Icon;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GiftBox == null) return;
        if(Vector3.Distance(GiftBox.transform.position,player.transform.position)<=3)
        {
            Icon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(Chapter1Flow.Instance.HandleInteractWithTable())
                {
                    Icon.SetActive(false);
                    Destroy(GiftBox);
                }
            }
        }
        else
        {
            Icon.SetActive(false);
        }
    }
}
