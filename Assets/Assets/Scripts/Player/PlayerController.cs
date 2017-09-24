using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Creature {

	///<summary>
	/// Components
	/// </summary>
	Rigidbody2D rb;

	///<summary>
	/// UI Elements
	/// </summary>

	public Slider healthBar;
	public Slider manaBar;
	public Text healthText;
	public Text manaText;

	public Text spell1Cooldown;
	public Text spell2Cooldown;
	public Text spell3Cooldown;
	public Text spell4Cooldown;

	public Image spell1Background;
	public Image spell2Background;
	public Image spell3Background;
	public Image spell4Background;


	public Image spell1Selection;
	public Image spell2Selection;
	public Image spell3Selection;
	public Image spell4Selection;

	public Image spell1Ticker;
	public Image spell2Ticker;
	public Image spell3Ticker;
	public Image spell4Ticker;



	SpellSlot[] spellSlotsUI = new SpellSlot[4];

	public Text currentSpellText;

	/// <summary>
	/// Member variables
	/// </summary>


	public GameObject[] spells = new GameObject[4];
	private int currentSpell = 0;
	public CooldownManager cm = new CooldownManager();

	public GameObject aimer;



	// Unity Callbacks
	void Start () {

		for(int i = 0; i < spells.Length; i++){
			/*
			cm.cooldownLengths [i] = 3f;
			cm.cooldownTimers [i] = 3f;
			cm.offCooldown [i] = true;
			*/

			cm.cooldownLengths [i] = spells [i].GetComponent<Spell> ().coolDown;
			cm.cooldownTimers [i] = cm.cooldownLengths [i];
			cm.offCooldown [i] = true;

		}

		spellSlotsUI [0] = new SpellSlot(spell1Cooldown, spell1Background, spell1Selection, spell1Ticker);
		spellSlotsUI [1] = new SpellSlot(spell2Cooldown, spell2Background, spell2Selection, spell2Ticker);
		spellSlotsUI [2] = new SpellSlot(spell3Cooldown, spell3Background, spell3Selection, spell3Ticker);
		spellSlotsUI [3] = new SpellSlot(spell4Cooldown, spell4Background, spell4Selection, spell4Ticker);


		rb = GetComponent<Rigidbody2D>();


		InvokeRepeating ("regenHealth", 0f, 1f);
		InvokeRepeating ("regenMana", 0f, 1f);

		currentSpellText.text = spells [currentSpell].name;


		spellSlotsUI [currentSpell].selected.enabled = true;
	}
	

	void Update () {
		updateHUD ();
		changeCurrentSpell ();
		castSpell1 ();
		checkDeath ();
		coolDownSpells ();

		updateStatusEffects (effectList);
		updateStatusEffects (buffList);

		updateRenderOrder ();

	}

	void FixedUpdate(){
		movement ();


	}
		
	/// <summary>
	/// Methods
	/// </summary>

	public void movement(){
		rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* speed, 0.8f),
		Mathf.Lerp(0, Input.GetAxis("Vertical")* speed, 0.8f));
	}

	public void updateHUD(){
		//health and mana
		updateHealth();
	}
		
	public void updateHealth(){
		healthBar.value = health;
		manaBar.value = mana;
		healthText.text = health + " / " + maxHealth;
		manaText.text = mana + " / " + maxMana;
		healthBar.maxValue = maxHealth;
		manaBar.maxValue = maxMana;
	}






	public void castSpell1(){
		if (Input.GetMouseButton (0) && spells [currentSpell].GetComponent<Spell> ().manaCost < mana) {
			if (cm.offCooldown[currentSpell]) {
				// no target
				if (spells [currentSpell].GetComponent<Spell> ().targetType == 0) {
					GameObject g = Instantiate (spells [currentSpell]);
					g.GetComponent<Spell> ().castSpell ();

					reduceMana (g.GetComponent<Spell> ().manaCost);
				}

				// projectile
				if (spells [currentSpell].GetComponent<Spell> ().targetType == 1) {
					GameObject g = Instantiate (spells [currentSpell]);





					g.GetComponent<Projectile> ().setPosition (new Vector2 (aimer.transform.position.x, aimer.transform.position.y));
					g.GetComponent<Projectile> ().setAim (Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y)) - transform.position);


					g.GetComponent<Projectile> ().castSpell ();
					reduceMana (g.GetComponent<Projectile> ().manaCost);

				}

				cm.offCooldown [currentSpell] = false;
			}
		}

	}

	public void changeCurrentSpell(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			spellSlotsUI [currentSpell].selected.enabled = false;
			currentSpell += 1;

		}
		if (currentSpell >= 4) {
			currentSpell = 0;
		}
		spellSlotsUI [currentSpell].selected.enabled = true;
		currentSpellText.text = spells [currentSpell].name;
	}

	public void coolDownSpells(){

		for (int i = 0; i < cm.cooldownTimers.Length; i++) {
			if (!cm.offCooldown [i]) {
				cm.cooldownTimers[i] -= Time.deltaTime;
				// text is timer ceil
				spellSlotsUI[i].coolDownText.text =  Mathf.Ceil( cm.cooldownTimers[i]).ToString();

				float percentComplete = cm.cooldownTimers [i] / cm.cooldownLengths [i];
				if (percentComplete < 0) {
					percentComplete = 0;
				}
				spellSlotsUI [i].coolDownImage.fillAmount = percentComplete;



			}

			if(cm.cooldownTimers[i] < 0){
				cm.offCooldown [i] = true;
				cm.cooldownTimers [i] = cm.cooldownLengths [i];
				//text is blank
				spellSlotsUI[i].coolDownText.text = "";
	
			}
		}
	}



}
