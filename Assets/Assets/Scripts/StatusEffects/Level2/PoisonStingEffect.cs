using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonStingEffect : StatusEffect {


	public float damage = 3;
	public float slow = 2;
	public float interval = 1;
	private float intervalTimer = -1;
	private bool applyOnce = true;



	public PoisonStingEffect(){
		totalDuration = 5f;
		timeLeft = totalDuration;
		isActive = true;
		id = "PoisonStingEffect";
		timed = true;
	}



	// apply effect is the C# code object's version of update
	public override void applyEffect(){
		
		if (applyOnce) {
			target.speed -= slow;
			applyOnce = false;
		}
		applyOnInterval ();
	}

	public override void reverseEffect(){
		target.speed += slow;
	}

	public void applyOnInterval(){
		if (intervalTimer > 0) {
			intervalTimer -= Time.deltaTime;
		} else {
			intervalTimer = 1;
			target.takeDmg (damage);
		}
	}
}
