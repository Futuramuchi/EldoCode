using EldoCodeDesktop.AppData;
using EldoCodeDesktop.Core;
using EldoCodeDesktop.Model;
using EldoCodeDesktop.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EldoCodeDesktop.ViewModel
{
    public class AuthVM : BaseViewModel
    {
        public string Login { get; set; }
        public string Password { private get; set; }


        private MainWindow _window { get; set; }
        private RelayCommand _auth { get; set; }
        private WorkerModel _worker { get; set; }

        public AuthVM(MainWindow mainWindow)
        {
            _window = mainWindow;
        }

        /// <summary>
        /// Система авторизации
        /// </summary>
        public ICommand Authorisation
        {
            get
            {
                return _auth ?? (_auth = new RelayCommand(async (o) =>
                {
                    try
                    {
                        if (ValidationEmpryFields.IsFieldEmpty(Login) || Password == null)
                        {
                            DefaultMessage.WarningMessage("Заполниет все поля данными!");
                        }
                        else
                        {
                            string url = $"http://eldocode.makievksy.ru.com/api/Worker?login={Login}&password={Password}";
                            HttpClient client = new HttpClient();

                            var response = await client.GetAsync(url);
                            var responseContent = await response.Content.ReadAsStringAsync();

                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                _worker = JsonConvert.DeserializeObject<WorkerModel>(responseContent);

                                if (_worker.Role.Id == 2)
                                {
                                    MainUserWindow mainUserWindow = new MainUserWindow();
                                    mainUserWindow.Show();

                                    _window.Close();

                                }
                                else
                                    DefaultMessage.WarningMessage("У вас недостаточно прав для этого аккаунта!");


                            }
                            else
                            {
                                string message = JsonConvert.DeserializeObject<string>(responseContent);
                                DefaultMessage.WarningMessage($"{message}");
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        er.Message.ToString();
                    }
                }));
                
            }
        }
    }
}
