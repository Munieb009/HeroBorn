using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Handles all the scene related logic in Unity
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public bool showWinscreen = false;
    public string labelText = "Collect all 10 Health Pickups to Win the Game";
    // max number of health pick up
    public int maxItems = 10;
    
    private int CollectedItems = 0;
    private int PlayerHP = 10;
    public int Items
    {
        get
        {
            return CollectedItems;
        }
        set
        {
            CollectedItems = value;
            if(CollectedItems >= maxItems)
            {
                labelText = "You have found all the HP";
                showWinscreen = true;
                // pause / freeze the game/scene when win screen displays
                // disable any input
                // for this we need to use Time class
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Items found , only" + (maxItems - CollectedItems) + "more to go";
            }
        }
    }
    public int HP
    {
        get
        {
            return PlayerHP;
        }
        set
        {
            PlayerHP = value;
            Debug.LogFormat("Health Pick up Value: {0}", PlayerHP);
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(15, 15, 150, 25), "Player Health " + PlayerHP);
        GUI.Box(new Rect(15, 35, 150, 25), "Items Collected " + CollectedItems);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), labelText);

        // check if ShowwinScreen is True
        if(showWinscreen)
        {
            // GUI.Button() method, bool method
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height/2 - 50, 200,120),"You Won the Game !!"))
            {
                // restart the game
                SceneManager.LoadScene(0);
                // Activate / Restart all the behavior again
                Time.timeScale = 1.0f;
            }
        }
    }

}
