// To give luzlifter functionality
// first create a folder in items ==> luz ==> lifter folder titled level + phase + item number with underscore in between.
// put the two scripts in that folder.
// =================== IDI =====================
// 1. include luzlifter object into scene.
//  This IDI does not need its own Script. Simply add the Lifter script to the object.
//  1b. Add animation as component to IDI
//  - add controller to animation
//  1c. add approprate box colliders
// =================== CDI ===================== 
// 2. include powerconnection box into scene.
//  2a. create new c# script titled PowerConnection_LuzLifter + level + phase + item number with underscore in between.
//  for example if I were adding a lifter to level 1 phase 3 and it was the second lifter, my script name would be PowerConnection_LuzLifter_01_03_2
//  - make new script class extend PowerConnection_LuzLifter.
//  - inlude lifter as gameobject in luzlifter slot in editor.
//  - Add new script as component to IDI
//  1c. add approprate box colliders


// test it


