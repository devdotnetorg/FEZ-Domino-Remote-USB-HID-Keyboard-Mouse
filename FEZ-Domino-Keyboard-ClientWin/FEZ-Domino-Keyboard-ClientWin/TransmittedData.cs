using System;

namespace FEZ_Domino_Keyboard.Net
{
    public static class TransmittedData
    {
        public enum HIDTypeDevice
        {
            None = 0,
            Keyboard = 1,
            Mouse = 2
        }
        public enum KeyboardKey
        {
            None = 0,
            CtrlAltDel = 300,
            ShiftAlt = 301,
            //
            Enter = 40,
            Escape =  41,
            BackSpace = 42,
            Tab = 43,
            Space = 44,
            Delete = 76,
            RightArrow = 79,
            LeftArrow = 80,
            DownArrow = 81,
            UpArrow = 82 
        }

        public enum MouseActions
        {
            None = 0,
            MouseDown=1,
            MouseUp=2
        }

        public enum MouseButtons
        {
            //
            // Summary:
            //     No mouse button was pressed.
            None = 0,
            //
            // Summary:
            //     The left mouse button was pressed.
            Left = 1,
            //
            // Summary:
            //     The right mouse button was pressed.
            Right = 2,
            //
            // Summary:
            //     The middle mouse button was pressed.
            Middle = 4,
            //
            // Summary:
            //     The first XButton was pressed.
            XButton1 = 8,
            //
            // Summary:
            //     The second XButton was pressed.
            XButton2 = 16
        }
    }
}
