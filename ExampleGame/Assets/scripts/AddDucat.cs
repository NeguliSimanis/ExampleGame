using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddDucat : MonoBehaviour {

    [SerializeField] Text ducatCountText;
    string defaultDucatCountText = "You have {0} ducats";
    string oneDucatCountText = "You have 1 ducat";
    //int ducats = 0;

    void Start()
    {
        Game.currentGame = new Game();
        ducatCountText.text = string.Format(defaultDucatCountText, Game.currentGame.ducatCount);
    }

    public void AddOneDucat()   
    {
        Game.currentGame.ducatCount++;
        if (Game.currentGame.ducatCount == 1)
        {
            ducatCountText.text = oneDucatCountText;
        }
        else ducatCountText.text = string.Format(defaultDucatCountText, Game.currentGame.ducatCount);
    }

    public void ShowDucatCount()
    {
        ducatCountText.text = string.Format(defaultDucatCountText, Game.currentGame.ducatCount);
    }
}
