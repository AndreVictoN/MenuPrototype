using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation Buttons")]
    public float duration = .2f;
    public float delay = .05f;

    public Ease ease = Ease.OutBack;

    public Ease exitEase = Ease.InSine;

    private void Awake()
    {
        HideAllButtons();
        ShowAllButtons();
    }

    public void HideAllButtons()
    {
        foreach (var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    public void ShowAllButtons()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            var bu = buttons[i];

            bu.SetActive(true);
            bu.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }

    public void ExitMenu()
    {
        int counter = buttons.Count;

        foreach (var buttons in buttons)
        {
            counter--;

            buttons.transform.DOScale(0, duration).SetDelay(counter*delay).SetEase(exitEase);
        }
    }
}
