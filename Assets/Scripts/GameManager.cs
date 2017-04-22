using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public PlayerBee playerBee;
	public ProgressBar energyProgressBar;
	public ProgressBar pollenProgressBar;
	public ProgressBar hivePollenProgressBar;

	void Start () {
	}

	void Update () {


		energyProgressBar.barProgress = playerBee.energy / 100f;

		pollenProgressBar.barProgress = playerBee.pollenCollected / 10f;

		hivePollenProgressBar.barProgress = 
			GameStateManager.Instance.HivePollen / GameStateManager.Instance.MaxHivePollen;

		//TODO: check if energy is expended and trigger game lost
	}
}
