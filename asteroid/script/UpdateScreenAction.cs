using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace asteroid.script
{
    class UpdateScreenAction : genie.script.Action
    {

        private RaylibScreenService screenService;

        public UpdateScreenAction(int priority, RaylibScreenService screenService) : base(priority)
        {
            this.screenService = screenService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            this.screenService.UpdateScreen();
        }
    }
}