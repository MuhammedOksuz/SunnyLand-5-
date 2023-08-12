using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UıController : MonoBehaviour
{
    PlayerHealt playerHealt;
    LevelController levelController;
    [SerializeField] Image heartOne, heartTwo, heartTree;
    [SerializeField] Sprite fullHeart, halfHeart, emtyHeart;

    [SerializeField] TMP_Text gemText;
    private void Awake()
    {
        playerHealt = Object.FindObjectOfType<PlayerHealt>();
        levelController = Object.FindObjectOfType<LevelController>();
    }
    public void UpdateHealt()
    {
        switch (playerHealt.validHeart)
        {
            case (6):
                heartOne.sprite = fullHeart;
                heartTwo.sprite = fullHeart;
                heartTree.sprite = fullHeart;
                break;
            case (5):
                heartOne.sprite = halfHeart;
                heartTwo.sprite = fullHeart;
                heartTree.sprite = fullHeart;
                break;
            case (4):
                heartOne.sprite = emtyHeart;
                heartTwo.sprite = fullHeart;
                heartTree.sprite = fullHeart;
                break;
            case (3):
                heartOne.sprite = emtyHeart;
                heartTwo.sprite = halfHeart;
                heartTree.sprite = fullHeart;
                break;
            case (2):
                heartOne.sprite = emtyHeart;
                heartTwo.sprite = emtyHeart;
                heartTree.sprite = fullHeart;
                break;
            case (1):
                heartOne.sprite = emtyHeart;
                heartTwo.sprite = emtyHeart;
                heartTree.sprite = halfHeart;
                break;
            case (0):
                heartOne.sprite = emtyHeart;
                heartTwo.sprite = emtyHeart;
                heartTree.sprite = emtyHeart;
                break;
        }
    }
    public void updateGemNumber()
    {
        gemText.text = levelController.collectNumber.ToString();
    }

}
