using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Chapter1Flow : MonoBehaviour
{
    public static Chapter1Flow Instance;
    public DialogSystemManager.DialogContent[] Dialog1;
    public DialogSystemManager.DialogContent[] Dialog2;
    public DialogSystemManager.DialogContent[] Dialog3;
    public DialogSystemManager.DialogContent[] Dialog4;
    public DialogSystemManager.DialogContent[] Dialog5;
    public DialogSystemManager.DialogContent[] Dialog6;
    public STAGE CurrentStage;
    public Dictionary<CLUES, bool> CollectedClues;
    public GameObject[] CluesGameObject;
    private UnityAction action;
    public GameObject NoteButton;
    private bool isGameEnd;
    public enum ROOM_TYPE
    {
        BEDROOM_PARENT,
        BEDROOM_SELF,
        LIVING_ROOM,
        STORAGE,
        STUDIO,
    }

    public enum STAGE
    {
        DIALOG_1,
        FREE_MOVMENT,
        DIALOG_2,
        FREE_MOVEMENT_TARGETING_TABLE,
        DIALOG_3,
        FINDING_NOTE,
        DIALOG_4,
        DIALOG_5,
        BACK_TO_MY_ROOM,
        DIALOG_6,
        FREE_MOVE,
    }

    public enum CLUES
    {
        DISCOUNT,
        CALENDAR,
        BOOK,
        MESSAGE,
        PACKAGE,
        POSTER
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void HandleConversationEnd()
    {
        switch(CurrentStage)
        {
            case STAGE.DIALOG_1:
                break;
            case STAGE.DIALOG_2:
                break;
            case STAGE.DIALOG_3:
                break;
            case STAGE.DIALOG_4:
                break;
            case STAGE.DIALOG_5:
                break;
            case STAGE.DIALOG_6:
                NoteButton.SetActive(true);
                break;
            default:
                break;
        }
        CurrentStage++;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameEnd = false;
        NoteButton.SetActive(false);
        CurrentStage = STAGE.DIALOG_1;
        action += HandleConversationEnd;
        DialogSystemManager.Instance.HandleStartConversation(action, Dialog1);
        CollectedClues = new Dictionary<CLUES, bool>();
        for(int i = 0;i<System.Enum.GetValues(typeof(CLUES)).Length;i++)
        {
            CollectedClues.Add((CLUES)i, false);
        }
    }

    public void HandleNoteOpen()
    {
        for(int i = 0;i< CluesGameObject.Length;i++)
        {
            if (CollectedClues[(CLUES)i]) CluesGameObject[i].SetActive(true);
            else CluesGameObject[i].SetActive(false);
        }
    }

    public void HandleCollectedClue(CLUES clue)
    {
        CollectedClues[clue] = true;
    }

    public bool GetIsClueCollected(CLUES clue)
    {
        return CollectedClues[clue];
    }

    public void HandlePlayerEnterRoom(ROOM_TYPE roomType)
    {
        switch (CurrentStage)
        {
            case STAGE.FREE_MOVMENT:
                if(roomType == ROOM_TYPE.BEDROOM_SELF)
                {
                    CurrentStage++;
                    DialogSystemManager.Instance.HandleStartConversation(action, Dialog2);
                }
                break;
            case STAGE.BACK_TO_MY_ROOM:
                if (roomType == ROOM_TYPE.BEDROOM_SELF)
                {
                    CurrentStage++;
                    DialogSystemManager.Instance.HandleStartConversation(action, Dialog6);
                }
                break;
        }
    }

    public bool HandleInteractWithTable()
    {
        switch (CurrentStage)
        {
            case STAGE.FREE_MOVEMENT_TARGETING_TABLE:
                CurrentStage++;
                DialogSystemManager.Instance.HandleStartConversation(action, Dialog3);
                return true;
            default:
                break;
        }
        return false;
    }

    public void HandleInteractWithNote()
    {
        if (CurrentStage == STAGE.FINDING_NOTE)
        {
            CurrentStage++;
            DialogSystemManager.Instance.HandleStartConversation(action, Dialog4);
        }
    }

    public void HandleInteractWithGrandMa()
    {
        if (CurrentStage == STAGE.DIALOG_5)
        {
            DialogSystemManager.Instance.HandleStartConversation(action, Dialog5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameEnd) return;
        bool allSuccess = true;
        for (int i = 0; i < CluesGameObject.Length; i++)
        {
            if(CluesGameObject[i].activeSelf
                && CluesGameObject[i].GetComponentInParent<InventorySlot>()!=null
                && CluesGameObject[i].GetComponentInParent<InventorySlot>().SuccessMapped)
            {
                //do nothing
            }
            else
            {
                allSuccess = false;
            }
        }
        if(allSuccess)
        {
            print("Game end");
            isGameEnd = true;
            GameManager.Instance.HandleFadeAndLoadNextScene();
        }
    }

}
