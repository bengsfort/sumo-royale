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

    private List<GameObject> PlayerObjects = new List<GameObject>();
   

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

    }

    private void setTextPressToJoin(TextMeshProUGUI text)
    {
        text.SetText("Press A to join");
    }

    

    // Update is called once per frame
    void Update()
    {
        // Map player controller to player GameObject.
        if (Input.GetButtonDown("C1_A"))
        {
            Debug.Log("Pressing P1");
            
        }
        if (Input.GetButtonDown("C2_A"))
        {
            Debug.Log("Pressing P2");

        }
    }
}
