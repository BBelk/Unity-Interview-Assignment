# Unity Interview Task

## Table of contents
1. [Link To Web Build](#linktowebbuild)
2. [Description](#description)
3. [Breakdown](#breakdown)
4. [Visuals](#visuals)

## Link To Web Build
https://bb-dev.itch.io/line-matching

## Description

This is a small minigame where users drag a line from a question to an answer. It starts with a main menu screen, because the task asked for two scenes. When the user presses the Start button, the game loads the second, main scene. This scene loads a JSON file of questions, which are then converted and transferred in the game onto with the questions going on the left side of the screen and the answers going on the right side. The user can then drag a line from the questions to whichever answer they think is correct. When this is finished, the user bresses a scoring button which gives them a score.

## Breakdown

So the magic starts when the main game scene is loaded. Most of the logic is contained in QuestionManager.cs. It loads the JSON file, first into the QuestionWrapper which contains an array of Questions derived from the data in the JSON.

Each Question object is sent to a newly instantiated LineObject, which contains a (also newly instantiated) LineAnswer and a LineQuestion, as well as the question weight. The LineAnswer and LineQuestion both contain an anchor point for the LineRenderer to attach to, as well as a Text object to take in the string from the Question object.

The Line Answer holds references to the LineRenderer which draws the line. It also contains a LineHandler. This is an image at the end of the LineRenderer that the user interacts with. There was a million ways to handle clicking the line but basically how it works is this. The LineHandler has IPointerDownHandler, IPointerUpHandler interfaces, and automatically moves the LineRenderers last points position to its position. When the player lets go of the LineHandler, it searches all of the LineObjects.LineQuestions and measures the distance between itself and the nearest LineQuestion.lineAnchor. It moves to this point, forming a complete line.

From there is also checks if any other LineHandler are on this point, and reels them in if so. It reels itself in if the distance is too far as well. This LineHandler finally retains a reference to the LineQuestion it's currently attached to, or if it's attached to anything at all.

When the User clicks the Score button, the QuestionManager first checks if each LineAnswer has a selectedQuestion (from its LineHandler). If not, then it doesn't have a line connected to a question. If they all have a reference, then it checks if each LineObjects.LineAnswer.selectedQuestion is the same as the LineObjects.LineQuestion. If so that means that the question was lined up correctly, and a the correct bool is flipped. If not then its incorrect.

The weight of each LineObject is tallied up, I assumed that the weight was the score each question was worth. Then the score isput on the score panel, it flips around a bit because you wanted an animation, and finally its done. Then the user can reload the scene and do it again. 

## Visuals
![Alt text](/wireMatchScreenshot.png "Website Screenshot")