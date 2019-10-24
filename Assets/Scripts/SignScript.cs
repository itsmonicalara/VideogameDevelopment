using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignScript : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string myDialog;
    public bool needDialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            needDialog = true;
        }
        if(needDialog){
            if(dialogBox.activeInHierarchy){
                dialogBox.SetActive(false);
            }else{
                dialogBox.SetActive(true);
                dialogText.text = myDialog;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            needDialog = false;
            dialogBox.SetActive(false);
        }
    }
}
