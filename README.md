# MAPL VRTIGO README

**[Overview Video and Quick Tutorial](https://youtu.be/als9t3aj5yU)**


## What the Project Does

Sudden-onset dizziness or vertigo is one of the most challenging stroke symptoms to diagnose, as only a small fraction of the nearly 4% of Emergency Department visits for new-onset vertigo are stroke-related. Current diagnostic approaches depend on clinical expertise and costly imaging, leading to frequent misdiagnoses, particularly in settings lacking neurological specialists. To address this, the MAPL lab developed a VR-based assessment system (VRITGO) that uses immersive technology with eye and head tracking to objectively distinguish between central (stroke-related) and peripheral causes of vertigo. This scalable, low-cost tool aims to improve stroke diagnosis in emergency settings, even when neurologists are unavailable. In addition to building out 5 core diagnostic tests, VRTIGO has a control panel for the physcian for live monitoring. All data is written and saved as text files for further analysis.

## What You Need
- Unity Game Engine and core files - where VRTIGO is stored and running from
- Meta Quest Pro (MQP) - critical to run the program and record data
- Laptop or PC - should be powerful enough/ have a good graphics card to run the Unity programs and connect to Meta Link. Helpful to be connected to power.
- Development Cord - to connect the MQP to the Laptop

## Core Diagnostic Tasks
1. **Head Stability Test**
Participants fixate on a stationary virtual point in space while the VR headset captures movements in head and trunk position. Subtle sway patterns are analyzed to assess postural stability and balance control—key indicators of vestibular function.

2. **Bucket Test**
This virtual replication of the traditional "bucket test" challenges participants to rotate a line until it appears perfectly vertical, without any contextual visual cues. The test provides insight into the participant's subjective visual vertical (SVV), often disrupted in cases of vestibular dysfunction or brainstem stroke.

3. **Nystagmus Detection**
A moving visual target guides participants' gaze while the system uses built-in eye tracking to detect signs of nystagmus—rapid, involuntary eye movements that can indicate vestibular pathology or central neurological issues.

4. **Test of Skew**
Modeled after the clinical cover-uncover test, this task alternately occludes each eye to detect vertical misalignment (skew deviation). It helps reveal disconjugate gaze patterns that may point to central nervous system involvement.

5. **Dysdiadochokinesia (Finger Tapping Test)**
In this motor coordination task, participants rapidly pinch their thumb and index finger together in quick succession. The VR system captures the timing and rhythm of these movements, which can highlight cerebellar dysfunction when irregular or slowed.

## Setting Up the Scene
1. Open Meta Link and connect your MQP to your PC. Ensure that it says that your MQP is connected; this is the only way in which you can stream the VRTIGO Unity file in real time.
2. Open Unity and the corresponding VRTIGO Files. Please use the same version of Unity as used in the original files - it should be version 2022.3.45f1
3. In your Unity project, open the StartMenu Scene


Core plug-ins for VR set up: Meta XR All-in-One SDK and Occulus XR Plugin


## Getting Started:
The code is built to work with VICON motion capture and BERTEC treadmill. The game will not run on your end without proper equipment, but the unity project may still be accessible.

To get started with the Motion Labs VR Gamification Project, follow these steps:

1. **Clone the Repository**: Use the following command to clone the repository to your local machine.
    ```bash
    git clone https://github.com/yourusername/motion-labs-vr-gamification.git
    ```

2. **Install Dependencies**: Navigate into the project folder and install required dependencies. Ensure you have Unity, any motion capture drivers, and EEG software integrated with the system.
    ```bash
    cd motion-labs-vr-gamification
    # Follow the setup instructions for your specific hardware/software configuration
    ```

3. **Run the Program**: Launch the Unity project, connect your motion capture and EEG devices, and initiate the VR program to begin a session.

## Maintainers and Contributors

This project is co-created by **Joshua Jones** and the Motion Labs team at [University of Rochester](https://www.rochester.edu/). All content belongs to Motion Labs.

---

