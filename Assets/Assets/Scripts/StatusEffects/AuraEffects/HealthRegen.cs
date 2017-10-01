using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthRegen : StatusEffect {

	public float healthRegen;
	public float radius;
	public bool once;


	public HealthRegen(){
		healthRegen = 5;
		id = "HealthRegen";
		once = true;
	}



	public override void applyEffect(){
		if (once) {
			target.healthRegen += healthRegen;
			once = false;
		}
	}

	public override void reverseEffect(){
		target.healthRegen -= healthRegen;

	}

	public override bool Equals(object obj){
		return base.Equals (obj);

	}


}
