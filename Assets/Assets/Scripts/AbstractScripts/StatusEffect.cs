using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect{

	public float totalDuration;
	public float timeLeft;
	public string id;

	public Creature target;

	public int stackSize;

	public bool timed;
	public bool isActive = true;

	// depending on what is needed, give the effect generic access to an enemy, creature, or the player upon activation/initialization
	// that is why no generic object variable is declared here, leave it to each individual effect


	public override bool Equals(object obj){
		
		StatusEffect other = obj as StatusEffect;

		if (other == null) {
			return false;
		}

		if (this.id.Equals(other.id)) {
			return true;
		} else {
			return false;
		}

	}

	public void decrementTime(){
		if (isActive) {
			timeLeft -= Time.deltaTime;
		}
		if (timeLeft < 0) {
			if (timed) {
				isActive = false;
			}
		}
	}
	// apply effect is the C# code object's version of update
	public abstract void applyEffect ();

	// reverse effect is called to remove/reset the effect
	public abstract void reverseEffect ();

	public void refresh(){
		timeLeft = totalDuration;
	}

}
