﻿using AlcoolGasolina.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlcoolGasolina
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            this.BindingContext = new MainPageViewModel();
		}
	}
}
