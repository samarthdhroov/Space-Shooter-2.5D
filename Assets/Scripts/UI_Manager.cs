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

    // Start is called before the first frame update
    void Start()
    {
       
        ScoreCard.text = "Score: " + 0;
    }
    
    public void UpdateScore(int playerScore)
    {
        ScoreCard.text = "Score: " + playerScore.ToString();
    }

    public void LivesDisplay(int spritNumber)
    {
        _LivesImage.sprite = _LivesSprite[spritNumber];
    }
}
