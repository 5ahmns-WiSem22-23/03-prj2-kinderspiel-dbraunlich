using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game : MonoBehaviour
{
    bool anyObjectReached = false;
    public static string winner;
    public GameObject object1, object2, object3, object4, boat;
    private int diceRoll;
    public bool object1Reached, object2Reached, object3Reached, object4Reached;
    public TextMeshProUGUI wurf;

    void Start() {
        diceRoll = 0;
        object1Reached = false;
        object2Reached = false;
        object3Reached = false;
        object4Reached = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            RollDice();
        }
        CheckReached();

        if (object1Reached == true || object2Reached == true || object3Reached == true || object4Reached == true)
        {
        anyObjectReached = true;
        }

        if (boat.transform.position.x >= 3)
        {
        Debug.Log("Das Boot gewinnt");
        }
        else if (object1.transform.position.x >= 3 && object2.transform.position.x >= 3 && object3.transform.position.x >= 3 && object4.transform.position.x >= 3)
        {
        Debug.Log("Die Fische gewinnen");
        }



    }

    void RollDice() {
        diceRoll = Random.Range(1, 7); // Würfelwert zwischen 1 und 6
        Debug.Log("Dice Roll: " + diceRoll);

        if (diceRoll >= 1 && diceRoll <= 4) {
            if (diceRoll == 1) {
                object1.transform.position += new Vector3(1, 0, 0);
            } else if (diceRoll == 2) {
                object2.transform.position += new Vector3(1, 0, 0);
            } else if (diceRoll == 3) {
                object3.transform.position += new Vector3(1, 0, 0);
            } else if (diceRoll == 4) {
                object4.transform.position += new Vector3(1, 0, 0);
            }
        } 
        else if (diceRoll == 5 || diceRoll == 6) {
            boat.transform.position += new Vector3(1, 0, 0);
        }
    
        if (diceRoll >= 1 && diceRoll <= 4 && anyObjectReached) {
            if (diceRoll == 1 && object1Reached) {
                boat.transform.position += new Vector3(1, 0, 0);
                Debug.Log("beide bewegt");
            } else if (diceRoll == 2 && object2Reached) {
                boat.transform.position += new Vector3(1, 0, 0);
                Debug.Log("beide bewegt");
            } else if (diceRoll == 3 && object3Reached) {
                boat.transform.position += new Vector3(1, 0, 0);
                Debug.Log("beide bewegt");
            } else if (diceRoll == 4 && object4Reached) {
                boat.transform.position += new Vector3(1, 0, 0);
                Debug.Log("beide bewegt");
            }

        }
        wurf.text = "" + diceRoll;
    }
    void CheckReached()
    {
        if (object1.transform.position.x == boat.transform.position.x)
        {
            object1Reached = true;
            object1.SetActive(false);

        }
        if (object2.transform.position.x == boat.transform.position.x)
        {
            object2Reached = true;
            object2.SetActive(false);

        }
        if (object3.transform.position.x == boat.transform.position.x)
        {
            object3Reached = true;
            object3.SetActive(false);
 
        }
        if (object4.transform.position.x == boat.transform.position.x)
        {
            object4Reached = true;
            object4.SetActive(false);

        }
    }

}
