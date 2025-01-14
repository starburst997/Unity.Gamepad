﻿using System.Collections.Generic;
using UnityEngine;

namespace Unity.Gamepad.Mappings
{
    public class SwitchProControllerMapping : InputMapping
    {
        public SwitchProControllerMapping()
        {
            OverridesAxisReading = true;
        }

        public static readonly List<string> GetControllerAliases = new List<string>() 
        { 
            /*"Pro Controller",*/
            "Wireless Gamepad"
        };

        public override void MapBindings(int deviceNumber)
        {
            //south 0
            //west 2
            //east 1
            //north 3
            //Leftbumper 4
            //Rightbumper 5
            //lefttrigger 6
            //righttrigger 7
            //leftThumbClick 10
            //rightThumbClick 11
            //Home 12 but opens steam and stuff
            //select 13
            //plus 9 (could be start)
            //minus 8

            //axis
            //rightanalogVerti 7
            //rightanalogHori 6

            //leftanalogvertical 3
            //leftanaloghorizontal 1

            //dpadverti 9
            //dpadhori 8

            ButtonBindingLookupTable[GamepadButton.RightBumper] = $"joystick {deviceNumber} button 5";
            ButtonBindingLookupTable[GamepadButton.LeftBumper] = $"joystick {deviceNumber} button 4";
            ButtonBindingLookupTable[GamepadButton.RightStickButton] = $"joystick {deviceNumber} button 11";

            ButtonBindingLookupTable[GamepadButton.ActionSouth] = $"joystick {deviceNumber} button 0";
            ButtonBindingLookupTable[GamepadButton.ActionWest] = $"joystick {deviceNumber} button 2";
            ButtonBindingLookupTable[GamepadButton.ActionEast] = $"joystick {deviceNumber} button 1";
            ButtonBindingLookupTable[GamepadButton.ActionNorth] = $"joystick {deviceNumber} button 3";
            ButtonBindingLookupTable[GamepadButton.Start] = $"joystick {deviceNumber} button 9";
            ButtonBindingLookupTable[GamepadButton.BackSelect] = $"joystick {deviceNumber} button 13";

            AxisBindingLookupTable[GamepadAxis.LeftHorizontal] = new GamepadAxisInfo() { AxisName = $"joystick {deviceNumber} analog 1", Minimum = -1.0f, Maximum = 1.0f, DeadZoneOffset = 0.2f };
            AxisBindingLookupTable[GamepadAxis.LeftVertical] = new GamepadAxisInfo() { AxisName = $"joystick {deviceNumber} analog 3", Minimum = -1.0f, Maximum = 1.0f, Inverted = true, DeadZoneOffset = 0.2f };
            AxisBindingLookupTable[GamepadAxis.RightHorizontal] = new GamepadAxisInfo() { AxisName = $"joystick {deviceNumber} analog 6", Minimum = -1.0f, Maximum = 1.0f, DeadZoneOffset = 0.2f };
            AxisBindingLookupTable[GamepadAxis.RightVertical] = new GamepadAxisInfo() { AxisName = $"joystick {deviceNumber} analog 7", Minimum = -1.0f, Maximum = 1.0f, Inverted = true, DeadZoneOffset = 0.2f };

            AxisBindingLookupTable[GamepadAxis.DpadHorizontal] = new GamepadAxisInfo() { AxisName = $"joystick {deviceNumber} analog 8", Minimum = -1.0f, Maximum = 1.0f, DeadZoneOffset = 0.3f, UnpressedValue = 0 };
            AxisBindingLookupTable[GamepadAxis.DpadVertical] = new GamepadAxisInfo() { AxisName = $"joystick {deviceNumber} analog 9", Minimum = -1.0f, Maximum = 1.0f, DeadZoneOffset = 0.3f, UnpressedValue = 0 };

            AxisBindingLookupTable[GamepadAxis.LeftTrigger] = new GamepadAxisInfo() { AxisName = $"joystick {deviceNumber} button 6" };
            AxisBindingLookupTable[GamepadAxis.RightTrigger] = new GamepadAxisInfo() { AxisName = $"joystick {deviceNumber} button 7" };
        }

        public override float OverrideAxisReading(GamepadAxis axis)
        {
            if (axis == GamepadAxis.LeftTrigger || axis == GamepadAxis.RightTrigger)
            {
                return Input.GetKey(AxisBindingLookupTable[axis].AxisName) ? 1 : 0;
            }
            else
            {
                return Input.GetAxisRaw(AxisBindingLookupTable[axis].AxisName);
            }
        }
    }
}