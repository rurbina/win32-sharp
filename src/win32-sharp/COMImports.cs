// win32-sharp - A simple library to wrap Windows API calls
//
// Copyright © 2007 - 2009 Justin Cherniak
//
// This library is free software; you can redistribute it and/or modify it
// under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2.1 of the License, or (at
// your option) any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
// License (COPYING.txt) for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation,
// Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Win32Sharp.COM
{
    #region Interfaces

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000001-0000-0000-C000-000000000046")]
    public interface IClassFactory
    {
        [PreserveSig]
        HResult CreateInstance([MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
            [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            out IntPtr ppvObject);
        [PreserveSig]
        HResult LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
    }

    #endregion

    public enum HResult : uint
    {
        S_OK = 0,
        S_FALSE = 1,

        E_NOTIMPL = 0x80004001,
        E_OUTOFMEMORY = 0x8007000E,
        E_INVALIDARG = 0x80070057,
        E_NOINTERFACE = 0x80004002,
        E_POINTER = 0x80004003,
        E_HANDLE = 0x80070006,
        E_ABORT = 0x80004004,
        E_FAIL = 0x80004005,
        E_ACCESSDENIED = 0x80070005,

        CLASS_E_NOAGGREGATION = 0x80040110
    }

#if MONO
    [Obsolete("For unix compatibility, these functions should not be used.")]
#endif
    public static class ComAPIFunctions
    {
        [DllImport("ole32.dll")]
        public static extern HResult CoRegisterClassObject([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            [MarshalAs(UnmanagedType.Interface)]IClassFactory pUnkn,
            RegistrationClassContext dwClsContext,
            RegistrationConnectionType flags,
            out IntPtr lpdwRegister);

        [DllImport("ole32.dll")]
        public static extern HResult CoRevokeClassObject(IntPtr dwRegister);
    }

    public static class IID
    {
        public static readonly Guid IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
    }
}
