using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public GameObject PlayerAvatar;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        cc.Move(new Vector3(h * Speed * Time.deltaTime, 0, v * Speed * Time.deltaTime));

        if (h != 0 || v != 0) 
        {
            this.GetComponentInChildren<Animator>().SetBool("IsWalking",true);
            PlayerAvatar.transform.forward = new Vector3(h, 0, v);
        }
        else
        {
            this.GetComponentInChildren<Animator>().SetBool("IsWalking", false);
        }
    }

    


}
