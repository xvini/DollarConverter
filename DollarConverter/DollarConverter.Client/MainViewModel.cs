using DollarConverter.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DollarConverter.Client
{
    class MainViewModel : INotifyPropertyChanged
    {
        private IDollarToWordService _client;
        private string _log;
        private string _output;
        private string _serverUrl;

        public ICommand Convert { get; }
        public string Input { get; set; } = "1";

        public string Log
        {
            get { return _log; }
            set { _log = value; OnPropertyChanged(); }
        }

        public string Output
        {
            get { return _output; }
            set { _output = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string ServerUrl
        {
            get
            {
                if (_serverUrl == null)
                {
                    LogMessage("Reading settings...");
                    _serverUrl = ConfigurationManager.AppSettings["ServerURL"];
                    LogMessage("Server URL: " + _serverUrl);
                }
                return _serverUrl;
            }
        }

        public MainViewModel()
        {
            Convert = new GenericCommand(ConvertDollarsToWords);
        }

        private void ConvertDollarsToWords()
        {
            try
            {
                var client = GetClient();

                LogMessage("Converting dollars: " + Input);
                Output = client.ConvertDollarsToWords(decimal.Parse(Input));
                LogMessage("Received response: " + Output);
            }
            catch (Exception ex)
            {
                LogMessage("Error occured: " + ex.ToString());
            }
        }

        private IDollarToWordService GetClient()
        {
            if (_client == null)
            {
                _client = InitializeClient();
            }

            ICommunicationObject comObj = (ICommunicationObject)_client;
            if (comObj.State != CommunicationState.Opened)
            {
                LogMessage("Detected broken connection.");
                _client = InitializeClient();
            }

            return _client;
        }

        private IDollarToWordService InitializeClient()
        {
            LogMessage("Connecting to server...");
            var factory = new ChannelFactory<IDollarToWordService>(new BasicHttpBinding(), new EndpointAddress(ServerUrl));
            var client = factory.CreateChannel();
            LogMessage("Connected");

            return client;
        }

        private void LogMessage(string msg)
        {
            Log = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + msg + Environment.NewLine + Log;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
