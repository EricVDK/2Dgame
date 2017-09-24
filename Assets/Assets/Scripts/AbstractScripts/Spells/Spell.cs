using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour {


	public PlayerController player;
	public GameObject spellPrefab;

	/// <summary>
	/// 0 is no target
	/// 1 is projectile
	/// 2 is ground target
	/// 3 is summon 
	/// </summary>

	public string name;
	public int id;
	public int targetType;

	public int manaCost;

	public float coolDown;

	public Sprite spellIcon;

	public int addStack<T>(Creature c, List<StatusEffect> list, string idstr) where T : StatusEffect, new(){

		for (int i = 0; i < list.Count; i++) {
			if (list [i].id != null) {
				if (list [i].id.Equals(idstr)) {
					T s = list [i] as T;
					if (s.timed) {
						s.refresh ();
					}
					s.stackSize += 1;

					list [i] = s;

					return s.stackSize;
				}
			}
		}

		T f = new T ();
		list.Add (f);
		return 0;
	}

	public bool checkExist(Creature c, List<StatusEffect> list, string idstr, bool refresh){
		for (int i = 0; i < list.Count; i++) {
			if (list [i].id.Equals (idstr)) {
				if (refresh) {
					list [i].refresh();

				}
				return true;
			}
		}
		return false;
	}
		




	public abstract void castSpell ();






}
