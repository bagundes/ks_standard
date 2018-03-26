using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace KS_Standard
{

    public partial class Shell
    {
        #region Cron
        /// <summary>
        /// Retorna true ou false se o formato está dentro das horas do sistema.
        /// No parâmetro do formato são aceitos:
        /// Asterisco - Qualquer momento.
        /// Hifen - Representa o até;
        /// Virgula - Representa "e";
        /// </summary>
        /// <param name="format">[minutos] [horas] [dias do mês] [mês] [dias da semana]</param>
        /// <param name="pause">O cron retornará true apenas se o formato for válido.</param>
        /// <returns></returns>
        public static bool Cron(string format, bool pause = false)
        {
            var oMethodBase = System.Reflection.MethodBase.GetCurrentMethod();

            try
            {

                int[] date = { DateTime.Now.Minute, DateTime.Now.Hour, DateTime.Now.Day, DateTime.Now.Month, (int)DateTime.Now.DayOfWeek };

                var cron = format.Split(' ');

                if (cron.Length != 5)
                    throw new KSException(oMethodBase, messages.m00002_1, format);

                var start = true;


                do
                {
                    // Para quando o sistema de pause estiver habilitado
                    if (!start)
                        System.Threading.Thread.Sleep(60000);

                    for (int i = 0; i < date.Length; i++)
                        if (!Cron_Valid1(date[i], cron[i]))
                            start = false;

                    // Caso o pause estiver habilitado, só sairá do while quando o start estiver OK.
                } while (pause && !start);


                return start;

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private static bool Cron_Valid1(int time, string cron)
        {
            var multiples = cron.Split(',');

            foreach (var val in multiples)
                if (time.ToString() == val || val == "*")
                    return true;
                else if (Cron_Valid2(time, val))
                    return true;


            return false;
        }

        private static bool Cron_Valid2(int time, string cron)
        {
            var interval = cron.Split('-');
            if (interval.Length < 2)
                return false;

            var ini = int.Parse(interval[0]);
            var fin = int.Parse(interval[1]);

            return time >= ini && time <= fin;
        }
        #endregion

        #region Directory
        /// <summary>
        /// Retorna a pasta temporária da aplicação
        /// </summary>
        /// <param name="subdirs">Caso necessite criar subdiretorios</param>
        /// <returns></returns>
        public static FileInfo TempFolder(params string[] subdirs)
        {
            try
            {
                var folder = System.IO.Path.GetTempPath() + Process.GetCurrentProcess().ProcessName;

                if (!System.IO.Directory.Exists(folder))
                    System.IO.Directory.CreateDirectory(folder);

                var dir = folder + String.Join(@"\", subdirs);
                if (!System.IO.Directory.Exists(dir))
                    System.IO.Directory.CreateDirectory(dir);

                return new FileInfo(dir + @"\");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Pasta da applicação
        /// </summary>
        /// <param name="subdirs"></param>
        /// <returns></returns>
        public static FileInfo ProjectFolder(params string[] subdirs)
        {
            try
            {
                var folder = Environment.CurrentDirectory;

                if (!System.IO.Directory.Exists(folder))
                    throw new KSException(messages.m00003_1, folder);

            var dir = folder + String.Join(@"\", subdirs);
                if (!System.IO.Directory.Exists(dir))
                    throw new KSException(messages.m00003_1, dir);

                return new FileInfo(dir + @"\");
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        #endregion


        //var Processes = Process.GetProcesses();
        //var pid = Process.GetCurrentProcess().Id;
        //foreach(var oProcess in Processes)
        //{
        //    if (oProcess.ProcessName.Contains(Process.GetCurrentProcess().ProcessName) && oProcess.Id != pid)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Já existe uma instancia do processo rodando nessa maquina");
        //        return;
        //    }
        //}
        #region Files
        public static void Delete(string dir, string search, SearchOption option)
        {
            string[] files;
            string file = String.Empty;
            try
            {
                files = Directory.GetFiles(dir, search, SearchOption.AllDirectories);

                foreach(var file1 in files)
                {
                    try
                    {
                        File.Delete(file);
                    }catch(IOException ex)
                    {
                        throw new KSException(ex);
                    }
                }
            } catch(Exception ex)
            {
                throw new KSException(ex);
            }
        }
        #endregion
    }
}
