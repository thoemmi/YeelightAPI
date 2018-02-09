﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YeelightAPI
{
    public partial class DeviceGroup : IBackgroundDeviceController
    {
        
        public async Task<bool> BackgroundSetBrightness(int value, int? smooth = null)
        {
            bool result = true;
            List<Task<bool>> tasks = new List<Task<bool>>();

            foreach (Device device in this)
            {
                tasks.Add(device.BackgroundSetBrightness(value, smooth));
            }

            await Task.WhenAll(tasks);

            foreach (Task<bool> t in tasks)
            {
                result &= t.Result;
            }

            return result;
        }

        public async Task<bool> BackgroundSetColorTemperature(int temperature, int? smooth)
        {
            bool result = true;
            List<Task<bool>> tasks = new List<Task<bool>>();

            foreach (Device device in this)
            {
                tasks.Add(device.BackgroundSetColorTemperature(temperature, smooth));
            }

            await Task.WhenAll(tasks);

            foreach (Task<bool> t in tasks)
            {
                result &= t.Result;
            }

            return result;
        }

        public async Task<bool> BackgroundSetPower(bool state = true)
        {
            bool result = true;
            List<Task<bool>> tasks = new List<Task<bool>>();

            foreach (Device device in this)
            {
                tasks.Add(device.BackgroundSetPower(state));
            }

            await Task.WhenAll(tasks);

            foreach (Task<bool> t in tasks)
            {
                result &= t.Result;
            }

            return result;
        }

        public async Task<bool> BackgroundSetRGBColor(int r, int g, int b, int? smooth)
        {
            bool result = true;
            List<Task<bool>> tasks = new List<Task<bool>>();

            foreach (Device device in this)
            {
                tasks.Add(device.BackgroundSetRGBColor(r, g, b, smooth));
            }

            await Task.WhenAll(tasks);

            foreach (Task<bool> t in tasks)
            {
                result &= t.Result;
            }

            return result;
        }

        public async Task<bool> BackgroundToggle()
        {
            bool result = true;
            List<Task<bool>> tasks = new List<Task<bool>>();

            foreach (Device device in this)
            {
                tasks.Add(device.BackgroundToggle());
            }

            await Task.WhenAll(tasks);

            foreach (Task<bool> t in tasks)
            {
                result &= t.Result;
            }

            return result;
        }
        
    }
}