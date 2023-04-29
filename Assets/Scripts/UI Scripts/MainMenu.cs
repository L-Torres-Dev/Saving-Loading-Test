using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button newGameButton;
    [SerializeField] Button continueButton;

    public delegate void GameTypeChosen();
    public GameTypeChosen onNewGame;
    public GameTypeChosen onContinue;

    public void NewGame()
    {
        onNewGame?.Invoke();
        gameObject.SetActive(false);
    }

    public void Continue()
    {
        onContinue?.Invoke();
        gameObject.SetActive(false);
    }

    public void DeactivateContinue()
    {
        continueButton.interactable = false;
    }
}
