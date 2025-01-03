using System.IO;

namespace Nanoray.FileAbstraction;

/// <summary>
/// Describes a writable file in a file system.
/// </summary>
public interface IWritableFileInfo : IFileInfo, IWritableFileSystemInfo
{
	/// <summary>
	/// Creates a write-only <see cref="Stream"/>.
	/// </summary>
	/// <returns>A new write-only <see cref="Stream"/>.</returns>
	Stream OpenWrite();
	
	/// <summary>
	/// Writes the given byte array to a file.
	/// </summary>
	/// <param name="data">The data to write.</param>
	void WriteAllBytes(byte[] data);
}

/// <summary>
/// Describes a typed writable file in a file system.
/// </summary>
/// <typeparam name="TFileInfo">The type describing files.</typeparam>
/// <typeparam name="TDirectoryInfo">The type describing directories.</typeparam>
public interface IWritableFileInfo<out TFileInfo, out TDirectoryInfo> : IFileInfo<TFileInfo, TDirectoryInfo>, IWritableFileSystemInfo<TFileInfo, TDirectoryInfo>, IWritableFileInfo
	where TFileInfo : class, IWritableFileInfo<TFileInfo, TDirectoryInfo>
	where TDirectoryInfo : class, IWritableDirectoryInfo<TFileInfo, TDirectoryInfo>;
