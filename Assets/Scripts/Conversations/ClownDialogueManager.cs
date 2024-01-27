using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Linq;

public enum Clowns
{
    TEST
}

public enum Locations
{ 
    BIGTOP
}

public class ClownInfo
{
    public Sprite clownPhoto;
    public string ClownIntro;

    public ClownInfo(string clownName, string introText)
    {
        clownPhoto = Resources.Load<Sprite>(@$"TestAssets\{clownName}_TestImage");
        ClownIntro = introText;
    }
}

public class LocationBackgrounds
{
    public Sprite BigTopBackground;

    public LocationBackgrounds()
    {
        BigTopBackground = Resources.Load<Sprite>(@$"TestAssets\Background_TestImage");

    }

}


public class ClownDialogueManager : MonoBehaviour
{
    /// <summary>
    /// Singleton reference for the <see cref="ClownDialogueManager"/>
    /// </summary>
    public static ClownDialogueManager ClownDialogueManagerInstance
    {
        get
        {
            return clownDialogueManager;
        }
    }
    private static ClownDialogueManager clownDialogueManager;

    /// <summary>
    /// Reference to the background image of the scene
    /// </summary>
    public Image BackgroundImage;

    /// <summary>
    /// Reference to the clown hero image.
    /// </summary>
    public Image ClownImage;

    /// <summary>
    /// Refernce to the text of the clown's dialogue to the player.
    /// </summary>
    public TextMeshProUGUI ClownDialogue;

    /// <summary>
    /// Reference to response button one.
    /// </summary>
    public Button ResponseButtonOne;

    /// <summary>
    /// Reference to response button two.
    /// </summary>
    public Button ResponseButtonTwo;

    /// <summary>
    /// Reference to response button three.
    /// </summary>
    public Button ResponseButtonThree;

    /// <summary>
    /// Reference to the object holding all of the other clowns dialogue.
    /// </summary>
    public GameObject DialogueHolder;

    /// <summary>
    /// Reference to the object holding all of the players available responses.
    /// </summary>
    public GameObject ResponsesHolder;

    /// <summary>
    /// The current node in conversation for navigating the dialogue tree.
    /// </summary>
    private ConversationNode conversation;


    ClownInfo cInfo;
    LocationBackgrounds locationBackgrounds;

    // Start is called before the first frame update
    private void Start()
    {
        clownDialogueManager = this;
        cInfo = new ClownInfo("Buggy", "It'sa Me Buggyman");
        locationBackgrounds = new LocationBackgrounds();

        BeginDialogue(Clowns.TEST, Locations.BIGTOP);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /// <summary>
    /// Begins the dialogue interaction for the clown and loads all relevant images.
    /// </summary>
    /// <param name="clownToLoad"></param>
    public void BeginDialogue(Clowns clownToLoad, Locations location)
    {
        switch (clownToLoad)
        {
            case Clowns.TEST:
                ClownImage.sprite = cInfo.clownPhoto;
                conversation = new ConversationNode(XElement.Load(@"Assets\Resources\TestAssets\TestConvo.xml"));
                ClownDialogue.SetText(conversation.Text);
                break;
            default:
                break;
        }

        switch (location)
        {
            case Locations.BIGTOP:
                BackgroundImage.sprite = locationBackgrounds.BigTopBackground;
                break;
            default:
                break;
        }

        HidePlayerOptions();
    }

    private void HidePlayerOptions()
    {
        DialogueHolder.SetActive(true);
        ResponsesHolder.SetActive(false);
    }

    private void ShowPlayerOptions()
    {
        DialogueHolder.SetActive(false);
        ResponsesHolder.SetActive(true);
    }

    public void Reply()
    {
        ShowPlayerOptions();
        PopulateResponses();
    }

    private void PopulateResponses()
    {
        ResponseButtonOne.GetComponentInChildren<TextMeshProUGUI>().SetText("Back To Start");
        ResponseButtonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText("Back To Start");
        ResponseButtonThree.GetComponentInChildren<TextMeshProUGUI>().SetText("Back To Start");

        if (conversation.Options.Count > 0)
        {
            ResponseButtonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(conversation.Options[0]);
        }
        if (conversation.Options.Count > 1)
        {
            ResponseButtonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(conversation.Options[1]);
        }
        if (conversation.Options.Count > 2)
        {
            ResponseButtonThree.GetComponentInChildren<TextMeshProUGUI>().SetText(conversation.Options[2]);
        }
    }

    public void IssueResponse(int choice)
    {
        HidePlayerOptions();
        ProcessNextDialogue(choice);
    }

    private void ProcessNextDialogue(int choice)
    {
        conversation = conversation.ConversationChoice(choice);
        ClownDialogue.SetText(conversation.Text);
    }
}
