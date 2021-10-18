using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Collections.Generic;

namespace Thayer.Birding.UI.Windows
{
	sealed class Utility
	{
		[DllImport("ListView")]
		public static extern void ListView_SetHeaderSortImage(IntPtr listViewHandle, int columnIndex, bool isAscending);

		[DllImport("ListView")]
		public static extern void ListView_SetHeaderImageFlag(IntPtr listViewHandle, int columnIndex);

		[DllImport("ListView")]
		public static extern void ListView_ClearAllHeaderImageFlags(IntPtr listViewHandle);

		private static Audio audio = null;

		private Utility()
		{
		}

		public static void PlaySound(string path)
		{
            StopSound();

			if (path != null && File.Exists(path))
			{
				audio = new Audio(path);
				audio.Play();
			}
		}

        public static void StopSound()
        {
            if (audio != null)
            {
                audio.Stop();
                audio.Dispose();
                audio = null;
            }
        }

		public static void ShowSoundForm(string path, bool loop)
		{
			SoundForm form = new SoundForm();
			form.Loop = loop;
			form.Path = path;
			form.ShowDialog();
		}

		public static void PlayVideo(string organismName, IMedia video)
		{
			VideoForm form = new VideoForm();
			form.OrganismName = organismName;
			form.Media = video;
			form.ShowDialog();
		}

		public static void ShowWebBrowser(string url)
		{
			Process.Start(url);
		}

		public static System.Drawing.Size GetOptimalSize(Image image, System.Drawing.Size maximumSize)
		{
			int newWidth;
			int newHeight;

			int width = maximumSize.Width;
			int height = maximumSize.Height;
			int sourceWidth = image.Width;
			int sourceHeight = image.Height;

			double widthRatio = sourceWidth / (double)width;
			double heightRatio = sourceHeight / (double)height;

			if (sourceWidth > width || sourceHeight > height)
			{
				if (widthRatio > heightRatio)
				{
					newWidth = width;
					newHeight = (int)(sourceHeight / widthRatio);
				}
				else
				{
					newWidth = (int)(sourceWidth / heightRatio);
					newHeight = height;
				}
			}
			else
			{
				newWidth = sourceWidth;
				newHeight = sourceHeight;
			}

			return new System.Drawing.Size(newWidth, newHeight);
		}

		public static Bitmap GenerateBitmapWithCopyright(IMedia photo, string copyrightFontName, float copyrightFontSize, System.Drawing.Color copyrightColor)
		{
			Bitmap bitmap = new Bitmap(photo.AbsolutePath);

//			if (photo.Caption != null && photo.Caption.Length > 0)
			if (photo.FullCopyright != null && photo.FullCopyright.Length > 0)
			{
				if (bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
				{
					Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
					using (Graphics g = Graphics.FromImage(newBitmap))
					{
						g.DrawImage(bitmap, 0, 0);
					}
					bitmap.Dispose();
					bitmap = newBitmap;
				}

				using (Graphics g = Graphics.FromImage(bitmap))
				{
					float fontFactor = 72f / bitmap.VerticalResolution;
					copyrightFontSize *= fontFactor;
					using (Font font = new Font(copyrightFontName, copyrightFontSize))
					{
						using (Brush brush = new SolidBrush(copyrightColor))
						{
							float heightFromBottom = font.GetHeight(bitmap.VerticalResolution);
							heightFromBottom *= 1.10f;
							g.DrawString(photo.FullCopyright, font, brush, 0, bitmap.Height - heightFromBottom);
						}
					}
				}
			}

			return bitmap;
		}

		public static Bitmap GenerateImage(string source, int width, int height)
		{
			Bitmap rep = new Bitmap(source);
			return GenerateImage(rep, new System.Drawing.Size(width, height));
		}

		public static Bitmap GenerateImage(Image sourceImage, System.Drawing.Size preferredSize)
		{
			System.Drawing.Size newSize = Utility.GetOptimalSize(sourceImage, preferredSize);

			Bitmap scratch = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb);
			scratch.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
			Graphics g = Graphics.FromImage(scratch);
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.DrawImage(sourceImage, new Rectangle(0, 0, newSize.Width, newSize.Height), new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), GraphicsUnit.Pixel);
			g.Dispose();

			return scratch;
		}

		public static void GenerateImage(string source, int width, int height, string destination)
		{
			Bitmap scratch = GenerateImage(source, width, height);

			scratch.Save(destination, ImageFormat.Jpeg);
		}

		public static void ShowPhotos(string organismName, IMedia[] photos, IMedia[] sounds, int initialPhotoIndex)
		{
			PhotoForm form = new PhotoForm();
			form.WindowState = FormWindowState.Maximized;
			form.OrganismName = organismName;
			form.Photos = photos;
			form.Sounds = sounds;
			form.SelectedPhotoIndex = initialPhotoIndex;
			form.ShowDialog();
		}

		public static void ShowPhotoList(List<PhotoListItem> photoListItems, int selectedListIndex)
		{
			PhotoListForm form = new PhotoListForm();
			form.WindowState = FormWindowState.Maximized;
			form.PhotoListItems = photoListItems;
			form.SelectedListIndex = selectedListIndex;
			form.ShowDialog();
		}

		public static string BrowseForSpectrogram(Form parent, string initialFileName)
		{
			string file = null;

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = initialFileName != null && initialFileName.Length > 0 ? Path.GetDirectoryName(initialFileName) : Environment.GetEnvironmentVariable("ProgramFiles");
			dialog.RestoreDirectory = true;
			dialog.Filter = "Executable Files (*.exe)|*.exe";
			dialog.CheckFileExists = true;
			if (dialog.ShowDialog(parent) == DialogResult.OK)
			{
				file = dialog.FileName;
			}

			return file;
		}

		public static T GetOpenForm<T>() where T : Form
		{
			T openForm = null;

			foreach (Form form in Application.OpenForms)
			{
				if (form is T)
				{
					openForm = form as T;
					break;
				}
			}

			return openForm;
		}

		public static List<T> GetOpenForms<T>() where T : Form
		{
			List<T> openForms = new List<T>();

			foreach (Form form in Application.OpenForms)
			{
				if (form is T)
				{
					openForms.Add(form as T);
				}
			}

			return openForms;
		}

		public static bool ImportMyMediaPackage()
		{
			bool imported = false;

			string fileName = GetMyMediaPackageFileName();
			if (File.Exists(fileName))
			{
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					CustomDatabase.Import(fileName);
					imported = true;
				}
				finally
				{
					Cursor.Current = Cursors.Default;
				}

				MessageBox.Show("Import completed successfully.", "My Media Package Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return imported;
		}

		private static string GetMyMediaPackageFileName()
		{
			string fileName = "";

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Select a My Media Package File";
			dialog.Filter = "My Media Package Files (*.zip)|*.zip";
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.Multiselect = false;
			dialog.ShowReadOnly = false;
			dialog.RestoreDirectory = true;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileName = dialog.FileName;
			}

			return fileName;
		}

		private static void CopyDirectory(string sourcePath, string destinationPath, bool overwrite, bool recursive)
		{
			DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
			DirectoryInfo destinationDirectory = new DirectoryInfo(destinationPath);

			CopyDirectory(sourceDirectory, destinationDirectory, overwrite, recursive);
		}

		private static void CopyDirectory(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory, bool overwrite, bool recursive)
		{
			if (!destinationDirectory.Exists)
			{
				destinationDirectory.Create();
			}

			// Copy files 
			foreach (FileInfo file in sourceDirectory.GetFiles())
			{
				file.CopyTo(Path.Combine(destinationDirectory.FullName, file.Name), overwrite);
			}

			// Copy directories 
			if (recursive)
			{
				foreach (DirectoryInfo directory in sourceDirectory.GetDirectories())
				{
					CopyDirectory(directory, new DirectoryInfo(Path.Combine(destinationDirectory.FullName, directory.Name)), overwrite, recursive);
				}
			}
		}
	}
}
