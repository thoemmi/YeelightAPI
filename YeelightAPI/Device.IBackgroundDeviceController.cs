﻿using System.Collections.Generic;
using System.Threading.Tasks;
using YeelightAPI.Models;
using YeelightAPI.Models.Adjust;
using YeelightAPI.Models.ColorFlow;

namespace YeelightAPI
{
    /// <summary>
    /// Yeelight Device : IBackgroundDeviceController implementation
    /// </summary>
    public partial class Device : IBackgroundDeviceController
    {
        #region Public Methods

        /// <summary>
        /// Adjusts the background light state
        /// </summary>
        /// <param name="action"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<bool> BackgroundSetAdjust(AdjustAction action, AdjustProperty property)
        {
            {
                List<object> parameters = new List<object>() { action.ToString(), property.ToString() };

                CommandResult result = await ExecuteCommandWithResponse(
                    method: METHODS.SetBackgroundLightAdjust,
                    id: (int)METHODS.SetBackgroundLightAdjust,
                    parameters: parameters);

                return result.IsOk();
            }
        }

        /// <summary>
        /// Set the brightness
        /// </summary>
        /// <param name="value"></param>
        /// <param name="smooth"></param>
        /// <returns></returns>
        public async Task<bool> BackgroundSetBrightness(int value, int? smooth = null)
        {
            List<object> parameters = new List<object>() { value };

            HandleSmoothValue(ref parameters, smooth);

            CommandResult result = await ExecuteCommandWithResponse(
                method: METHODS.SetBackgroundLightBrightness,
                id: (int)METHODS.SetBackgroundLightBrightness,
                parameters: parameters);

            return result.IsOk();
        }

        /// <summary>
        /// Set the background temperature
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="smooth"></param>
        /// <returns></returns>
        public async Task<bool> BackgroundSetColorTemperature(int temperature, int? smooth)
        {
            List<object> parameters = new List<object>() { temperature };

            HandleSmoothValue(ref parameters, smooth);

            CommandResult result = await ExecuteCommandWithResponse(
                method: METHODS.SetBackgroundColorTemperature,
                id: (int)METHODS.SetBackgroundColorTemperature,
                parameters: parameters);

            return result.IsOk();
        }

        /// <summary>
        /// Set the background light HSV color
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="sat"></param>
        /// <param name="smooth"></param>
        /// <returns></returns>
        public async Task<bool> BackgroundSetHSVColor(int hue, int sat, int? smooth = null)
        {
            List<object> parameters = new List<object>() { hue, sat };

            HandleSmoothValue(ref parameters, smooth);

            CommandResult result = await ExecuteCommandWithResponse(
                method: METHODS.SetBackgroundLightHSVColor,
                id: (int)METHODS.SetBackgroundLightHSVColor,
                parameters: parameters);

            return result.IsOk();
        }

        /// <summary>
        /// Set the power of the device
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<bool> BackgroundSetPower(bool state = true)
        {
            CommandResult result = await ExecuteCommandWithResponse(
                method: METHODS.SetBackgroundLightPower,
                id: (int)METHODS.SetBackgroundLightPower,
                parameters: new List<object>() { state ? "on" : "off" }
            );

            return result.IsOk();
        }

        /// <summary>
        /// set the RGB color
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="smooth"></param>
        /// <returns></returns>
        public async Task<bool> BackgroundSetRGBColor(int r, int g, int b, int? smooth)
        {
            //Convert RGB into integer 0x00RRGGBB
            int value = ((r) << 16) | ((g) << 8) | (b);
            List<object> parameters = new List<object>() { value };

            HandleSmoothValue(ref parameters, smooth);

            CommandResult result = await ExecuteCommandWithResponse(
                method: METHODS.SetBackgroundLightRGBColor,
                id: (int)METHODS.SetBackgroundLightRGBColor,
                parameters: parameters);

            return result.IsOk();
        }

        /// <summary>
        /// Starts a background color flow
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="action"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<bool> BackgroundStartColorFlow(ColorFlow flow)
        {
            List<object> parameters = new List<object>() { flow.RepetitionCount, (int)flow.EndAction, flow.GetColorFlowExpression() };

            CommandResult result = await ExecuteCommandWithResponse(
                method: METHODS.StartBackgroundLightColorFlow,
                id: (int)METHODS.StartBackgroundLightColorFlow,
                parameters: parameters);

            return result.IsOk();
        }

        /// <summary>
        /// Stops the background color flow
        /// </summary>
        /// <returns></returns>
        public async Task<bool> BackgroundStopColorFlow()
        {
            CommandResult result = await ExecuteCommandWithResponse(
                            method: METHODS.StopBackgroundLightColorFlow,
                            id: (int)METHODS.StopBackgroundLightColorFlow);

            return result.IsOk();
        }

        /// <summary>
        /// Toggle device
        /// </summary>
        /// <returns></returns>
        public async Task<bool> BackgroundToggle()
        {
            CommandResult result = await ExecuteCommandWithResponse(METHODS.ToggleBackgroundLight, id: (int)METHODS.ToggleBackgroundLight);

            return result.IsOk();
        }

        /// <summary>
        /// Toggle Both Background and normal light
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DevToggle()
        {
            CommandResult result = await ExecuteCommandWithResponse(METHODS.ToggleDev, id: (int)METHODS.ToggleDev);

            return result.IsOk();
        }

        #endregion Public Methods
    }
}