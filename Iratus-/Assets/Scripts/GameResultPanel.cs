using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameResultPanel : MonoBehaviour
{
    [SerializeField] private Image _gameResultPanel;
    [SerializeField] private TMP_Text _gameResultText;
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _quitButton;

    private void OnEnable()
    {
        NPCLogic.GameFinished += ShowGameResult;
        _playAgainButton.onClick.AddListener(PlayAgain);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        NPCLogic.GameFinished -= ShowGameResult;
        _playAgainButton.onClick.RemoveListener(PlayAgain);
        _quitButton.onClick.RemoveListener(QuitGame);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _gameResultPanel.gameObject.SetActive(!_gameResultPanel.gameObject.activeSelf);
        }
    }

    private void ShowGameResult(string result)
    {
        _gameResultPanel.gameObject.SetActive(true);
        _gameResultText.text = result;
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene("Battle");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
