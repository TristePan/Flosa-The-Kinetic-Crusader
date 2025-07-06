using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importante per usare TMP_Dropdown

public class DifficultyDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Cambiato da Dropdown a TMP_Dropdown

    private void Start()
    {
        //PopulateDropdown();

        //dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });

        SetInitialValue();
    }

    /*
    private void PopulateDropdown()
    {
        dropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (var difficulty in System.Enum.GetValues(typeof(GameDifficultyManager.GameDifficulty)))
        {
            options.Add(difficulty.ToString());
        }

        dropdown.AddOptions(options);
    }
    */

    public void DropdownValueChanged() // Cambiato da Dropdown a TMP_Dropdown
    {
        GameStatus.GameDifficulty selectedDifficulty = (GameStatus.GameDifficulty)dropdown.value;
        GameStatus.Instance.SetDifficulty(selectedDifficulty);
    }

    private void SetInitialValue()
    {
        dropdown.value = (int)GameStatus.Instance.GetDifficulty();
    }
}
