﻿namespace Lands.ViewModels
{
   using Lands.Models;
   using System;
   using System.Collections.Generic;
   using System.Collections.ObjectModel;
   using Lands.Helpers;
   using Lands.Domain;

   public class MainViewModel : BaseViewModel
    {
      #region Attributes
      private UserLocal user;
      #endregion

      #region Properties
      public List<Land> LandsList
      {
         get;
         set;
      }
      
      public ObservableCollection<MenuItemViewModel> Menus { get; set; }

      public TokenResponse Token { get; set; }

      public UserLocal User
      {
         get { return this.user; }
         set { SetValue(ref this.user, value); }
      }
      #endregion

      #region ViewModels
      public LoginViewModel Login { get; set; }
      public LandsViewModel Lands { get; set; }
      public LandViewModel Land { get; set; }
      public RegisterViewModel Register { get; set; }
      public MyProfileViewModel MyProfile { get; set; }
      public ChangePasswordViewModel ChangePassword { get; set; }
      #endregion

      #region Constructors
      public MainViewModel()
      {
         instance = this;
         this.Login = new LoginViewModel();
         this.LoadMenu();
      }
      #endregion

      #region Methods
      private void LoadMenu()
      {
         this.Menus = new ObservableCollection<MenuItemViewModel>();

         this.Menus.Add(new MenuItemViewModel
         {
            Icon = "ic_settings",
            PageName = "MyProfilePage",
            Title = Languages.MyProfile
         });

         this.Menus.Add(new MenuItemViewModel
         {
            Icon = "ic_insert_chart",
            PageName = "StatisticsPage",
            Title = Languages.Statistics
         });

         this.Menus.Add(new MenuItemViewModel
         {
            Icon = "ic_exit_to_app",
            PageName = "LoginPage",
            Title = Languages.LogOut
         });
      } 
      #endregion

      #region Singleton
      private static MainViewModel instance;

      public static MainViewModel GetInstance()
      {
         if (instance == null)
         {
            return new MainViewModel();
         }

         return instance;
      }
      #endregion
   }
}
