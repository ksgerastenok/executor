using System;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Collections.Generic;

namespace AutoRun
{
    public partial class REGUtil : Object
    {
        private Socket socket;
        private static REGUtil instance;

        static REGUtil()
        {
            REGUtil.instance = new REGUtil();

            return;
        }

        private REGUtil()
        {
            return;
        }

        public static REGUtil Instance
        {
            get
            {
                return REGUtil.instance;
            }
        }

        private Object[] Read()
        {
            Object[] Result;
            Byte[] buffer;

            buffer = new Byte[0];
            this.socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);

            if ((this.socket.Available == 0))
            {
                throw new Exception(String.Format("Ошибка 979: {0}", "Некорректный формат ответа"));
            }

            buffer = new Byte[this.socket.Available];
            this.socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            if ((BitConverter.IsLittleEndian))
            {
                Result = new Object[3];
                Result[0] = BitConverter.ToInt32(buffer.Skip(0).Take(4).Reverse().ToArray(), 0);
                Result[1] = BitConverter.ToInt32(buffer.Skip(4).Take(4).Reverse().ToArray(), 0);
                Result[2] = Encoding.GetEncoding(866).GetString(buffer.Skip(8).Take(buffer.Length - 9).ToArray());
            }
            else
            {
                Result = new Object[3];
                Result[0] = BitConverter.ToInt32(buffer.Skip(0).Take(4).ToArray(), 0);
                Result[1] = BitConverter.ToInt32(buffer.Skip(4).Take(4).ToArray(), 0);
                Result[2] = Encoding.GetEncoding(866).GetString(buffer.Skip(8).Take(buffer.Length - 9).ToArray());
            }

            return Result;
        }

        private void Write(params Object[] Request)
        {
            Int32 i;
            Int32 size;
            Byte[] buffer;

            buffer = new Byte[0];
            this.socket.Send(buffer, 0, buffer.Length, SocketFlags.None);

            if ((Request.Length == 0))
            {
                throw new Exception(String.Format("Ошибка 979: {0}", "Некорректный формат запроса"));
            }

            size = 0;
            buffer = new Byte[0];
            size += sizeof(Int32);
            for (i = 0; !(i == Request.Length); i += 1)
            {
                switch (Request[i].GetType().FullName)
                {
                    case "System.Int32":
                    {
                        size += sizeof(Int32);
                        Request[i] = (Int32)(Request[i]);
                    }
                    break;
                    case "System.String":
                    {
                        size += String.Format("{0}\0", Request[i]).Length;
                        Request[i] = String.Format("{0}\0", Request[i]);
                    }
                    break;
                    default:
                    {
                        throw new Exception(String.Format("Ошибка 969: {0}", "Некорректный тип аргумента"));
                    }
                    break;
                }
            }
            size += 0;
            if ((BitConverter.IsLittleEndian))
            {
                buffer = buffer.Concat(BitConverter.GetBytes((Int32)(size)).Reverse()).ToArray();
            }
            else
            {
                buffer = buffer.Concat(BitConverter.GetBytes((Int32)(size))).ToArray();
            }
            size = 0;
            for (i = 0; !(i == Request.Length); i += 1)
            {
                switch (Request[i].GetType().FullName)
                {
                    case "System.Int32":
                    {
                        if ((BitConverter.IsLittleEndian))
                        {
                            buffer = buffer.Concat(BitConverter.GetBytes((Int32)(Request[i])).Reverse()).ToArray();
                        }
                        else
                        {
                            buffer = buffer.Concat(BitConverter.GetBytes((Int32)(Request[i]))).ToArray();
                        }
                    }
                    break;
                    case "System.String":
                    {
                        if ((BitConverter.IsLittleEndian))
                        {
                            buffer = buffer.Concat(Encoding.GetEncoding(866).GetBytes((String)(Request[i]))).ToArray();
                        }
                        else
                        {
                            buffer = buffer.Concat(Encoding.GetEncoding(866).GetBytes((String)(Request[i]))).ToArray();
                        }
                    }
                    break;
                    default:
                    {
                        throw new Exception(String.Format("Ошибка 969: {0}", "Некорректный тип аргумента"));
                    }
                    break;
                }
            }
            size = 0;
            this.socket.Send(buffer, 0, buffer.Length, SocketFlags.None);

            return;
        }

        private void Process(params Object[] Values)
        {
            Object[] buffer;
            
            switch ((Int32)(Values[0]))
            {
                case 136: // Execute
                {
                    buffer = this.Read();
                    switch ((Int32)(buffer[1]))
                    {
                        case 151: // Refusal
                        {
                            if ((!(String.Format("{0}", buffer[2]) == String.Empty)))
                            {
                                throw new Exception(String.Format("Ошибка 151: {0}", buffer[2]));
                            }
                        }
                        break;
                        case 701: // Acknowledgement
                        {
                            if ((!(String.Format("{0}", buffer[2]) == String.Format("{0}", "OK"))))
                            {
                                throw new Exception(String.Format("Ошибка 701: {0}", buffer[2]));
                            }
                        }
                        break;
                        case 708: // Unknown
                        {
                            if ((!(String.Format("{0}", buffer[2]) == String.Empty)))
                            {
                                throw new Exception(String.Format("Ошибка 708: {0}", buffer[2]));
                            }
                        }
                        break;
                        default: // Default
                        {
                            if ((!(String.Format("{0}", "Неизвестный код ответа") == String.Empty)))
                            {
                                throw new Exception(String.Format("Ошибка 989: {0}", "Неизвестный код ответа"));
                            }
                        }
                        break;
                    }
                }
                break;
                case 784: // Auth
                {
                    buffer = this.Read();
                    switch ((Int32)(buffer[1]))
                    {
                        case 780: // AuthFailure
                        {
                            this.Write(Int32.Parse("781")); // AuthStop
                            if ((!(String.Format("{0}", buffer[2]) == String.Empty)))
                            {
                                throw new Exception(String.Format("Ошибка 780: {0}", buffer[2]));
                            }
                        }
                        break;
                        case 785: // PasswordExpiry
                        {
                            this.Write(Int32.Parse("781")); // AuthStop
                            if ((!(String.Format("{0}", buffer[2]) == String.Empty)))
                            {
                                throw new Exception(String.Format("Ошибка 785: {0}", "Истек срок действия пароля"));
                            }
                        }
                        break;
                        case 779: // AuthConfirmation
                        {
                            this.Write(Int32.Parse("134"), String.Format("{0}", Values[1]), Int32.Parse("0"), String.Format("{0}", Values[2]), Int32.Parse("0"), Int32.Parse("0")); // InitStart
                            this.Write(Int32.Parse("135")); // InitFinish
                        }
                        break;
                        case 708: // Unknown
                        {
                            this.Write(Int32.Parse("781")); // AuthStop
                            if ((!(String.Format("{0}", buffer[2]) == String.Empty)))
                            {
                                throw new Exception(String.Format("Ошибка 708: {0}", buffer[2]));
                            }
                        }
                        break;
                        default: // Default
                        {
                            if ((!(String.Format("{0}", "Неизвестный код ответа") == String.Empty)))
                            {
                                throw new Exception(String.Format("Ошибка 989: {0}", "Неизвестный код ответа"));
                            }
                        }
                        break;
                    }
                }
                break;
                default: // Default
                {
                    if ((!(String.Format("{0}", "Неизвестный код обработки") == String.Empty)))
                    {
                        throw new Exception(String.Format("Ошибка 999: {0}", "Неизвестный код обработки"));
                    }
                }
                break;
            }

            return;
        }

        public void Connect(String Host, String Port, String Service, String Login, String Password)
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.Connect(String.Format("{0}", Host), Int32.Parse(Port));
            this.Write(Int32.Parse("784"), String.Format("{0}", Login), String.Format("{0}", Password), String.Format("{0}", Service)); // Auth
            this.Process(Int32.Parse("784"), String.Format("{0}", Login), String.Format("{0}", DateTime.Now.ToString("dd.MM.yyyy"))); // Auth

            return;
        }

        public void Disconnect()
        {
            this.Write(Int32.Parse("781")); // AuthStop
            this.socket.Close();
            this.socket = null;

            return;
        }

        public void Execute(String id, String oldState, String oldAction, String restCount, String newState, String newAction)
        {
            this.Write(Int32.Parse("136"), Int32.Parse(id), Int32.Parse(oldState), Int32.Parse(oldAction), Int32.Parse(restCount), Int32.Parse(newState), Int32.Parse(newAction)); // Execute
            this.Process(Int32.Parse("136")); // Execute

            return;
        }
    }
}
