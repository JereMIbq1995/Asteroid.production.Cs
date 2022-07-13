using Raylib_cs;
using System.Numerics;

namespace genie.services.raylib
{
    /***************************************************************
    *   This class encapsulates most things you need to do to check
    *   for gamepad events.
    *   Note:
    *     ButtonDown means whether you're holding the Button - opposite of ButtonUp.
    *     ButtonPressed means whether you just pressed the Button once - opposite of ButtonReleased.
    ****************************************************************/
    class RaylibGamepadService
    {
        //The gamepad service has a button map that maps
        // all genie button codes into Raylib button codes
        private GamepadMap gamepadMap;

        /***************************************************************
        * Constructor
        ****************************************************************/
        public RaylibGamepadService()
        {
            this.gamepadMap = new GamepadMap();
        }

        /***************************************************************
        * Get a dictionary that map a set of buttons to their states (Up or Down)
        * True = Down, False = Up
        ****************************************************************/
        public Dictionary<int, bool> GetButtonsState(int gamepadNumber, List<int> buttons)
        {
            Dictionary<int, bool> buttonsState = new Dictionary<int, bool>();
            foreach (int button in buttons)
            {
                buttonsState.Add(button, Raylib.IsGamepadButtonDown(gamepadNumber, this.gamepadMap.GetRaylibGamepadButton(button)));
            }
            return buttonsState;
        }

        /***************************************************************
        * Check to see if a button is pressed ONCE.
        * This function only returns True once when the button is pressed.
        * On the next frame, it will return false even if the button is still
        * held down
        ****************************************************************/
        public bool IsButtonPressed(int gamepadNumber, int button)
        {
            return Raylib.IsGamepadButtonPressed(gamepadNumber, this.gamepadMap.GetRaylibGamepadButton(button));
        }

        /***************************************************************
        * Check to see if a button is released ONCE.
        * This function only returns True once when the button is released from
        * being held down.
        * On the next frame, it will return false even if the button is UP.
        * (This function is different from IsbuttonUp())
        ****************************************************************/
        public bool IsButtonReleased(int gamepadNumber, int button)
        {
            return Raylib.IsGamepadButtonReleased(gamepadNumber, this.gamepadMap.GetRaylibGamepadButton(button));
        }

        /***************************************************************
        * Check to see if a button is currently being held down.
        * Return True every frame if the button is held down at the time of
        * the check.
        ****************************************************************/
        public bool IsButtonDown(int gamepadNumber, int button)
        {
            return Raylib.IsGamepadButtonDown(gamepadNumber, this.gamepadMap.GetRaylibGamepadButton(button));
        }

        /***************************************************************
        * This is just the opposite of IsButtonDown()
        ****************************************************************/
        public bool IsButtonUp(int gamepadNumber, int button)
        {
            return Raylib.IsGamepadButtonUp(gamepadNumber, this.gamepadMap.GetRaylibGamepadButton(button));
        }

        /***************************************************************
        * Get the coordinate of a joy stick
        ****************************************************************/
        public Vector2 GetJoystickCoordinates(int gamepadNumber, int joystick) {
            if (joystick == Gamepad.LSB) {
                return new Vector2(Raylib.GetGamepadAxisMovement(gamepadNumber, GamepadAxis.GAMEPAD_AXIS_LEFT_X),
                                    Raylib.GetGamepadAxisMovement(gamepadNumber, GamepadAxis.GAMEPAD_AXIS_LEFT_Y));
            }
            else if (joystick == Gamepad.RSB)
            {
                return new Vector2(Raylib.GetGamepadAxisMovement(gamepadNumber, GamepadAxis.GAMEPAD_AXIS_RIGHT_X),
                                    Raylib.GetGamepadAxisMovement(gamepadNumber, GamepadAxis.GAMEPAD_AXIS_RIGHT_Y));
            }
            else {
                throw (new Exception("Invalid joystick constant. Use either genie.services.Gamepad.LSB or genie.services.Gamepad.RSB"));
            }
        }

        /***************************************************************
        * Is gamepad available
        ****************************************************************/
        public bool IsGamepadAvailable(int gamepadNumber) {
            return Raylib.IsGamepadAvailable(gamepadNumber);
        }
    }
}