using UnityEngine;

public class DialogueResources
{
    public Sprite ClownPhoto;
    public Sprite BallClownPhoto;
    public Sprite JohnClownPhoto;
    public Sprite JugglingClownPhoto;
    public Sprite GirlClownPhoto;

    public Sprite BigTopBackground;

    public Sprite RedWhiteBigTop;
    public Sprite PurpleBigTop;
    public Sprite Bridge;
    public Sprite Field;

    public void PreLoadClowns()
    {
        ClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
        BallClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\BallClownPhoto");
        JohnClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
        GirlClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\GirlClownPhoto");
        JugglingClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JugglingClownPhoto");
    }

    public void PreLoadBackgrounds()
    {
        BigTopBackground = Resources.Load<Sprite>(@$"TestAssets\Background_TestImage");
        RedWhiteBigTop = Resources.Load<Sprite>(@$"Clown Backgrounds\Red Tent");
        PurpleBigTop = Resources.Load<Sprite>(@$"Clown Backgrounds\PurpleTent");
        Bridge = Resources.Load<Sprite>(@$"Clown Backgrounds\Bridge");
        Field = Resources.Load<Sprite>(@$"Clown Backgrounds\Fence Trees");
    }
}
