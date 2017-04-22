using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public PlayerBee playerBee;
	public ProgressBar energyProgressBar;
	public ProgressBar pollenProgressBar;


	//TODO: add progress bar for pollen in hive

	void Start () {
		
	}

	void Update () {


		energyProgressBar.barProgress = playerBee.energy / 100f;

		pollenProgressBar.barProgress = playerBee.pollenCollected / 10f;

		//TODO: check if energy is expended and trigger game lost
	}
}
