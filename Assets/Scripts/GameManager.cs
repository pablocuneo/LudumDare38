using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public PlayerBee playerBee;
	public ProgressBar energyProgressBar;
	public ProgressBar pollenProgressBar;
	public ProgressBar hivePollenProgressBar;
	public GameObject HivePollenDisplay;
	public GameObject NotEnoughEnergyText;
	public GameObject GameWonImage;
	public GameObject GameLoseImage;

	private Vector3 playerBeeStartingPosition;

	void Awake () {
		playerBeeStartingPosition = playerBee.transform.position;
		GameStateManager.Instance.IsGamePaused = true;
		Time.timeScale = 0;
	}

	public void RestartGame(){
		GameWonImage.SetActive(false);
		GameLoseImage.SetActive(false);

		playerBee.transform.position = playerBeeStartingPosition;
		playerBee.energy = 100f;
		playerBee.pollenCollected = 0f;
		GameStateManager.Instance.HivePollen = 0f;

		GameStateManager.Instance.IsGamePaused = false;
		Time.timeScale = 1;
	}

	void Update () {
		Time.timeScale = (GameStateManager.Instance.IsGamePaused) ? 0 : 1;;

		energyProgressBar.barProgress = playerBee.energy / 100f;

		pollenProgressBar.barProgress = playerBee.pollenCollected / 10f;

		hivePollenProgressBar.barProgress = 
			GameStateManager.Instance.HivePollen / GameStateManager.Instance.MaxHivePollen;

		HivePollenDisplay.SetActive (playerBee.IsInHive);

		NotEnoughEnergyText.SetActive (playerBee.energy < 30f);

		if (playerBee.energy <= 0f){
			GameStateManager.Instance.IsGamePaused = true;
			Time.timeScale = 0;

			GameLoseImage.SetActive(true);
		}

		if (GameStateManager.Instance.HivePollen >= GameStateManager.Instance.MaxHivePollen) {
			GameStateManager.Instance.IsGamePaused = true;
			Time.timeScale = 0;

			GameWonImage.SetActive(true);
		}
	}
}
