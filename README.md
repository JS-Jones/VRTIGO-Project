# MAPL VRTIGO README

**[Overview Video and Quick Tutorial](https://youtu.be/als9t3aj5yU)**

**[VRTIGO Article](https://www.library.rochester.edu/about/news/vr-emergency-department)**


## What the Project Does

Sudden-onset dizziness or vertigo is one of the most challenging stroke symptoms to diagnose, as only a small fraction of the nearly 4% of Emergency Department visits for new-onset vertigo are stroke-related. Current diagnostic approaches depend on clinical expertise and costly imaging, leading to frequent misdiagnoses, particularly in settings lacking neurological specialists. To address this, the MAPL lab developed a VR-based assessment system (VRITGO) that uses immersive technology with eye and head tracking to objectively distinguish between central (stroke-related) and peripheral causes of vertigo. This scalable, low-cost tool aims to improve stroke diagnosis in emergency settings, even when neurologists are unavailable. In addition to building out 5 core diagnostic tests, VRTIGO has a control panel for the physcian for live monitoring. All data is written and saved as text files for further analysis.

## What You Need
- Unity Game Engine and core files - where VRTIGO is stored and running from
- Meta Quest Pro (MQP) - critical to run the program and record data
- Laptop or PC - should be powerful enough/ have a good graphics card to run the Unity programs and connect to Meta Link. Helpful to be connected to power.
- Development Cord - to connect the MQP to the Laptop

## Core Diagnostic Tasks
1. **Bucket Test**
This virtual replication of the traditional "bucket test" challenges participants to rotate a line until it appears perfectly vertical, without any contextual visual cues. The test provides insight into the participant's subjective visual vertical (SVV), often disrupted in cases of vestibular dysfunction or brainstem stroke.

2. **Nystagmus Detection**
A moving visual target guides participants' gaze while the system uses built-in eye tracking to detect signs of nystagmus—rapid, involuntary eye movements that can indicate vestibular pathology or central neurological issues.

3. **Dysdiadochokinesia (Finger Tapping Test)**
In this motor coordination task, participants rapidly pinch their thumb and index finger together in quick succession. The VR system captures the timing and rhythm of these movements, which can highlight cerebellar dysfunction when irregular or slowed.

4. **Test of Skew**
Modeled after the clinical cover-uncover test, this task alternately occludes each eye to detect vertical misalignment (skew deviation). It helps reveal disconjugate gaze patterns that may point to central nervous system involvement.

5. **Finger-to-Target Test**
Based on a previous research study from the MAPL lab. The focus is to learn how participants focus their body to hand perception and assess dysmetria and spatial coordination in space

6. **Head Stability Test**
Participants fixate on a stationary virtual point in space while the VR headset captures movements in head and trunk position. Subtle sway patterns are analyzed to assess postural stability and balance control—key indicators of vestibular function.

## Setting Up the Scene/Project
1. Open Meta Quest Link and connect your MQP to your PC. Ensure that it says that your MQP is connected; this is the only way in which you can stream the VRTIGO Unity file in real time.
2. In your headset, make sure you click on the notification called "USB Debugging" and then enter Quest Link via the settings. You should be in a white room after you click this.
3. In Meta Quest Link, go to settings. In the "General" Tab, ensure that the "OpenXR Runtime" is set so the meta quest link as act. Then in the "Beta" Tab, enable "Developer Runtime Features" and all the options below this. If you don't see this, then you might need to log in with a different account - it doesn't appear when I used my University of Rochester account.
4. Open Unity and the corresponding VRTIGO Files. Please use the same version of Unity as used in the original files - it should be version 2022.3.45f1
5. In your Unity project, open the StartMenu Scene in the project explorer. You will need to set up your screen where you can see 2 "Game" Displays. If you right click on the "Scene" or "Game" tab on the top of your screen, you can press "Add Tab" and then "Game".
6. You can drag your game tabs to be side by side. In your first game tab, there will be an option to change the "Display" (right under the tab). Ensure that one game tab says "Display 1" and the other says "Display 2". Display 1 is what the participant will see and this will adjust based on how they move their head with the headset. Display 2 is the Experimenter Control - you can control what tests to use and how data is collected. See **Controller Menu** for more info on this.
7. You should be able to click play right after this and run the system. If there are any issues with the VR system, try going to Edit > Project settings > Meta XR and check the Checklist for any issues (dont need to worry about the recommeded items). Please consult with the video at the start of this document for any questions.
8. Place the controllers and headset on the participant. On the the experiment side, enter the participant's name and click "Start/Next Step" to begin.
9. For Specific outlines of each tests, please see **Test Code**

## Code
---------------------------------------------------- **CODE/Technical Stuff** -----------------------------------------------------------

Just a headsup, I apologize for not commenting each code (was too focused on making it work).
- When you have a new scene for the game (only when you add a whole new test), you may need to build the project again while connected to the headset: File --> Build Settings --> Android --> change Run Device to the headset --> Build and Run. This will usually result in an Error but as long as it runs, then it shoudl run if you run the game in Unity.
    - **NOTE:** When you load this game into a new headset for the first time, you will need to do this

## VR Systems

VRTIGO uses a combinations of plugins. Core plug-ins for VR set up: Meta XR All-in-One SDK and Occulus XR Plugin. If there are issues with VR setup, it may be worth looking into whether these are functional via Windows > Package Manager. You may need to update these packages, but keep an eye out if any methods are changed. In General, I reccomend not changing any code directly with the VR Rigs. Try to solve your issue using the inspector before touching the code, or at least save a backup.


All Scenes and tests have the "[BuildingBlock] Camera Rig" gameobject. This gameobject is different for every scene, based on that test's needs. For example, Finger Tapping will have hand tracking enabled, whereas Bucket Test will focus solely on controller user. You can edit the properties of this using the inspector tab. 


**Notable Exceptions**

- The Test of Skew uses a regular "XRRig". It doesn't necessarily integrate with Meta's OVR SDK, but we use a combination of Occulus's Rig with OVR's Eye gaze tracking. This allows us to cover each eye indepenently (something you can't do with just the OVR SDK by itself), but still record eye movement. We may need to look into this further to ensure that eye tracking is accurate using this method.


## Controller Menu

The controller menu was implemented so the experimenter can control the program without needing to take the headset off after every test. It also allows for specific and easy to use data collection and correction when needed. 
- Reload Scene: If you ever need to rerun a test or something breaks in the scene
- Disable/Show Tutorials: Some tests have a tutorial like the bucket test and test of nystagmus. You can turn off these tutorials after the patient has read through them.
- Recenter Player: Sometimes the screen is not right in front of the user. In this case, this button should help recenter the screen. If this doesn't work, you can also use the Meta button on your right hand controller to recenter while the headset is on the participant.
- Skip Test: Moves on to the next test, following the same order as outlined in **Core Diagnostic Tasks**
- Textbox/Participant Name: Enter the patient ID or participant's name. This is how the data will be stored on the PC after each test.
- Start/Next Step: Starts the test and progresses through the system.
- Running Indicator: Shows when the test is working and in progress
- Recording Indicator: Shows when the test is also recording data. Some tests have trial periods where data is not recorded, this helps distinguish these trials.

## Controller Menu Code and Core Game Loop Code

In your Heirarchy, you can find the Controller Menu gameobject as "ControllerScreen. Each of the buttons inside this game object has its own code associated with its function. The core code that controls the progrssion of the test is in the "Start" button and called "StartSystem.cs". 

**StartSystem.cs** --> MAIN MANAGEMENT CODE FOR ALL THE TESTS

In the method "Start()" we record the player name as written in and saves it so that it is consistent while switiching scenes for each tests


In the Method "StartProcedure()" you can see the general game loop which progresses from startmenu > buckettest > TestofNystagmus > FingerTapping > TestofSkew > FingerToTarget > HeadStability. In each of these If statements, it follows a "phase" value of Tutorial, Round 1 (up to Round 3), and then Final. Please see **Test Code** for specific outlines on each tests. In each phase, we find a gameobject in the scene called "SceneCode". This is the life for each test, and is different for each scene. It basically works by Disabling and Enabling the gameobject every phase so that the code runs multiple times.


The Update() method just changes the color of the recording and running UIs based on the value of the variables.


In the method "DelaySceneCodeChange()" we change the phase value from tutorial to the different round values.


Example:
1. At around line 50, would be the first test - the Bucket Test managment core. It first checks if "SceneCode" is present in the scene (which should either be a gameobject with the core code of each test inside of it, or parent it in some way. Then there are 3 nested "IF Statements" - these work from bottom ot top. So the first phase should always be set at Tutorial. That means the bottom of the nested if statements runs --> it sets the SceneCode object as true in that specific test, and turns the "Running" variable to True (this is usually a check that the SceneCode makes to ensure that the experimenter has pressed start. Additionally, the "Recording" variable is still set as False, so that means no data is recorded which is what we want for the tutorial or test phase while the patient gets used to the system). Lastly, we change the phase to "Round1", so that the next time the experimenter presses the "Start/Next Step" Button, the second nested "IF statement" is triggered.
2. When the second nested if statement is triggered, it runs the DelaySceneCodeChange() function which makes sure that we disable SceneCode and then Enable it again (All the scenecode uses "OnEnable()" functions so that it resets whenever we disable and enable). We also make sure to Turn the recording variable to true BEFORE we enable the SceneCode - this is important, otherwise SceneCodes in each test still assumes that recording is false - we want to make sure that data is being recorded. Laslty, it moves phase 1 to phase 2, then to phase 3, and then to phase "Final.
3. Step 2 repeats until Phase "Final is reached"
4. Phase final activated the first nested "IF statement" which first resets the phase to "Tutorial (to prepare for the next test), saves the playername that we entered so we can just move it eaily, sets recording and running variables to false, and loads the next scene


NOTE: Step 2 is the most variable - not every test needs to be recorded/reset 3 times. For example, HeadStability Test doesnt need a tutorial or test phase, so as soon as the "Start/Next Step" button is clicked, the nested if statement for phase "tutorial" is triggered --> recording and running are true, set phase to "Round1" and the scene code is set as active. The next click will make the variables off, change the phase back to "tutorial" and move to the next test. So the Above is very much dependent on the type of test and the code involved in the SceneCode. The specifics of each test can all be found below: 

## Test Code


### BucketTest
The bucket test involves placing a bucket with a straight line inside over a person's head and asking them to align the line with what they perceive as vertical. This test helps assess spatial perception and can reveal signs of vertigo or vestibular dysfunction by detecting a person's perceived vertical tilt. In stroke analysis, abnormal results may indicate damage to brain regions responsible for balance and spatial orientation, helping differentiate between peripheral and central causes of dizziness.


Sequence of Events (as written in StartSystem.cs): Test Phase (Data is not recorded), Phase 1, 2, and 3 (data is recorded). 


Circular UI Rotation
The circularUI GameObject represents a rotatable visual reference (the line in the middle of the bucket). The user can adjust its Z-axis rotation using the right thumbstick X-axis:
```
float joystickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;
circularUI.transform.Rotate(0f, 0f, -joystickInput * rotationSpeed * Time.deltaTime);
```

Adjust the speed of this rotation using the rotationSpeed variable, e.g.:
```
public float rotationSpeed = 50f; // Speed of rotation adjustment
```

Random Start Orientation: When enabled, the circularUI begins with a random Z rotation between 0° and 360°, simulating perceptual disorientation:
```
float randomZRotation = Random.Range(0f, 360f);
circularUI.transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
```

When startMenu.recording is true, the script logs data to a session-specific folder:
```
path = Path.Combine(Application.persistentDataPath, "BucketTest", StartSystem.playerName, timestamp);
```
Files:
HeadPosition.txt – Logs X, Y, Z position per frame
HeadRotation.txt – Logs Euler angles of head rotation
BucketAngle.txt – Logs the circular UI’s normalized Z rotation (angle difference)
TimeStamps are included in all files and in all tests.

File logging is handled in Update():
```
File.AppendAllText(headposfile, headsetPosition.x + ", " + headsetPosition.y + ", " + headsetPosition.z + "\n");
```

Angle Normalization: To simulate subjective alignment with vertical, the script normalizes the Z-rotation of circularUI into a 0–90° range:
```
Angle.text = "Angle Difference: " + normalizedAngle.ToString("F2") + "°";
```
This helps maintain consistent evaluation of perceptual accuracy across all trials.



### Test of Nystagmus

The horizontal gaze nystagmus test involves moving a visual stimulus, like a finger, side to side across a patient’s field of vision to observe for involuntary, jerky eye movements. In vertigo, especially of peripheral origin like vestibular neuritis, nystagmus typically has a consistent direction and is often accompanied by dizziness. In stroke, particularly in the brainstem or cerebellum, nystagmus may change direction or be vertical, helping distinguish it from benign vertigo and signaling a potentially serious central cause. 

In this test, the smiley face moves across the scene and we ask the patient to follow the smiley face without moving their head.

Order of events: Experimenter clicks Start/Next step ---> Test phase--> Experimenter clicks Start/Next step--> record phase

The **scene code** basically activates the Movebetweentwotransform code. It also: 
- Tracks left and right eye rotation using OVREyeGaze
- Tracks headset position and rotation using centerEyeAnchor
- Logs all data to .txt files during active recording sessions
- Organizes recordings into timestamped folders under Application.persistentDataPath
- Enables stimulus movement via a MoveBetweenTwoTransforms component when the session is running
- Converts all rotation data to the range [-180°, 180°]

Output Files

When startMenu.recording is enabled, the script creates and writes to the following files:

/TestOfNystagmus/[PlayerName]/[Timestamp]/
- LeftEyeRotation.txt      // Left eye X, Y, Z Euler angles
- RightEyeRotation.txt     // Right eye X, Y, Z Euler angles
-  HeadPosition.txt         // Headset world position
- HeadRotation.txt         // Headset rotation (Euler angles)

Each line in the files includes the current phase value from the MoveBetweenTwoTransforms script, allowing easy segmentation of data by stimulus condition.

How It Works
On OnEnable():
- Finds the OVRCameraRig and sets centerEyeAnchor
- Creates a session folder and initializes output file paths if recording is active
- Enables MoveBetweenTwoTransforms if the session is running

On Update():
- Reads left/right eye rotation and headset position/rotation
- Converts all rotations to [-180°, 180°]
- Appends all data to their respective .txt files if recording is active

The **MoveBetweenTwoTransform Code**

The smiley face in the scene is located inside the Camera Rig in the CenterEyeAnchor (this is what allows the face to move with the headset). Inside the smiley face is also the Move between two transform code. This code basically works by moving the smiley face between the all the Point Objects. So it moves all the way to the left (Point E) then all the way to the right (point B) and then loops through all the points in a "H-shape". This repeats 1 time during the test phase, and then 3 times during the actual recording phase. You can change where the smiley face goes by adjusting these Point locations in the game space.
```
B → C → D → B → E → F → G → E → A (then repeat)
```
End Condition. Automatically stops when:
- counter > 2 if recording
- counter == 1 if not recording

The Phase value is what is used by the scene code when its tracking the data, so that we know at which phase the smiley face is at.

Each call to MoveToPoint() includes a delay: You can change how long the Sphere pauses after reaching each point by adjusting the delay parameter in each call.

```
yield return MoveToPoint(target, moveSpeed, delayInSeconds);
```


### Finger Tapping Test

The finger tapping test assesses motor speed and coordination by having the patient rapidly tap their index finger and thumb together or tap their finger repeatedly against a surface. In conditions like stroke or Parkinson’s disease, finger tapping may be slowed, irregular, or diminished due to motor pathway or basal ganglia dysfunction. Impaired performance can also indicate cerebellar damage, which affects fine motor coordination and timing.

Make sure you turn off the Tutorial to see the counter. Every single time the index and thumb touch, the counter should go up. 

Order of events: Experimenter clicks Start/Next step --> Test phase (left hand) --> Experimenter clicks Start/Next step --> Record Phase (left hand then right hand after clicking start again)

The FingerTap script tracks finger pinch gestures using OVRHand on Oculus VR devices. It counts individual finger taps during timed phases, logs data to local files, and displays real-time feedback via UI elements. This is commonly used for motor control experiments or gesture-based interaction tasks.


Detects individual finger pinches (excluding thumbs) on either the left or right hand
- Tracks and displays a live tap counter and countdown timer
- Records timestamped tap events, finger name, and headset position/rotation to text files


Supports 3 sequential phases:
- Tutorial (Left hand, 10 seconds)
- Round1 (Left hand, 15 seconds)
- Round2 (Right hand, 15 seconds)

The script detects pinches using:
```
hand.GetFingerIsPinching(finger)
```
Each successful pinch (excluding thumbs) increments a tap counter


A short cooldown is applied to avoid duplicate counts:
```
public float pinchCooldown = 0.005f; // Adjust this to change sensitivity
```

Output Files
When StartSystem.recording is enabled, the script writes to:
/FingerTap/[PlayerName]/[Timestamp]/
- FingerTapCounter.txt  // Timestamp, finger name, tap count
- HeadPosition.txt      // X, Y, Z position of headset at each tap
- HeadRotation.txt      // X, Y, Z Euler rotation of headset at each tap


Each line in FingerTapCounter.txt looks like:
```
2025-04-19 12:45:33.456,Left-Index,23
```

recording state: phase name (e.g., "Tutorial", "Round1", "Round2")

Phases are initiated in SetPhase(string newPhase), and a countdown timer is handled via a coroutine:
```
StartCoroutine(StartCountdown(15f)); // Round duration
```
You can change the duration of each phase here



### Test of Skew

This test asses how each eye adjusts or compensate when a stimulus disappears from the other eye. In our system, there is a smiley face that is present in both eyes. After about 5 seconds, it disappears from the left eye, but is still present in the right eye. This reappears and then does the same for the other eye after 5 seconds. This whole cycle repeats 2 times. 

Order of events: Experimenter clicks Start/Next step --> (no test phase) Smiley Face visible in both eyes --> visible in only right eye --> visible in both --> visible in only left eye --> repeat

Big Point here is that using OVR camera Rig doesn't allow you to assign specific scenes to specific eyes, so instead we are using just a regular XR rig and combining it with the OVR eye tracking to record data. How this works is that the Smiley Face present is actually 2 Smiley Face one for the left eye and one for the right eye. Each smiley face is given a mask layer for left and right and then the cameras are set to not render the other side. Here are the specific of the camera rig:

In the XRRig --> Camera Offset --> LeftEyeCamera --> In properties: Target Eye set to Left --> Culling Mask set to LeftEyeOnly (Or everything but the RightEyeOnly)
In the Left Smiley Gameobject --> In properties: Layer set to LeftEyeOnly

^ Do the same with the other eye camera and the other smiley gameobject

The system works by effectively enabling and disabling the corresponding smiley gameobject based on which eye is supposed to be visible. There should be a code called "Skew Display Rotation" located inside the SceneCode gameobject:


LeftObject1 and RightObject2 are the "SmileyRight" and "SmileyLeft" eye each located in the coresponding camera.


Ensures that the lefteyetracking adn righteyetracking are enabled based on the ovr camera rig, and that the startmenu recording variable is true. We create a new "phase" varaible for this test to always know which set of smiley faces are active. So the phases go in this order
```
Both --> LeftActive --> BothAfterLeft --> RightActive --> BothAfterRight --> None
```

In each of these pahses we just change whether the leftobject or rightoject are active and then change the activeobject/phase values.


Output Files:
/TestOfSkew/[PlayerName]/[Timestamp]/
- LeftEyeRotation.txt  //  X, Y, Z rotations of left position, Active Object (which smiley face is visible)
- RightEyeRotation.txt  // X, Y, Z rotations of right position, Active Object
- HeadPosition.txt      // X, Y, Z position of headset at each tap, Active Object
- HeadRotation.txt      // X, Y, Z Euler rotation of headset at each tap, Active Object


### Finger to Target (just a heads up this might not be completely up to date with the most recent iteration of VRTIGO)

This test is built to asses one's mind to body perception. Randomly, the user can see or wont see their hand and target. They are then asked to reach out to a point in space represetned by the target. This test is used to assess dysmetria and spatial coordination in space.

Order of events: player chooses their dominant hand --> player reach out right in front of them and pinches finger to determine maximum lenght --> Experimenter clicks Start/Next step --> player returns to center point (Square right in front of them) and start testing trial --> 5 targets appear one at a time in front of them after returning to center point while their hand is visible --> 5 targets appear one at a time and the player is asked to reach for them without seeing their hand or the target --> Goes into the actual recording phase --> the system randomly assigns visible or invisible inicators and does 10 trials with the dominant hand --> the system randomly assigns visible or invisible inicators and does 10 trials with the other hand
1. Hand Detection (Left or Right)
2. Calibration Trial (Trial 1)
3. Practice Trials (Trials 2–10) — Always with the same hand.
4. Recorded Trials (Trials 11–20) — Randomized visibility.
5. Switch Hands Automatically
6. Recorded Trials (Trials 21–30) — With flipped visibility.


In the SceneCode object, there should be a script called "FingerTargetCode"


Key Variables
- instructionText, trialText, visibilityText – UI elements
- fabLeft, fabRight – Hand prefabs
- leftBall, rightBall – Proximity detection objects
- cube, cubeblue – Reset/start triggers
- activeHand, activeFab – Currently used hand
- trial, phase, calibrationComplete – Trial control
- randomizedVisibilityList, flippedVisibilityList – Trial visibility lists


Lifecycle
- Start(): Initializes camera rig, detects hands, creates log files
- Update(): Manages phase progression and data logging
- RunCalibrationTrial(): Captures reach distance using a pinch gesture
- RunPracticeTrials(): 9 unlogged visible trials with visual feedback
- RunRecordedTrials(): 20 logged trials with randomized visibility
- EvaluateReachAfterDelay(), EvaluateAndLogReachAfterDelay(): Measure error and log results
- LogStandardData(), LogResetReturn(): Write per-frame and event data to files


NOTE: at the begining of the **Start() **method, I identify the OVR rig's left and right hand anchors, but won't be am not using these because thier location in space is different than that of the targets which makes it confusing. Instead, I use the left and rigth hand prefabs that I manually assigned which I thought worked pretty well. The Con of using this approach over OVRs direct rig is that I cant target the tip of the index finger or specific parts of the hand. The start function also has a small bit where a list is generate dfor which trials will the hand be visible and which ones will be invisible. This will be used in determing visibility later.


In the **Update() **function we want to check if handedness (the calibration for which is their dominant hand) is complete. If not then it waits till the patient reaches out their hand to the left or right and writes it to the handedness.txt file. It checks which hand by comparing the hand prefabs position to the left or right ball position. 


After Handedness is selected, the experimenter has to click "Start/Next Step" to continue the test and turn the StartMenu "Recording" variable to true (Check the section above on "Controller Menu" for more info) to proceed. Once conditions are met, the left and right balls are set false, the corresponding hand selected is set as active while the other hand is turned off to avoid any confusion in touching the targets. The Varaibles "ActiveHand" and "ActiveFab" are assigned to the the enabled hand. 


the method LogStandardData() is called in the Update() method to make sure to log head,eye, and hand data at every frame. After that, there are 3 "IF statements" if the trial number is 1, then the RunCalibrationTrial() is run. if the trial number is between 2 to 10, then its just a test phase and no data is recorded here. If the trial numbers are between 11 and 30, then the RunRecordedTrials() is run. To change the number of trials see the below section on that point.


**RunCalibrationTrial():**

This method runs the initial calibration step, where the participant reaches out and pinches with their fingers. It captures the reach distance (z-axis difference) between the hand and head, which is later used for target spawning and evaluation. Automatically triggered when trial == 1 in the Update() loop.


Key Logic:

Detects if the user is pinching with the index finger:
```
if (activeHand.GetFingerIsPinching(OVRHand.HandFinger.Index)) { ... }
```
Calculates the reach distance:
```
zDistance = handPos.z - headPos.z;
```
Only records calibration once the hand is sufficiently extended:
```
if (zDistance >= 0.1f && !calibrationComplete) { ... }
```
Enables the green reset cube after calibration, which the user must touch to begin trials:
```
cube.SetActive(true);
```

NOTE: If you wanted to add alternations or add an offset for shoulder distance, then this would be hte place to do it by adjusting the "reachDistance" or "shoulderOffset" variables after doing the pinch. You might need to run another form of calibration to calculate this for every person - but right now its basing the distance and location off of the headset.


**RunPracticeTrials()**

Runs trials 2–10. During these, the participant practices reaching toward a ball (visible only in trials 2–5) and triggering an effect when crossing the target z-threshold. Triggered when trial >= 2 && trial <= 10 in Update().


Key Logic:

There are 2 phases, the reaching and the resetting phase. during the reaching phase, there will be a target present which is assigned to the variable called "currentBall".

Ensures the hand is visible only for the first 5 practice trials:
```
SetHandVisibility(trial < 6);
```
Detection logic for when the hand reaches beyond the ball:
```
if (handPos.z > currentBall.transform.position.z && !evaluating)
```
If true, Triggers the evaluation with a brief delay:
```
StartCoroutine(EvaluateReachAfterDelay(0.01f));
```
Once the evaluation is done, and the user returns to the cube:
```
if (phase == Phase.Reset) { ... }
```
Increments the trial and spawns a new ball. at Trial 10, set the hand visibiliyt to true and move to the recorded phase.:
```
trial++;
...
ShowRandomBall();
```

**RunRecordedTrials()**

Executes the actual experiment trials (trial 11–30), logs all relevant trial data, and manages the visibility of the hand using randomized lists. Also manages switching hands at trial 21. Triggered when trial >= 11 && trial <= 30 in Update()

Uses randomizedVisibilityList to determine whether the hand is visible in these trials:
```
if (trial >= 11 && trial <= 20) { ... }
```
Uses flippedVisibilityList for the second hand's visibility control
```
else if (trial >= 21 && trial <= 30) { ... }
```
Same reach detection logic as in practice (line ~483)
```
if (handPos.z > currentBall.transform.position.z && !evaluating) { ... }
```
if true, to record hand, head, eye, and error data:
```
StartCoroutine(EvaluateAndLogReachAfterDelay(0.01f));
```
in the reset phase section Switches hands right after trial 20
```
if (trial == 21 && !flippedHands)
```
This then switches the active hand fab and creates a new visibility list.


**EvaluateReachAfterDelay(float delay)**
Temporarily pauses input evaluation, shows a success effect if the hand reaches the ball, hides the ball, and moves to the reset phase. Used during practice trials.

**EvaluateAndLogReachAfterDelay(float delay)**
Same as EvaluateReachAfterDelay, but also logs detailed trial data (positions, error, visibility, etc.) to a file. Used during recorded trials. Explosion effects are triggered here by instatiating them from a prefab.

**LogResetReturn()**
Called when the user touches the green cube after a trial. Logs the return time, increments the trial counter, and either spawns the next ball or ends the session.


**ShowRandomBall()**
Randomly positions the ball in one of several preset locations for each new trial. At the beginning of each new trial (from RunPracticeTrials(), RunRecordedTrials(), and LogResetReturn()).

Selects a random index and applies the shoulder offset to compute final position
```
int index = UnityEngine.Random.Range(0, ballPositions.Length);
Vector3 spawnPosition = new Vector3(...);
```
Moves the ball and shows it
```
currentBall.transform.position = spawnPosition;
currentBall.SetActive(true);
```

Trial Structure:
| Phase             | Trial # Range | Description                                 |
| ----------------- | ------------- | ------------------------------------------- |
| Calibration       | 1             | Measures reach distance and shoulder offset |
| Practice Trials   | 2–10          | Visual feedback, visible hand               |
| Recorded Trials 1 | 11–20         | Mixed visibility (randomized), same hand    |
| Recorded Trials 2 | 21–30         | Mixed visibility, opposite hand             |


Output Files:
/VisInvisStability/[PlayerName]/[Timestamp]/
- Handedness.txt     // Results on which hand they choose duing callabration
- HeadPosition.txt    // X, Y, Z
- HeadRotation.txt    // X, Y, Z
- LeftHandPosition.txt    // X, Y, Z in game space recorded always/per frame. 
- RightHandPosition.txt    // X, Y, Z in game space recorded always/ per frame.
- LeftEyeRotation.txt    // X, Y, Z
- RightEyeRotation.txt    // X, Y, Z
- Trails.txt     // This one might be different or split into visible/invisible trails. Only writes when a target is hit (whether the reset block or the target.
                 // Time stamp, trial number, phase name, is the target/hand visible, which hand is being used, that hands position, the targets position, error %, Head position, Left                     eye rotation, right eye rotation


**Changing the Distance of the targets:**
In the method "SpawnRandomSphere()" at the bottom of the code
```
float distance = zDistance - 0.05f; // You can remove the subtract 0.05f so that the ball just spawns exactly where the user pinched.
```

**Changing the Number of Trails:**

This is a bit messy because this was done last minute, but you might want to assign a variable at the start for these numbers later on. To change the number of trails to 25 recorded reaches per arm (all changes are in the comments):

Trial Structure:
| Phase             | Trial # Range | Description                                 |
| ----------------- | ------------- | ------------------------------------------- |
| Calibration       | 1             | Measures reach distance and shoulder offset |
| Practice Trials   | 2–10          | Visual feedback, visible hand               |
| Recorded Trials 1 | 11–35         | Mixed visibility (randomized), same hand    |
| Recorded Trials 2 | 36–60         | Mixed visibility, opposite hand             |

In Start(): 
```
for (int i = 0; i < 5; i++) visList.Add(true); // Change 5 to 13 - creates 13 instances of visible hand
for (int i = 0; i < 5; i++) visList.Add(false); // Change 5 to 12 - creates 12 instances of invisible hand
```
In Update():
```
if (trial == 1)
    {
        RunCalibrationTrial();
    }
    else if (trial >= 2 && trial <= 10)
    {
        RunPracticeTrials();
    }
    else if (trial >= 11 && trial <= 30) // Change 30 to 60  - will record data for total of 60 trials
    {
        RunRecordedTrials();
    }
```
In RunRecordedTrials():
```
 if (trial >= 11 && trial <= 20) // Change 20 to 35
    {
        int visIndex = trial - 11;
        if (visIndex >= 0 && visIndex < randomizedVisibilityList.Count)
        {
            SetHandVisibility(randomizedVisibilityList[visIndex]);
        }
    }
    else if (trial >= 21 && trial <= 30) // Change 21 to 36, and change 30 to 60
    {
        int visIndex = trial - 21; // Change 21 to 36
        if (visIndex >= 0 && visIndex < flippedVisibilityList.Count)
        {
            SetHandVisibility(flippedVisibilityList[visIndex]);
        }
    }
....
    else if (phase == Phase.Reset)
        {
            ....

                if (trial == 21 && !flippedHands) // Change 21 to 36
                {
                    // Flip handedness
                    flippedHands = true;

                    ....

                    List<bool> visList = new List<bool>();
                    for (int i = 0; i < 5; i++) visList.Add(true); // Change 5 to 13
                    for (int i = 0; i < 5; i++) visList.Add(false); // Change 5 to 12
                    System.Random rng = new System.Random();
                    int n = visList.Count;

                    ....

                if (trial <= 30) // Change 30 to 60
                {
                    instructionText.text = $"Trial {trial}";

                   ....
                }
            }

        }
    }
```
In EvaluateAndLogReachAfterDelay():
```
 private IEnumerator EvaluateAndLogReachAfterDelay(float delay)
    {
       ....

        if (trial >= 11 && trial <= 30) // Change 30 to 60
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            ....

            bool isVisible = trial <= 20 // change 20 to 35
                    ? randomizedVisibilityList[trial - 11] 
                    : flippedVisibilityList[trial - 21]; // change 21 to 36
                ....

    }
```
In LogResetReturn():
```
If (trial < 11 || trial > 30) return); // change 30 t0 60
```



### Head Stability

This test focuses on determining torso sway while looking at a target. Imagine there is a dot on the wall and we want to see how a person moves when they stand or sit upstraight and just look at the target. We are using a smiley face locked in space meanings that it doesnt move from its spot even if the patient moves their head. In addition to this, we want to observe whether this changes with how the environment changes. The 3 environment/backgrounds we are looking at are: Full black, passthrough (real world), and unity landscape scene.

Order of events: (no test phase) player looks at target --> Experimenter clicks Start/Next step --> 10 seconds on full black --> 10 seconds on passthrough --> 10 seconds in landscape.

There is code called "CameraBackgroundChanger" is in the SceneCode gameobject which handles the background changing adn the data recording. the Update() methods waits till running and recording are set active in the StartMenu (done by click "Start/Next Step") then changes the background every 10 seconds by changing the camera's background color and clearflags. The main camera is the centerEyeAnchor. 

Output Files:
/HeadStability/[PlayerName]/[Timestamp]/
- HeadPosition.txt    // X, Y, Z
- HeadRotation.txt    // X, Y, Z
- LeftEyeRotation.txt    // X, Y, Z
- RightEyeRotation.txt    // X, Y, Z


---

## Maintainers and Contributors

This project is co-created by **Joshua Jones '25** and the MAPL Labs team at [University of Rochester](https://www.rochester.edu/). All content belongs to [MAPL labs](https://www.urmc.rochester.edu/labs/movement-and-plasticity-lab).
