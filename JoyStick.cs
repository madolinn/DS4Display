using System;
using System.Runtime.InteropServices;

namespace DS4Display
{
	public class JoyStick
	{

		JOYINFOEX pji;

		public JoyStick()
		{
			pji = new JOYINFOEX();
		}

		public struct JOYINFOEX
		{
			public uint dwSize;
			public uint dwFlags;
			public uint dwXpos;
			public uint dwYpox;
			public uint dwZpos;
			public uint dwRpos;
			public uint dwUpos;
			public uint dwVpos;
			public uint dwButtons;
			public uint dwButtonNumber;
			public uint dwPOV;
			public uint dwReserved1;
			public uint dwReserved2;
		}

		[DllImport("winmm.dll", EntryPoint = "joyGetNumDevs")]
		private static extern uint joyGetNumDevs();

		[DllImport("winmm.dll", EntryPoint = "joyGetPosEx")]
		private static extern uint joyGetPosEx(uint uJoyID, ref JOYINFOEX pji);

		private static uint getPos(uint uJoyID, ref JOYINFOEX pji)
		{
			pji.dwSize = (uint)Marshal.SizeOf(pji);
			pji.dwFlags = 0xFF;
			return joyGetPosEx(uJoyID, ref pji);
		}

		public uint getNumDevs()
		{
			return joyGetNumDevs();
		}

		public JOYINFOEX getPos(uint uJoyID)
		{
			uint res = getPos(uJoyID, ref pji);
			return pji;
		}

	}
}
