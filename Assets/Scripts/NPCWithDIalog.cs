using Doublsb.Dialog;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NPCWithDIalog : MonoBehaviour
{
    [Serializable]
    public struct ConversationData
    {
        public string Conversation;
        public string Speaker;
    }
    public ConversationData[] Conversation;
    public GameObject dialogManager;
    protected List<DialogData> dialogTexts;
    protected UnityAction action;

    public void OnStart()
    {
         action += HandleConversationEnd;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)startConversation();
    }

    private void Awake()
    {
        OnStart();
    }

    public virtual void HandleConversationEnd()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameManager.Instance.HandleFadeAndLoadNextScene(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void startConversation()
    {
        dialogManager.SetActive(true);
        dialogTexts = new List<DialogData>();
        for (int i = 0; i < Conversation.Length; i++)
        {
            dialogTexts.Add(new DialogData(Conversation[i].Conversation, Conversation[i].Speaker, null, false));
             dialogTexts[i].isSkippable = true;
        }
        dialogTexts[Conversation.Length - 1].Callback = action;
        dialogManager.GetComponent<DialogManager>().Show(dialogTexts);
    }

}
