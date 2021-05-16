# ButtonWithCooldown
A class to create a RAGENativeUI button with a cooldown.
When the button is pressed, lastTimePressed is updated to the current time.
Before drawing, the button is enabled/disabled depending on if the current time is greater than lastTimePressed + the cooldown.
When enabled, the description of the button is set to defaultDescription, otherwise it is defaultDescription + a string formatting the remaining time.

Download RAGENativeUI:
GitHub: https://github.com/alexguirre/RAGENativeUI/releases
NuGet: https://www.nuget.org/packages/RAGENativeUI/

For support join my Discord Server: https://discord.gg/g82638j
