using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeyBindingManager : MonoBehaviour
{
    public static KeyBindingManager Instance;
    public KeyBindingList keyBindings = new KeyBindingList();

    // Singleton Pattern
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RebindAction(string action)
    {
        StartCoroutine(WaitForActionKey(action));
    }

    private IEnumerator WaitForActionKey(string action)
    {
        yield return null; // Aspetta il prossimo frame per evitare di catturare immediatamente il tasto premuto per cliccare il bottone

        bool keyDetected = false;
        while (!keyDetected)
        {
            keyDetected = IsActionRebound(action);
            yield return null;
        }
    }

    private bool IsActionRebound(string action)
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(keyCode))
            {
                keyBindings[action] = keyCode;
                Debug.Log($"New key for {action} is {keyCode}");
                return true;
            }
        }
        return false;
    }
}

[Serializable]
public class KeyBindingList
{
    public List<KeyBinding> list = new();

    public KeyCode this[string action]
    {
        get
        {
            foreach (var keyBinding in list)
            {
                if (keyBinding.action == action)
                {
                    return keyBinding.keyCode;
                }
            }

            throw new Exception("Key not found");
        }

        set
        {
            foreach (var keyBinding in list)
            {
                if (keyBinding.action == action)
                {
                    keyBinding.keyCode = value;
                    return;
                }
            }
            list.Add(new KeyBinding(action, value));
        }
    }
}

[Serializable]
public class KeyBinding
{
    public string action;
    public KeyCode keyCode;

    public KeyBinding(string action, KeyCode keyCode)
    {
        this.action = action;
        this.keyCode = keyCode;
    }
}