using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textHealth;
	[SerializeField] private GameObject _losePanel;

	private void OnEnable()
	{
		Player.OnHealthChange += TextChange;
		Player.OnHealthChange += LosePanel;
	}

	private void OnDisable()
	{
		Player.OnHealthChange -= TextChange;
		Player.OnHealthChange -= LosePanel;
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

	public void Restart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}