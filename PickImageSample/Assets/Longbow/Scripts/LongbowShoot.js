﻿#pragma strict
var arrowSpawn : Transform; //the arrow's spawn point
var projectile : Transform; //the arrow to be instantiated
var drawSound : AudioClip; //sound to be played when drawing the bow (when the string is pulled back)
var shootSound : AudioClip; //sound to play when arrow is shot
var maxPower : int = 2000; //max force applied to the arrow
private var power : float; //how far the arrow will be shoot
var destroyTime : float = 10; //destroy the instantiated arrow, after this many seconds | if destroyArrows is unchecked, this time will have no effect
var destroyArrows = false; //destroy arrows shortly after they've been shot, or not

function Update () {
	if(Input.GetMouseButtonDown(0)) {
		//play drawSound
		GetComponent.<AudioSource>().Stop();
		GetComponent.<AudioSource>().clip = drawSound;
		GetComponent.<AudioSource>().volume = 1;
		GetComponent.<AudioSource>().Play();
	
		//Play Draw animation On Mouse Down
		GetComponent.<Animation>().Play("Draw");
		GetComponent.<Animation>()["Draw"].speed = 1;
		GetComponent.<Animation>()["Draw"].wrapMode = WrapMode.Once;
		
		//Enable arrowSpawn MeshRenderer
		arrowSpawn.GetComponent(MeshRenderer).enabled = true;
		
		//reset power to 0
		power = 0;
	}
	if(Input.GetMouseButton(0)) {
		//Increase power of shot
		if(power < maxPower) { //power will not exceed 2000
			power += maxPower * Time.deltaTime; //add 2000 to power every second
		}
	}
	if(Input.GetMouseButtonUp(0)) {
		//Calculate Shoot animation Time
		//This way, if the player lets go of the mouse before the entire Draw animation is complete, 
		//the Shoot animation isn't played from the begining (where the the string is drawn all the way back)
		var percent : float = GetComponent.<Animation>()["Draw"].time / GetComponent.<Animation>()["Draw"].length;
		var shootTime = 1 * percent;
		
		//play shootSound
		GetComponent.<AudioSource>().Stop();
		GetComponent.<AudioSource>().time = 0.2;
		GetComponent.<AudioSource>().clip = shootSound;
		if(percent == 0) {
			GetComponent.<AudioSource>().volume = 1;
		}
		else {
			//volume of sound will be determined by arrow's power
			GetComponent.<AudioSource>().volume = 1 * percent;
		}
		GetComponent.<AudioSource>().Play();
		
		//Play Shoot animation On Mouse Up
		GetComponent.<Animation>().Play("Shoot");
		GetComponent.<Animation>()["Shoot"].speed = 1;
		GetComponent.<Animation>()["Shoot"].time = shootTime;
		GetComponent.<Animation>()["Shoot"].wrapMode = WrapMode.Once;
		
		//Disable arrow Spawn MeshRenderer
		arrowSpawn.GetComponent(MeshRenderer).enabled = false;
		
		//Instantiated projectile (arrow)
		var arrow = Instantiate(projectile, arrowSpawn.transform.position, transform.rotation);
		
		//Add force to projectile, based off power
		arrow.transform.GetComponent.<Rigidbody>().AddForce(transform.forward * power);
		arrow.transform.GetChild(0).GetComponent.<Camera>().enabled=true;
	//	StartCoroutine(ResetCamera());

		if(destroyArrows == true) {
			//Destroy instantiated arrow, after given time
			Destroy(arrow.gameObject, destroyTime); //< you can change the amount of time until the arrow is destroyed by chaning destroyTime on the script, in the editor
		}
	}
	
}