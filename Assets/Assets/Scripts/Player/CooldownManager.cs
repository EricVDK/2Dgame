using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager {


	public bool[] offCooldown;
	public float[] cooldownLengths;
	public float[] cooldownTimers;

	public CooldownManager(){
		offCooldown = new bool[4];
		cooldownLengths = new float[4];
		cooldownTimers = new float[4];
	}


}
