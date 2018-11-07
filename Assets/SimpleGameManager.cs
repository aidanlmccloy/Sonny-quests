﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnStateChangeHandler();
public class SimpleGameManager : MonoBehaviour
{
    // Class Variables and Properties
    public bool Quest1 = false;
    public bool Quest2 = false;
    public bool Quest3 = false;
    private static SimpleGameManager instance = null;
    public static SimpleGameManager Instance
    {
        get
        {
            if (SimpleGameManager.instance == null)
            {
                SimpleGameManager.instance = FindObjectOfType<SimpleGameManager>();
                if (SimpleGameManager.instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SimpleGameManager";
                    SimpleGameManager.instance = go.AddComponent<SimpleGameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return SimpleGameManager.instance;
        }
    }

    // ignore this event, it's for some fancy scene changes I'm doing
    public event OnStateChangeHandler OnStateChange;

    // Class Methods
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FinishQuest(string questName)
    {
        Debug.Log("Handling Quest for " + questName);
        // See Assets/Easy FPS/Scripts/BulletScript.cs to see
        // what tags are in use!

          switch (questName)
            {
                case "Pick Up":
                    Quest1 = true;
                    Debug.Log("Quest1 True");
                    break;
                case "Pick Up 2":
                    Quest2 = true;
                    break;
                case "Pick Up 3":
                    Quest3 = true;
                    break;
                default:
                    break;
            }

            // Open the gate if all quests are complete!
            if (AreQuestsFinished()) OpenTheGate();
    }
    bool AreQuestsFinished()
    {
        Debug.Log("Are Quests Finished? " + (Quest1 && Quest2 && Quest3));
        Debug.Log("Quest1: " + Quest1);
        Debug.Log("Quest2: " + Quest2);
        Debug.Log("Quest3: " + Quest3);
        return Quest1 && Quest2 && Quest3;
    }
    void OpenTheGate()
    {
        // Open the gates in 2s
        GameObject[] gates;
        gates = GameObject.FindGameObjectsWithTag("finish");
        Debug.Log("Got " + gates.Length + "gates");
        foreach (GameObject gate in gates)
        {
            Destroy(gate, 2.0f);
        }
    }


    /*
     * Don't look in this section! It's far too advanced for you!
     *
     * Seriously, let's take a look, and I'll try to explain some
     * of it. Computers are very good at keeping track of lists,
     * so let's make the computer keep track of our quests for us!
     *
     * We'll start with a Dictionary, named quests, which is a list
     * of keys (the terms), and values (the definitions). We'll
     * make this a Dictionary with strings for keys, and booleans
     * for values. We can add quests to this dictionary when we use
     * this class's constructor method.
     *
     * The last bit of wizardry is in our AdvancedFinishQuest
     * method! Rather than use all of those if/else statements
     * or a switch/case statement, we can simplify things an
     * incredible amount by just looking up the value in the
     * quests Dictionary: quests.ContainsKey("name of key").
     * If we find the key, we set the key's value to true!
     * If we don't find it, we just exit the method: no harm,
     * no foul!
     *
     * Season lightly with some Debug.Log statements, and you've
     * got a nice, compact method that's pretty easy to under-
     * stand, and to debug!
     *
     * I've left some of this code for you to figure out.
     *
     * Good Luck!
     */

    private Dictionary<string, bool> questStates = new Dictionary<string, bool>();
    private Dictionary<string, string> questDescriptions = new Dictionary<string, string>();
    // Hmm. Some more initialization code! Looks like
    protected SimpleGameManager()
    {
        questStates.Add("Pick Up", false);
        questDescriptions.Add("Pick Up", "Picked up 1 coin!");
        questStates.Add("Pick Up 2", false);
        questDescriptions.Add("Pick Up 2", "Picked up 2 coins!");
        questStates.Add("Pick Up 3", false);
        questDescriptions.Add("Pick Up 3", "Picked up 3 coins!");
        Debug.Log("Added Quests for Pick Up, Pick Up 2, and Pick Up 3");
    }

    public void AdvancedFinishQuest(string questName)
    {
        Debug.Log("Finishing Quest for " + questName);
        if (questStates.ContainsKey(questName))
        {
            questStates[questName] = true;
        }
    }

    public string GetQuestDescription(string questName)
    {
        string desc = "";
        questDescriptions.TryGetValue(questName, out desc);
        return desc;
    }

}