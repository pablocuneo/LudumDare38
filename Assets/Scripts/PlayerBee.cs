using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBee : MonoBehaviour {

	public float energy = 100f; //0-100
	public float pollenCollected = 0f;
	public float maxPollen = 10f;
	public bool IsInHive = false;

	private float energyLostPerSecond = 3f;
	private float energyRechargePerSecond = 20f;

	void Start () {
	}

	void Update () {
		if (IsInHive) {
			if (energy < 100f) {
				energy += (Time.deltaTime * energyRechargePerSecond);
				if (energy > 100f) { energy = 100f; }
			}
		} else {
			energy -= (Time.deltaTime * energyLostPerSecond);
		}
	}
}
