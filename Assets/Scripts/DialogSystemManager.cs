using Doublsb.Dialog;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogSystemManager : MonoBehaviour
{
    public static DialogSystemManager Instance;
    public GameObject DialogManager;
    private List<DialogData> dialogTexts;
    [Serializable]
    public struct DialogContent
    {
        public string DialogText;
        public string SpeakerName;
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        dialogTexts = new List<DialogData>();
    }

    public void HandleStartConversation(UnityAction action, DialogContent[] DialogContents)
    {
        dialogTexts.Clear();
        DialogManager.SetActive(true);
        for(int i = 0;i<DialogContents.Length;i++)
        {
            dialogTexts.Add(new DialogData(DialogContents[i].DialogText, DialogContents[i].SpeakerName, null, false));
            dialogTexts[i].isSkippable = true;
        }
        dialogTexts[DialogContents.Length - 1].Callback = action;
        DialogManager.GetComponent<DialogManager>().Show(dialogTexts);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
