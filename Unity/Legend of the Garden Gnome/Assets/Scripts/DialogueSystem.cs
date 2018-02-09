using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }

    public GameObject dialoguePanel;
    [HideInInspector]
    public string npcName;
    [HideInInspector]
    public List<string> dialogueLines;

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    // Use this for initialization
    void Awake () {
        continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}

    public void AddNewDialogue(string[] _lines, string _npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(_lines.Length);
        dialogueLines.AddRange(_lines);
        this.npcName = _npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];   //Show the first line
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];   //Show the next line
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
