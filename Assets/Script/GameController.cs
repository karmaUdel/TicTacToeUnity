using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player{
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor {
    public Color panelColor;
    public Color textColor;
}
public class GameController : MonoBehaviour {

    public Text[] buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text winText;
    private int movecount;
    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerOnButtons();
        playerSide = "X";
        movecount = 0;
    }
    void SetGameControllerOnButtons() {
        for(int i=0;i<buttonList.Length ; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }
    public string GetPlayerSide()
    {
        return playerSide;
    }
    public void EndTurn() {
        movecount++;
        if (movecount >= 9 || checkWin())
        {
            gameOverPanel.SetActive(true);
            winText.text = GameOver();
        }
        else
        {
            changeSides();
        }
    }
    void changeSides() {
        playerSide = playerSide == "X" ? "O" : "X";
    }
    string GameOver()
    {
        string message;
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable=false;
        }
        if (movecount >= 9) {
            message = "It's a draw";
        }
        else
        {
            message = "Congratulation Player " + playerSide + "!!!!!\n You are Victoriuos!!!!! ";
        }
        return message;
    }
    bool checkWin()
    {
        bool win = false;
        if (buttonList[1].text==playerSide && buttonList[2].text == playerSide && buttonList[3].text == playerSide)
        {
            win = true;
        }//1st row
        if (buttonList[1].text == playerSide && buttonList[0].text == playerSide && buttonList[8].text == playerSide)
        {
            win = true;
        }//diagonal
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            win = true;
        }//1st col
        if (buttonList[2].text == playerSide && buttonList[0].text == playerSide && buttonList[7].text == playerSide)
        {
            win = true;
        }//2nd col
        if (buttonList[3].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            win = true;
        }//3rd col
        if (buttonList[3].text == playerSide && buttonList[0].text == playerSide && buttonList[6].text == playerSide)
        {
            win = true;
        }//reverse diagonal
        if (buttonList[5].text == playerSide && buttonList[4].text == playerSide && buttonList[0].text == playerSide)
        {
            win = true;
        }//2nd row
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            win = true;
        }//3rd row

        return win;
    }
}
