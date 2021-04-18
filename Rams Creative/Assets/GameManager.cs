using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool hasEnded = false;    

    [SerializeField] Text winText;
    [SerializeField] Text winText2;
    public string player1WonText = "Player 1 Won";
    public string player2WonText = "Player 2 Won";
   
    public void EndGame(bool Player1Won)
    {
        if (hasEnded) return;///End game once per session

        hasEnded = true;
        StartCoroutine(PlayEndGameAnimation(Player1Won));
    }
    IEnumerator PlayEndGameAnimation(bool player1Won)/////displays player win text
    {
        Debug.Log("gameOver");
        winText.gameObject.SetActive(true);
        winText2.gameObject.SetActive(true);
        if (player1Won)             
        {           
            winText.text = player1WonText;
            winText2.text = player1WonText;
        }
        else
        {
            winText.text = player2WonText;
            winText2.text = player2WonText;
        }
        yield return new WaitForSeconds(1f);
        winText.gameObject.SetActive(false);
        winText2.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        hasEnded = false;////// in future if the class is turned into a singleton


    }
}
