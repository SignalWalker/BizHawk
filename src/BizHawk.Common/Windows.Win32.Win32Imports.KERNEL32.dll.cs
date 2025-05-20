using System.Runtime.InteropServices;

using Windows.Win32.Foundation;
using Windows.Win32.System.Memory;

namespace Windows.Win32
{
	public static partial class Win32Imports
	{
		/// <inheritdoc cref="GetShortPathNameW(PCWSTR, PWSTR, uint)"/>
		public static unsafe uint GetShortPathNameW(string lpszLongPath)
		{
			fixed (char* lpszLongPathLocal = lpszLongPath)
			{
				return Win32Imports.GetShortPathNameW(lpszLongPathLocal, default, 0U);
			}
		}

		/// <seealso cref="HeapAlloc(SafeHandle, HEAP_FLAGS, nuint)"/>
		public static unsafe IntPtr HeapAlloc(int dwBytes, HEAP_FLAGS dwFlags = HEAP_FLAGS.HEAP_NONE)
			=> unchecked((IntPtr) HeapAlloc(GetProcessHeap_SafeHandle(), dwFlags, dwBytes: (UIntPtr) dwBytes));

		/// <inheritdoc cref="IsWow64Process(HANDLE, BOOL*)"/>
		public static unsafe BOOL IsWow64Process(HANDLE hProcess, out BOOL Wow64Process)
		{
			fixed (BOOL* ptr = &Wow64Process) return IsWow64Process(hProcess, ptr);
		}
	}
}
