// using genie;
using genie.cast;

namespace genie.script {
    public abstract class Action {

        public abstract class Callback {
            public abstract void OnNext(Cast cast, Script script);
            public abstract void OnStop();
        }

        private int priority;

        public Action(int priority) {
            this.priority = priority;
        }

        public int GetPriority() {
            return this.priority;
        }

        public void SetPriority(int priority) {
            this.priority = priority;
        }

        public abstract void execute(Cast cast, Script script, Clock clock, Callback callback);
    }
}