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

#pragma warning disable 618

using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace Win32Sharp
{
	#region Enums

	public enum AppBarEdge
	{
		Left = 0,
		Top = 1,
		Right = 2,
		Bottom = 3,
	}
	public enum AppBarCallbackMessage
	{
		ABN_STATECHANGE = 0,
		ABN_POSCHANGED = 1,
		ABN_FULLSCREENAPP = 2,
		ABN_WINDOWARRANGE = 3,
	}
	public enum AppBarMessage
	{
		ABM_NEW = 0,
		ABM_REMOVE = 1,
		ABM_QUERYPOS = 2,
		ABM_SETPOS = 3,
		ABM_GETSTATE = 4,
		ABM_GETTASKBARPOS = 5,
		ABM_ACTIVATE = 6,
		ABM_GETAUTOHIDEBAR = 7,
		ABM_SETAUTOHIDEBAR = 8,
		ABM_WINDOWPOSCHANGED = 9,
		ABM_SETSTATE = 10,
	}
	public enum AppCommand
	{
		APPCOMMAND_BROWSER_BACKWARD = 1,
		APPCOMMAND_BROWSER_FORWARD = 2,
		APPCOMMAND_BROWSER_REFRESH = 3,
		APPCOMMAND_BROWSER_STOP = 4,
		APPCOMMAND_BROWSER_SEARCH = 5,
		APPCOMMAND_BROWSER_FAVORITES = 6,
		APPCOMMAND_BROWSER_HOME = 7,
		APPCOMMAND_VOLUME_MUTE = 8,
		APPCOMMAND_VOLUME_DOWN = 9,
		APPCOMMAND_VOLUME_UP = 10,
		APPCOMMAND_MEDIA_NEXTTRACK = 11,
		APPCOMMAND_MEDIA_PREVIOUSTRACK = 12,
		APPCOMMAND_MEDIA_STOP = 13,
		APPCOMMAND_MEDIA_PLAY_PAUSE = 14,
		APPCOMMAND_LAUNCH_MAIL = 15,
		APPCOMMAND_LAUNCH_MEDIA_SELECT = 16,
		APPCOMMAND_LAUNCH_APP1 = 17,
		APPCOMMAND_LAUNCH_APP2 = 18,
		APPCOMMAND_BASS_DOWN = 19,
		APPCOMMAND_BASS_BOOST = 20,
		APPCOMMAND_BASS_UP = 21,
		APPCOMMAND_TREBLE_DOWN = 22,
		APPCOMMAND_TREBLE_UP = 23,
		APPCOMMAND_MICROPHONE_VOLUME_MUTE = 24,
		APPCOMMAND_MICROPHONE_VOLUME_DOWN = 25,
		APPCOMMAND_MICROPHONE_VOLUME_UP = 26,
		APPCOMMAND_HELP = 27,
		APPCOMMAND_FIND = 28,
		APPCOMMAND_NEW = 29,
		APPCOMMAND_OPEN = 30,
		APPCOMMAND_CLOSE = 31,
		APPCOMMAND_SAVE = 32,
		APPCOMMAND_PRINT = 33,
		APPCOMMAND_UNDO = 34,
		APPCOMMAND_REDO = 35,
		APPCOMMAND_COPY = 36,
		APPCOMMAND_CUT = 37,
		APPCOMMAND_PASTE = 38,
		APPCOMMAND_REPLY_TO_MAIL = 39,
		APPCOMMAND_FORWARD_MAIL = 40,
		APPCOMMAND_SEND_MAIL = 41,
		APPCOMMAND_SPELL_CHECK = 42,
		APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE = 43,
		APPCOMMAND_MIC_ON_OFF_TOGGLE = 44,
		APPCOMMAND_CORRECTION_LIST = 45,
		APPCOMMAND_MEDIA_PLAY = 46,
		APPCOMMAND_MEDIA_PAUSE = 47,
		APPCOMMAND_MEDIA_RECORD = 48,
		APPCOMMAND_MEDIA_FAST_FORWARD = 49,
		APPCOMMAND_MEDIA_REWIND = 50,
		APPCOMMAND_MEDIA_CHANNEL_UP = 51,
		APPCOMMAND_MEDIA_CHANNEL_DOWN = 52,
	}
	public enum CbtHookMsg
	{
		HCBT_MOVESIZE = 0,
		HCBT_MINMAX = 1,
		HCBT_QS = 2,
		HCBT_CREATEWND = 3,
		HCBT_DESTROYWND = 4,
		HCBT_ACTIVATE = 5,
		HCBT_CLICKSKIPPED = 6,
		HCBT_KEYSKIPPED = 7,
		HCBT_SYSCOMMAND = 8,
		HCBT_SETFOCUS = 9,
	}
	public enum ChangeDisplaySettingsStatus
	{
		DISP_CHANGE_SUCCESSFUL = 0,
		DISP_CHANGE_BADDUALVIEW = -6,
		DISP_CHANGE_BADFLAGS = -4,
		DISP_CHANGE_BADMODE = -2,
		DISP_CHANGE_BADPARAM = -5,
		DISP_CHANGE_FAILED = -1,
		DISP_CHANGE_NOTUPDATED = -3,
		DISP_CHANGE_RESTART = 1,
	}
	[Flags]
	public enum DeviceIOControlCode : uint
	{
		// CDROM
		CdromBase = DeviceIOFileDevice.CDRom,
		CdromReadToc = (CdromBase << 16) | (0x0000 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromSeekAudio = (CdromBase << 16) | (0x0001 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromStopAudio = (CdromBase << 16) | (0x0002 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromPauseAudio = (CdromBase << 16) | (0x0003 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromResumeAudio = (CdromBase << 16) | (0x0004 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromGetVolume = (CdromBase << 16) | (0x0005 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromPlayAudio = (CdromBase << 16) | (0x0006 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromSetVolume = (CdromBase << 16) | (0x000A << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromReadQChannel = (CdromBase << 16) | (0x000B << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromGetControl = (CdromBase << 16) | (0x000D << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromGetLastSession = (CdromBase << 16) | (0x000E << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromRawRead = (CdromBase << 16) | (0x000F << 2) | DeviceIOMethod.OutDirect | (FileAccess.Read << 14),
		CdromDiskType = (CdromBase << 16) | (0x0010 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromGetDriveGeometry = (CdromBase << 16) | (0x0013 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromGetDriveGeometryEx = (CdromBase << 16) | (0x0014 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromReadTocEx = (CdromBase << 16) | (0x0015 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		CdromGetConfiguration = (CdromBase << 16) | (0x0016 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		// STORAGE
		StorageBase = DeviceIOFileDevice.MassStorage,
		StorageCheckVerify = (StorageBase << 16) | (0x0200 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageCheckVerify2 = (StorageBase << 16) | (0x0200 << 2) | DeviceIOMethod.Buffered | (0 << 14), // FileAccess.Any
		StorageMediaRemoval = (StorageBase << 16) | (0x0201 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageEjectMedia = (StorageBase << 16) | (0x0202 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageLoadMedia = (StorageBase << 16) | (0x0203 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageLoadMedia2 = (StorageBase << 16) | (0x0203 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		StorageReserve = (StorageBase << 16) | (0x0204 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageRelease = (StorageBase << 16) | (0x0205 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageFindNewDevices = (StorageBase << 16) | (0x0206 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageEjectionControl = (StorageBase << 16) | (0x0250 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		StorageMcnControl = (StorageBase << 16) | (0x0251 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		StorageGetMediaTypes = (StorageBase << 16) | (0x0300 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		StorageGetMediaTypesEx = (StorageBase << 16) | (0x0301 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		StorageResetBus = (StorageBase << 16) | (0x0400 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageResetDevice = (StorageBase << 16) | (0x0401 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		StorageGetDeviceNumber = (StorageBase << 16) | (0x0420 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		StoragePredictFailure = (StorageBase << 16) | (0x0440 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		StorageObsoleteResetBus = (StorageBase << 16) | (0x0400 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		StorageObsoleteResetDevice = (StorageBase << 16) | (0x0401 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		// SCSI
		ControllerBase = DeviceIOFileDevice.Controller,
		ScsiPassThrough = (ControllerBase << 16) | (0x0401 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		ScsiMiniport = (ControllerBase << 16) | (0x0402 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		ScsiGetInquiryData = (ControllerBase << 16) | (0x0403 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		ScsiGetCapabilities = (ControllerBase << 16) | (0x0404 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		ScsiPassThroughDirect = (ControllerBase << 16) | (0x0405 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		ScsiGetAddress = (ControllerBase << 16) | (0x0406 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		ScsiRescanBus = (ControllerBase << 16) | (0x0407 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		ScsiGetDumpPointers = (ControllerBase << 16) | (0x0408 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		ScsiIdePassThrough = (ControllerBase << 16) | (0x040a << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		// DISK
		DiskBase = DeviceIOFileDevice.Disk,
		DiskGetDriveGeometry = (DiskBase << 16) | (0x0000 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskGetPartitionInfo = (DiskBase << 16) | (0x0001 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskSetPartitionInfo = (DiskBase << 16) | (0x0002 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskGetDriveLayout = (DiskBase << 16) | (0x0003 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskSetDriveLayout = (DiskBase << 16) | (0x0004 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskVerify = (DiskBase << 16) | (0x0005 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskFormatTracks = (DiskBase << 16) | (0x0006 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskReassignBlocks = (DiskBase << 16) | (0x0007 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskPerformance = (DiskBase << 16) | (0x0008 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskIsWritable = (DiskBase << 16) | (0x0009 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskLogging = (DiskBase << 16) | (0x000a << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskFormatTracksEx = (DiskBase << 16) | (0x000b << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskHistogramStructure = (DiskBase << 16) | (0x000c << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskHistogramData = (DiskBase << 16) | (0x000d << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskHistogramReset = (DiskBase << 16) | (0x000e << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskRequestStructure = (DiskBase << 16) | (0x000f << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskRequestData = (DiskBase << 16) | (0x0010 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskControllerNumber = (DiskBase << 16) | (0x0011 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskSmartGetVersion = (DiskBase << 16) | (0x0020 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskSmartSendDriveCommand = (DiskBase << 16) | (0x0021 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskSmartRcvDriveData = (DiskBase << 16) | (0x0022 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskUpdateDriveSize = (DiskBase << 16) | (0x0032 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskGrowPartition = (DiskBase << 16) | (0x0034 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskGetCacheInformation = (DiskBase << 16) | (0x0035 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskSetCacheInformation = (DiskBase << 16) | (0x0036 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskDeleteDriveLayout = (DiskBase << 16) | (0x0040 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskFormatDrive = (DiskBase << 16) | (0x00f3 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		DiskSenseDevice = (DiskBase << 16) | (0x00f8 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		DiskCheckVerify = (DiskBase << 16) | (0x0200 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskMediaRemoval = (DiskBase << 16) | (0x0201 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskEjectMedia = (DiskBase << 16) | (0x0202 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskLoadMedia = (DiskBase << 16) | (0x0203 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskReserve = (DiskBase << 16) | (0x0204 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskRelease = (DiskBase << 16) | (0x0205 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskFindNewDevices = (DiskBase << 16) | (0x0206 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		DiskGetMediaTypes = (DiskBase << 16) | (0x0300 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		// CHANGER
		ChangerBase = DeviceIOFileDevice.Changer,
		ChangerGetParameters = (ChangerBase << 16) | (0x0000 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		ChangerGetStatus = (ChangerBase << 16) | (0x0001 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		ChangerGetProductData = (ChangerBase << 16) | (0x0002 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		ChangerSetAccess = (ChangerBase << 16) | (0x0004 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		ChangerGetElementStatus = (ChangerBase << 16) | (0x0005 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		ChangerInitializeElementStatus = (ChangerBase << 16) | (0x0006 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		ChangerSetPosition = (ChangerBase << 16) | (0x0007 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		ChangerExchangeMedium = (ChangerBase << 16) | (0x0008 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		ChangerMoveMedium = (ChangerBase << 16) | (0x0009 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		ChangerReinitializeTarget = (ChangerBase << 16) | (0x000A << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		ChangerQueryVolumeTags = (ChangerBase << 16) | (0x000B << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		// FILESYSTEM
		FsctlRequestOplockLevel1 = (DeviceIOFileDevice.FileSystem << 16) | (0 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlRequestOplockLevel2 = (DeviceIOFileDevice.FileSystem << 16) | (1 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlRequestBatchOplock = (DeviceIOFileDevice.FileSystem << 16) | (2 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlOplockBreakAcknowledge = (DeviceIOFileDevice.FileSystem << 16) | (3 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlOpBatchAckClosePending = (DeviceIOFileDevice.FileSystem << 16) | (4 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlOplockBreakNotify = (DeviceIOFileDevice.FileSystem << 16) | (5 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlLockVolume = (DeviceIOFileDevice.FileSystem << 16) | (6 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlUnlockVolume = (DeviceIOFileDevice.FileSystem << 16) | (7 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlDismountVolume = (DeviceIOFileDevice.FileSystem << 16) | (8 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlIsVolumeMounted = (DeviceIOFileDevice.FileSystem << 16) | (10 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlIsPathnameValid = (DeviceIOFileDevice.FileSystem << 16) | (11 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlMarkVolumeDirty = (DeviceIOFileDevice.FileSystem << 16) | (12 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlQueryRetrievalPointers = (DeviceIOFileDevice.FileSystem << 16) | (14 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlGetCompression = (DeviceIOFileDevice.FileSystem << 16) | (15 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlSetCompression = (DeviceIOFileDevice.FileSystem << 16) | (16 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		FsctlMarkAsSystemHive = (DeviceIOFileDevice.FileSystem << 16) | (19 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlOplockBreakAckNo2 = (DeviceIOFileDevice.FileSystem << 16) | (20 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlInvalidateVolumes = (DeviceIOFileDevice.FileSystem << 16) | (21 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlQueryFatBpb = (DeviceIOFileDevice.FileSystem << 16) | (22 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlRequestFilterOplock = (DeviceIOFileDevice.FileSystem << 16) | (23 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlFileSystemGetStatistics = (DeviceIOFileDevice.FileSystem << 16) | (24 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlGetNtfsVolumeData = (DeviceIOFileDevice.FileSystem << 16) | (25 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlGetNtfsFileRecord = (DeviceIOFileDevice.FileSystem << 16) | (26 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlGetVolumeBitmap = (DeviceIOFileDevice.FileSystem << 16) | (27 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlGetRetrievalPointers = (DeviceIOFileDevice.FileSystem << 16) | (28 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlMoveFile = (DeviceIOFileDevice.FileSystem << 16) | (29 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlIsVolumeDirty = (DeviceIOFileDevice.FileSystem << 16) | (30 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlGetHfsInformation = (DeviceIOFileDevice.FileSystem << 16) | (31 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlAllowExtendedDasdIo = (DeviceIOFileDevice.FileSystem << 16) | (32 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlReadPropertyData = (DeviceIOFileDevice.FileSystem << 16) | (33 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlWritePropertyData = (DeviceIOFileDevice.FileSystem << 16) | (34 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlFindFilesBySid = (DeviceIOFileDevice.FileSystem << 16) | (35 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlDumpPropertyData = (DeviceIOFileDevice.FileSystem << 16) | (37 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlSetObjectId = (DeviceIOFileDevice.FileSystem << 16) | (38 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlGetObjectId = (DeviceIOFileDevice.FileSystem << 16) | (39 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlDeleteObjectId = (DeviceIOFileDevice.FileSystem << 16) | (40 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlSetReparsePoint = (DeviceIOFileDevice.FileSystem << 16) | (41 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlGetReparsePoint = (DeviceIOFileDevice.FileSystem << 16) | (42 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlDeleteReparsePoint = (DeviceIOFileDevice.FileSystem << 16) | (43 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlEnumUsnData = (DeviceIOFileDevice.FileSystem << 16) | (44 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlSecurityIdCheck = (DeviceIOFileDevice.FileSystem << 16) | (45 << 2) | DeviceIOMethod.Neither | (FileAccess.Read << 14),
		FsctlReadUsnJournal = (DeviceIOFileDevice.FileSystem << 16) | (46 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlSetObjectIdExtended = (DeviceIOFileDevice.FileSystem << 16) | (47 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlCreateOrGetObjectId = (DeviceIOFileDevice.FileSystem << 16) | (48 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlSetSparse = (DeviceIOFileDevice.FileSystem << 16) | (49 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlSetZeroData = (DeviceIOFileDevice.FileSystem << 16) | (50 << 2) | DeviceIOMethod.Buffered | (FileAccess.Write << 14),
		FsctlQueryAllocatedRanges = (DeviceIOFileDevice.FileSystem << 16) | (51 << 2) | DeviceIOMethod.Neither | (FileAccess.Read << 14),
		FsctlEnableUpgrade = (DeviceIOFileDevice.FileSystem << 16) | (52 << 2) | DeviceIOMethod.Buffered | (FileAccess.Write << 14),
		FsctlSetEncryption = (DeviceIOFileDevice.FileSystem << 16) | (53 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlEncryptionFsctlIo = (DeviceIOFileDevice.FileSystem << 16) | (54 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlWriteRawEncrypted = (DeviceIOFileDevice.FileSystem << 16) | (55 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlReadRawEncrypted = (DeviceIOFileDevice.FileSystem << 16) | (56 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlCreateUsnJournal = (DeviceIOFileDevice.FileSystem << 16) | (57 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlReadFileUsnData = (DeviceIOFileDevice.FileSystem << 16) | (58 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlWriteUsnCloseRecord = (DeviceIOFileDevice.FileSystem << 16) | (59 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlExtendVolume = (DeviceIOFileDevice.FileSystem << 16) | (60 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlQueryUsnJournal = (DeviceIOFileDevice.FileSystem << 16) | (61 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlDeleteUsnJournal = (DeviceIOFileDevice.FileSystem << 16) | (62 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlMarkHandle = (DeviceIOFileDevice.FileSystem << 16) | (63 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlSisCopyFile = (DeviceIOFileDevice.FileSystem << 16) | (64 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		FsctlSisLinkFiles = (DeviceIOFileDevice.FileSystem << 16) | (65 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		FsctlHsmMsg = (DeviceIOFileDevice.FileSystem << 16) | (66 << 2) | DeviceIOMethod.Buffered | ((FileAccess.Read | FileAccess.Write) << 14),
		FsctlNssControl = (DeviceIOFileDevice.FileSystem << 16) | (67 << 2) | DeviceIOMethod.Buffered | (FileAccess.Write << 14),
		FsctlHsmData = (DeviceIOFileDevice.FileSystem << 16) | (68 << 2) | DeviceIOMethod.Neither | ((FileAccess.Read | FileAccess.Write) << 14),
		FsctlRecallFile = (DeviceIOFileDevice.FileSystem << 16) | (69 << 2) | DeviceIOMethod.Neither | (0 << 14),
		FsctlNssRcontrol = (DeviceIOFileDevice.FileSystem << 16) | (70 << 2) | DeviceIOMethod.Buffered | (FileAccess.Read << 14),
		// VIDEO
		VideoQuerySupportedBrightness = (DeviceIOFileDevice.Video << 16) | (0x0125 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		VideoQueryDisplayBrightness = (DeviceIOFileDevice.Video << 16) | (0x0126 << 2) | DeviceIOMethod.Buffered | (0 << 14),
		VideoSetDisplayBrightness = (DeviceIOFileDevice.Video << 16) | (0x0127 << 2) | DeviceIOMethod.Buffered | (0 << 14)
	}
	[Flags]
	public enum DeviceIOFileDevice : uint
	{
		Beep = 0x00000001,
		CDRom = 0x00000002,
		CDRomFileSytem = 0x00000003,
		Controller = 0x00000004,
		Datalink = 0x00000005,
		Dfs = 0x00000006,
		Disk = 0x00000007,
		DiskFileSystem = 0x00000008,
		FileSystem = 0x00000009,
		InPortPort = 0x0000000a,
		Keyboard = 0x0000000b,
		Mailslot = 0x0000000c,
		MidiIn = 0x0000000d,
		MidiOut = 0x0000000e,
		Mouse = 0x0000000f,
		MultiUncProvider = 0x00000010,
		NamedPipe = 0x00000011,
		Network = 0x00000012,
		NetworkBrowser = 0x00000013,
		NetworkFileSystem = 0x00000014,
		Null = 0x00000015,
		ParellelPort = 0x00000016,
		PhysicalNetcard = 0x00000017,
		Printer = 0x00000018,
		Scanner = 0x00000019,
		SerialMousePort = 0x0000001a,
		SerialPort = 0x0000001b,
		Screen = 0x0000001c,
		Sound = 0x0000001d,
		Streams = 0x0000001e,
		Tape = 0x0000001f,
		TapeFileSystem = 0x00000020,
		Transport = 0x00000021,
		Unknown = 0x00000022,
		Video = 0x00000023,
		VirtualDisk = 0x00000024,
		WaveIn = 0x00000025,
		WaveOut = 0x00000026,
		Port8042 = 0x00000027,
		NetworkRedirector = 0x00000028,
		Battery = 0x00000029,
		BusExtender = 0x0000002a,
		Modem = 0x0000002b,
		Vdm = 0x0000002c,
		MassStorage = 0x0000002d,
		Smb = 0x0000002e,
		Ks = 0x0000002f,
		Changer = 0x00000030,
		Smartcard = 0x00000031,
		Acpi = 0x00000032,
		Dvd = 0x00000033,
		FullscreenVideo = 0x00000034,
		DfsFileSystem = 0x00000035,
		DfsVolume = 0x00000036,
		Serenum = 0x00000037,
		Termsrv = 0x00000038,
		Ksec = 0x00000039
	}
	[Flags]
	public enum DeviceIOMethod : uint
	{
		Buffered = 0,
		InDirect = 1,
		OutDirect = 2,
		Neither = 3
	}
	public enum DeviceType
	{
		DBT_DEVTYP_DEVICEINTERFACE = 5,
		DBT_DEVTYP_DEVNODE = 1,
		DBT_DEVTYP_HANDLE = 6,
		DBT_DEVTYP_NET = 4,
		DBT_DEVTYP_OEM = 0,
		DBT_DEVTYP_PORT = 3,
		DBT_DEVTYP_VOLUME = 2,
	}
	public enum DriveTypes : uint
	{
		DRIVE_UNKNOWN = 0,
		DRIVE_NO_ROOT_DIR,
		DRIVE_REMOVABLE,
		DRIVE_FIXED,
		DRIVE_REMOTE,
		DRIVE_CDROM,
		DRIVE_RAMDISK
	}
	public enum EnumDisplayMode
	{
		ENUM_CURRENT_SETTINGS = -1,
		ENUM_REGISTRY_SETTINGS = -2,
	}
	public enum ExitWindowsType
	{
		Force = 4,
		ForceIfHung = 0x10,
		Logoff = 0,
		Poweroff = 8,
		Reboot = 2,
		RestartApps = 0x40,
		Shutdown = 1,
	}
	[Flags]
	public enum FileAttributesAndFlags : uint
	{
		FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
		FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
		FILE_ATTRIBUTE_DEVICE = 0x00000040,
		FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
		FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,
		FILE_ATTRIBUTE_HIDDEN = 0x00000002,
		FILE_ATTRIBUTE_NORMAL = 0x00000080,
		FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
		FILE_ATTRIBUTE_OFFLINE = 0x00001000,
		FILE_ATTRIBUTE_READONLY = 0x00000001,
		FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
		FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
		FILE_ATTRIBUTE_SYSTEM = 0x00000004,
		FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
		FILE_FLAG_BACKUP_SEMANTICS = 0x02000000,
		FILE_FLAG_DELETE_ON_CLOSE = 0x04000000,
		FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,
		FILE_FLAG_NO_BUFFERING = 0x20000000,
		FILE_FLAG_OPEN_NO_RECALL = 0x00100000,
		FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000,
		FILE_FLAG_OVERLAPPED = 0x40000000,
		FILE_FLAG_POSIX_SEMANTICS = 0x01000000,
		FILE_FLAG_RANDOM_ACCESS = 0x10000000,
		FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000,
		FILE_FLAG_WRITE_THROUGH = 0x80000000,
	}
	[Flags]
	public enum FilterProtocol : uint
	{
		FILTER_PROTO_ANY = 0x00,
		FILTER_PROTO_ICMP = 0x01,
		FILTER_PROTO_TCP = 0x06,
		FILTER_PROTO_UDP = 0x11,
	}
	public enum HookType
	{
		WH_MIN = -1,
		WH_MSGFILTER = -1,
		WH_JOURNALRECORD = 0,
		WH_JOURNALPLAYBACK = 1,
		WH_KEYBOARD = 2,
		WH_GETMESSAGE = 3,
		WH_CALLWNDPROC = 4,
		WH_CBT = 5,
		WH_SYSMSGFILTER = 6,
		WH_MOUSE = 7,
		WH_HARDWARE = 8,
		WH_DEBUG = 9,
		WH_SHELL = 10,
		WH_FOREGROUNDIDLE = 11,
		WH_CALLWNDPROCRET = 12,
		WH_KEYBOARD_LL = 13,
		WH_MOUSE_LL = 14
	}
	[Flags]
	public enum KeyModifier : int
	{
		MOD_ALT = 0x0001,
		MOD_CONTROL = 0x0002,
		MOD_SHIFT = 0x0004,
		MOD_WIN = 0x0008,
	}
	public enum ListViewMessage
	{
		LVM_APPROXIMATEVIEWRECT = (LVM_FIRST + 64),
		LVM_ARRANGE = (LVM_FIRST + 22),
		LVM_CANCELEDITLABEL = (LVM_FIRST + 179),
		LVM_CREATEDRAGIMAGE = (LVM_FIRST + 33),
		LVM_DELETEALLITEMS = (LVM_FIRST + 9),
		LVM_DELETECOLUMN = (LVM_FIRST + 28),
		LVM_DELETEITEM = (LVM_FIRST + 8),
		LVM_EDITLABELA = (LVM_FIRST + 23),
		LVM_EDITLABELW = (LVM_FIRST + 118),
		LVM_ENABLEGROUPVIEW = (LVM_FIRST + 157),
		LVM_ENSUREVISIBLE = (LVM_FIRST + 19),
		LVM_FINDITEMA = (LVM_FIRST + 13),
		LVM_FINDITEMW = (LVM_FIRST + 83),
		LVM_FIRST = 0x1000,// ListView messages
		LVM_GETBKCOLOR = (LVM_FIRST + 0),
		LVM_GETBKIMAGEA = (LVM_FIRST + 69),
		LVM_GETBKIMAGEW = (LVM_FIRST + 139),
		LVM_GETCALLBACKMASK = (LVM_FIRST + 10),
		LVM_GETCOLUMNA = (LVM_FIRST + 25),
		LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59),
		LVM_GETCOLUMNW = (LVM_FIRST + 95),
		LVM_GETCOLUMNWIDTH = (LVM_FIRST + 29),
		LVM_GETCOUNTPERPAGE = (LVM_FIRST + 40),
		LVM_GETEDITCONTROL = (LVM_FIRST + 24),
		LVM_GETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 55),
		LVM_GETGROUPINFO = (LVM_FIRST + 149),
		LVM_GETGROUPMETRICS = (LVM_FIRST + 156),
		LVM_GETHOTCURSOR = (LVM_FIRST + 63),
		LVM_GETHOTITEM = (LVM_FIRST + 61),
		LVM_GETHOVERTIME = (LVM_FIRST + 72),
		LVM_GETIMAGELIST = (LVM_FIRST + 2),
		LVM_GETINSERTMARK = (LVM_FIRST + 167),
		LVM_GETINSERTMARKCOLOR = (LVM_FIRST + 171),
		LVM_GETINSERTMARKRECT = (LVM_FIRST + 169),
		LVM_GETISEARCHSTRINGA = (LVM_FIRST + 52),
		LVM_GETISEARCHSTRINGW = (LVM_FIRST + 117),
		LVM_GETITEMA = (LVM_FIRST + 5),
		LVM_GETITEMCOUNT = (LVM_FIRST + 4),
		LVM_GETITEMPOSITION = (LVM_FIRST + 16),
		LVM_GETITEMRECT = (LVM_FIRST + 14),
		LVM_GETITEMSPACING = (LVM_FIRST + 51),
		LVM_GETITEMSTATE = (LVM_FIRST + 44),
		LVM_GETITEMTEXTA = (LVM_FIRST + 45),
		LVM_GETITEMTEXTW = (LVM_FIRST + 115),
		LVM_GETITEMW = (LVM_FIRST + 75),
		LVM_GETNUMBEROFWORKAREAS = (LVM_FIRST + 73),
		LVM_GETORIGIN = (LVM_FIRST + 41),
		LVM_GETOUTLINECOLOR = (LVM_FIRST + 176),
		LVM_GETSELECTEDCOLUMN = (LVM_FIRST + 174),
		LVM_GETSELECTEDCOUNT = (LVM_FIRST + 50),
		LVM_GETSELECTIONMARK = (LVM_FIRST + 66),
		LVM_GETSTRINGWIDTHA = (LVM_FIRST + 17),
		LVM_GETSTRINGWIDTHW = (LVM_FIRST + 87),
		LVM_GETSUBITEMRECT = (LVM_FIRST + 56),
		LVM_GETTEXTBKCOLOR = (LVM_FIRST + 37),
		LVM_GETTEXTCOLOR = (LVM_FIRST + 35),
		LVM_GETTILEINFO = (LVM_FIRST + 165),
		LVM_GETTILEVIEWINFO = (LVM_FIRST + 163),
		LVM_GETTOOLTIPS = (LVM_FIRST + 78),
		LVM_GETTOPINDEX = (LVM_FIRST + 39),
		LVM_GETVIEW = (LVM_FIRST + 143),
		LVM_GETVIEWRECT = (LVM_FIRST + 34),
		LVM_GETWORKAREAS = (LVM_FIRST + 70),
		LVM_HASGROUP = (LVM_FIRST + 161),
		LVM_HITTEST = (LVM_FIRST + 18),
		LVM_INSERTCOLUMNA = (LVM_FIRST + 27),
		LVM_INSERTCOLUMNW = (LVM_FIRST + 97),
		LVM_INSERTGROUP = (LVM_FIRST + 145),
		LVM_INSERTGROUPSORTED = (LVM_FIRST + 159),
		LVM_INSERTITEMA = (LVM_FIRST + 7),
		LVM_INSERTITEMW = (LVM_FIRST + 77),
		LVM_INSERTMARKHITTEST = (LVM_FIRST + 168),
		LVM_ISGROUPVIEWENABLED = (LVM_FIRST + 175),
		LVM_MAPIDTOINDEX = (LVM_FIRST + 181),
		LVM_MAPINDEXTOID = (LVM_FIRST + 180),
		LVM_MOVEGROUP = (LVM_FIRST + 151),
		LVM_MOVEITEMTOGROUP = (LVM_FIRST + 154),
		LVM_REDRAWITEMS = (LVM_FIRST + 21),
		LVM_REMOVEALLGROUPS = (LVM_FIRST + 160),
		LVM_REMOVEGROUP = (LVM_FIRST + 150),
		LVM_SCROLL = (LVM_FIRST + 20),
		LVM_SETBKCOLOR = (LVM_FIRST + 1),
		LVM_SETBKIMAGEA = (LVM_FIRST + 68),
		LVM_SETBKIMAGEW = (LVM_FIRST + 138),
		LVM_SETCALLBACKMASK = (LVM_FIRST + 11),
		LVM_SETCOLUMNA = (LVM_FIRST + 26),
		LVM_SETCOLUMNORDERARRAY = (LVM_FIRST + 58),
		LVM_SETCOLUMNW = (LVM_FIRST + 96),
		LVM_SETCOLUMNWIDTH = (LVM_FIRST + 30),
		LVM_SETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 54),
		LVM_SETGROUPINFO = (LVM_FIRST + 147),
		LVM_SETGROUPMETRICS = (LVM_FIRST + 155),
		LVM_SETHOTCURSOR = (LVM_FIRST + 62),
		LVM_SETHOTITEM = (LVM_FIRST + 60),
		LVM_SETHOVERTIME = (LVM_FIRST + 71),
		LVM_SETICONSPACING = (LVM_FIRST + 53),
		LVM_SETIMAGELIST = (LVM_FIRST + 3),
		LVM_SETINFOTIP = (LVM_FIRST + 173),
		LVM_SETINSERTMARK = (LVM_FIRST + 166),
		LVM_SETINSERTMARKCOLOR = (LVM_FIRST + 170),
		LVM_SETITEMA = (LVM_FIRST + 6),
		LVM_SETITEMCOUNT = (LVM_FIRST + 47),
		LVM_SETITEMPOSITION = (LVM_FIRST + 15),
		LVM_SETITEMPOSITION32 = (LVM_FIRST + 49),
		LVM_SETITEMSTATE = (LVM_FIRST + 43),
		LVM_SETITEMTEXTA = (LVM_FIRST + 46),
		LVM_SETITEMTEXTW = (LVM_FIRST + 116),
		LVM_SETITEMW = (LVM_FIRST + 76),
		LVM_SETOUTLINECOLOR = (LVM_FIRST + 177),
		LVM_SETSELECTEDCOLUMN = (LVM_FIRST + 140),
		LVM_SETSELECTIONMARK = (LVM_FIRST + 67),
		LVM_SETTEXTBKCOLOR = (LVM_FIRST + 38),
		LVM_SETTEXTCOLOR = (LVM_FIRST + 36),
		LVM_SETTILEINFO = (LVM_FIRST + 164),
		LVM_SETTILEVIEWINFO = (LVM_FIRST + 162),
		LVM_SETTILEWIDTH = (LVM_FIRST + 141),
		LVM_SETTOOLTIPS = (LVM_FIRST + 74),
		LVM_SETVIEW = (LVM_FIRST + 142),
		LVM_SETWORKAREAS = (LVM_FIRST + 65),
		LVM_SORTGROUPS = (LVM_FIRST + 158),
		LVM_SORTITEMS = (LVM_FIRST + 48),
		LVM_SORTITEMSEX = (LVM_FIRST + 81),
		LVM_SUBITEMHITTEST = (LVM_FIRST + 57),
		LVM_UPDATE = (LVM_FIRST + 42),
	}
	[Flags]
	public enum MenuFlags
	{
		MF_INSERT = 0x0000,
		MF_CHANGE = 0x0080,
		MF_APPEND = 0x0100,
		MF_DELETE = 0x0200,
		MF_REMOVE = 0x1000,
		MF_BYCOMMAND = 0x0000,
		MF_BYPOSITION = 0x0400,
		MF_SEPARATOR = 0x0800,
		MF_ENABLED = 0x0000,
		MF_GRAYED = 0x0001,
		MF_DISABLED = 0x0002,
		MF_UNCHECKED = 0x0000,
		MF_CHECKED = 0x0008,
		MF_USECHECKBITMAPS = 0x0200,
		MF_STRING = 0x0000,
		MF_BITMAP = 0x0004,
		MF_OWNERDRAW = 0x0100,
		MF_POPUP = 0x0010,
		MF_MENUBARBREAK = 0x0020,
		MF_MENUBREAK = 0x0040,
		MF_UNHILITE = 0x0000,
		MF_HILITE = 0x0080,
		MF_DEFAULT = 0x1000,
		MF_SYSMENU = 0x2000,
		MF_HELP = 0x4000,
		MF_RIGHTJUSTIFY = 0x4000,
		MF_MOUSESELECT = 0x8000,
		MF_END = 0x0080,
	}
	public enum PacketFilterAction
	{
		PF_ACTION_FORWARD = 0,
		PF_ACTION_DROP = 1
	}
	public enum PacketFilterAddressType
	{
		PF_IPV4 = 0,
		PF_IPV6 = 1
	}
	[Flags]
	public enum PipeMode : uint
	{
		PIPE_TYPE_BYTE = 0x00000000,
		PIPE_TYPE_MESSAGE = 0x00000004,
		PIPE_READMODE_BYTE = 0x00000000,
		PIPE_READMODE_MESSAGE = 0x00000002,
		PIPE_WAIT = 0x00000000,
		PIPE_NOWAIT = 0x00000001
	}
	[Flags]
	public enum PipeOpenMode : uint
	{
		PIPE_ACCESS_DUPLEX = 1,
		PIPE_ACCESS_OUTBOUND = 2,
		PIPE_ACCESS_INBOUND = 3,
		FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,
		FILE_FLAG_WRITE_THROUGH = 0x80000000,
		FILE_FLAG_OVERLAPPED = 0x40000000,
		WRITE_DAC = 0x00040000,
		WRITE_OWNER = 0x00080000,
		ACCESS_SYSTEM_SECURITY = 0x01000000
	}
	public enum RawDataCommand : uint
	{
		RID_INPUT = 0x10000003,
		RID_HEADER = 0x10000005,
	}
	public enum RawInputButton
	{
		RAWINPUT_DETAILS = 0x209,
		RAWINPUT_GUIDE = 0x8D,
		RAWINPUT_TVJUMP = 0x25,
		RAWINPUT_STANDBY = 0x82,
		RAWINPUT_OEM1 = 0x80,
		RAWINPUT_OEM2 = 0x81,
		RAWINPUT_MYTV = 0x46,
		RAWINPUT_MYVIDEOS = 0x4A,
		RAWINPUT_MYPICTURES = 0x49,
		RAWINPUT_MYMUSIC = 0x47,
		RAWINPUT_RECORDEDTV = 0x48,
		RAWINPUT_DVDANGLE = 0x4B,
		RAWINPUT_DVDAUDIO = 0x4C,
		RAWINPUT_DVDMENU = 0x24,
		RAWINPUT_DVDSUBTITLE = 0x4D,
	}
	[Flags]
	public enum RawInputDeviceFlag
	{
		RIDEV_REMOVE = 0x00000001,
		RIDEV_EXCLUDE = 0x00000010,
		RIDEV_PAGEONLY = 0x00000020,
		RIDEV_NOLEGACY = 0x00000030,
		RIDEV_INPUTSINK = 0x00000100,
		RIDEV_CAPTUREMOUSE = 0x00000200,  // effective when mouse nolegacy is specified, otherwise it would be an error
		RIDEV_NOHOTKEYS = 0x00000200,  // effective for keyboard.
		RIDEV_APPKEYS = 0x00000400,  // effective for keyboard.
		RIDEV_EXMODEMASK = 0x000000F0,
	}
	public enum RawInputType : uint
	{
		RIM_TYPEMOUSE = 0,
		RIM_TYPEKEYBOARD = 1,
		RIM_TYPEHID = 2,
	}
	public enum SetWindowLongIndex
	{
		GWL_WNDPROC = -4,
		GWL_HINSTANCE = -6,
		GWL_HWNDPARENT = -8,
		GWL_STYLE = -16,
		GWL_EXSTYLE = -20,
		GWL_USERDATA = -21,
		GWL_ID = -12,
	}
	[Flags]
	public enum SetWindowPosFlags
	{
		SWP_NOSIZE = 0x0001,
		SWP_NOMOVE = 0x0002,
		SWP_NOZORDER = 0x0004,
		SWP_NOREDRAW = 0x0008,
		SWP_NOACTIVATE = 0x0010,
		SWP_FRAMECHANGED = 0x0020, /* The frame changed: send WM_NCCALCSIZE */
		SWP_SHOWWINDOW = 0x0040,
		SWP_HIDEWINDOW = 0x0080,
		SWP_NOCOPYBITS = 0x0100,
		SWP_NOOWNERZORDER = 0x0200,  /* Don't do owner Z ordering */
		SWP_NOSENDCHANGING = 0x0400,  /* Don't send WM_WINDOWPOSCHANGING */
		SWP_DRAWFRAME = SWP_FRAMECHANGED,
		SWP_NOREPOSITION = SWP_NOOWNERZORDER,
		SWP_DEFERERASE = 0x2000,
		SWP_ASYNCWINDOWPOS = 0x4000,
	}
	public enum SetWindowPosWindow
	{
		HWND_TOP = 0,
		HWND_BOTTOM = 1,
		HWND_TOPMOST = -1,
		HWND_NOTOPMOST = -2,
	}
	public enum ShowWindowCommand : uint
	{
		SW_HIDE = 0,
		SW_SHOWNORMAL = 1,
		SW_NORMAL = 1,
		SW_SHOWMINIMIZED = 2,
		SW_SHOWMAXIMIZED = 3,
		SW_MAXIMIZE = 3,
		SW_SHOWNOACTIVATE = 4,
		SW_SHOW = 5,
		SW_MINIMIZE = 6,
		SW_SHOWMINNOACTIVE = 7,
		SW_SHOWNA = 8,
		SW_RESTORE = 9,
		SW_SHOWDEFAULT = 10,
		SW_FORCEMINIMIZE = 11,
		SW_MAX = 11,
	}
	[Flags]
	public enum ShutdownReason : uint
	{
		SHTDN_REASON_FLAG_USER_DEFINED = 0x40000000,
		SHTDN_REASON_FLAG_PLANNED = 0x80000000,

		// Microsoft major reasons.
		SHTDN_REASON_MAJOR_OTHER = 0x00000000,
		SHTDN_REASON_MAJOR_NONE = 0x00000000,
		SHTDN_REASON_MAJOR_HARDWARE = 0x00010000,
		SHTDN_REASON_MAJOR_OPERATINGSYSTEM = 0x00020000,
		SHTDN_REASON_MAJOR_SOFTWARE = 0x00030000,
		SHTDN_REASON_MAJOR_APPLICATION = 0x00040000,
		SHTDN_REASON_MAJOR_SYSTEM = 0x00050000,
		SHTDN_REASON_MAJOR_POWER = 0x00060000,
		SHTDN_REASON_MAJOR_LEGACY_API = 0x00070000,

		// Microsoft minor reasons.
		SHTDN_REASON_MINOR_OTHER = 0x00000000,
		SHTDN_REASON_MINOR_NONE = 0x000000ff,
		SHTDN_REASON_MINOR_MAINTENANCE = 0x00000001,
		SHTDN_REASON_MINOR_INSTALLATION = 0x00000002,
		SHTDN_REASON_MINOR_UPGRADE = 0x00000003,
		SHTDN_REASON_MINOR_RECONFIG = 0x00000004,
		SHTDN_REASON_MINOR_HUNG = 0x00000005,
		SHTDN_REASON_MINOR_UNSTABLE = 0x00000006,
		SHTDN_REASON_MINOR_DISK = 0x00000007,
		SHTDN_REASON_MINOR_PROCESSOR = 0x00000008,
		SHTDN_REASON_MINOR_NETWORKCARD = 0x00000009,
		SHTDN_REASON_MINOR_POWER_SUPPLY = 0x0000000a,
		SHTDN_REASON_MINOR_CORDUNPLUGGED = 0x0000000b,
		SHTDN_REASON_MINOR_ENVIRONMENT = 0x0000000c,
		SHTDN_REASON_MINOR_HARDWARE_DRIVER = 0x0000000d,
		SHTDN_REASON_MINOR_OTHERDRIVER = 0x0000000e,
		SHTDN_REASON_MINOR_BLUESCREEN = 0x0000000F,
		SHTDN_REASON_MINOR_SERVICEPACK = 0x00000010,
		SHTDN_REASON_MINOR_HOTFIX = 0x00000011,
		SHTDN_REASON_MINOR_SECURITYFIX = 0x00000012,
		SHTDN_REASON_MINOR_SECURITY = 0x00000013,
		SHTDN_REASON_MINOR_NETWORK_CONNECTIVITY = 0x00000014,
		SHTDN_REASON_MINOR_WMI = 0x00000015,
		SHTDN_REASON_MINOR_SERVICEPACK_UNINSTALL = 0x00000016,
		SHTDN_REASON_MINOR_HOTFIX_UNINSTALL = 0x00000017,
		SHTDN_REASON_MINOR_SECURITYFIX_UNINSTALL = 0x00000018,
		SHTDN_REASON_MINOR_MMC = 0x00000019,
		SHTDN_REASON_MINOR_SYSTEMRESTORE = 0x0000001a,
		SHTDN_REASON_MINOR_TERMSRV = 0x00000020,
		SHTDN_REASON_MINOR_DC_PROMOTION = 0x00000021,
		SHTDN_REASON_MINOR_DC_DEMOTION = 0x00000022,

		SHTDN_REASON_UNKNOWN = SHTDN_REASON_MINOR_NONE,
		SHTDN_REASON_LEGACY_API = (SHTDN_REASON_MAJOR_LEGACY_API | SHTDN_REASON_FLAG_PLANNED),

		// This mask cuts out UI flags.
		SHTDN_REASON_VALID_BIT_MASK = 0xc0ffffff,
	}
	public enum TrackMode
	{
		YellowMode2,
		XAForm2,
		CDDA
	}
	public enum VirtualKey : byte
	{
		VK_LBUTTON = 0x01,
		VK_RBUTTON = 0x02,
		VK_CANCEL = 0x03,
		VK_MBUTTON = 0x04,
		VK_XBUTTON1 = 0x05,
		VK_XBUTTON2 = 0x06,
		VK_BACK = 0x08,
		VK_TAB = 0x09,
		VK_CLEAR = 0x0C,
		VK_RETURN = 0x0D,
		VK_SHIFT = 0x10,
		VK_CONTROL = 0x11,
		VK_MENU = 0x12,
		VK_PAUSE = 0x13,
		VK_CAPITAL = 0x14,
		VK_KANA = 0x15,
		VK_HANGUL = 0x15,
		VK_JUNJA = 0x17,
		VK_FINAL = 0x18,
		VK_HANJA = 0x19,
		VK_KANJI = 0x19,
		VK_ESCAPE = 0x1B,
		VK_CONVERT = 0x1C,
		VK_NONCONVERT = 0x1D,
		VK_ACCEPT = 0x1E,
		VK_MODECHANGE = 0x1F,
		VK_SPACE = 0x20,
		VK_PRIOR = 0x21,
		VK_NEXT = 0x22,
		VK_END = 0x23,
		VK_HOME = 0x24,
		VK_LEFT = 0x25,
		VK_UP = 0x26,
		VK_RIGHT = 0x27,
		VK_DOWN = 0x28,
		VK_SELECT = 0x29,
		VK_PRbyte = 0x2A,
		VK_EXECUTE = 0x2B,
		VK_SNAPSHOT = 0x2C,
		VK_INSERT = 0x2D,
		VK_DELETE = 0x2E,
		VK_HELP = 0x2F,
		VK_0 = 0x30,
		VK_1 = 0x31,
		VK_2 = 0x32,
		VK_3 = 0x33,
		VK_4 = 0x34,
		VK_5 = 0x35,
		VK_6 = 0x36,
		VK_7 = 0x37,
		VK_8 = 0x38,
		VK_9 = 0x39,
		VK_A = 0x41,
		VK_B = 0x42,
		VK_C = 0x43,
		VK_D = 0x44,
		VK_E = 0x45,
		VK_F = 0x46,
		VK_G = 0x47,
		VK_H = 0x48,
		VK_I = 0x49,
		VK_J = 0x4A,
		VK_K = 0x4B,
		VK_L = 0x4C,
		VK_M = 0x4D,
		VK_N = 0x4E,
		VK_O = 0x4F,
		VK_P = 0x50,
		VK_Q = 0x51,
		VK_R = 0x52,
		VK_S = 0x53,
		VK_T = 0x54,
		VK_U = 0x55,
		VK_V = 0x56,
		VK_W = 0x57,
		VK_X = 0x58,
		VK_Y = 0x59,
		VK_Z = 0x5A,
		VK_LWIN = 0x5B,
		VK_RWIN = 0x5C,
		VK_APPS = 0x5D,
		VK_SLEEP = 0x5F,
		VK_NUMPAD0 = 0x60,
		VK_NUMPAD1 = 0x61,
		VK_NUMPAD2 = 0x62,
		VK_NUMPAD3 = 0x63,
		VK_NUMPAD4 = 0x64,
		VK_NUMPAD5 = 0x65,
		VK_NUMPAD6 = 0x66,
		VK_NUMPAD7 = 0x67,
		VK_NUMPAD8 = 0x68,
		VK_NUMPAD9 = 0x69,
		VK_MULTIPLY = 0x6A,
		VK_ADD = 0x6B,
		VK_SEPARATOR = 0x6C,
		VK_SUBTRACT = 0x6D,
		VK_DECIMAL = 0x6E,
		VK_DIVIDE = 0x6F,
		VK_F1 = 0x70,
		VK_F2 = 0x71,
		VK_F3 = 0x72,
		VK_F4 = 0x73,
		VK_F5 = 0x74,
		VK_F6 = 0x75,
		VK_F7 = 0x76,
		VK_F8 = 0x77,
		VK_F9 = 0x78,
		VK_F10 = 0x79,
		VK_F11 = 0x7A,
		VK_F12 = 0x7B,
		VK_F13 = 0x7C,
		VK_F14 = 0x7D,
		VK_F15 = 0x7E,
		VK_F16 = 0x7F,
		VK_F17 = 0x80,
		VK_F18 = 0x81,
		VK_F19 = 0x82,
		VK_F20 = 0x83,
		VK_F21 = 0x84,
		VK_F22 = 0x85,
		VK_F23 = 0x86,
		VK_F24 = 0x87,
		VK_NUMLOCK = 0x90,
		VK_SCROLL = 0x91,
		VK_OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
		VK_OEM_FJ_JISHO = 0x92,   // 'Dictionary' key
		VK_OEM_FJ_MASSHOU = 0x93,   // 'Unregister word' key
		VK_OEM_FJ_TOUROKU = 0x94,   // 'Register word' key
		VK_OEM_FJ_LOYA = 0x95,   // 'Left OYAYUBI' key
		VK_OEM_FJ_ROYA = 0x96,   // 'Right OYAYUBI' key
		VK_LSHIFT = 0xA0,
		VK_RSHIFT = 0xA1,
		VK_LCONTROL = 0xA2,
		VK_RCONTROL = 0xA3,
		VK_LMENU = 0xA4,
		VK_RMENU = 0xA5,
		VK_BROWSER_BACK = 0xA6,
		VK_BROWSER_FORWARD = 0xA7,
		VK_BROWSER_REFRESH = 0xA8,
		VK_BROWSER_STOP = 0xA9,
		VK_BROWSER_SEARCH = 0xAA,
		VK_BROWSER_FAVORITES = 0xAB,
		VK_BROWSER_HOME = 0xAC,
		VK_VOLUME_MUTE = 0xAD,
		VK_VOLUME_DOWN = 0xAE,
		VK_VOLUME_UP = 0xAF,
		VK_MEDIA_NEXT_TRACK = 0xB0,
		VK_MEDIA_PREV_TRACK = 0xB1,
		VK_MEDIA_STOP = 0xB2,
		VK_MEDIA_PLAY_PAUSE = 0xB3,
		VK_LAUNCH_MAIL = 0xB4,
		VK_LAUNCH_MEDIA_SELECT = 0xB5,
		VK_LAUNCH_APP1 = 0xB6,
		VK_LAUNCH_APP2 = 0xB7,
		VK_OEM_1 = 0xBA,   // ',:' for US
		VK_OEM_PLUS = 0xBB,   // '+' any country
		VK_OEM_COMMA = 0xBC,   // ',' any country
		VK_OEM_MINUS = 0xBD,   // '-' any country
		VK_OEM_PERIOD = 0xBE,   // '.' any country
		VK_OEM_2 = 0xBF,   // '/?' for US
		VK_OEM_3 = 0xC0,   // '`~' for US
		VK_OEM_4 = 0xDB,  //  '[{' for US
		VK_OEM_5 = 0xDC,  //  '\|' for US
		VK_OEM_6 = 0xDD,  //  ']}' for US
		VK_OEM_7 = 0xDE,  //  ''"' for US
		VK_OEM_8 = 0xDF,
		VK_OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
		VK_OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
		VK_ICO_HELP = 0xE3,  //  Help key on ICO
		VK_ICO_00 = 0xE4,  //  00 key on ICO
		VK_PROCESSKEY = 0xE5,
		VK_PACKET = 0xE7,
		VK_OEM_RESET = 0xE9,
		VK_OEM_JUMP = 0xEA,
		VK_OEM_PA1 = 0xEB,
		VK_OEM_PA2 = 0xEC,
		VK_OEM_PA3 = 0xED,
		VK_OEM_WSCTRL = 0xEE,
		VK_OEM_CUSEL = 0xEF,
		VK_OEM_ATTN = 0xF0,
		VK_OEM_FINISH = 0xF1,
		VK_OEM_COPY = 0xF2,
		VK_OEM_AUTO = 0xF3,
		VK_OEM_ENLW = 0xF4,
		VK_OEM_BACKTAB = 0xF5,
		VK_ATTN = 0xF6,
		VK_CRSEL = 0xF7,
		VK_EXSEL = 0xF8,
		VK_EREOF = 0xF9,
		VK_PLAY = 0xFA,
		VK_ZOOM = 0xFB,
		VK_NONAME = 0xFC,
		VK_PA1 = 0xFD,
		VK_OEM_CLEAR = 0xFE,
	}
	public enum VolumeType
	{
		DBTF_MEDIA = 1,
		DBTF_NET = 2,
	}
	[Flags]
	public enum WindowStyle : uint
	{
		Invalid = 0,
		WS_OVERLAPPED = 0x00000000,
		WS_POPUP = 0x80000000,
		WS_CHILD = 0x40000000,
		WS_MINIMIZE = 0x20000000,
		WS_VISIBLE = 0x10000000,
		WS_DISABLED = 0x08000000,
		WS_CLIPSIBLINGS = 0x04000000,
		WS_CLIPCHILDREN = 0x02000000,
		WS_MAXIMIZE = 0x01000000,
		WS_CAPTION = 0x00C00000,     /* WS_BORDER | WS_DLGFRAME  */
		WS_BORDER = 0x00800000,
		WS_DLGFRAME = 0x00400000,
		WS_VSCROLL = 0x00200000,
		WS_HSCROLL = 0x00100000,
		WS_SYSMENU = 0x00080000,
		WS_THICKFRAME = 0x00040000,
		WS_GROUP = 0x00020000,
		WS_TABSTOP = 0x00010000,
		WS_MINIMIZEBOX = 0x00020000,
		WS_MAXIMIZEBOX = 0x00010000,
		WS_TILED = WS_OVERLAPPED,
		WS_ICONIC = WS_MINIMIZE,
		WS_SIZEBOX = WS_THICKFRAME,
		WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,
		WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),
		WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU),
		WS_CHILDWINDOW = (WS_CHILD),
		WS_EX_DLGMODALFRAME = 0x00000001,
		WS_EX_NOPARENTNOTIFY = 0x00000004,
		WS_EX_TOPMOST = 0x00000008,
		WS_EX_ACCEPTFILES = 0x00000010,
		WS_EX_TRANSPARENT = 0x00000020,
		WS_EX_MDICHILD = 0x00000040,
		WS_EX_TOOLWINDOW = 0x00000080,
		WS_EX_WINDOWEDGE = 0x00000100,
		WS_EX_CLIENTEDGE = 0x00000200,
		WS_EX_CONTEXTHELP = 0x00000400,
		WS_EX_RIGHT = 0x00001000,
		WS_EX_LEFT = 0x00000000,
		WS_EX_RTLREADING = 0x00002000,
		WS_EX_LTRREADING = 0x00000000,
		WS_EX_LEFTSCROLLBAR = 0x00004000,
		WS_EX_RIGHTSCROLLBAR = 0x00000000,
		WS_EX_CONTROLPARENT = 0x00010000,
		WS_EX_STATICEDGE = 0x00020000,
		WS_EX_APPWINDOW = 0x00040000,
		WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
		WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),
		WS_EX_LAYERED = 0x00080000,
		WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
		WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring
		WS_EX_COMPOSITED = 0x02000000,
		WS_EX_NOACTIVATE = 0x08000000
	}
	public enum WmDeviceChangeEvent
	{
		DBT_CONFIGCHANGECANCELED = 0x0019,
		DBT_CONFIGCHANGED = 0x0018,
		DBT_CUSTOMEVENT = 0x8006,
		DBT_DEVICEARRIVAL = 0x8000,
		DBT_DEVICEQUERYREMOVE = 0x8001,
		DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
		DBT_DEVICEREMOVEPENDING = 0x8003,
		DBT_DEVICEREMOVECOMPLETE = 0x8004,
		DBT_DEVICETYPESPECIFIC = 0x8005,
		DBT_DEVNODES_CHANGED = 0x0007,
		DBT_QUERYCHANGECONFIG = 0x0017,
		DBT_USERDEFINED = 0xFFFF,
	}
	public enum CaptureMessage
	{
		WM_CAP_START = WmMessage.WM_USER,

		// start of unicode messages
		WM_CAP_UNICODE_START = WmMessage.WM_USER + 100,

		WM_CAP_GET_CAPSTREAMPTR = (WM_CAP_START + 1),

		WM_CAP_SET_CALLBACK_ERRORW = (WM_CAP_UNICODE_START + 2),
		WM_CAP_SET_CALLBACK_STATUSW = (WM_CAP_UNICODE_START + 3),
		WM_CAP_SET_CALLBACK_ERRORA = (WM_CAP_START + 2),
		WM_CAP_SET_CALLBACK_STATUSA = (WM_CAP_START + 3),
		WM_CAP_SET_CALLBACK_ERROR = WM_CAP_SET_CALLBACK_ERRORW,
		WM_CAP_SET_CALLBACK_STATUS = WM_CAP_SET_CALLBACK_STATUSW,
		WM_CAP_SET_CALLBACK_YIELD = (WM_CAP_START + 4),
		WM_CAP_SET_CALLBACK_FRAME = (WM_CAP_START + 5),
		WM_CAP_SET_CALLBACK_VIDEOSTREAM = (WM_CAP_START + 6),
		WM_CAP_SET_CALLBACK_WAVESTREAM = (WM_CAP_START + 7),
		WM_CAP_GET_USER_DATA = (WM_CAP_START + 8),
		WM_CAP_SET_USER_DATA = (WM_CAP_START + 9),

		WM_CAP_DRIVER_CONNECT = (WM_CAP_START + 10),
		WM_CAP_DRIVER_DISCONNECT = (WM_CAP_START + 11),

		WM_CAP_DRIVER_GET_NAMEA = (WM_CAP_START + 12),
		WM_CAP_DRIVER_GET_VERSIONA = (WM_CAP_START + 13),
		WM_CAP_DRIVER_GET_NAMEW = (WM_CAP_UNICODE_START + 12),
		WM_CAP_DRIVER_GET_VERSIONW = (WM_CAP_UNICODE_START + 13),
		WM_CAP_DRIVER_GET_NAME = WM_CAP_DRIVER_GET_NAMEW,
		WM_CAP_DRIVER_GET_VERSION = WM_CAP_DRIVER_GET_VERSIONW,

		WM_CAP_DRIVER_GET_CAPS = (WM_CAP_START + 14),

		WM_CAP_FILE_SET_CAPTURE_FILEA = (WM_CAP_START + 20),
		WM_CAP_FILE_GET_CAPTURE_FILEA = (WM_CAP_START + 21),
		WM_CAP_FILE_SAVEASA = (WM_CAP_START + 23),
		WM_CAP_FILE_SAVEDIBA = (WM_CAP_START + 25),
		WM_CAP_FILE_SET_CAPTURE_FILEW = (WM_CAP_UNICODE_START + 20),
		WM_CAP_FILE_GET_CAPTURE_FILEW = (WM_CAP_UNICODE_START + 21),
		WM_CAP_FILE_SAVEASW = (WM_CAP_UNICODE_START + 23),
		WM_CAP_FILE_SAVEDIBW = (WM_CAP_UNICODE_START + 25),
		WM_CAP_FILE_SET_CAPTURE_FILE = WM_CAP_FILE_SET_CAPTURE_FILEW,
		WM_CAP_FILE_GET_CAPTURE_FILE = WM_CAP_FILE_GET_CAPTURE_FILEW,
		WM_CAP_FILE_SAVEAS = WM_CAP_FILE_SAVEASW,
		WM_CAP_FILE_SAVEDIB = WM_CAP_FILE_SAVEDIBW,

		// out of order to save on ifdefs
		WM_CAP_FILE_ALLOCATE = (WM_CAP_START + 22),
		WM_CAP_FILE_SET_INFOCHUNK = (WM_CAP_START + 24),

		WM_CAP_EDIT_COPY = (WM_CAP_START + 30),

		WM_CAP_SET_AUDIOFORMAT = (WM_CAP_START + 35),
		WM_CAP_GET_AUDIOFORMAT = (WM_CAP_START + 36),

		WM_CAP_DLG_VIDEOFORMAT = (WM_CAP_START + 41),
		WM_CAP_DLG_VIDEOSOURCE = (WM_CAP_START + 42),
		WM_CAP_DLG_VIDEODISPLAY = (WM_CAP_START + 43),
		WM_CAP_GET_VIDEOFORMAT = (WM_CAP_START + 44),
		WM_CAP_SET_VIDEOFORMAT = (WM_CAP_START + 45),
		WM_CAP_DLG_VIDEOCOMPRESSION = (WM_CAP_START + 46),

		WM_CAP_SET_PREVIEW = (WM_CAP_START + 50),
		WM_CAP_SET_OVERLAY = (WM_CAP_START + 51),
		WM_CAP_SET_PREVIEWRATE = (WM_CAP_START + 52),
		WM_CAP_SET_SCALE = (WM_CAP_START + 53),
		WM_CAP_GET_STATUS = (WM_CAP_START + 54),
		WM_CAP_SET_SCROLL = (WM_CAP_START + 55),

		WM_CAP_GRAB_FRAME = (WM_CAP_START + 60),
		WM_CAP_GRAB_FRAME_NOSTOP = (WM_CAP_START + 61),

		WM_CAP_SEQUENCE = (WM_CAP_START + 62),
		WM_CAP_SEQUENCE_NOFILE = (WM_CAP_START + 63),
		WM_CAP_SET_SEQUENCE_SETUP = (WM_CAP_START + 64),
		WM_CAP_GET_SEQUENCE_SETUP = (WM_CAP_START + 65),

		WM_CAP_SET_MCI_DEVICEA = (WM_CAP_START + 66),
		WM_CAP_GET_MCI_DEVICEA = (WM_CAP_START + 67),
		WM_CAP_SET_MCI_DEVICEW = (WM_CAP_UNICODE_START + 66),
		WM_CAP_GET_MCI_DEVICEW = (WM_CAP_UNICODE_START + 67),
		WM_CAP_SET_MCI_DEVICE = WM_CAP_SET_MCI_DEVICEW,
		WM_CAP_GET_MCI_DEVICE = WM_CAP_GET_MCI_DEVICEW,

		WM_CAP_STOP = (WM_CAP_START + 68),
		WM_CAP_ABORT = (WM_CAP_START + 69),

		WM_CAP_SINGLE_FRAME_OPEN = (WM_CAP_START + 70),
		WM_CAP_SINGLE_FRAME_CLOSE = (WM_CAP_START + 71),
		WM_CAP_SINGLE_FRAME = (WM_CAP_START + 72),

		WM_CAP_PAL_OPENA = (WM_CAP_START + 80),
		WM_CAP_PAL_SAVEA = (WM_CAP_START + 81),
		WM_CAP_PAL_OPENW = (WM_CAP_UNICODE_START + 80),
		WM_CAP_PAL_SAVEW = (WM_CAP_UNICODE_START + 81),
		WM_CAP_PAL_OPEN = WM_CAP_PAL_OPENW,
		WM_CAP_PAL_SAVE = WM_CAP_PAL_SAVEW,
		WM_CAP_PAL_PASTE = (WM_CAP_START + 82),
		WM_CAP_PAL_AUTOCREATE = (WM_CAP_START + 83),
		WM_CAP_PAL_MANUALCREATE = (WM_CAP_START + 84),

		// Following added post VFW 1.1
		WM_CAP_SET_CALLBACK_CAPCONTROL = (WM_CAP_START + 85),

		// Defines end of the message range
		WM_CAP_UNICODE_END = WM_CAP_PAL_SAVEW,
		WM_CAP_END = WM_CAP_UNICODE_END,

	}
	public enum WmMessage
	{
		WM_ACTIVATE = 0x6,
		WM_ACTIVATEAPP = 0x1C,
		WM_AFXFIRST = 0x360,
		WM_AFXLAST = 0x37F,
		WM_APP = 0x8000,
		WM_APPCOMMAND = 0x0319,
		WM_ASKCBFORMATNAME = 0x30C,
		WM_CANCELJOURNAL = 0x4B,
		WM_CANCELMODE = 0x1F,
		WM_CAP_START = WM_USER,
		WM_CAPTURECHANGED = 0x215,
		WM_CHANGECBCHAIN = 0x30D,
		WM_CHAR = 0x102,
		WM_CHARTOITEM = 0x2F,
		WM_CHILDACTIVATE = 0x22,
		WM_CLEAR = 0x303,
		WM_CLOSE = 0x10,
		WM_COMMAND = 0x111,
		WM_COMPACTING = 0x41,
		WM_COMPAREITEM = 0x39,
		WM_CONTEXTMENU = 0x7B,
		WM_COPY = 0x301,
		WM_COPYDATA = 0x4A,
		WM_CREATE = 0x1,
		WM_CTLCOLORBTN = 0x135,
		WM_CTLCOLORDLG = 0x136,
		WM_CTLCOLOREDIT = 0x133,
		WM_CTLCOLORLISTBOX = 0x134,
		WM_CTLCOLORMSGBOX = 0x132,
		WM_CTLCOLORSCROLLBAR = 0x137,
		WM_CTLCOLORSTATIC = 0x138,
		WM_CUT = 0x300,
		WM_DEADCHAR = 0x103,
		WM_DELETEITEM = 0x2D,
		WM_DESTROY = 0x2,
		WM_DESTROYCLIPBOARD = 0x307,
		WM_DEVICECHANGE = 0x219,
		WM_DEVMODECHANGE = 0x1B,
		WM_DISPLAYCHANGE = 0x7E,
		WM_DRAWCLIPBOARD = 0x308,
		WM_DRAWITEM = 0x2B,
		WM_DROPFILES = 0x233,
		WM_ENABLE = 0xA,
		WM_ENDSESSION = 0x16,
		WM_ENTERIDLE = 0x121,
		WM_ENTERMENULOOP = 0x211,
		WM_ENTERSIZEMOVE = 0x231,
		WM_ERASEBKGND = 0x14,
		WM_EXITMENULOOP = 0x212,
		WM_EXITSIZEMOVE = 0x232,
		WM_FONTCHANGE = 0x1D,
		WM_GETDLGCODE = 0x87,
		WM_GETFONT = 0x31,
		WM_GETHOTKEY = 0x33,
		WM_GETICON = 0x7F,
		WM_GETMINMAXINFO = 0x24,
		WM_GETOBJECT = 0x3D,
		WM_GETSYSMENU = 0x313,
		WM_GETTEXT = 0xD,
		WM_GETTEXTLENGTH = 0xE,
		WM_HANDHELDFIRST = 0x358,
		WM_HANDHELDLAST = 0x35F,
		WM_HELP = 0x53,
		WM_HOTKEY = 0x312,
		WM_HSCROLL = 0x114,
		WM_HSCROLLCLIPBOARD = 0x30E,
		WM_ICONERASEBKGND = 0x27,
		WM_IME_CHAR = 0x286,
		WM_IME_COMPOSITION = 0x10F,
		WM_IME_COMPOSITIONFULL = 0x284,
		WM_IME_CONTROL = 0x283,
		WM_IME_ENDCOMPOSITION = 0x10E,
		WM_IME_KEYDOWN = 0x290,
		WM_IME_KEYLAST = 0x10F,
		WM_IME_KEYUP = 0x291,
		WM_IME_NOTIFY = 0x282,
		WM_IME_REQUEST = 0x288,
		WM_IME_SELECT = 0x285,
		WM_IME_SETCONTEXT = 0x281,
		WM_IME_STARTCOMPOSITION = 0x10D,
		WM_INITDIALOG = 0x110,
		WM_INITMENU = 0x116,
		WM_INITMENUPOPUP = 0x117,
		WM_INPUTLANGCHANGE = 0x51,
		WM_INPUTLANGCHANGEREQUEST = 0x50,
		WM_KEYDOWN = 0x100,
		WM_KEYFIRST = 0x100,
		WM_KEYLAST = 0x108,
		WM_KEYUP = 0x101,
		WM_KILLFOCUS = 0x8,
		WM_LBUTTONDBLCLK = 0x203,
		WM_LBUTTONDOWN = 0x201,
		WM_LBUTTONUP = 0x202,
		WM_MBUTTONDBLCLK = 0x209,
		WM_MBUTTONDOWN = 0x207,
		WM_MBUTTONUP = 0x208,
		WM_MDIACTIVATE = 0x222,
		WM_MDICASCADE = 0x227,
		WM_MDICREATE = 0x220,
		WM_MDIDESTROY = 0x221,
		WM_MDIGETACTIVE = 0x229,
		WM_MDIICONARRANGE = 0x228,
		WM_MDIMAXIMIZE = 0x225,
		WM_MDINEXT = 0x224,
		WM_MDIREFRESHMENU = 0x234,
		WM_MDIRESTORE = 0x223,
		WM_MDISETMENU = 0x230,
		WM_MDITILE = 0x226,
		WM_MEASUREITEM = 0x2C,
		WM_MENUCHAR = 0x120,
		WM_MENUCOMMAND = 0x126,
		WM_MENUDRAG = 0x123,
		WM_MENUGETOBJECT = 0x124,
		WM_MENURBUTTONUP = 0x122,
		WM_MENUSELECT = 0x11F,
		WM_MOUSEACTIVATE = 0x21,
		WM_MOUSEFIRST = 0x200,
		WM_MOUSEHOVER = 0x2A1,
		WM_MOUSELAST = 0x20A,
		WM_MOUSELEAVE = 0x2A3,
		WM_MOUSEMOVE = 0x200,
		WM_MOUSEWHEEL = 0x20A,
		WM_MOVE = 0x3,
		WM_MOVING = 0x216,
		WM_NCACTIVATE = 0x86,
		WM_NCCALCSIZE = 0x83,
		WM_NCCREATE = 0x81,
		WM_NCDESTROY = 0x82,
		WM_NCHITTEST = 0x84,
		WM_NCLBUTTONDBLCLK = 0xA3,
		WM_NCLBUTTONDOWN = 0xA1,
		WM_NCLBUTTONUP = 0xA2,
		WM_NCMBUTTONDBLCLK = 0xA9,
		WM_NCMBUTTONDOWN = 0xA7,
		WM_NCMBUTTONUP = 0xA8,
		WM_NCMOUSEHOVER = 0x2A0,
		WM_NCMOUSELEAVE = 0x2A2,
		WM_NCMOUSEMOVE = 0xA0,
		WM_NCPAINT = 0x85,
		WM_NCRBUTTONDBLCLK = 0xA6,
		WM_NCRBUTTONDOWN = 0xA4,
		WM_NCRBUTTONUP = 0xA5,
		WM_NEXTDLGCTL = 0x28,
		WM_NEXTMENU = 0x213,
		WM_NOTIFY = 0x4E,
		WM_NOTIFYFORMAT = 0x55,
		WM_NULL = 0x0,
		WM_PAINT = 0xF,
		WM_PAINTCLIPBOARD = 0x309,
		WM_PAINTICON = 0x26,
		WM_PALETTECHANGED = 0x311,
		WM_PALETTEISCHANGING = 0x310,
		WM_PARENTNOTIFY = 0x210,
		WM_PASTE = 0x302,
		WM_PENWINFIRST = 0x380,
		WM_PENWINLAST = 0x38F,
		WM_POWER = 0x48,
		WM_PRINT = 0x317,
		WM_PRINTCLIENT = 0x318,
		WM_QUERYDRAGICON = 0x37,
		WM_QUERYENDSESSION = 0x11,
		WM_QUERYNEWPALETTE = 0x30F,
		WM_QUERYOPEN = 0x13,
		WM_QUERYUISTATE = 0x129,
		WM_QUEUESYNC = 0x23,
		WM_QUIT = 0x12,
		WM_RBUTTONDBLCLK = 0x206,
		WM_RBUTTONDOWN = 0x204,
		WM_RBUTTONUP = 0x205,
		WM_RENDERALLFORMATS = 0x306,
		WM_RENDERFORMAT = 0x305,
		WM_SETCURSOR = 0x20,
		WM_SETFOCUS = 0x7,
		WM_SETFONT = 0x30,
		WM_SETHOTKEY = 0x32,
		WM_SETICON = 0x80,
		WM_SETREDRAW = 0xB,
		WM_SETTEXT = 0xC,
		WM_SETTINGCHANGE = 0x1A,
		WM_SHOWWINDOW = 0x18,
		WM_SIZE = 0x5,
		WM_SIZECLIPBOARD = 0x30B,
		WM_SIZING = 0x214,
		WM_SPOOLERSTATUS = 0x2A,
		WM_STYLECHANGED = 0x7D,
		WM_STYLECHANGING = 0x7C,
		WM_SYNCPAINT = 0x88,
		WM_SYSCHAR = 0x106,
		WM_SYSCOLORCHANGE = 0x15,
		WM_SYSCOMMAND = 0x112,
		WM_SYSDEADCHAR = 0x107,
		WM_SYSKEYDOWN = 0x104,
		WM_SYSKEYUP = 0x105,
		WM_SYSTIMER = 0x118,  // undocumented, see http://support.microsoft.com/?id=108938
		WM_TCARD = 0x52,
		WM_TIMECHANGE = 0x1E,
		WM_TIMER = 0x113,
		WM_UNDO = 0x304,
		WM_UNINITMENUPOPUP = 0x125,
		WM_USER = 0x400,
		WM_USERCHANGED = 0x54,
		WM_VKEYTOITEM = 0x2E,
		WM_VSCROLL = 0x115,
		WM_VSCROLLCLIPBOARD = 0x30A,
		WM_WINDOWPOSCHANGED = 0x47,
		WM_WINDOWPOSCHANGING = 0x46,
		WM_WININICHANGE = 0x1A,
		WM_XBUTTONDBLCLK = 0x20D,
		WM_XBUTTONDOWN = 0x20B,
		WM_XBUTTONUP = 0x20C
	}
	public enum WmNchitTestPos
	{
		HTERROR = (-2),
		HTTRANSPARENT = (-1),
		HTNOWHERE = 0,
		HTCLIENT = 1,
		HTCAPTION = 2,
		HTSYSMENU = 3,
		HTGROWBOX = 4,
		HTSIZE = HTGROWBOX,
		HTMENU = 5,
		HTHSCROLL = 6,
		HTVSCROLL = 7,
		HTMINBUTTON = 8,
		HTMAXBUTTON = 9,
		HTLEFT = 10,
		HTRIGHT = 11,
		HTTOP = 12,
		HTTOPLEFT = 13,
		HTTOPRIGHT = 14,
		HTBOTTOM = 15,
		HTBOTTOMLEFT = 16,
		HTBOTTOMRIGHT = 17,
		HTBORDER = 18,
		HTREDUCE = HTMINBUTTON,
		HTZOOM = HTMAXBUTTON,
		HTSIZEFIRST = HTLEFT,
		HTSIZELAST = HTBOTTOMRIGHT,
		HTOBJECT = 19,
		HTCLOSE = 20,
		HTHELP = 21,
	}
	public enum WmSizeType
	{
		SIZE_RESTORED = 0,
		SIZE_MINIMIZED = 1,
		SIZE_MAXIMIZED = 2,
		SIZE_MAXSHOW = 3,
		SIZE_MAXHIDE = 4,
	}
	public enum WmSizingEdge
	{
		WMSZ_LEFT = 1,
		WMSZ_RIGHT = 2,
		WMSZ_TOP = 3,
		WMSZ_TOPLEFT = 4,
		WMSZ_TOPRIGHT = 5,
		WMSZ_BOTTOM = 6,
		WMSZ_BOTTOMLEFT = 7,
		WMSZ_BOTTOMRIGHT = 8,
	}
	public enum WmSystemCommand
	{
		SC_SIZE = 0xF000,
		SC_MOVE = 0xF010,
		SC_MINIMIZE = 0xF020,
		SC_MAXIMIZE = 0xF030,
		SC_NEXTWINDOW = 0xF040,
		SC_PREVWINDOW = 0xF050,
		SC_CLOSE = 0xF060,
		SC_VSCROLL = 0xF070,
		SC_HSCROLL = 0xF080,
		SC_MOUSEMENU = 0xF090,
		SC_KEYMENU = 0xF100,
		SC_ARRANGE = 0xF110,
		SC_RESTORE = 0xF120,
		SC_TASKLIST = 0xF130,
		SC_SCREENSAVE = 0xF140,
		SC_HOTKEY = 0xF150,
		SC_DEFAULT = 0xF160,
		SC_MONITORPOWER = 0xF170,
		SC_CONTEXTHELP = 0xF180,
		SC_SEPARATOR = 0xF00F,
	}

	#endregion

	#region Structures

	[StructLayout(LayoutKind.Sequential)]
	public struct APPBARDATA
	{
		public int cbSize;
		public IntPtr hWnd;
		public int uCallbackMessage;
		public AppBarEdge uEdge;
		public RECT rc;
		public int lParam;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BITMAPINFO
	{
		public BITMAPINFOHEADER bmiHeader;
		public int bmiColors;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BITMAPINFOHEADER
	{
		public uint biSize;
		public int biWidth;
		public int biHeight;
		public ushort biPlanes;
		public ushort biBitCount;
		public uint biCompression;
		public uint biSizeImage;
		public int biXPelsPerMeter;
		public int biYPelsPerMeter;
		public uint biClrUsed;
		public uint biClrImportant;
	}

	[StructLayout(LayoutKind.Sequential)]
	public class CDROM_TOC
	{
		public ushort Length;
		public byte FirstTrack = 0;
		public byte LastTrack = 0;

		public TrackDataList TrackData;

		public CDROM_TOC()
		{
			TrackData = new TrackDataList();
			Length = (ushort)Marshal.SizeOf(this);
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct COPYDATASTRUCT
	{
		public IntPtr dwData;
		public int cbData;
		public IntPtr lpData;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct DEV_BROADCAST_HDR
	{
		public int dbch_size;
		public DeviceType dbch_devicetype;
		private int dbch_reserved;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct DEV_BROADCAST_VOLUME
	{
		public int dbcv_size;
		public DeviceType dbcv_devicetype;
		private int dbcv_reserved;
		public int dbcv_unitmask;
		public VolumeType dbcv_flags;
	}
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct DEVMODE
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmDeviceName;

		public short dmSpecVersion;
		public short dmDriverVersion;
		public short dmSize;
		public short dmDriverExtra;
		public int dmFields;
		public int dmPositionX;
		public int dmPositionY;
		public System.Windows.Forms.ScreenOrientation dmDisplayOrientation;
		public int dmDisplayFixedOutput;
		public short dmColor;
		public short dmDuplex;
		public short dmYResolution;
		public short dmTTOption;
		public short dmCollate;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmFormName;

		public short dmLogPixels;
		public short dmBitsPerPel;
		public int dmPelsWidth;
		public int dmPelsHeight;
		public int dmDisplayFlags;
		public int dmDisplayFrequency;
		public int dmICMMethod;
		public int dmICMIntent;
		public int dmMediaType;
		public int dmDitherType;
		public int dmReserved1;
		public int dmReserved2;
		public int dmPanningWidth;
		public int dmPanningHeight;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct MARGINS
	{
		public int cxLeftWidth;
		public int cxRightWidth;
		public int cyTopHeight;
		public int cyBottomHeight;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct MENUITEMINFO
	{
		public uint cbSize;
		public uint fMask;
		public uint fType;
		public uint fState;
		public uint wID;
		public IntPtr hSubMenu;
		public IntPtr hbmpChecked;
		public IntPtr hbmpUnchecked;
		public string dwTypeData;
		public IntPtr dwItemData;
		public uint cch;
		public IntPtr hbmpItem;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct MouseHookStruct
	{
		public Point pt;
		public IntPtr hwnd;
		public int wHitTestCode;
		public int dwExtraInfo;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct MouseHookStructEx
	{
		public MouseHookStruct MouseHookStruct;
		public uint MouseData;
	}
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct PF_FILTER_DESCRIPTOR
	{
		/// <summary>
		/// Always set to FD_FLAGS_NOSYN (1) as per MSDN
		/// </summary>
		public const uint dwFilterFlags = 1;
		public uint dwRule;
		public PacketFilterAddressType pfatType;
		public IntPtr SrcAddr;
		public IntPtr SrcMask;
		public IntPtr DstAddr;
		public IntPtr DstMask;
		public FilterProtocol dwProtocol;
		[MarshalAs(UnmanagedType.Bool)]
		public bool fLateBound;
		public ushort wSrcPort;
		public ushort wDstPort;
		public ushort wSrcPortHighRange;
		public ushort wDstPortHighRange;
	};
	[StructLayout(LayoutKind.Sequential)]
	public class PREVENT_MEDIA_REMOVAL
	{
		public byte PreventMediaRemoval = 0;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;

		public RECT(int Left, int Right, int Top, int Bottom)
		{
			this.Left = Left;
			this.Right = Right;
			this.Top = Top;
			this.Bottom = Bottom;
		}

		public static implicit operator Rectangle(RECT Rect)
		{
			return new Rectangle(Rect.Left, Rect.Top, Rect.Right - Rect.Left, Rect.Bottom - Rect.Top);
		}
		public static implicit operator RECT(Rectangle Rectangle)
		{
			return new RECT(Rectangle.Left, Rectangle.Right, Rectangle.Top, Rectangle.Bottom);
		}
	}
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct RAWINPUT
	{
		[FieldOffset(0)]
		public RAWINPUTHEADER Header;
		[FieldOffset(16)]
		public RAWINPUTMOUSE Mouse;
		[FieldOffset(16)]
		public RAWINPUTKEYBOARD Keyboard;
		[FieldOffset(16)]
		public RAWINPUTHID HID;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTDEVICE
	{
		public ushort UsagePage;
		public ushort Usage;
		public RawInputDeviceFlag Flags;
		public IntPtr WindowHandle;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTHEADER
	{
		public RawInputType Type;
		public int Size;
		public IntPtr Device;
		public IntPtr wParam;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTHID
	{
		public int Size;
		public int Count;
		public IntPtr Data;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTKEYBOARD
	{
		public ushort MakeCode;
		public ushort Flags;
		public ushort Reserved;
		public ushort VirtualKey;
		public uint Message;
		public int ExtraInformation;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTMOUSE
	{
		public uint Flags;
		public ulong Buttons;
		public ushort ButtonData;
		public int RawButtons;
		public int LastX;
		public int LastY;
		public int ExtraInformation;
	}
	[StructLayout(LayoutKind.Sequential)]
	public class RAW_READ_INFO
	{
		public long DiskOffset = 0;
		public uint SectorCount = 0;
		public TrackMode TrackMode = TrackMode.CDDA;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct SCSI_PASS_THROUGH
	{
		public ushort Length;
		public byte ScsiStatus;
		public byte PathId;
		public byte TargetId;
		public byte Lun;
		public byte CdbLength;
		public byte SenseInfoLength;
		public byte DataIn;
		public uint DataTransferLength;
		public uint TimeOutValue;
		public IntPtr DataBufferOffset;
		public IntPtr SenseInfoOffset;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] Cdb;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_NUMBER
	{
		public DeviceIOFileDevice DeviceType;
		public uint DeviceNumber;
		public uint PartitionNumber;
	}
	[StructLayout(LayoutKind.Sequential)]
	public class TRACK_DATA
	{
		public byte Reserved;
		private byte BitMapped;
		public byte Control
		{
			get
			{
				return (byte)(BitMapped & 0x0F);
			}
			set
			{
				BitMapped = (byte)((BitMapped & 0xF0) | (value & (byte)0x0F));
			}
		}
		public byte Adr
		{
			get
			{
				return (byte)((BitMapped & (byte)0xF0) >> 4);
			}
			set
			{
				BitMapped = (byte)((BitMapped & (byte)0x0F) | (value << 4));
			}
		}
		public byte TrackNumber;
		public byte Reserved1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] Address = new byte[4];
		public int BlockAddress
		{
			get
			{
				return (Address[1] * (ApiFunctions.CD_BLOCKS_PER_SECOND * 60)) +
				(Address[2] * ApiFunctions.CD_BLOCKS_PER_SECOND) +
				Address[3] - 150; // 150 == Redbook Frame pregap
			}
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	public class TrackDataList
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = ApiFunctions.MAXIMUM_NUMBER_TRACKS * 8)]
		private byte[] Data;
		public TRACK_DATA this[int Index]
		{
			get
			{
				if ((Index < 0) | (Index >= ApiFunctions.MAXIMUM_NUMBER_TRACKS))
				{
					throw new IndexOutOfRangeException();
				}
				TRACK_DATA res;
				GCHandle handle = GCHandle.Alloc(Data, GCHandleType.Pinned);
				try
				{
					IntPtr buffer = handle.AddrOfPinnedObject();
					if (IntPtr.Size == 32)
						buffer = (IntPtr)(buffer.ToInt32() + (Index * Marshal.SizeOf(typeof(TRACK_DATA))));
					else
						buffer = (IntPtr)(buffer.ToInt64() + (Index * Marshal.SizeOf(typeof(TRACK_DATA))));
					res = (TRACK_DATA)Marshal.PtrToStructure(buffer, typeof(TRACK_DATA));
				}
				finally
				{
					handle.Free();
				}
				return res;
			}
		}
		public TrackDataList()
		{
			Data = new byte[ApiFunctions.MAXIMUM_NUMBER_TRACKS * Marshal.SizeOf(typeof(TRACK_DATA))];
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct VIDEOHDR
	{
		public IntPtr lpData;                 /* pointer to locked data buffer */
		public uint dwBufferLength;         /* Length of data buffer */
		public uint dwBytesUsed;            /* Bytes actually used */
		public uint dwTimeCaptured;         /* Milliseconds from start of stream */
		public IntPtr dwUser;                 /* for client's use */
		public uint dwFlags;                /* assorted flags (see defines) */
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public IntPtr[] dwReserved;          /* reserved for driver */
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WINDOWPOS
	{
		public IntPtr hWnd;
		public IntPtr hWndInsertAfter;
		public int x;
		public int y;
		public int cx;
		public int cy;
		public uint flags;
	}

	#endregion

	#region Delegates

	public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
	public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

	#endregion

#if MONO
    [Obsolete("For unix compatibility, these functions should not be used.")]
#endif
	public class ApiFunctions
	{
		#region Constants

		public const int CD_BLOCKS_PER_SECOND = 75;
		public const int FAPPCOMMAND_MASK = 0xF000;
		public const int MAX_PATH = 260;
		public const int MAXIMUM_NUMBER_TRACKS = 100;
		public const int SRCCOPY = 13369376;
		public static readonly IntPtr HWND_BROADCAST = new IntPtr((int)0xffff);

		#endregion

		#region Functions

		#region Avicap32.dll

		[DllImport("avicap32.dll", SetLastError = true)]
		public static extern IntPtr capCreateCaptureWindow(string windowName, WindowStyle style, int x, int y, int width, int height, IntPtr hWndParent, int windowIdentifier);

		[DllImport("avicap32.dll", SetLastError = true)]
		public static extern bool capGetDriverDescription(short driverIndex, StringBuilder name, int cbName, StringBuilder description, int cbDescription);

		#endregion

		#region IPHlpApi

		[DllImport("iphlpapi.dll", SetLastError = true)]
		public static extern int PfAddFiltersToInterface(IntPtr ih, uint cInFilters, ref PF_FILTER_DESCRIPTOR pfiltIn, uint cOutFilters, ref PF_FILTER_DESCRIPTOR pfiltOut, IntPtr pfHandle);

		[DllImport("iphlpapi.dll", SetLastError = true)]
		public static extern int PfBindInterfaceToIPAddress(IntPtr pInterface, PacketFilterAddressType pfatType, byte[] IPAddress);

		[DllImport("iphlpapi.dll", SetLastError = true)]
		public static extern int PfCreateInterface(uint dwName, PacketFilterAction inAction, PacketFilterAction outAction, bool bUseLog, bool bMustBeUnique, ref IntPtr ppInterface);

		[DllImport("iphlpapi.dll", SetLastError = true)]
		public static extern int PfDeleteInterface(IntPtr ppInterface);

		[DllImport("iphlpapi.dll", SetLastError = true)]
		public static extern int PfRemoveFiltersFromInterface(IntPtr ih, uint cInFilters, ref PF_FILTER_DESCRIPTOR pfiltIn, uint cOutFilters, ref PF_FILTER_DESCRIPTOR pfiltOut);

		[DllImport("iphlpapi.dll", SetLastError = true)]
		public static extern int PfUnBindInterface(IntPtr pInterface);

		#endregion
		#region Kernel32

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ConnectNamedPipe(SafeFileHandle hNamedPipe, ref Overlapped lpOverlapped);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern SafeFileHandle CreateNamedPipe(string lpName, PipeOpenMode dwOpenMode, PipeMode dwPipeMode,
			uint nMaxInstances, uint nOutBufferSize, uint nInBufferSize, uint nDefaultTimeOut,
			IntPtr lpSecurityAttributes);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern SafeFileHandle CreateFile(string lpFileName, [MarshalAs(UnmanagedType.U4)]System.IO.FileAccess dwDesiredAccess,
			[MarshalAs(UnmanagedType.U4)]System.IO.FileShare dwShareMode, uint SecurityAttributes,
			[MarshalAs(UnmanagedType.U4)]System.IO.FileMode dwCreationDisposition,
			FileAttributesAndFlags dwFlagsAndAttributes, IntPtr hTemplateFile);

		[DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool DeviceIoControl(SafeFileHandle hDevice, DeviceIOControlCode dwIoControlCode, IntPtr InBuffer,
			int nInBufferSize, IntPtr OutBuffer, int nOutBufferSize, out int pBytesReturned, [In] ref NativeOverlapped lpOverlapped);

		[DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool DeviceIoControl(SafeFileHandle hDevice, DeviceIOControlCode dwIoControlCode,
			[MarshalAs(UnmanagedType.AsAny), In] object InBuffer, int nInBufferSize,
			[MarshalAs(UnmanagedType.AsAny), In, Out] object OutBuffer, int nOutBufferSize, out int pBytesReturned,
			[In] ref System.Threading.NativeOverlapped lpOverlapped);

		[DllImport("Kernel32.dll")]
		public extern static DriveTypes GetDriveType(string drive);
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, int cchBuffer);

		[DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

		[DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceFrequency(out long lpFrequency);

		#endregion
		#region Gdi32

		[DllImport("gdi32.dll", EntryPoint = "BitBlt")]
		public static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int RasterOp);

		[DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		[DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
		public static extern IntPtr DeleteDC(IntPtr hDc);

		[DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
		public static extern IntPtr DeleteObject(IntPtr hDc);

		[DllImport("gdi32.dll", EntryPoint = "SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

		#endregion
		#region User32.dll

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, int uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern ChangeDisplaySettingsStatus ChangeDisplaySettings(ref DEVMODE lpDevMode, int dwFlags);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, [MarshalAs(UnmanagedType.Struct)] Point Point);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool ClipCursor(ref RECT lpRect);
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth,
			int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr DefWindowProc(IntPtr hWnd, WmMessage uMsg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool DestroyWindow(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, int lParam);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		public static extern int EnumDisplaySettings(string lpszDeviceName, EnumDisplayMode iModeNum, ref DEVMODE lpDevMode);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool ExitWindowsEx(ExitWindowsType uFlags, ShutdownReason dwReason);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern void GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetCursorPos(out Point lpPoint);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr ptr);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", SetLastError = true)]
		public static extern short GetKeyState(int nVirtKey);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool GetMenuItemInfo(IntPtr hMenu, int uItem, bool fByPosition, ref MENUITEMINFO lpmii);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern uint GetParent(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetRawInputData(IntPtr hRawInput, RawDataCommand uiCommand, out RAWINPUT pData, ref int pcbSize, int cbSizeHeader);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetSystemMetrics(int nIndex);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetWindowDC(Int32 ptr);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern WindowStyle GetWindowLong(IntPtr hWnd, SetWindowLongIndex nIndex);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool GetWindowRect(IntPtr hWnd, out RECT WindowRECT);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern void GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool IsIconic(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool IsWindowVisible(IntPtr hwnd);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern void keybd_event(VirtualKey bVk, byte bScan, uint dwFlags, int dwExtraInfo);

		[DllImport("user32.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int cx, int cy, bool repaint);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr PostMessage(IntPtr hWnd, ListViewMessage Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, ref ValueType wParam, ref ValueType lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr PostMessage(IntPtr hWnd, WmMessage Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr RealChildWindowFromPoint(IntPtr hWndParent, [MarshalAs(UnmanagedType.Struct)] Point Point);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool RegisterHotKey(IntPtr hWnd, int uniqueID, uint fsModifiers, uint vk);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool RegisterRawInputDevices(RAWINPUTDEVICE pRawInputDevices, int uiNumDevices, int cbSize);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int RegisterWindowMessage(string msg);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hdc);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, ListViewMessage Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, ref ValueType wParam, ref ValueType lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, WmMessage Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, CaptureMessage Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetForegroundWindow(IntPtr hwnd);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetWindowsHookEx(HookType idHook, HookProc lpfn, IntPtr hInstance, int threadId);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern WindowStyle SetWindowLong(IntPtr hWnd, SetWindowLongIndex nIndex, WindowStyle dwNewLong);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetWindowPos(IntPtr hWnd, SetWindowPosWindow hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int SetWindowText(IntPtr hWnd, string lpString);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int ShowWindow(IntPtr hWnd, ShowWindowCommand command);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool UnhookWindowsHookEx(IntPtr hHook);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr WindowFromPoint([MarshalAs(UnmanagedType.Struct)] Point Point);

		#endregion
		#region Shell32

		[DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr SHAppBarMessage(AppBarMessage dwMessage, ref APPBARDATA pData);

		#endregion
		#region Vista - Dwmapi

		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

		#endregion

		#endregion

		#region Converters

		public static Rectangle GetWindowRectangle(IntPtr hWnd)
		{
			RECT rect = new RECT();
			GetWindowRect(hWnd, out rect);
			return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
		}
		public static AppCommand GetAppcommandLparam(IntPtr WmAppcommandLparam)
		{
			return (AppCommand)(HiWord(WmAppcommandLparam.ToInt32()) & ~ApiFunctions.FAPPCOMMAND_MASK);
		}

		public static int HiWord(int Number)
		{
			return (Number >> 16) & 0xffff;
		}

		#endregion
	}
}

#pragma warning restore 618
