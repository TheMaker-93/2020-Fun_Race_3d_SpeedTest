using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup endGameCanvas;


    private void Awake()
    {
        if (endGameCanvas == null)
            Debug.LogError("No end game canvas set"); 
        else
        {
            HideCanvasGroup(endGameCanvas);
        }
    }

    public void ShowEndGameCanvas()
    {
        endGameCanvas.alpha = 1f;
        endGameCanvas.blocksRaycasts = true;
        endGameCanvas.interactable = true;
    }

    private void HideCanvasGroup(CanvasGroup _canvasGroup)
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }


}
