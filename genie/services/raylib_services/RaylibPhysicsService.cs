using Raylib_cs;
using genie.cast;

namespace genie.services.raylib {
    class RaylibPhysicsService {
        
        //Doesn't need any field for now

        public RaylibPhysicsService() {
            //Empty for now
        }

        private Rectangle GetRectangle(Actor actor) {
            (float x, float y) topLeft = actor.GetTopLeft();
            return new Rectangle(topLeft.x, topLeft.y, actor.GetWidth(), actor.GetHeight());
        }

        public void RotateActors(List<Actor> actors) {
            foreach (Actor actor in actors) {
                actor.Rotate();
            }
        }

        public void MoveActors(List<Actor> actors) {
            foreach (Actor actor in actors) {
                actor.MoveWithVelocity();
            }
        }

        public bool CheckCollision(Actor actor1, Actor actor2) {
            return Raylib.CheckCollisionRecs(this.GetRectangle(actor1), this.GetRectangle(actor2));
        }

        public bool CheckCollisionPoint(Actor actor, (float x, float y) point) {
            return Raylib.CheckCollisionPointRec(new System.Numerics.Vector2(point.x, point.y), this.GetRectangle(actor));
        }

        public Actor? CheckCollisionList(Actor target, List<Actor> actors) {
            foreach (Actor actor in actors) {
                if (Raylib.CheckCollisionRecs(this.GetRectangle(actor), this.GetRectangle(target))) {
                    return actor;
                }
            }
            return null;
        }

        public bool CheckCollisionAll(Actor target, List<Actor> actors) {
            foreach (Actor actor in actors) {
                if (!Raylib.CheckCollisionRecs(this.GetRectangle(actor), this.GetRectangle(target))) {
                    return false;
                }
            }
            return true;
        }

        public bool IsAbove(Actor actor1, Actor actor2) {
            return actor1.GetTopLeft().Item2 < actor2.GetTopLeft().Item2; 
        }

        public bool IsBelow(Actor actor1, Actor actor2)
        {
            return actor1.GetBottomLeft().Item2 > actor2.GetBottomLeft().Item2;
        }

        public bool IsLeftOf(Actor actor1, Actor actor2) {
            return actor1.GetTopLeft().Item1 < actor2.GetTopLeft().Item1;
        }

        public bool IsRightOf(Actor actor1, Actor actor2) {
            return actor1.GetTopRight().Item1 > actor2.GetTopRight().Item1;
        }

    }
}