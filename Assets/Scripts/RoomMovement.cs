using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMovement : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 myPlayer;
    private CameraMovement myCamera;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            myCamera.minPosition += cameraChange;
            myCamera.maxPosition += cameraChange;
            col.transform.position += myPlayer;
            if(needText){
                StartCoroutine(PlaceNameCo());
            }
        }
    }

    private IEnumerator PlaceNameCo(){
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }

}
