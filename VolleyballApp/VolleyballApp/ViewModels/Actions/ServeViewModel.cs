﻿using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Rallies;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Actions
{
    public class ServeViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;
        public RallyViewModel RallyViewModel { get; private set; }

        public Team Team { get; protected set; }

        public Serve Serve { get; protected set; }

        public ICommand SaveCommand { get; protected set; }

        public ServeViewModel(INavigationService navigator, RallyViewModel rallyViewModel , Team team)
        {
            _navigator = navigator;
            RallyViewModel = rallyViewModel;

            Serve = new Serve();
            Serve.Team = team;
            Team = team;

            SaveCommand = new Command(Save);
        }

        private void Save()
        {
            Serve.Index = RallyViewModel.Actions.Count;
            RallyViewModel.Actions.Add(Serve);

            


            //если фейл, добавить очко противоположной команде

            _navigator.PopModal();
        }
    }
}
