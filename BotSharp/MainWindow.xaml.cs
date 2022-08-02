using Ecng.Serialization;
using StockSharp.Algo;
using StockSharp.Configuration;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace BotSharp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(fileName))
            connector.Load(new XmlSerializer<SettingsStorage>().Deserialize(fileName));
        }
        Connector connector = new Connector();
        string fileName = "Connect";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connector.Configure(this);
            new XmlSerializer<SettingsStorage>().Serialize(connector.Save(), fileName);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            connector.Connect();
        }
    }
}
