using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textHealth;
	[SerializeField] private GameObject _losePanel;
	[SerializeField] private GameObject _winPanel;

	private void OnEnable()
	{
		Player.OnHealthChange += TextChange;
		Player.OnHealthChange += LosePanel;
		Win.OnWin += WinPanel;
	}

	private void OnDisable()
	{
		Player.OnHealthChange -= TextChange;
		Player.OnHealthChange -= LosePanel;
		Win.OnWin -= WinPanel;
	}

	private void TextChange(int health)
	{
		_textHealth.text = $"Health = {health}";
	}

	private void LosePanel(int health)
	{
		if (health <= 0)
		{
			Time.timeScale = 0;
			_losePanel.SetActive(true);
		}
	}

	private void WinPanel(bool isWin)
	{
		if (isWin)
		{
			Time.timeScale = 0;
			_winPanel.SetActive(isWin);
		}
	}

	public void Restart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}