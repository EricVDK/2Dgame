using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour {


	/// <summary>
	/// Member variables
	/// </summary>
	public float health;
	public float maxHealth;
	public float healthRegen;
	public float dmgModifier;

	public float mana;
	public float maxMana;
	public float manaRegen;

	public float speed;

	public float renderOffset;

	public bool alive;
	// ---------------------------
	public SpriteRenderer sprite;

	public List<StatusEffect> effectList = new List<StatusEffect>();
	public List<StatusEffect>   buffList = new List<StatusEffect> ();

	/// <summary>
	/// Methods
	/// </summary>

	public void takeDmg(float dmg){
		health -= dmg*dmgModifier;
		if (health <= 0) {
			alive = false;
		}
	}

	public void reduceMana(float cost){
		mana -= cost;
		if (mana < 0) {
			mana = 0;
		}
	}	

	public void regenHealth(){
		health += healthRegen;
		if (health > maxHealth) {
			health = maxHealth;
		}
	}

	public void regenMana(){
		mana += manaRegen;
		if (mana > maxMana) {
			mana = maxMana;
		}
	}






	public void checkDeath(){
		if (alive == false) {
			Destroy (gameObject);
		}
	}

	//entering and leaving auras, adding and removing those aura's effects
	// these functions are designed for the unity OnTriggerEnter2D calls

	public void enterAura(Collider2D col){
		if (col.tag == "buffAura") {
			//StatusEffect s = col.gameObject
		}

		else if (col.tag == "debuffAura") {
			
		}
	}

	public void leaveAura(){
		
	}
	// Each buff/debuff needs its own script. 
	//It will be a c# object that gets created and added to 
	//the buff/debuff arraylist of a creature. This method
	// should be called in update to apply effects and reduce timer variable

	public void updateStatusEffects(List<StatusEffect> s){
		//remove all status effects that are expired
		for (int i = 0; i < s.Count; i++) {
			if(!s[i].isActive){
				s [i].reverseEffect ();
				s.RemoveAt (i);
			}
		}

		//decrement the timer of all of the status effects that are left in the array, this is how the statusEffect "updates"
		for(int i = 0; i < s.Count; i++){
				s [i].decrementTime ();
			s [i].applyEffect ();
		}
	}

	public void updateRenderOrder(){
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y - renderOffset);
	}





}
