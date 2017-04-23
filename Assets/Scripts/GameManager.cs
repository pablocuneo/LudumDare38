using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public PlayerBee playerBee;
	public ProgressBar energyProgressBar;
	public ProgressBar pollenProgressBar;
	public ProgressBar hivePollenProgressBar;
	public GameObject HivePollenDisplay;

	void Awake () {
		
		GameStateManager.Instance.IsGamePaused = true;
		Time.timeScale = 0;
	}

	void Update () {
		Time.timeScale = (GameStateManager.Instance.IsGamePaused) ? 0 : 1;;

		energyProgressBar.barProgress = playerBee.energy / 100f;

		pollenProgressBar.barProgress = playerBee.pollenCollected / 10f;

		hivePollenProgressBar.barProgress = 
			GameStateManager.Instance.HivePollen / GameStateManager.Instance.MaxHivePollen;

		HivePollenDisplay.SetActive (playerBee.IsInHive);

		if (playerBee.energy <= 0f){
			//TODO: trigger game lost	
		}

		if (GameStateManager.Instance.HivePollen >= GameStateManager.Instance.MaxHivePollen) {
			//TODO: trigger game won
		}
	}
}
