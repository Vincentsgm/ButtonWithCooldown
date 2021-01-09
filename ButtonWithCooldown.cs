using System;
using RAGENativeUI;
using RAGENativeUI.Elements;
using Rage;

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
            Game.FrameRender += (s, e) =>
            {
                Enabled = DateTime.Now > lastTimePressed.AddSeconds(Cooldown);
                if (!Enabled)
                {
                    Description = defaultDescription + $"\nAvailable again in {lastTimePressed.AddSeconds(cooldown) - DateTime.Now}";
                }
                else
                {
                    Description = defaultDescription;
                }
            };
            Activated += ButtonWithCooldown_Activated;
        }

        private void ButtonWithCooldown_Activated(UIMenu sender, UIMenuItem selectedItem)
        {
            lastTimePressed = DateTime.Now;
            
        }
    }
}
