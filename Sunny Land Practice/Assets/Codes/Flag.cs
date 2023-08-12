using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Flag : MonoBehaviour
{
    public GameObject DoFade;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //SceneManager.LoadScene("Menu");
            StartCoroutine(DoFadeOpen());
        }
    }
    IEnumerator DoFadeOpen()
    {
        yield return new WaitForSeconds(1);
        DoFade.GetComponent<CanvasGroup>().DOFade(2, 1);
        yield return new WaitForSeconds(1);
        DoFade.GetComponent<CanvasGroup>().DOFade(2, 1);
        SceneManager.LoadScene("Menu");
    }
}
