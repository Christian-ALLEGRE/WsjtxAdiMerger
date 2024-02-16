/*******************************************************************
 * ACSoft (Copyright 2006-2017)
 * 
 * Module : ACRegistry.cs
 * Auteur : Christian ALLEGRE
 * Créé le : 30/01/2006
 * Description : 
 *          DLL de gestion de la base de registre
 *
 * *****************************************************************/
using System;
using Microsoft.Win32;

namespace WsjtxAdiMerger
{
    public class ACRegistry
    {
        private string _rootKey = "";
        private bool _user;

        public ACRegistry(string rootkey, bool user)
        {
            _rootKey = rootkey;
            _user = user;
        }

        private RegistryKey _openRootKey()
        {
            if (_user)
                return Registry.CurrentUser;
            else
                return Registry.LocalMachine;
        }

        public void SetKey(string key, string val)
        {
            RegistryKey rklm;
            try
            {
                rklm = _openRootKey();
            }
            catch
            {
                if (_user)
                    throw new Exception("ACRegistry : Can't open [HKCurrentUser] key !!!");
                else
                    throw new Exception("ACRegistry : Can't open [HKLocalMachine] key !!!");
            }
            RegistryKey rk = null;
            try
            {
                rk = rklm.OpenSubKey(_rootKey, true);
            }
            catch
            {
                if (_user)
                    throw new Exception("ACRegistry : Can't open [HKCurrentUser\\" + _rootKey + "] key !!!");
                else
                    throw new Exception("ACRegistry : Can't open [HKLocalMachine\\" + _rootKey + "] key !!!");
            }
            if (rk == null)
                rk = rklm.CreateSubKey(_rootKey);
            if (rk == null)
                throw new Exception("ACRegistry : Can't create [" + _rootKey + "] key !!!");

            rk.SetValue(key, val);

            // POST-CONDITION
            if (val != (string)rk.GetValue(key))
                throw new Exception("ACRegistry : Can't set [" + _rootKey + "] value (" + val + ") !!!");
        }

        public string GetKey(string key)
        {
            string result = null;
            RegistryKey rklm = _openRootKey();
            RegistryKey rk = rklm.OpenSubKey(_rootKey, true);
            if (rk != null)
            {
                result = (string)rk.GetValue(key);
                rk.Close();
            }
            return result;
        }

        public bool DelKey(string key)
        {
            bool result = false;
            RegistryKey rklm = _openRootKey();
            RegistryKey rk = rklm.OpenSubKey(_rootKey, true);
            if (rk != null)
            {
                rk.DeleteValue(key, false);
                rk.Close();
                result = true;
            }
            return result;
        }

        public bool RenameKey(string oldname, string newname)
        {
            bool result = false;

            string valeur = GetKey(oldname);
            if (valeur != null)
            {
                SetKey(newname, valeur);
                DelKey(oldname);
                result = true;
            }
            return result;
        }
    }
}
