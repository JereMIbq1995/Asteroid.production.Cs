using genie.cast;
using genie.script;

namespace genie {

    /*************************************************************
    * These 2 exceptions are designed to skip the rest of the game loop
    * and move on to the next iteration or stop the game completely.
    * Note that StopGame means that:
    *    The game loop is exited immediately, skipping all following actions.
    * This means that the game window will close immediately as well.
    **************************************************************/
    class ChangeSceneException : Exception {
        
        public ChangeSceneException(string? message) : base(message) {
            // Other stuff that might need to be done.
        }
    }

    class StopGameException : Exception {
        public StopGameException(string? message) : base(message) {
            // Other stuff that might need to be done
        }
    }

    /*************************************************************
    * The director class:
    *   - Holds the cast and the script.
    *   - DirectScene runs the game loop by running:
    *         + All input actions
    *         + All update actions
    *         + All output actions
    *   ...every iteration of the loop
    **************************************************************/
    public class Director : script.Action.Callback {

        private bool isDirecting;
        private Cast cast;
        private Script script;
        private Clock clock;

        public Director() {
            this.isDirecting = true;
            this.cast = new Cast();
            this.script = new Script();
            this.clock = new Clock();
        }

        public void DirectScene(Cast cast, Script script) {
            
            this.cast = cast;
            this.script = script;
            this.isDirecting = true;

            while (isDirecting) {
                try {
                    DoInputs();
                    DoUpdates();
                    DoOutputs();
                }
                
                // Skip the rest of the actions if
                //  - The game must be exited right the way
                //  - or The cast and script are completely changed (change scene)
                catch (ChangeSceneException e) { Console.WriteLine(e.Message); }
                catch (StopGameException e) { Console.WriteLine(e.Message); }
            }
        }

        public override void OnStop()
        {
            this.isDirecting = false;
            throw new StopGameException("Game is stopped.");
        }

        public override void OnNext(Cast cast, Script script) {
            this.cast = cast;
            this.script = script;
            throw new ChangeSceneException("Changing scene with a new CAST and a new SCRIPT...");
        }

        private void DoInputs() {
            // Console.WriteLine("Doing inputs...");
            this.clock.Tick();
            foreach (script.Action action in this.script.GetActions("input")) {
                action.execute(this.cast, this.script, this.clock, this);
            }
        }

        private void DoUpdates() {
            // Console.WriteLine("Doing Updates...");
            while (this.clock.IsLagging()) {
                foreach (script.Action action in this.script.GetActions("update")) {
                    action.execute(this.cast, this.script, this.clock, this);
                }
                this.clock.CatchUp();
            }
        }

        private void DoOutputs() {
            // Console.WriteLine("Doing outputs...");
            foreach (script.Action action in this.script.GetActions("output")) {
                action.execute(this.cast, this.script, this.clock, this);
            }
        }
    }
}