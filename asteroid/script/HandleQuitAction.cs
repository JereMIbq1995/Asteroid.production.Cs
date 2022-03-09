using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace asteroid.script
{
    class HandleQuitAction : genie.script.Action
    {

        private RaylibScreenService screenService;

        public HandleQuitAction(int priority, RaylibScreenService screenService) : base(priority)
        {
            this.screenService = screenService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            if (this.screenService.IsQuit()) {
                callback.OnStop();
            }
        }
    }
}