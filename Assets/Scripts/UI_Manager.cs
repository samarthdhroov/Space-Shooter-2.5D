using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text ScoreCard;
    [SerializeField]
    private Sprite[] _LivesSprite;
    [SerializeField]
    private Image _LivesImage;
    [SerializeField]
    private Text _GameOverText;
    [SerializeField]
    private Text _RestartText;
    [SerializeField]
    private GameManager _gameManager;



    // Start is called before the first frame update
    void Start()
    {
       
        ScoreCard.text = "Score: " + 0;
        _GameOverText.gameObject.SetActive(false);
    }
    
    public void UpdateScore(int playerScore)
    {
        ScoreCard.text = "Score: " + playerScore.ToString();
    }

    public void LivesDisplay(int spritNumber)
    {
        _LivesImage.sprite = _LivesSprite[spritNumber];
    }

    public void DisplayGameOver()
    {
        GameOverSequene();
        
    }


    void GameOverSequene()
    {
        _gameManager.GameOver();
        _GameOverText.gameObject.SetActive(true);
        _RestartText.gameObject.SetActive(true);
        StartCoroutine(Flicker());

    }

    IEnumerator Flicker()
    {

        while (true)
        {
            _GameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _GameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
            _GameOverText.text = "GAME OVER";
        }
    }



}
