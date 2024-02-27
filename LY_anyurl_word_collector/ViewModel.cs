using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LY_anyurl_word_collector
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _currentpagehtml = "";
        public string CurrentPageHTML
        {
            get => _currentpagehtml;
            set
            {
                _currentpagehtml = value;
                OnPropertyChanged();
            }
        }


        private RelayCommand<string> _startsearch;
        public ICommand StartSearch
        {
            get
            {
                _startsearch = new RelayCommand<string>(async (url) =>
                {
                    if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))//Ha nem URL
                    {
                        MessageBox.Show("A beírt szöveg nem URL.", "LY kereső", MessageBoxButton.OK, MessageBoxImage.Error);//Üzenet a usernek
                        return;//Kilépés
                    }
                    else
                    {
                        try
                        {
                            string page = await new HttpClient().GetStringAsync(url);

                            if (page.Contains("<meta charset="))
                            {
                                Encoding enc = Encoding.GetEncoding(page.Substring(page.LastIndexOf("<meta charset='"), 10));
                                CurrentPageHTML = enc.GetString(await new HttpClient().GetByteArrayAsync(url));
                            }
                            else
                                CurrentPageHTML = await new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Nem sikerült lekérni az oldal tartalmát.", "LY kereső", MessageBoxButton.OK, MessageBoxImage.Error);//Üzenet a usernek
                            return;
                        }
                        await Task.Run(() =>
                        {
                            SeekLYWords(CurrentPageHTML);//Szavak keresésének megkezdése
                        });
                    }

                });
                return _startsearch;
            }
        }
        public ObservableCollection<string> ListOfWords { get; set; } = new ObservableCollection<string>();
        public void SeekLYWords(string html)
        {
            html = html.Substring(html.IndexOf("<body>") + 6);
            var teszt = 0;
        }
    }
}
