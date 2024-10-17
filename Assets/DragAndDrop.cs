using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); //storing the first touch of the player
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); //converting phone pixels into position in Unity
            
            if(touch.phase == TouchPhase.Began) //if we just touched screen for the 1st time
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchedCollider)
                {
                    moveAllowed = true;
                }
            }
            if(touch.phase == TouchPhase.Moved) //if our finger is still on the screen
            {
                if(moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if(touch.phase == TouchPhase.Ended) //if our figer stopped touching the screen
            {
                moveAllowed = false;
            }
        }
    }
}
