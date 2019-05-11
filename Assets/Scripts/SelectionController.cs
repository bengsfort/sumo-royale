using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionController : MonoBehaviour
{
    // Initialize player game objects.
    public GameObject p1Ui;
    public GameObject p2Ui;
    public GameObject p3Ui;
    public GameObject p4Ui;

    private List<Player> players = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {
        // Set default text for each player.
        TextMeshProUGUI textMeshp1Ui = p1Ui.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textMeshp2Ui = p2Ui.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textMeshp3Ui = p3Ui.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textMeshp4Ui = p4Ui.GetComponent<TextMeshProUGUI>();
        setTextPressToJoin(textMeshp1Ui);
        setTextPressToJoin(textMeshp2Ui);
        setTextPressToJoin(textMeshp3Ui);
        setTextPressToJoin(textMeshp4Ui);

        // Create all player objects.
        // C1_Left Stick X Axis
        // Player p1 = new Player(1, "C1", "C1_A", "C1_Left Stick X Axis", "C1_Left Stick Y Axis", false);
        // Player p2 = new Player(1, "C2", "C2_A", "C2_Left Stick X Axis", "C2_Left Stick Y Axis", false);
    }

    private void setTextPressToJoin(TextMeshProUGUI text)
    {
        text.SetText("Press A to join");
    }
   

    // Update is called once per frame
    void Update()
    {
        // Register Players
        if (Input.GetButtonDown("C1_A"))
            if(isAssigned("C1"))
            {
                {
                    TextMeshProUGUI textMeshp1Ui = p1Ui.GetComponent<TextMeshProUGUI>();
                    textMeshp1Ui.SetText("P1");

                    // C1_Left Stick X Axis
                    string xAxis = "C1_Left Stick X Axis";
                    string yAxis = "C1_Left Stick Y Axis";
                    string aButton = "C1_A";
                    int controllerId = 1;
                    string playerId = "C1";
                    bool isAssigned = true;

                    Player p1 = new Player(controllerId, playerId, aButton, xAxis, yAxis, isAssigned);
                    players.Add(p1);

                }
            }

        if (Input.GetButtonDown("C2_A"))
        {
            TextMeshProUGUI textMeshp2Ui = p2Ui.GetComponent<TextMeshProUGUI>();
            textMeshp2Ui.SetText("P2");

        }


    }
    private bool isAssigned(string playerId)
    {
        foreach(Player player in players)
        {
            if(player.playerId == playerId)
            {
                return true;
            }
        }
        return false;
    }
}


