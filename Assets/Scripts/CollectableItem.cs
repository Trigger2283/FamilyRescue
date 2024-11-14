using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public DialogSystemManager.DialogContent[] Dialog;
    public Chapter1Flow.CLUES ClueType;
    public GameObject Icon;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Chapter1Flow.Instance.CurrentStage < Chapter1Flow.STAGE.FREE_MOVE) return;

        if (Vector3.Distance(this.transform.position, player.transform.position) <= 3)
        {
            Icon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Dialog != null && Dialog.Length != 0) DialogSystemManager.Instance.HandleStartConversation(null, Dialog);
                Chapter1Flow.Instance.HandleCollectedClue(ClueType);
                Icon.SetActive(false);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Icon.SetActive(false);
        }
    }


}
