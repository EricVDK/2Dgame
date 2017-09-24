using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlot{

	public Text coolDownText;
	public Image background;
	public Image selected;
	public Image coolDownImage;



	public SpellSlot (Text cd, Image bg, Image selected, Image cdi){
		this.coolDownText = cd;
		this.background = bg;
		this.selected = selected;
		this.coolDownImage = cdi;
	}


}
