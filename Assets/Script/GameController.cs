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
    public Text resetText;
    private int movecount;
    public GameObject resetButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activeColor;
    public PlayerColor inactiveColor;



    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerOnButtons();
        playerSide = "X";
        movecount = 0;
        resetButton.GetComponentInParent<Button>().interactable = true;
        resetText.text= "Reset";
        setPlayerColors(playerO, playerX);
        
    }
    
    void SetGameControllerOnButtons() {
        for(int i=0;i<buttonList.Length ; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
            buttonList[i].text = "";
            buttonList[i].GetComponentInParent<Button>().interactable = true;

        }
    }
    public string GetPlayerSide()
    {
        return playerSide;
    }
    public void EndTurn() {
        movecount++;
        if (checkWin() || movecount >= 9  )
        {
            gameOverPanel.SetActive(true);
            winText.text = GameOver();
            resetButton.GetComponentInParent<Button>().interactable = true;//resetWindow();
        }
        else
        {
            changeSides();
        }
    }
    void changeSides() {
        if (playerSide == "X")
        {
            playerSide = "O";
            setPlayerColors(playerX, playerO);
        }
        else
        {
            playerSide = "X";
            setPlayerColors(playerO, playerX);
        }
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
    public void resetWindow() {
        // Reset stuff
        Awake();
        // disable reset button 
        // done in awake
    }
    void setPlayerColors(Player old, Player newP){
        newP.panel.color = activeColor.panelColor;
        newP.text.color = activeColor.textColor;
        old.panel.color = inactiveColor.panelColor;
        old.text.color = inactiveColor.textColor;
    }
}
