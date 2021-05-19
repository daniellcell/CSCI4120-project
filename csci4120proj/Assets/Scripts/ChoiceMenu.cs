using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ChoiceMenu : MonoBehaviour
{
 
 
DialogueManager instance;
Dialogue dialogue;
DialogueTrigger trigger;
 
public Button choice01;
public Button choice02;
 
public bool isPressed01 = false;
public bool isPressed02 = false;
 
static int Saki = 0;
static int Yumi = 0;
static int Hikari = 0; // temporary name
static int Ashley = 0;
static int Elisa = 0;
static int Mika = 0;
static int Minako = 0; // last name will be changed
public int ChoiceMade = 0;
static int badPoint = 0;
static int goodPoint = 0;
 
public void DisplayChoices()
{
switch(DialogueManager.TextboxCounter)
{
case 61:
choice01.gameObject.SetActive(true);
choice02.gameObject.SetActive(true);
 
choice01Identifier();
choice02Identifier();
break;
default:
trigger.TriggerDialogue();
break;
}
}
 
 
public void choice01Identifier()
{
choice01 = choice01.GetComponent<Button>();
choice01.onClick.AddListener(TaskOnClick01);
}
 
public void TaskOnClick01()
{
isPressed01 = true;
Debug.Log("You clicked the first choice");
}
 
public void choice02Identifier()
{
choice02 = choice02.GetComponent<Button>();
choice02.onClick.AddListener(TaskOnClick02);
}
 
public void TaskOnClick02()
{
isPressed02 = true;
Debug.Log("You clicked the second choice");
}
 
public void ChoicesPrologue01()
{
if (isPressed01 == true)
{
Saki += 1;
badPoint += 1;
ChoiceMade = 1;
}
else if (isPressed02 == true)
{
Saki += 1;
goodPoint += 1;
ChoiceMade = 2;
}
 
}
 
 
// Update is called once per frame
public void Update()
{
if (ChoiceMade >= 1)
{
choice01.gameObject.SetActive(false);
choice02.gameObject.SetActive(false);
}
 
}
 
 
}