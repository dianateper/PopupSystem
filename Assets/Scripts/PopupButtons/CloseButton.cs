namespace PopupButtons
{
    public class CloseButton : PopupButton
    {
        public override void Execute() 
        {
            _popup.Hide();
        }

        public CloseButton(Popup popup) : base(popup)
        {
        }
    }
}