using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class DialogueManager : MonoBehaviour
{
public TextSpeedSlider instance;
public Text nameText;
public Text dialogueText;
 
public Animator animator;
// Start is called before the first frame update
private Queue<string> sentences = new Queue<string>();
 
public static int TextboxCounter = 0;
 
public ChoiceMenu callChoices;
 
 
 
void Start()
{
sentences = new Queue<string>();
callChoices.choice01.gameObject.SetActive(false);
callChoices.choice02.gameObject.SetActive(false);
}
 
public void StartDialogue(Dialogue dialogue)
{
animator.SetBool("IsOpen", true);
nameText.text = dialogue.name;
 
sentences.Clear();
 
foreach(string sentence in dialogue.sentences)
{
sentences.Enqueue(sentence);
}
 
DisplayNextSentence();
}
 
public void DisplayNextSentence()
{
//TextboxCounter += 1; //commented out for now would like to increment in Dialogue.cs
 
if(sentences.Count == 0)
{
EndDialogue();
return;
}
 
string sentence = sentences.Dequeue();
dialogueText.text = sentence;
 
StopAllCoroutines();
 
StartCoroutine(TypeSentence(sentence));
}
 
IEnumerator TypeSentence(string sentence)
{
dialogueText.text = "";
 
foreach(char letter in sentence.ToCharArray())
{
dialogueText.text += letter;
 
//controlling textspeed via slider in UI
if (instance.speed == 10f)
yield return new WaitForSeconds(1);
else if (instance.speed == 9f)
yield return new WaitForSeconds(2);
else if (instance.speed == 8f)
yield return new WaitForSeconds(3);
else if (instance.speed == 7f)
yield return new WaitForSeconds(4);
else if (instance.speed == 6f)
yield return new WaitForSeconds(5);
else if (instance.speed == 5f)
yield return new WaitForSeconds(6);
else if (instance.speed == 4f)
yield return new WaitForSeconds(7);
else if (instance.speed == 3f)
yield return new WaitForSeconds(8);
else if (instance.speed == 2f)
yield return new WaitForSeconds(9);
else if (instance.speed == 1f)
yield return new WaitForSeconds(10);
else if (instance.speed == 0f)
yield return new WaitForSeconds(11);
}
}
 
void EndDialogue()
{
animator.SetBool("IsOpen", false);
callChoices.DisplayChoices();
 
}
 
}
 
