using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Cache;

namespace Domain.Singleton
{
    public class SessionManager
    {

            private static object _lock = new object();

            public string user { get; set; }
            public DateTime FechaInicio { get; set; }


            private static SessionManager _session;

            public static SessionManager GetInstance
            {
                get
                {
                    return _session;
                }
            }


            public static void Login()
            {
                lock (_lock)
                {
                    if (_session == null)
                    {
                        _session = new SessionManager();
                        _session.user = UserLoginCache.firstName;
                        _session.FechaInicio = DateTime.Now;

                        MessageBox.Show("El usuario " + _session.user + " ha iniciado a las " + _session.FechaInicio);
                        
                    }

                    else
                    {
                        throw new Exception("Sesion ya iniciada");
                    }
                }

            }


            public static void Logout()
            {
                lock (_lock)
                {
                    if (_session != null)
                    {
                        _session = null;

                        MessageBox.Show("Se ha cerrado la sesion");

                    }
                    else
                    {
                        throw new Exception("Sesion no iniciada");
                    }
                }

            }


            private SessionManager()
            {

            }
        }
    }

