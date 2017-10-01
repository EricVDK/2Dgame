using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Auras : MonoBehaviour {

	public string auraKey;
	StatusEffect aura;

	Dictionary<string, Action<Collider2D, bool>> d = new Dictionary<string, Action<Collider2D, bool>>{
		{"HealthRegen", addHealthRegen},
		{"BonusSpeed", addBonusSpeed}
	};



	// Use this for initialization
	void Start () {
		
	}

	static private void addHealthRegen(Collider2D col, bool entering){
		addAura<HealthRegen> (col, entering);
	}

	static private void addBonusSpeed(Collider2D col, bool entering){
		addAura<BonusSpeed> (col, entering);
	}

	void OnTriggerEnter2D(Collider2D col){
		d [auraKey] (col, true);
	}

	void OnTriggerExit2D(Collider2D col){
		d [auraKey] (col, false);
	}










	static private void addAura<T>(Collider2D col, bool entering)where T : StatusEffect, new(){
		GameObject g = col.gameObject;
		if (g.GetComponent<Creature>() != null) {
			Creature c = g.GetComponent<Creature> ();
			if (entering) {
				T hr = new T ();
				hr.target = c;
				Debug.Log ("Entered");
				c.buffList.Add (hr);
			} else {
				T hr = new T ();
				for(int i = 0; i < c.buffList.Count; i++){
					if (c.buffList [i].Equals (hr)) {
						c.buffList [i].reverseEffect ();
						c.buffList.RemoveAt (i);
					}
				}
				Debug.Log ("Left");
			}

		}
	}

}
