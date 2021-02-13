using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {
    
    //References
    private Vector3 ogPos;
    private Vector3 otherPos;
    private GameObject otherCard;

    //Vars for detecting mouse position.
    private Vector3 screenSpace;
    private Vector3 offset;

    //Bools
    private bool touch;
    private bool move;

    void Start() {
        ogPos = transform.position;
    } 

    //Source used for OnMouseDown and Drag: https://www.codegrepper.com/code-examples/csharp/how+to+get+2D+object+drag+with+mouse+unity
    void OnMouseDown() {
        //translate the cubes position from the world to Screen Point
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        
        //calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenSpace.z));

        move = true;  
    }
 
    //OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse.
    //OnMouseDrag is called every frame while the mouse is down.
    void OnMouseDrag() {
    
        //keep track of the mouse position
        var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);    
    
        //convert the screen mouse position to world point and adjust with offset
        var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
    
        //update the position of the object in the world
        transform.position = curPosition;
    }

    void OnMouseUp() {
        move = false;

        //If touch true, replace the other card. Otherwise, set it to the original position.
        if (touch == true){
            transform.position = otherPos;
            Destroy(otherCard);
            ogPos = otherPos;
        } else {
            transform.position = ogPos;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        // Getting position and card in case of mouse release.
        touch = true;
        otherPos = other.transform.position;
        otherCard = other.gameObject;

        // Give border outline to indicate which card is being touched atm.
        if (move == true) {
            var otherCard = other.GetComponent<Renderer>();
            otherCard.material.SetColor("_Color", Color.red);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        touch = false;

        var otherCard = other.GetComponent<Renderer>();
        otherCard.material.SetColor("_Color", Color.green);
    }
}
