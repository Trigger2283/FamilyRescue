using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Note;

    public void HandleOpenOrCloseNote()
    {
        if(!Note.activeSelf)
        {
            Chapter1Flow.Instance.HandleNoteOpen();
        }
        Note.SetActive(!Note.activeSelf);
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
