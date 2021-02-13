using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {
    
    // Vars for detecting mouse position.
    private Vector3 screenSpace;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start() {
    }

    // Source: https://www.codegrepper.com/code-examples/csharp/how+to+get+2D+object+drag+with+mouse+unity
    void OnMouseDown() {
        //translate the cubes position from the world to Screen Point
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        
        //calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenSpace.z));  
    }
 
    // OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse.
    // OnMouseDrag is called every frame while the mouse is down.
    void OnMouseDrag () {
    
        //keep track of the mouse position
        var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);    
    
        //convert the screen mouse position to world point and adjust with offset
        var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
    
        //update the position of the object in the world
        transform.position = curPosition;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Touch");
    }
}
