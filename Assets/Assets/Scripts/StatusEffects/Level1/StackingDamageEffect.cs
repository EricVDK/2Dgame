using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingDamageEffect : StatusEffect {

	float stackSize = 0;




	Creature victim;

	public StackingDamageEffect(){
		totalDuration = 10f;
		timeLeft = totalDuration;
		isActive = true;
		id = "stacking";
		timed = true;
	}
	public override void applyEffect(){}
	public override void reverseEffect(){}

}
