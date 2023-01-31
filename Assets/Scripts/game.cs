using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{
    bool anyObjectReached = false;
    public static string winner;
    public GameObject object1, object2, object3, object4, boat;
    private int diceRoll;
    public bool object1Reached, object2Reached, object3Reached, object4Reached;
    public TextMeshProUGUI wurf;
    private bool object1first, object2first, object3first, object4first;
    public int fischeReached;

    void Start() {
        diceRoll = 0;
        fischeReached = 0;
        object1Reached = false;
        object2Reached = false;
        object3Reached = false;
        object4Reached = false;

        object1first = false;
        object2first = false;
        object3first = false;
        object4first = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            RollDice();
        }
        CheckReached();

        CheckWinner();

        if (object1Reached == true || object2Reached == true || object3Reached == true || object4Reached == true)
        {
        anyObjectReached = true;
        }
    }

    void RollDice() {
        diceRoll = Random.Range(1, 7); // Würfelwert zwischen 1 und 6
        Debug.Log("Dice Roll: " + diceRoll);

//Würfel trifft auf Fisch im Ziel
        if (diceRoll >= 1 && diceRoll <= 4)
         {

            if (diceRoll == 1 && object1.transform.position.x >=3) {
                        diceRoll = Random.Range(1, 5);
                        Debug.Log("anderer");
            } else if (diceRoll == 2 && object2.transform.position.x >=3) {
                        diceRoll = Random.Range(1, 5);
                        Debug.Log("anderer");
            } else if (diceRoll == 3 && object3.transform.position.x >=3) {
                        diceRoll = Random.Range(1, 5);
                        Debug.Log("anderer");

            } else if (diceRoll == 4 && object4.transform.position.x >=3) {
                        diceRoll = Random.Range(1, 5);
                        Debug.Log("anderer");
            }

        }
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
//Würfel trifft gefangenen Fisch    
        if (diceRoll >= 1 && diceRoll <= 4 && anyObjectReached) {
            if (diceRoll == 1 && object1Reached) {
                boat.transform.position += new Vector3(1, 0, 0);
            } else if (diceRoll == 2 && object2Reached) {
                boat.transform.position += new Vector3(1, 0, 0);
            } else if (diceRoll == 3 && object3Reached) {
                boat.transform.position += new Vector3(1, 0, 0);
            } else if (diceRoll == 4 && object4Reached) {
                boat.transform.position += new Vector3(1, 0, 0);
            }

        }

        wurf.text = "" + diceRoll;
    }
    void CheckReached()
    {
        if (object1.transform.position.x == boat.transform.position.x && object1first == false && boat.transform.position.x < 3)
        {
            object1Reached = true;
            object1.SetActive(false);
            fischeReached++;
            object1first = true;

        }
        if (object2.transform.position.x == boat.transform.position.x && object2first == false && boat.transform.position.x < 3)
        {
            object2Reached = true;
            object2.SetActive(false);
            fischeReached++;
            object2first = true;

        }
        if (object3.transform.position.x == boat.transform.position.x && object3first == false && boat.transform.position.x < 3)
        {
            object3Reached = true;
            object3.SetActive(false);
            fischeReached++;
            object3first = true;
 
        }
        if (object4.transform.position.x == boat.transform.position.x && object4first == false && boat.transform.position.x < 3)
        {
            object4Reached = true;
            object4.SetActive(false);
            fischeReached++;
            object4first = true;

        }
    }


    void CheckWinner()
    {

        if (boat.transform.position.x >=3 || object1.transform.position.x >=3 && object2.transform.position.x >=3 && object3.transform.position.x >=3 && object4.transform.position.x >=3)
        
         {

            if (fischeReached == 2)
            {
                Debug.Log("Unentschieden");
                SceneManager.LoadScene("Unentschieden");
            }
            else if (fischeReached > 2)
            {
                Debug.Log("Fischer gewinnen");
                SceneManager.LoadScene("FischerEnd");
            }
            else if (fischeReached < 2)
            {
                Debug.Log("Fische gewinnen");
                SceneManager.LoadScene("FischeEnd");
            }
        }
    }

}
