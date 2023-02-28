namespace PopupButtons
{
    public abstract class PopupButton
    {
        protected Popup _popup;
        public PopupButton(Popup popup)
        {
            _popup = popup;
        }

        public abstract void Execute();
    }
}
