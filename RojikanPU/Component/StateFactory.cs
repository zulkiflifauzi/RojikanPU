﻿using RojikanPU.Logic;
using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RojikanPU.Component
{
    public static class StateFactory
    {
        private static List<CityViewModel> _cityViewModels = new List<CityViewModel>();
        private static List<StateViewModel> _stateViewModels = new List<StateViewModel>();

        public static void InitializeContainers()
        {
            CityLogic _cityLogic = new CityLogic();
            StateLogic _stateLogic = new StateLogic();

            var cities = _cityLogic.GetAll();
            foreach (var city in cities)
            {
                _cityViewModels.Add(new CityViewModel() { Id = city.Id, StateId = city.StateId, Title = city.Title });
            }

            var states = _stateLogic.GetAll();
            foreach (var state in states)
            {
                _stateViewModels.Add(new StateViewModel() { Id = state.Id, Title = state.Title, Latitude = state.Latitude.HasValue ? state.Latitude.Value : 0, Longitude = state.Longitude.HasValue ? state.Longitude.Value : 0 });
            }
        }

        public static List<StateViewModel> GetAllStates()
        {
            return _stateViewModels;
        }

        public static List<CityViewModel> GetCitiesByStateId(int id)
        {
            return _cityViewModels.Where(c => c.StateId == id).ToList();
        }
    }
}