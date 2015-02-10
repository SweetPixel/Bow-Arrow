#pragma strict

//here's how I would do it:

 var arrowPrefab: Rigidbody;   
 var ArrowSpeed = 100.0;
 var fireRate = 1.5;
 var nextFire = 0.0;
 var pullStartTime = 0.0;
 var pullTime = 0.5;
 var falsePull : boolean;
 var maxStrengthPullTime = 1.5; // how long to hold button until max strength reached
 
 function Start(){
 falsePull = false;
 }
 
 function Update ()
 { 
 // pull back string
  if(Input.GetMouseButtonDown(0))
 {
 if(Time.time > nextFire)
 {
 nextFire = Time.time + fireRate; // this line is unnecessary, since you are going to change it onMouseUp
 animation.Play("Armature|ArmatureAction");
//animation.Play("Take 001");
  pullStartTime = Time.time; //store the start time
 }
 else
 falsePull = true; 
 }
  // fire arrow
 if(Input.GetMouseButtonUp(0)){ //your way wouldn't work right, since you just increased nextFire
 if(!falsePull)
 {
 nextFire = Time.time + pullTime;
  // this is the actual fire rate as things stand now
  animation.Play("Armature|ArmatureAction0");
 //animation.Play("Take 0010");
 var timePulledBack = Time.time - pullStartTime; // this is how long the button was held
 if(timePulledBack > maxStrengthPullTime) // this says max strength is reached 
 timePulledBack = maxStrengthPullTime; // max strength is ArrowSpeed * maxStrengthPullTime
 var arrowSpeed = ArrowSpeed * timePulledBack; // adjust speed directly using pullback time
  //var arrow : Rigidbody = Instantiate(arrowPrefab,
    //           GameObject.Find("Target").transform.position, transform.rotation);
      //    Physics.IgnoreCollision(arrowPrefab.collider, transform.root.collider);
        //   arrow.rigidbody.AddForce(transform.forward * arrowSpeed); // adjusted speed
  }
 else
 falsePull = false;
 }
 }