# Kinderrechner: 2 Zahlen addieren

### Project description: 
This project serves to visualize the process for the implementation of a microgame. We use git / GitHub not only for version control, but also to display the individual tasks (see Projects pane) and for feedback (see Issues pane). 

## Problem descripton: 
A friend wants a web-based game for her daughter (elementary school) to practice adding two numbers.

The task is to use this requirement to independently create a microgame for browsers (WebGL, 960x600) with Unity 2D.
1. Concept including feedback
2. Breakdown of the project into individual steps (for programming using GitHub Projects)
3. Processing of individual steps
4. Release for testing (note in readme)

### WebGL Build:
https://hs-teaching.github.io/KinderRechner-Addieren2Zahlen/

### Development platform: 
Windows 10, Unity 2020.1.5f1, Visual Studio 2019

### Target platform: 
Desktop Browsers; WebGL reference resolution 960x600 

### Concept
![kinderaddierer-v3-vereinfacht-concept](https://user-images.githubusercontent.com/28704310/123055170-e497a300-d405-11eb-863f-65851a63aadf.jpg)

### Functional working
![kinderadd-functional](https://user-images.githubusercontent.com/28704310/123515937-d95ca580-d699-11eb-8c1a-10fe778aae99.JPG)

### First prototype
![kinderaddierer-v3-vereinfacht-concept](https://user-images.githubusercontent.com/28704310/123055170-e497a300-d405-11eb-863f-65851a63aadf.jpg)

### Necessary setup/execution steps: 
WebGL Export: be sure to disable in the player settings the compression Format. https://github.com/HTL-SBG/FAQIssuesUnityVSGitGitHub/issues/11

In Unity installed via Package Manager: 2D Sprite (for slicing sprites)

### Third party material: 
- Font: https://fonts.google.com/specimen/Kirang+Haerang?preview.text=Susanne&preview.text_type=custom#standard-styles
- Sound Button Press: https://freesound.org/s/171697/
- Sound Calc correct: https://freesound.org/s/320887/
- Sound Failure: https://freesound.org/s/342756/
- Quill shader: https://quill.fb.com/developers/how-to-use-quill-fbx-in-unity
- Sound End scene enter: https://freesound.org/s/521644/

### Limitations: 
- The game works functionally, the visual design has yet to be done. 
- If the child must enter SummandA and SummandB and the answer is incorrect, the values for the correct answers are not based on what the child entered. This should be fixed in a future release.
- Error messages concerning Timeline Animator SerializedObjectNotCreatedExeption. Program is running with errors, will be fixed in the next iterations.

### Lessons Learned: 
- using ScriptableObject
- using todo-list/issues for programming workflow
- using enums
- using switch/case statements

Copyright by smeerws
