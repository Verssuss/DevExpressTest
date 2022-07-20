using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using WpfApp3.Collections;
using WpfApp3.Extensions;
using WpfApp3.IoC;

namespace WpfApp3
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static List<CultureInfo> m_Languages = new List<CultureInfo>();
		public static List<CultureInfo> Languages
		{
			get
			{
				return m_Languages;
			}
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			new DI();

			m_Languages.Clear();
			var langs = this.FindResource("LanguageCollection") as LanguageCollection;
			foreach (var lang in langs)
			{
				m_Languages.Add(new CultureInfo(lang.Lang.GetEnumTextValue()));
			}
		}

		public static event EventHandler LanguageChanged;

		public static CultureInfo Language
		{
			get
			{
				return System.Threading.Thread.CurrentThread.CurrentUICulture;
			}
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

				//1. Меняем язык приложения:
				System.Threading.Thread.CurrentThread.CurrentUICulture = value;

				//2. Создаём ResourceDictionary для новой культуры
				ResourceDictionary dict = new ResourceDictionary();
				dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);


				//3. Находим старую ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
				ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
											  where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
											  select d).First();
				if (oldDict != null)
				{
					int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
					Application.Current.Resources.MergedDictionaries.Remove(oldDict);
					Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
				}
				else
				{
					Application.Current.Resources.MergedDictionaries.Add(dict);
				}

			}
		}
	}
}