using Raylib_cs;

namespace genie.services.raylib
{
    /*
        This class maps the Genie Keys to the Raylib Keys
    */
    public class GamepadMap
    {

        // hold the mapping of genie key to raylib key
        private Dictionary<int, GamepadButton> gamepadMap;

        /*
            Constructor:
            Put all the mapping of supported genie keys to raylib keys inside keysMap
        */
        public GamepadMap()
        {
            this.gamepadMap = new Dictionary<int, GamepadButton>();
            
            // D-pad Up-Down-Left-Right buttons
            gamepadMap.Add(Gamepad.LFU, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_UP);
            gamepadMap.Add(Gamepad.LFD, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_DOWN);
            gamepadMap.Add(Gamepad.LFL, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_LEFT);
            gamepadMap.Add(Gamepad.LFR, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_RIGHT);

            // ABXY (XBox), or TCSX (PS3) Up-Down-Left-Right buttons
            gamepadMap.Add(Gamepad.RFU, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_UP);
            gamepadMap.Add(Gamepad.RFD, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_DOWN);
            gamepadMap.Add(Gamepad.RFL, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_LEFT);
            gamepadMap.Add(Gamepad.RFR, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_RIGHT);

            // Triggers 1 and 2
            gamepadMap.Add(Gamepad.L1, GamepadButton.GAMEPAD_BUTTON_LEFT_TRIGGER_1);
            gamepadMap.Add(Gamepad.R1, GamepadButton.GAMEPAD_BUTTON_RIGHT_TRIGGER_1);
            gamepadMap.Add(Gamepad.L2, GamepadButton.GAMEPAD_BUTTON_LEFT_TRIGGER_2);
            gamepadMap.Add(Gamepad.R2, GamepadButton.GAMEPAD_BUTTON_RIGHT_TRIGGER_2);

            // Stick press buttons
            gamepadMap.Add(Gamepad.LSB, GamepadButton.GAMEPAD_BUTTON_LEFT_THUMB);
            gamepadMap.Add(Gamepad.RSB, GamepadButton.GAMEPAD_BUTTON_RIGHT_THUMB);

            // Middle buttons
            gamepadMap.Add(Gamepad.MIDDLE, GamepadButton.GAMEPAD_BUTTON_MIDDLE);
            gamepadMap.Add(Gamepad.MIDDLE_LEFT, GamepadButton.GAMEPAD_BUTTON_MIDDLE_LEFT);
            gamepadMap.Add(Gamepad.MIDDLE_RIGHT, GamepadButton.GAMEPAD_BUTTON_MIDDLE_RIGHT);

            gamepadMap.Add(Gamepad.UNKNOWN, GamepadButton.GAMEPAD_BUTTON_UNKNOWN);
        }

        public GamepadButton GetRaylibGamepadButton(int genieGamepadButton)
        {
            try
            {
                return this.gamepadMap[genieGamepadButton];
            }
            catch (KeyNotFoundException e)
            {
                if (e.Source != null)
                    Console.WriteLine("KeyNotFoundException source: {0}", e.Source);
                throw new KeyNotFoundException($"Genie Gamepad button {genieGamepadButton} is not a valid button");
            }
        }
    }
}