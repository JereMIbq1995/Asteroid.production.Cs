namespace genie.services
{
    /* These constants define what integer each mouse button is known by the user should the
        key is supported.
        However, whether each mouse button is supported depends on the specific
        services that the user uses.
        For example, some of the mouse buttons defined here are supported by Raylib
        and some are not.
    */
    public static class Gamepad
    {
        // D-Pad Up Down Left Right
        public const int LFU = 0;     // Left Face Up
        public const int LFD = 1;     // Left Face Down
        public const int LFL = 2;     // Left Face Left
        public const int LFR = 3;     // Left Face Right

        // A, B, X, Y on XBox; Triangle, Square, Circle, and X on PS: Depending on position
        public const int RFU = 4;     // Right Face Up
        public const int RFD = 5;     // Right Face Down
        public const int RFL = 6;     // Right Face Left
        public const int RFR = 7;     // Right Face Right

        // Left Right Triggers and Bumpers
        public const int L1 = 8;     // Left Trigger 1
        public const int R1 = 9;     // Right Trigger 1
        public const int L2 = 10;    // Left Trigger 2
        public const int R2 = 11;    // Right Trigger 2

        // Left and Right Stick Press Buttons
        public const int LSB = 12;
        public const int RSB = 13;

        // Middle buttons:
        public const int MIDDLE = 14;           // Has the XBox symbol on the XBox gamepad, PS3 symbol on the PS3 controller (Whatever button in the middle)
        public const int MIDDLE_LEFT = 15;      // The tiny button on the left of the middle button
        public const int MIDDLE_RIGHT = 16;     // The tiny button on the right of the middle button

        // UNKNOWN Button:
        public const int UNKNOWN = 17;
    }
}