﻿/*
 *    Copyright 2009, 2010 Francesco Tonucci
 * 
 * This file is part of PDFRider.
 * 
 * PDFRider is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 * 
 * PDFRider is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with PDFRider; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 * 
 * 
 * Project page: http://pdfrider.codeplex.com
*/

using System;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.IO;

namespace PDFRider
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// </summary>
    public class WndNewVersionViewModel : WindowViewModel
    {
        Updater.UpdaterConfig _config = Updater.Updater.LoadConfig();

        /// <summary>
        /// Initializes a new instance of the WndNewVersionViewModel class.
        /// </summary>
        public WndNewVersionViewModel()
        {
            Messenger.Default.Register<TMsgShowNewVersion>(this, MsgShowNewVersion_Handler);
        }


        #region Properties

        public string CurrentVersion { get; private set; }
        public string NewVersion { get; private set; }

        public bool ShowAtStartup
        {
            get
            {
                return this._config.CheckAtStartup;
            }
            set
            {
                this._config.CheckAtStartup = value;
                RaisePropertyChanged("ShowAtStartup");
            }
        }

        #endregion


        #region Commands

        #region CmdDownload

        RelayCommand _cmdDownload;
        public ICommand CmdDownload
        {
            get
            {
                if (this._cmdDownload == null)
                {
                    this._cmdDownload = new RelayCommand(() => this.DoCmdDownload());
                }
                return this._cmdDownload;
            }
        }

        private void DoCmdDownload()
        {
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo(App.WEBSITE));

            this.CmdClose.Execute(null);
        }


        #endregion


        protected override void OnCmdClose()
        {
            Updater.Updater.SaveConfig(this._config);

            base.OnCmdClose();
        }


        #endregion


        #region Message handlers

        void MsgShowNewVersion_Handler(TMsgShowNewVersion msg)
        {
            this.CurrentVersion = msg.Info.CurrentVersion;
            this.NewVersion = msg.Info.NewVersion;
        }

        #endregion

    }
}