using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableOnlyItem : MonoBehaviour
{
    public DialogSystemManager.DialogContent[] Dialog;
    public DialogSystemManager.DialogContent[] Dialog2;
    public GameObject Icon;
    private GameObject player;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Icon.SetActive(false);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= 3)
        {
            Icon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (index == 0 && Dialog != null && Dialog.Length != 0)
                {
                    DialogSystemManager.Instance.HandleStartConversation(null, Dialog);
                    index++;
                }
                else if(index> 0 && Dialog2 != null && Dialog2.Length != 0)
                {
                    DialogSystemManager.Instance.HandleStartConversation(null, Dialog2);
                }
                Icon.SetActive(false);
            }
        }
        else
        {
            Icon.SetActive(false);
        }
    }
}
