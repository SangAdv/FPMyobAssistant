using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    internal class MACUsers
    {
        #region Variables

        private SAAzureTableStorage mStor;
        private int mPasswordAttempts = 3;

        #endregion Variables

        #region Properties

        public Dictionary<string, MACUserItem> Users = new Dictionary<string, MACUserItem>();
        public MACUserItem User { get; set; } = new MACUserItem();
        public MACUserItem CurrentUser { get; private set; } = new MACUserItem();
        public string CurrentUserEmail { get; private set; } = string.Empty;
        public string SelectedUserEmail { get; set; } = string.Empty;
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MACUsers(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync(string email)
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MACTableNames.UserData, MACPartitionNames.User, email.ToUpper().Trim(), User);
                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Database.SaveError);
            }
        }

        public async Task<bool> LoadAsync(string email)
        {
            try
            {
                var tUser = await mStor.GetAsync<MACUserItem>(MACTableNames.UserData, MACPartitionNames.User, email.ToUpper().Trim());
                User = tUser ?? new MACUserItem();
                SelectedUserEmail = email;
                return true;
            }
            catch
            {
                User = new MACUserItem();
                SelectedUserEmail = string.Empty;
                return false;
            }
        }

        public async Task LoadAllAsync()
        {
            try
            {
                Users.Clear();
                var t = await mStor.GetAllAsync<MACUserItem>(MACTableNames.UserData, MACPartitionNames.User);
                foreach (var item in t) Users[item.Key] = item.Value;
            }
            catch
            {
                Users.Clear();
            }
        }

        public async Task DeleteAsync(string email)
        {
            try
            {
                ErrorMessage = string.Empty;
                await mStor.DeleteAsync(MACTableNames.UserData, MACPartitionNames.User, email.ToUpper().Trim());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public void Clear()
        {
            User = new MACUserItem();
            Users.Clear();
        }

        public MACUserItem Get(string email)
        {
            User = Users.ContainsKey(email.ToUpper().Trim()) ? Users[email.ToUpper().Trim()] : new MACUserItem();
            return User;
        }

        public async Task<bool> IsActiveUserAsync(string email, string password)
        {
            if (!await LoadAsync(email))
            {
                ErrorMessage = "User not defined";
                return false;
            }

            if (User.password != password)
            {
                if (mPasswordAttempts == 0)
                {
                    ErrorMessage = "0 login attempts remain.";
                    return false;
                }
                mPasswordAttempts--;
                ErrorMessage = $"Incorrect password. Please try again. ({mPasswordAttempts} attempts remaining)";
                return false;
            }

            return true;
        }

        public void LoadCurrentUser()
        {
            CurrentUser = new MACUserItem();
            CurrentUser.Name = User.Name;
            CurrentUser.IsAdministrator = User.IsAdministrator;
            CurrentUserEmail = SelectedUserEmail;
        }

        #endregion Methods
    }
}