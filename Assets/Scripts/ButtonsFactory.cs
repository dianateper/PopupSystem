using PopupButtons;

public class ButtonsFactory
{
    public PopupButton CreateButton(Popup popup, ButtonType buttonType)
    {
        switch (buttonType)
        {
            case ButtonType.OpenURL : return new URLButton(popup);
            case ButtonType.Close : return new CloseButton(popup);
            case ButtonType.Particle : return new PlayEffectButton(popup);
        }

        return null;
    }
}