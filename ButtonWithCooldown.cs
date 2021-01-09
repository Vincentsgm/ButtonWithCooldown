using System;
using RAGENativeUI;
using RAGENativeUI.Elements;

namespace SwatCallouts.Menus.SpecialButtons
{
    public class ButtonWithCooldown : UIMenuItem
    {
        internal DateTime lastTimePressed;
        internal string defaultDescription;
        public int Cooldown { get; internal set; }

        public ButtonWithCooldown(string text, string description, int cooldown) : base(text, description)
        {
            Cooldown = cooldown;
            defaultDescription = description;
            lastTimePressed = DateTime.MinValue;
            Activated += (s, e) => lastTimePressed = DateTime.Now;     
        }

        public override void Draw(float x, float y, float width, float height)
        {
            Enabled = DateTime.Now > lastTimePressed.AddSeconds(Cooldown);
            if (!Enabled)
            {
                TimeSpan availableNext = lastTimePressed.AddSeconds(Cooldown) - DateTime.Now;
                Description = defaultDescription + $"\nAvailable again in {availableNext:mm\\:ss}";
            }
            else
            {
                Description = defaultDescription;
            }
            base.Draw(x, y, width, height);
        }
    }
}
