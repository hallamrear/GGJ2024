using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Clowns
{
    TEST
}

public class ClownInfo
{
    public Sprite clownBackground;
    public Sprite clownPhoto;
    public string ClownIntro;

    public ClownInfo()
    {
        clownBackground = Resources.Load<Sprite>(@"TestAssets\Background_TestImage");
        clownPhoto = Resources.Load<Sprite>(@"TestAssets\Buggy_TestImage");
        ClownIntro = "Heyo itsa me buggy";
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


    ClownInfo cInfo;

    // Start is called before the first frame update
    private void Start()
    {
        clownDialogueManager = this;
        cInfo = new ClownInfo();

        BeginDialogue(Clowns.TEST);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    /// <summary>
    /// Begins the dialogue interaction for the clown and loads all relevant images.
    /// </summary>
    /// <param name="clownToLoad"></param>
    public void BeginDialogue(Clowns clownToLoad)
    {
        switch (clownToLoad)
        {
            case Clowns.TEST:
                BackgroundImage.sprite = cInfo.clownBackground;
                ClownImage.sprite = cInfo.clownPhoto;
                ClownDialogue.SetText(cInfo.ClownIntro);
                break;
            default:
                break;
        }
    }
}
