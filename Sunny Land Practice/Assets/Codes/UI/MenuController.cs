using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    public string sceneName;

    public GameObject gameName;
    public GameObject buttons;
    public GameObject DoFade_imj;

    private void Start()
    {
        StartCoroutine(OpenGame());
    }
    IEnumerator OpenGame()
    {
        yield return new WaitForSeconds(0.5f);
        gameName.GetComponent<CanvasGroup>().DOFade(1, 0.7f);
        yield return new WaitForSeconds(0.6f);
        buttons.GetComponent<CanvasGroup>().DOFade(1,0.7f);
        buttons.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase ( Ease.OutBack);
    }

    public void Play()
    {
        StartCoroutine(StartScene());
    }
    IEnumerator StartScene()
    {
        DoFade_imj.GetComponent<CanvasGroup>().DOFade(1, 1);
        yield return new WaitForSeconds(2);
        DoFade_imj.GetComponent<CanvasGroup>().DOFade(0, 3);
        SceneManager.LoadScene(sceneName);
    }
    public void Out()
    {
        Application.Quit();
    }
}
