using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.IO;

namespace Thayer.MediaCleanup
{
	public partial class CleanupMediaForm : Form
	{
		public CleanupMediaForm()
		{
			InitializeComponent();
		}

		private void cleanupMediaButton_Click(object sender, EventArgs e)
		{
			CleanupMedia();
		}

		private void CleanupMedia()
		{
			try
			{
				MediaFileList mapList = new MediaFileList();
				MediaFileList photoList = new MediaFileList();
				MediaFileList soundList = new MediaFileList();
				MediaFileList videoList = new MediaFileList();

				List<MediaFileCollection> list = MediaFile.GetMediaFileCollectionList();
				foreach (MediaFileCollection collection in list)
				{
					mapList.AddRange(collection.AbundanceMaps);
					mapList.AddRange(collection.RangeMaps);
					photoList.AddRange(collection.Photos);
					soundList.AddRange(collection.Sounds);
					videoList.AddRange(collection.Videos);
				}

				CleanupMediaFileList(mapList, "maps");
				CleanupMediaFileList(photoList, "photos");
				CleanupMediaFileList(soundList, "sounds");
				CleanupMediaFileList(videoList, "videos");
			}
			catch (Exception ex)
			{
				string currentMessage = "An exception has occurred and the conversion has stopped.";

				StringBuilder errorMessage = new StringBuilder(currentMessage);
				errorMessage.Append("  Details of the exception:  ");
				errorMessage.Append(ex.Message);
				MessageBox.Show(this, errorMessage.ToString(), "Media Cleanup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
			}
		}

		private void CleanupMediaFileList(MediaFileList mediaFileList, string typePath)
		{
			string mediaPath = @"C:\Projects\Thayer\v7.0\Media\";
			mediaPath += typePath;
			string[] files = Directory.GetFiles(mediaPath);
			foreach (string file in files)
			{
				bool found = false;
				foreach (MediaFile mediaFile in mediaFileList)
				{
					if (mediaFile.FileName == Path.GetFileName(file))
					{
						found = true;
					}
				}

				if (!found)
				{
					File.Delete(file);

					if (typePath == "videos")
					{
						// Need to delete the thumbnail
						string thumbnailPath = mediaPath + @"\thumbs\";
						string thumbnailFileName = Path.GetFileNameWithoutExtension(file);
						string thumbnailFile = thumbnailPath + thumbnailFileName + ".jpg";
						File.Delete(thumbnailFile);
					}
				}
			}
		}

		private void checkMediaExistsButton_Click(object sender, EventArgs e)
		{
			CheckMediaExists();
		}

		private void CheckMediaExists()
		{
			try
			{
				MediaFileList mapList = new MediaFileList();
				MediaFileList photoList = new MediaFileList();
				MediaFileList soundList = new MediaFileList();
				MediaFileList videoList = new MediaFileList();

				List<MediaFileCollection> list = MediaFile.GetMediaFileCollectionList();
				foreach (MediaFileCollection collection in list)
				{
					mapList.AddRange(collection.AbundanceMaps);
					mapList.AddRange(collection.RangeMaps);
					photoList.AddRange(collection.Photos);
					soundList.AddRange(collection.Sounds);
					videoList.AddRange(collection.Videos);
				}

				CheckMediaFilesExist(mapList, "maps");
				CheckMediaFilesExist(photoList, "photos");
				CheckMediaFilesExist(soundList, "sounds");
				CheckMediaFilesExist(videoList, "videos");
			}
			catch (Exception ex)
			{
				string currentMessage = "An exception has occurred and the conversion has stopped.";

				StringBuilder errorMessage = new StringBuilder(currentMessage);
				errorMessage.Append("  Details of the exception:  ");
				errorMessage.Append(ex.Message);
				MessageBox.Show(this, errorMessage.ToString(), "Media Cleanup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
			}
		}

		private void CheckMediaFilesExist(MediaFileList mediaFileList, string typePath)
		{
			string mediaPath = @"C:\Projects\Thayer\v7.0\Media\";
//			mediaPath += typePath;

			List<string> missingFileList = new List<string>();
			foreach (MediaFile mediaFile in mediaFileList)
			{
				if (!File.Exists(Path.Combine(mediaPath, mediaFile.Path)))
				{
					missingFileList.Add(Path.Combine(mediaPath, mediaFile.Path));
				}
			}

			StringBuilder message = new StringBuilder();
			foreach (string missingFile in missingFileList)
			{
				message.Append(missingFile);
				message.Append("\r\n");
			}

			if (missingFileList.Count > 0)
			{
				MessageBox.Show(this, message.ToString(), "Missing Media Files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}
}