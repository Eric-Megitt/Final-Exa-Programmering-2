using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class MenuHandler : MonoBehaviour {
	[SerializeField] GameObject optionsMenu;
	[SerializeField] Settings settingsFile;
	[SerializeField] Slider _slider;
	[SerializeField] TextMeshProUGUI mouseSensativityText;

	void Start() {
		_slider.value = settingsFile.rotationCoefficient;
		SetMouseSensativityText(settingsFile.rotationCoefficient);
	}
	
	public void LoadNextScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ToggleOptionsMenu(bool enable) {
		optionsMenu.SetActive(enable);
	}

	public void ChangeMouseSensativity(float sensativity) {
		settingsFile.rotationCoefficient = sensativity;
		SetMouseSensativityText(sensativity);
	}

	void SetMouseSensativityText(float value) {
		mouseSensativityText.text = $"{Mathf.RoundToInt(value * 100)}%";
	}
}
